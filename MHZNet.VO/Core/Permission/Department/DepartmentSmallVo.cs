using MHZNet.Common.Attributes;

namespace MHZNet.VO.Core.Permission.Department;

/// <summary>
/// ²¿ÃÅVo
/// </summary>
[AutoMapping(typeof(MHZNet.PO.Core.Permission.Department), typeof(DepartmentSmallVo))]
public class DepartmentSmallVo
{
    /// <summary>
    /// ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Ãû³Æ
    /// </summary>
    public string Name { get; set; }
}

