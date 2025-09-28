using MHZNet.Common.Attributes;
using MHZNet.Common.Enums;
using MHZNet.PO.Base;

namespace MHZNet.VO.Core.System.Dict;

/// <summary>
/// 字典Vo
/// </summary>
[AutoMapping(typeof(MHZNet.PO.Core.System.Dict.Dict), typeof(DictVo))]
public class DictVo : BaseEntityDto<long>
{
    /// <summary>
    /// 字典类型
    /// </summary>
    /// <returns></returns>
    public DictType DictType { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 字典详情
    /// </summary>
    public List<DictDetailVo> DictDetails { get; set; }
}

