using System;

namespace MHZNet.Common.Attributes;

/// <summary>
/// �Զ����Ȩ����
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class MHZNetAuthorizeAttribute : Attribute
{
    public MHZNetAuthorizeAttribute(string[] roles)
    {
        Roles = roles;
    }

    /// <summary>
    /// ��ɫ����
    /// </summary>
    public string[] Roles { get; }
}
