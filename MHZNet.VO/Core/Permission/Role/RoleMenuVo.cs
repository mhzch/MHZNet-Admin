using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;

namespace MHZNet.VO.Core.Permission.Role;

/// <summary>
/// 角色菜单Vo
/// </summary>
[AutoMapping(typeof(MHZNet.PO.Core.Permission.Menu), typeof(RoleMenuVo))]
public class RoleMenuVo
{
    /// <summary>
    /// ID
    /// </summary>
    [Display(Name = "Sys.Id")]
    [RegularExpression(@"^\+?[1-9]\d*$")]
    public long Id { get; set; }
}

