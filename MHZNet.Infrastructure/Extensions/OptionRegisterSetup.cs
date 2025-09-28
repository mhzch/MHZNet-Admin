using System.Reflection;
using MHZNet.Common.Attributes;
using MHZNet.Common.Global;
using MHZNet.Core.ConfigOptions.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MHZNet.Infrastructure.Extensions;

public static class OptionRegisterSetup
{
    /// <summary>
    /// ◊¢≤·≈‰÷√—°œÓ
    /// </summary>
    /// <param name="services"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddOptionRegisterSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var optionTypes = GlobalType.CoreTypes
            .Where(x => x.GetCustomAttribute<OptionsSettingsAttribute>() != null).ToList();

        foreach (var optionType in optionTypes)
        {
            services.AddConfigurableOptions(optionType);
        }
    }
}
