using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Test
{
    public static class TestMapper
    {
        public static TDestination MapBaseEnum<TSource, TSourceEnum, TDestination, TDestinationEnum>(TSource source)
            where TSource : BaseEnum<TSourceEnum>
            where TSourceEnum : Enum
            where TDestination : BaseEnum<TDestinationEnum>, new()
            where TDestinationEnum : Enum
        {
            var mapped = PolkadotMapping.Instance.Map<BaseEnum<TSourceEnum>, BaseEnum<TDestinationEnum>>(source);
            var res = new TDestination();
            res.Create(mapped.Value);

            return res;
        }

        /// <summary>
        /// Map an IBaseEnum to a new IBaseEnum
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <typeparam name="TDestinationEnum"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <exception cref="InvalidTypeSizeException"></exception>
        /// <exception cref="MissingMappingException"></exception>
        public static TDestination MapEnum<TDestination, TDestinationEnum>(IBaseEnum source)
            where TDestination : IBaseEnum, new()
            where TDestinationEnum : struct, Enum
        {
            var destination = new TDestination();
            if (source == null) return destination;

            TDestinationEnum mapped;
            if (Enum.TryParse(source.GetEnum().ToString(), out mapped))
            {
                var baseEnumExtBytes = new List<byte>()
                {
                    Convert.ToByte(mapped)
                };
                baseEnumExtBytes.AddRange(source.GetValues().Encode());
                destination.Create(baseEnumExtBytes.ToArray());

                // Check if Value2 type is valid
                int sourceTypeSize = source.GetValues().TypeSize;
                int destinationTypeSize = destination.GetValues().TypeSize;
                if (sourceTypeSize != destinationTypeSize)
                {
                    throw new InvalidTypeSizeException($"Error while trying to map {source.GetType()} to {typeof(TDestination)}," +
                        $"associated data (Value2) does not have same TypeSize (source = {sourceTypeSize} / " +
                        $"destination = {destinationTypeSize})");
                }

                return destination;
            }

            throw new MissingMappingException($"Impossible to cast {source.GetType()} to BaseEnum<{typeof(TDestination)}>");
        }
    }

    #region BaseEnum
    public enum SubstrateEnum1
    {
        PrimarySlots = 0,
        PrimaryAndSecondaryPlainSlots = 1,
        PrimaryAndSecondaryVRFSlots = 2
    }

    public sealed class EnumSubstrateEnum1 : BaseEnum<SubstrateEnum1>
    {
    }

    public enum SubstrateEnum2
    {
        PrimarySlots = 0,
        PrimaryAndSecondaryPlainSlots = 1,
        PrimaryAndSecondaryVRFSlots = 2,
        AnotherOne = 3,
    }

    public sealed class EnumSubstrateEnum2 : BaseEnum<SubstrateEnum2>
    {
    }

    public enum SubstrateEnum3
    {
        PrimaryAndSecondaryPlainSlots = 0,
        AnotherOne = 1,
        TheFourth = 2
    }

    public sealed class EnumSubstrateEnum3 : BaseEnum<SubstrateEnum3>
    {
    }

    public enum DomainSubstrateEnum
    {
        PrimarySlots = 0,
        PrimaryAndSecondaryPlainSlots = 1,
        PrimaryAndSecondaryVRFSlots = 2,
        AnotherOne = 3,
        TheFourth = 4
    }

    public sealed class EnumDomainSubstrateEnum : BaseEnum<DomainSubstrateEnum>
    {
    }

    #endregion

    #region BaseEnumExt
    public enum SubstrateEnumExt1
    {
        Awesome1 = 0,
        Awesome2 = 1,
        Awesome3 = 2
    }

    public sealed class EnumSubstrateEnumExt1 : BaseEnumExt<SubstrateEnumExt1, BaseVoid, U32, Bool>
    {
    }

    public enum SubstrateEnumExt2
    {
        Awesome1 = 0,
        Awesome3 = 1,
        Awesome4 = 2,
    }

    public sealed class EnumSubstrateEnumExt2 : BaseEnumExt<SubstrateEnumExt2, BaseVoid, Bool, U128>
    {
    }

    public enum SubstrateEnumExt3
    {
        Awesome2 = 0,
        Awesome5 = 1,
        Awesome4 = 2,
        Awesome1 = 3,
    }

    public sealed class EnumSubstrateEnumExt3 : BaseEnumExt<SubstrateEnumExt3, U32, BaseVoid, U128, BaseVoid>
    {
    }

    public enum SubstrateEnumExt4Error
    {
        Awesome1 = 0,
        Awesome2 = 1,
        Awesome3 = 2,
        Awesome4 = 3,
        Awesome10 = 4,
    }

    public sealed class EnumSubstrateEnumExt4Error : BaseEnumExt<SubstrateEnumExt4Error, U32, BaseVoid, U128, BaseVoid, U32>
    {
    }

    public enum SubstrateEnumExtDomain
    {
        Awesome1 = 0,
        Awesome2 = 1,
        Awesome4 = 2,
        Awesome3 = 3,
        Awesome5 = 4,
    }

    public sealed class EnumSubstrateEnumExtDomain : BaseEnumExt<SubstrateEnumExtDomain, BaseVoid, U32, U128, Bool, BaseVoid>
    {
    }
    #endregion

}
