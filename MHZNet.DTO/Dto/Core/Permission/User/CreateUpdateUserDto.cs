using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;
using MHZNet.PO.Base;

namespace MHZNet.DTO.Dto.Core.Permission.User;

/// <summary>
/// 用户Dto
/// </summary>
[AutoMapping(typeof(MHZNet.PO.Core.Permission.User.User), typeof(CreateUpdateUserDto))]
public class CreateUpdateUserDto : BaseEntityDto<long>
{
    /// <summary>
    /// 用户�?    /// </summary>
    [Display(Name = "User.Username")]
    [Required(ErrorMessage = "{0}required")]
    public string Username { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [Display(Name = "User.NickName")]
    [Required(ErrorMessage = "{0}required")]
    public string NickName { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [Display(Name = "Sys.Email")]
    [Required(ErrorMessage = "{0}required")]
    [EmailAddress(ErrorMessage = "{0}Error.Format")]
    public string Email { get; set; }

    /// <summary>
    /// 是否激�?    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    [Display(Name = "Sys.Phone")]
    [Required(ErrorMessage = "{0}required")]
    [RegularExpression(@"^(13[0-9]|14[01456879]|15[0-35-9]|16[2567]|17[0-8]|18[0-9]|19[0-35-9])\d{8}$",
        ErrorMessage = "{0}Error.Format")]
    public string Phone { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [Display(Name = "User.Gender")]
    [Required(ErrorMessage = "{0}required")]
    public string Gender { get; set; }

    /// <summary>
    /// 部门
    /// </summary>
    [Display(Name = "Sys.Department")]
    [Required(ErrorMessage = "{0}required")]
    public UserDeptDto Dept { get; set; }

    /// <summary>
    /// 角色
    /// </summary>
    [Display(Name = "Sys.Role")]
    [Required(ErrorMessage = "{0}required")]
    [AtLeastOneItem]
    public List<UserRoleDto> Roles { get; set; }

    /// <summary>
    /// 岗位
    /// </summary>
    [Display(Name = "Sys.Job")]
    [Required(ErrorMessage = "{0}required")]
    [AtLeastOneItem]
    public List<UserJobDto> Jobs { get; set; }

    /// <summary>
    /// 租户ID
    /// </summary>
    public int? TenantId { get; set; }
}

