using MHZNet.Common.Extensions;
using MHZNet.Common.Helper;
using Microsoft.AspNetCore.Builder;

namespace MHZNet.Infrastructure.Extensions;

public static class ApplicationNotifierSetup
{
    public static void ApplicationStartedNotifier(this WebApplication app)
    {
        if (app.IsNull())
            throw new ArgumentNullException(nameof(app));
        app.Lifetime.ApplicationStarted.Register(() =>
        {
            var port = "8002";
            if (app.Configuration["urls"] != null)
            {
                port = app.Configuration["urls"].Split(':').Last();
            }

            ConsoleHelper.WriteLine($"应用程序启动成功! {{端口号 : {port}}}\n" +
                                    "欢迎使用 MHZNet 企业级后台管理系统\n" +
                                    $"接口文档地址:http://localhost:{port}/swagger/api/index.html\n" +
                                    "前端运行地址:http://localhost:8001\n",
                ConsoleColor.Green);
        });
    }
}
