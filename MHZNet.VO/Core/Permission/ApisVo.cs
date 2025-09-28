using MHZNet.Common.Attributes;
using MHZNet.PO.Base;
using MHZNet.PO.Core.Permission;

namespace MHZNet.VO.Core.Permission;

/// <summary>
/// Api路由 Vo
/// </summary>
[AutoMapping(typeof(Apis), typeof(ApisVo))]
public class ApisVo : BaseEntityDto<long>
{
    /// <summary>
    /// 组
    /// </summary>
    public string Group { get; set; }

    /// <summary>
    /// 路径
    /// </summary>
    public string Url { get; set; }


    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    public string Method { get; set; }
}
