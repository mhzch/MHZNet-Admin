using MHZNet.Common.Attributes;
using MHZNet.Common.Enums;
using MHZNet.PO.Base;
using MHZNet.PO.Core.Permission;
using MHZNet.VO.Core.Permission.Department;
using MHZNet.VO.Core.Permission.Menu;
using Newtonsoft.Json;

namespace MHZNet.VO.Core.Permission.Role;

/// <summary>
/// 角色Vo
/// </summary>
[AutoMapping(typeof(MHZNet.PO.Core.Permission.Role.Role), typeof(RoleVo))]
public class RoleVo : BaseEntityDto<long>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 等级
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 数据权限
    /// </summary>
    public DataScopeType DataScopeType { get; set; }

    /// <summary>
    /// 权限标识
    /// </summary>
    public string Permission { get; set; }

    /// <summary>
    /// 菜单列表
    /// </summary>
    [JsonProperty(PropertyName = "menus")]
    public List<MenuVo> MenuList { get; set; }

    /// <summary>
    /// 部门列表
    /// </summary>
    [JsonProperty(PropertyName = "depts")]
    public List<DepartmentVo> DepartmentList { get; set; }

    /// <summary>
    /// 菜单列表
    /// </summary>
    [JsonProperty(PropertyName = "apis")]
    public List<Apis> Apis { get; set; }
}

