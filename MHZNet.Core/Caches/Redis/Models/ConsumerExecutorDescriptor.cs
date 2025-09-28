using System.Reflection;
using MHZNet.Common.Attributes.Redis;

namespace MHZNet.Core.Caches.Redis.Models;

public class ConsumerExecutorDescriptor
{
    public MethodInfo MethodInfo { get; set; }

    public TypeInfo ImplTypeInfo { get; set; }

    public TopicAttribute Attribute { get; set; }
}
