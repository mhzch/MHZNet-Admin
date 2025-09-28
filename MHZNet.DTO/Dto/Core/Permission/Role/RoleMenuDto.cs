using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;
using MHZNet.PO.Core.Permission;

namespace MHZNet.DTO.Dto.Core.Permission.Role;

/// <summary>
/// 角色菜单Dto
/// </summary>
[AutoMapping(typeof(Menu), typeof(RoleMenuDto))]
public class RoleMenuDto
{
    /// <summary>
    /// ID
    /// </summary>
    [Display(Name = "Sys.Id")]
    [RegularExpression(@"^\+?[1-9]\d*$")]
    public long Id { get; set; }
}
