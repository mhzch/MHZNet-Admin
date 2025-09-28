using System.ComponentModel.DataAnnotations;
using MHZNet.Common.Attributes;

namespace MHZNet.DTO.Queries.Common;

/// <summary>
/// idÄ£ÐÍ(string)
/// </summary>
public class IdCollectionString
{
    /// <summary>
    /// 
    /// </summary>
    [Display(Name = "Sys.Id")]
    [Required(ErrorMessage = "{0}required")]
    [AtLeastOneItem]
    public HashSet<string> IdArray { get; set; }
}
