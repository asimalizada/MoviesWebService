using Core.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,
            ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }

            return ServiceHelper.CreateInstance(services);
        }
    }
}
