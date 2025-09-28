using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;

namespace MHZNet.DTO.Dto.Core.Permission.User;

/// <summary>
/// 用户角色Dto
/// </summary>
[AutoMapping(typeof(MHZNet.PO.Core.Permission.Role.Role), typeof(UserRoleDto))]
public class UserRoleDto
{
    /// <summary>
    /// ID
    /// </summary>
    [Display(Name = "Sys.Id")]
    [RegularExpression(@"^\+?[1-9]\d*$", ErrorMessage = "{0}Error.Format")]

    public long Id { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [Display(Name = "Sys.Name")]
    [Required(ErrorMessage = "{0}required")]
    public string Name { get; set; }
}

