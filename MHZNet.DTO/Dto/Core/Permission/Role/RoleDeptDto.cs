using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;
using MHZNet.PO.Core.Permission;

namespace MHZNet.DTO.Dto.Core.Permission.Role;

/// <summary>
/// ½ÇÉ«²¿ÃÅDto
/// </summary>
[AutoMapping(typeof(Department), typeof(RoleDeptDto))]
public class RoleDeptDto
{
    /// <summary>
    /// ID
    /// </summary>
    [RegularExpression(@"^\+?[1-9]\d*$")]
    public long Id { get; set; }
}
