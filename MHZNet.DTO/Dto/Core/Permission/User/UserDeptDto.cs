using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;
using MHZNet.PO.Core.Permission;

namespace MHZNet.DTO.Dto.Core.Permission.User;

/// <summary>
/// 用户部门Dto
/// </summary>
[AutoMapping(typeof(Department), typeof(UserDeptDto))]
public class UserDeptDto
{
    /// <summary>
    /// ID
    /// </summary>
    [RegularExpression(@"^\+?[1-9]\d*$")]
    public long Id { get; set; }
}
