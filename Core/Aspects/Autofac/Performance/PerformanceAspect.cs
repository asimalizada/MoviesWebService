using Core.Interceptors;
using Core.IoC;
using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceHelper.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            this._stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (this._stopwatch.Elapsed.TotalSeconds > this._interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} --> {this._stopwatch.Elapsed.TotalSeconds}");
                throw new System.Exception("Process take longer than expect.");
            }
            this._stopwatch.Reset();
        }

    }
}
