using EmployeeSystem.Infra.IRepositories;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace EmployeeSystem.Infra.Repositories
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            try
            {
                var value = await _cache.GetStringAsync(key);

                if (value != null)
                {
                    return JsonSerializer.Deserialize<T>(value);
                }
                return default;

            }
            catch (Exception)
            {

                return default;
            }
            
        }
        public async Task< T> SetAsync<T>(string key, T value, TimeSpan? absoluteExpireTime = null,TimeSpan? slidingExpireTime = null)
        {
            var timeOut = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(60),
                SlidingExpiration = slidingExpireTime ?? TimeSpan.FromMinutes(60)
            };

           await _cache.SetStringAsync(key, JsonSerializer.Serialize(value), timeOut);

            return value;
        }

        public async Task< bool> Remove(string key)
        {
            try
            {
                await _cache.RemoveAsync(key);
                return true;
            }
            catch (Exception)
            {

              return false;
            }
            

        }

    }
}
