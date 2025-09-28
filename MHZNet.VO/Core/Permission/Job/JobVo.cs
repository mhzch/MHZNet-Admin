using MHZNet.Common.Attributes;
using MHZNet.PO.Base;

namespace MHZNet.VO.Core.Permission.Job;

/// <summary>
/// 岗位Vo
/// </summary>
[AutoMapping(typeof(MHZNet.PO.Core.Permission.Job), typeof(JobVo))]
public class JobVo : BaseEntityDto<long>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled { get; set; }
}

