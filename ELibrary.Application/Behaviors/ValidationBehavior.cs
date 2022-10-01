using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ELibrary.Application.Contracts.Common;
using ELibrary.Domain.Errors;
using FluentValidation;
using MediatR;

namespace ELibrary.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Result
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any()) return await next();

            List<Error> errors = _validators
                .Select(validator => validator.Validate(request))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure is not null)
                .Select(failure => new Error(
                    failure.PropertyName,
                    failure.ErrorMessage,
                    ErrorTypes.Validation))
                .Distinct()
                .ToList();

            if (errors.Any()) return CreateValidationResult<TResponse>(errors);

            return await next();
        }

        private static TResult CreateValidationResult<TResult>(List<Error> errors) // https://youtu.be/85dxwd8HzEk?t=510
            where TResult : Result
        {
            if (typeof(TResult) == typeof(Result))
                return (Result.Fail(errors) as TResult)!;
            // Compiler won't allow to cast it explicitly, so gotta try cast it. Ok since ValidationResult is
            // essentially the Result and the type parameter specified this way
            object validationResult = typeof(Result<>)
                .GetGenericTypeDefinition()
                .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
                .GetMethod("FailWithErrors")!
                .MakeGenericMethod(typeof(TResult).GenericTypeArguments[0])
                .Invoke(null, new object?[] {errors})!;

            return (TResult) validationResult;
        }
    }
}