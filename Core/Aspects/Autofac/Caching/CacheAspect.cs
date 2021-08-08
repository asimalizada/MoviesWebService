using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Interceptors;
using Core.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            this._duration = duration;
            this._cacheManager = ServiceHelper.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.ReflectedType.FullName;
            var arguments = invocation.Arguments.ToList();

            var key = 
                $"{methodName}({string.Join(",", arguments.Select(a => a?.ToString() ?? "<Null>"))})";

            if (this._cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = this._cacheManager.Get<object>(key);
                return;
            }

            invocation.Proceed();

            this._cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
