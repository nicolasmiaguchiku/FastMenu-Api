using FoodManager.Domain.Services;
using Microsoft.Extensions.Caching.Memory;

namespace FoodManager.Infrastructure.Caching
{
    public class MemoryCacheService(IMemoryCache _cache) : ICacheService
    {
        public Task<T?> GetCacheValueAsync<T>(string key)
        {
            var cacheData = _cache.TryGetValue(key, out T? value);

            return Task.FromResult(cacheData ? value : default);
        }

        public Task SetCacheValueAsync<T>(string key, T data, TimeSpan expiration)
        {
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration,
            };

            _cache.Set(key, data, cacheOptions);

            return Task.CompletedTask;
        }
    }
}