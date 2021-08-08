using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Interceptors;
using Core.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            this._pattern = pattern;
            this._cacheManager = ServiceHelper.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            this._cacheManager.RemoveByPattern(this._pattern);
        }
    }
}
