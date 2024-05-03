using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Common
{
    public class RangeDateValidator : AbstractValidator<RangeDate>
    {
        public RangeDateValidator()
        {
            RuleFor(x => x.To)
                .GreaterThanOrEqualTo(x => x.From)
                .When(x => x.To.HasValue && x.From.HasValue)
                .WithMessage("Start date must be less than or equal to end date");
        }
    }
}
