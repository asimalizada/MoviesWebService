using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidatorTool
    {
        public static void Validate(object entity, IValidator validator)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

        public static void ValidateGeneric<T>(T entity, IValidator validator)
        {
            var context = new ValidationContext<T>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
