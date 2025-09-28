using System.ComponentModel.DataAnnotations;

namespace MHZNet.Common.Enums;

/// <summary>
/// ◊‚ªß¿‡–Õ
/// </summary>
public enum TenantType
{
    /// <summary>
    /// Id∏Ù¿Î
    /// </summary>
    [Display(Name = "Enum.Tenant.Id")]
    Id = 1,

    /// <summary>
    /// ø‚∏Ù¿Î
    /// </summary>
    [Display(Name = "Enum.Tenant.Db")]
    Db = 2
}
