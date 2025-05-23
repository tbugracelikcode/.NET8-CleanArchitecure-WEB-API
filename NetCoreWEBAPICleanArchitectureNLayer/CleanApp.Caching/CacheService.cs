﻿using CleanApp.Application.Contracts.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace CleanApp.Caching
{
    public class CacheService(IMemoryCache memoryCache) : ICacheService
    {
        public Task AddAsync<T>(string cacheKey, T value, TimeSpan exprTimeSpan)
        {
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = exprTimeSpan
            };

            memoryCache.Set(cacheKey, value, cacheOptions);

            return Task.CompletedTask;
        }

        public Task<T?> GetAsync<T>(string cacheKey)
        {
            return Task.FromResult(memoryCache.TryGetValue(cacheKey, out T cacheItem) ? cacheItem : default(T));
        }

        public Task RemoveAsync(string cacheKey)
        {
            memoryCache.Remove(cacheKey);

            return Task.CompletedTask;
        }
    }
}
