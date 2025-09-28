using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;

namespace MHZNet.DTO.Dto.Core.Permission.Role;

/// <summary>
/// 更新角色菜单
/// </summary>
public class UpdateRoleMenuDto
{
    /// <summary>
    /// 角色ID
    /// </summary>
    [Display(Name = "Sys.Id")]
    [RegularExpression(@"^\+?[1-9]\d*$")]
    public long Id { get; set; }

    /// <summary>
    /// 角色菜单
    /// </summary>
    [Display(Name = "Sys.Menu")]
    [Required(ErrorMessage = "{0}required")]
    [AtLeastOneItem]
    public List<RoleMenuDto> Menus { get; set; }
}
