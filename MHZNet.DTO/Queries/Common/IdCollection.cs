using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;

namespace MHZNet.DTO.Queries.Common;

/// <summary>
/// idÄ£ÐÍ(log)
/// </summary>
public class IdCollection
{
    /// <summary>
    /// ids
    /// </summary>
    [Display(Name = "Sys.Id")]
    [Required(ErrorMessage = "{0}required")]
    [AtLeastOneItem]
    public HashSet<long> IdArray { get; set; }
}
