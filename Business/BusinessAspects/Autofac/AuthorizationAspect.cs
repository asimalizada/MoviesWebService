using Castle.DynamicProxy;
using Core.Extensions;
using Core.Interceptors;
using Core.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    public class AuthorizationAspect : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthorizationAspect(string roles)
        {
            this._roles = roles.Split(',');
            this._httpContextAccessor = 
                ServiceHelper.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = this._httpContextAccessor.HttpContext.User.ClaimRoles();

            foreach (var role in this._roles)
            {
                if (roleClaims.Contains(role)) return;
            }

            throw new System.Exception("Access denied!");
        }

    }
}
