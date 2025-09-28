using MHZNet.Common.Extensions;
using MHZNet.Core;
using MHZNet.Core.Caches;
using MHZNet.Core.Caches.Distributed;
using MHZNet.Core.Caches.Redis;
using MHZNet.Core.ConfigOptions;
using Microsoft.Extensions.DependencyInjection;

namespace MHZNet.Infrastructure.Extensions;

/// <summary>
/// 缓存启动�?/// </summary>
public static class CacheSetup
{
    public static void AddCacheSetup(this IServiceCollection services)
    {
        if (services.IsNull())
            throw new ArgumentNullException(nameof(services));
        services.AddDistributedMemoryCache(); //session需�?
        if (App.GetOptions<SystemOptions>().UseRedisCache)
        {
            services.AddSingleton<ICache, RedisCache>();
            return;
        }

        services.AddSingleton<ICache, DistributedCache>();
    }
}
