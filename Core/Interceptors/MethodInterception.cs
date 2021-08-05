using Castle.DynamicProxy;
using System;

namespace Core.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception ex) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            this.OnBefore(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                isSuccess = false;
                OnException(invocation, ex);
                throw;
            }
            finally
            {
                if (isSuccess)
                    OnSuccess(invocation);
            }

            this.OnAfter(invocation);
        }
    }
}
