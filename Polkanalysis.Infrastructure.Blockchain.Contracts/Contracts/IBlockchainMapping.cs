using AutoMapper;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts
{
    public interface IBlockchainMapping
    {
        public IMapper StandardMapper { get; }

        public TDestination Map<TSource, TDestination>(TSource source)
            where TSource : IType;

        public TDestination MapWithVersion<TSource, TDestination>(uint version, TSource source, CancellationToken token)
            where TSource : IType
            where TDestination: IType;

        public TDestination MapEnum<TDestination, TDestinationEnum>(IBaseEnum source)
            where TDestination : IBaseEnum, new()
            where TDestinationEnum : struct, Enum;
    }
}
