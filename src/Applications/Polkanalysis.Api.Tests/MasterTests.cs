using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using OperationResult;
using Polkanalysis.Api.Controllers;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polkanalysis.Domain.Contracts.Primary.Result.ErrorResult;

namespace Polkanalysis.Api.Tests
{
    public abstract class MasterTests<T>
        where T : MasterController
    {
        protected IMediator _mediator;

        /// <summary>
        /// This is a default call to a child controller
        /// </summary>
        /// <returns></returns>
        protected abstract T defaultUseCase();

        [SetUp]
        public void SetupBase()
        {
            _mediator = Substitute.For<IMediator>();
        }

        protected static Result<T, ErrorResult> GetValidResult<T>(T result)
        {
            return Helpers.Ok(result);
        }

        protected static Result<T, ErrorResult> GetInvalidResult_EmptyParam<T>()
        {
            return Helpers.Error(new ErrorResult()
            {
                Status = ErrorType.EmptyParam,
                Description = string.Empty
            });
        }
    }
}
