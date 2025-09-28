using MHZNet.Common.Attributes;
using MHZNet.PO.Base;
using MHZNet.PO.Core.System;

namespace MHZNet.VO.Core.System;

/// <summary>
/// 全局设置Vo
/// </summary>
[AutoMapping(typeof(Setting), typeof(SettingVo))]
public class SettingVo : BaseEntityDto<long>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// �?    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }
}
