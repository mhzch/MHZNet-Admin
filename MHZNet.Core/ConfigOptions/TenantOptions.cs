using MHZNet.Common.Attributes;
using MHZNet.Common.Enums;

namespace MHZNet.Core.ConfigOptions;

/// <summary>
/// 租户配置
/// </summary>
[OptionsSettings]
public class TenantOptions
{
    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// 租户类型
    /// </summary>
    public TenantType Type { get; set; }
}
