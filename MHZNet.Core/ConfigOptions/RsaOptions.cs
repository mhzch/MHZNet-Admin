using MHZNet.Common.Attributes;

namespace MHZNet.Core.ConfigOptions;

/// <summary>
/// RSA√‹‘ø≈‰÷√
/// </summary>
[OptionsSettings]
public class RsaOptions
{
    /// <summary>
    /// ÀΩ‘ø
    /// </summary>
    public string PrivateKey { get; set; }

    /// <summary>
    /// π´‘ø
    /// </summary>
    public string PublicKey { get; set; }
}
