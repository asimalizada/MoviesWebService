using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Interceptors;
using FluentValidation;
using System;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Parameter must be assignable from IValidator.");
            }

            this._validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator) Activator.CreateInstance(this._validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(a => a.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidatorTool.Validate(entity, validator);
            }
        }
    }
}
