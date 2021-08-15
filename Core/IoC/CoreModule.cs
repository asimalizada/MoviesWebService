using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.MicrosoftMemoryCache;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace Core.IoC
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
