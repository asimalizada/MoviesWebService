using Core.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.CrossCuttingConcerns.Caching.MicrosoftMemoryCache
{
    public class MemoryCacheManager : ICacheManager
    {
        private IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceHelper.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            this._memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return this._memoryCache.Get<T>(key);
        }

        public bool IsAdd(string key)
        {
            return this._memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            this._memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern) 
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty(
                "EntriesCollection", 
                System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.NonPublic);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition
                .GetValue(this._memoryCache) as dynamic;

            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();
            foreach (var cacheCollectionItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheCollectionItem.GetType()
                    .GetProperty("Value").GetValue(cacheCollectionItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern,
                RegexOptions.Singleline
                | RegexOptions.Compiled
                | RegexOptions.IgnoreCase);

            var keysToRemove = cacheCollectionValues.Where(c => regex.IsMatch(c.Key.ToString()))
                .Select(c => c.Key).ToList();

            foreach (var key in keysToRemove)
            {
                this._memoryCache.Remove(key);
            }

        }
    }
}
