using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;
using MHZNet.PO.Core.Permission;

namespace MHZNet.DTO.Dto.Core.Permission.Role;

/// <summary>
/// ½ÇÉ«²Ëµ¥Dto
/// </summary>
[AutoMapping(typeof(Apis), typeof(RoleApisDto))]
public class RoleApisDto
{
    /// <summary>
    /// ID
    /// </summary>
    [RegularExpression(@"^\+?[1-9]\d*$")]
    public long Id { get; set; }
}
