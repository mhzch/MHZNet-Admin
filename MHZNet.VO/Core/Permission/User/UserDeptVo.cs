using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;

namespace MHZNet.VO.Core.Permission.User;

/// <summary>
/// 用户部门Vo
/// </summary>
[AutoMapping(typeof(MHZNet.PO.Core.Permission.Department), typeof(UserDeptVo))]
public class UserDeptVo
{
    /// <summary>
    /// ID
    /// </summary>
    [RegularExpression(@"^\+?[1-9]\d*$")]
    public long Id { get; set; }
}

