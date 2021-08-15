using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
