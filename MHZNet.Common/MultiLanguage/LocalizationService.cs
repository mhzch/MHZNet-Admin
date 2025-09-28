using System.Collections.Generic;
using MHZNet.Common.MultiLanguage.Contract;
using MHZNet.Common.MultiLanguage.Resources;
using Microsoft.Extensions.Localization;

namespace MHZNet.Common.MultiLanguage;

public class LocalizationService : ILocalizationService
{
    private readonly IStringLocalizer _localizer;

    public LocalizationService(IStringLocalizer<Language> localizer)
    {
        _localizer = localizer;
    }


    public string R(string name)
    {
        return _localizer[name];
    }

    public string R(string name, params object[] arguments)
    {
        return _localizer[name, arguments];
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        return _localizer.GetAllStrings();
    }
}
