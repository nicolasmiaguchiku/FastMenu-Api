namespace FoodManager.Domain.Interfaces.Services
{
    public interface ICacheService
    {
        Task<T?> GetCacheValueAsync<T>(string key);
        Task SetCacheValueAsync<T>(string key, T value, TimeSpan expiration);
    }
}