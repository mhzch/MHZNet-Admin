using System.Runtime.InteropServices;
using MHZNet.Common.Extensions;
using MHZNet.Common.Global;
using MHZNet.Common.Helper.Serilog;
using MHZNet.Core;
using MHZNet.Core.ConfigOptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;

namespace MHZNet.Infrastructure.Extensions;

/// <summary>
/// swaggerSetup启动�?/// </summary>
public static class SwaggerSetup
{
    private static readonly ILogger Logger = SerilogManager.GetLogger(typeof(SwaggerSetup));

    public static void AddSwaggerSetup(this IServiceCollection services)
    {
        if (services.IsNull()) throw new ArgumentNullException(nameof(services));

        var basePath = AppContext.BaseDirectory;
        var options = App.GetOptions<SwaggerOptions>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(options.Name, new OpenApiInfo
            {
                Version = options.Version,
                Title = options.Title + "    " + RuntimeInformation.FrameworkDescription,
                Description = $"Build: {DateTime.Now:yyyy-MM-dd HH:mm:ss}  | User: xianhc",
                Contact = new OpenApiContact
                {
                    Name = "xianhc",
                    Email = "apevolo@gamil.com",
                    Url = new Uri("http://doc.apevolo.com")
                }
            });

            try
            {
                var apiXml = Path.Combine(basePath, GlobalType.ApiAssembly + ".xml");
                var sharedModelXml = Path.Combine(basePath, GlobalType.SharedModelAssembly + ".xml");
                var viewModelXml = Path.Combine(basePath, GlobalType.ViewModelAssembly + ".xml");
                var commonXml = Path.Combine(basePath, GlobalType.CommonAssembly + ".xml");
                c.IncludeXmlComments(apiXml, true);
                c.IncludeXmlComments(sharedModelXml, true);
                c.IncludeXmlComments(viewModelXml, true);
                c.IncludeXmlComments(commonXml, true);
            }
            catch (Exception ex)
            {
                Logger.Error("swagger startup failed\n" + ex.Message);
            }

            // 开启加权小�?            c.OperationFilter<AddResponseHeadersFilter>();
            c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

            // 在header中添加token，传递到后台
            c.OperationFilter<SecurityRequirementsOperationFilter>();


            // 必须�?oauth2
            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token} \"",
                Name = "Authorization", //jwt默认的参数名�?                In = ParameterLocation.Header, //jwt默认存放Authorization信息的位�?请求头中)
                Type = SecuritySchemeType.ApiKey
            });
            //c.SchemaFilter<ExcludeSchemaFilter>();
            //c.CustomSchemaIds(type => type.FullName);
            // c.CustomSchemaIds(type =>
            // {
            //     var typeName = type.Name;
            //
            //     // 处理泛型类型
            //     if (type.IsGenericType)
            //         typeName = type.Name.Split('`')[0] +
            //                    type.GetGenericArguments().Select(a => a.Name).Aggregate((x, y) => $"{x}Of{y}");
            //
            //     // 添加命名空间前缀以避免冲�?            //     return type.Namespace.StartsWith("System") ? $"System{typeName}" :
            //         type.Namespace.Contains("SqlSugar") ? $"SqlSugar{typeName}" : typeName;
            // });
            c.CustomSchemaIds(type => type.FullName?.Replace("+", "."));
        });
    }

    // public class ExcludeSchemaFilter : ISchemaFilter
    // {
    //     public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    //     {
    //         if (context.Type == typeof(System.Data.DbType))
    //         {
    //             // 将此类型标记为不应生成完整架�?    //             schema.Reference = null;
    //         }
    //     }
    // }
}
