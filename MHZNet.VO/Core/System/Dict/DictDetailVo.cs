using MHZNet.Common.Attributes;
using MHZNet.PO.Base;
using MHZNet.PO.Core.System.Dict;

namespace MHZNet.VO.Core.System.Dict;

/// <summary>
/// ◊÷µ‰œÍ«ÈVo
/// </summary>
[AutoMapping(typeof(DictDetail), typeof(DictDetailVo))]
public class DictDetailVo : BaseEntityDto<long>
{
    /// <summary>
    /// ◊÷µ‰ID
    /// </summary>
    //[JsonIgnore]
    //[JsonProperty]
    public long DictId { get; set; }

    /// <summary>
    /// ±Í«©
    /// </summary>
    public string Label { get; set; }

    /// <summary>
    /// ÷µ
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// ≈≈–Ú
    /// </summary>
    public int DictSort { get; set; }
}
