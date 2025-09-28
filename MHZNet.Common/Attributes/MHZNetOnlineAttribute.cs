using System;

namespace MHZNet.Common.Attributes;

/// <summary>
/// 自定义鉴权特性，在线则可通行
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class MHZNetOnlineAttribute : Attribute
{
}
