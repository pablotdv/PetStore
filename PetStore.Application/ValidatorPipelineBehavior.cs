using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Application
{
    public class ValidatorPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>         
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidatorPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)            
        {
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(
                _validators.Select(validator => validator.ValidateAsync(context)));

            var errors = validationFailures
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors)
                .Select(validationFailure => new
                {
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage
                })
                .ToList();

            if (errors.Any())
            {
                var errorResponse = new BadRequestResponse();

                return (TResponse)(object)errorResponse; // Assuming TResponse can be cast to BadRequestObjectResult
            }

            var response = await next();

            return response;
        }
    }
}
