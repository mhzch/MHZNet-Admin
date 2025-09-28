using System;

namespace MHZNet.Common.Attributes;

/// <summary>
/// 自定义校验特�?/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class MHZNetRequiredAttribute : Attribute
{
    /// <summary>
    /// 验证失败说明内容
    /// </summary>
    public string Message { get; set; }
}
