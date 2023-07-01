using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase
{
    public class ValidationPipelineBehaviour<TReq, TRes> : IPipelineBehavior<TReq, TRes>
        where TReq : IRequest<TRes>
    {
        private readonly IEnumerable<IValidator<TReq>> _validators;

        public ValidationPipelineBehaviour(IEnumerable<IValidator<TReq>> validators)
        {
            _validators = validators;
        }

        public async Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                var context = new ValidationContext<TReq>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .SelectMany(x => x.Errors)
                    .Where(x =>  x != null)
                    .ToList();

                if (failures.Any())
                    throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
