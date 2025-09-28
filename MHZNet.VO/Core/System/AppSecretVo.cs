using MHZNet.Common.Attributes;
using MHZNet.PO.Base;
using MHZNet.PO.Core.System;

namespace MHZNet.VO.Core.System;

/// <summary>
/// 应用密钥Vo
/// </summary>
[AutoMapping(typeof(AppSecret), typeof(AppSecretVo))]
public class AppSecretVo : BaseEntityDto<long>
{
    /// <summary>
    /// 应用ID
    /// </summary>
    public string AppId { get; set; }

    /// <summary>
    /// 签名Key
    /// </summary>
    public string AppSecretKey { get; set; }

    /// <summary>
    /// 应用名称
    /// </summary>
    public string AppName { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; set; }
}
