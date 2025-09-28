using MHZNet.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MHZNet.Infrastructure.Extensions;

/// <summary>
/// Serilog»’÷æ ÃÊªªƒ⁄÷√Logging
/// </summary>
public static class SerilogSetup
{
    public static void AddSerilogSetup(this IServiceCollection services)
    {
        if (services.IsNull()) throw new ArgumentNullException(nameof(services));

        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddSerilog(dispose: true);
        });
        //services.AddSingleton<Serilog.Extensions.Hosting.DiagnosticContext>();
    }
}
