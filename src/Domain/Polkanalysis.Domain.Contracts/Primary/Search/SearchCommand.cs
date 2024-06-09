using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Search;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Search
{
    public class SearchCommand : IRequest<Result<bool, ErrorResult>>
    {
        public SearchCommand(ISearchData data, DataType dataType)
        {
            Data = data;
            DataType = dataType;
        }

        public ISearchData Data { get; set; }
        public DataType DataType { get; set; }
    }

    public enum DataType
    {
        Pool
    }
}
