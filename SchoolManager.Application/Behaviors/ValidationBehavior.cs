using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using MediatR;
using SchoolManager.Domain.Entities;
using SchoolManager.SharedKernel;
using SchoolManager.SharedKernel.Extesions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();

            var validationErrors = await Task.WhenAll(_validators
                .Select(v => v.ValidateAsync(request, cancellationToken)));

            var failures = validationErrors.SelectMany(result => result.AsErrors()).ToList();
            if (failures.Any())         
                return ReturnValidationResult(failures);      
           
            return await next();
        }

        private static TResponse ReturnValidationResult(List<ValidationError> failures)
        {
            if (typeof(TResponse) == typeof(Result))
                return (TResponse)(object)Result.Invalid(failures)!;

            var validationResult = typeof(Result<>)
                .GetGenericTypeDefinition()
                .MakeGenericType(typeof(TResponse).GenericTypeArguments[0])
                .GetMethod(nameof(Result.Invalid))!
                .Invoke(null, new object?[] { failures })!;

            return (TResponse)validationResult;
        }
    }
}
