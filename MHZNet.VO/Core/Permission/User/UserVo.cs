using MHZNet.Common.Attributes;
using MHZNet.PO.Base;
using MHZNet.VO.Core.Permission.Department;
using MHZNet.VO.Core.Permission.Job;
using MHZNet.VO.Core.Permission.Role;
using MHZNet.VO.Core.System;

namespace MHZNet.VO.Core.Permission.User;

/// <summary>
/// 用户Vo
/// </summary>
[AutoMapping(typeof(MHZNet.PO.Core.Permission.User.User), typeof(UserVo))]
public class UserVo : BaseEntityDto<long>
{
    /// <summary>
    /// 
    /// </summary>
    public UserVo()
    {
        Roles = new List<RoleSmallVo>();
        Jobs = new List<JobSmallDto>();
    }

    /// <summary>
    /// 用户名
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    public string NickName { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 内置管理员
    /// </summary>
    public bool IsAdmin { get; set; }

    /// <summary>
    /// 是否激活
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 部门
    /// </summary>
    public long DeptId { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    public string Phone { get; set; }


    /// <summary>
    /// 头像文件路径
    /// </summary>
    public string AvatarPath { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    public string Gender { get; set; }

    /// <summary>
    /// 最后修改密码时间
    /// </summary>
    public DateTime? PasswordReSetTime { get; set; }

    /// <summary>
    /// 角色列表
    /// </summary>
    public List<RoleSmallVo> Roles { get; set; }

    /// <summary>
    /// 部门
    /// </summary>
    public DepartmentSmallVo Dept { get; set; }

    /// <summary>
    /// 岗位列表
    /// </summary>
    public List<JobSmallDto> Jobs { get; set; }

    /// <summary>
    /// 租户ID
    /// </summary>
    public int TenantId { get; set; }

    /// <summary>
    /// 租户
    /// </summary>
    public TenantVo Tenant { get; set; }
}

