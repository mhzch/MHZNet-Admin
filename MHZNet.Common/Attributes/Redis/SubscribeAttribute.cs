namespace MHZNet.Common.Attributes.Redis;

public class SubscribeAttribute : TopicAttribute
{
    public SubscribeAttribute(string name, bool bulk = false) : base(name, bulk)
    {
    }
}
