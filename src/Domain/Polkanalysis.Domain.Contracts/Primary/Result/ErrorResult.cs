using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Result
{
    public class ErrorResult
    {
        public required ErrorType Status { get; set; }
        public required string Description { get; set; }

        public enum ErrorType
        {
            EmptyParam,
            InvalidParam,
            EmptyModel,
            BusinessError,
            NoNeed
        }
    }
}
