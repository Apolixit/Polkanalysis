using Substrate.NetApi;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using System.Numerics;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Enum;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Mapping;
using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Blockchain.Runtime
{
    [ExcludeFromCodeCoverage]
    public class EventNodeMapping : INodeMapping
    {
        protected IList<EventMappingElem> Elements { get; set; }

        public EventNodeMapping(MetaData metaData) : this()
        {
        }

        public EventNodeMapping()
        {
            Elements = new List<EventMappingElem>
            {
                new EventMappingElem()
                {
                    CategoryName = "Amount",
                    Mapping = new List<IMappingElement>() {
                        new MappingElementU128(),
                        new MappingElementU64(),
                        new MappingElementU32(),
                        new MappingElementU16(),
                        new MappingElementU8(),
                        new MappingElementBaseCom<BaseCom<U256>>(),
                        new MappingElementBaseCom<BaseCom<U128>>(),
                        new MappingElementBaseCom<BaseCom<U64>>(),
                        new MappingElementBaseCom<BaseCom<U32>>(),
                        new MappingElementBaseCom<BaseCom<U16>>(),
                        new MappingElementBaseCom<BaseCom<U8>>(),
                        new MappingElementBaseCom<BaseCom<I256>>(),
                        new MappingElementBaseCom<BaseCom<I128>>(),
                        new MappingElementBaseCom<BaseCom<I64>>(),
                        new MappingElementBaseCom<BaseCom<I32>>(),
                        new MappingElementBaseCom<BaseCom<I16>>(),
                        new MappingElementBaseCom<BaseCom<I8>>(),
                        new MappingElementBaseCom<BigInteger>(),
                    }
                },
                new EventMappingElem()
                {
                    CategoryName = "Account",
                    Mapping = new List<IMappingElement>() { new MappingElementEnumRuntimeEvent(), new MappingElementAccount() }
                },
                new EventMappingElem()
                {
                    CategoryName = "Nameable",
                    Mapping = new List<IMappingElement>() { new MappingElementNameable() }
                },

                new EventMappingElem()
                {
                    CategoryName = "Hash",
                    Mapping = new List<IMappingElement>() { new MappingElementHashByteArray() }
                },

                //new EventMappingElem()
                //{
                //    CategoryName = "Maybe",
                //    Mapping = new List<IMappingElement>() { new MappingMaybeEnum<EnumRuntimeEvent>() }
                //},
                //new EventMappingElem()
                //{
                //    CategoryName = "Text",
                //    Mapping = new List<IMappingElement>() { new MappingElementText() }
                //}
                
                //new EventMappingElem()
                //{
                //    CategoryName = "DispatchInfo",
                //    Mapping = new List<IMappingElement>() { new MappingElementDispatchInfo() }
                //}
            };
        }

        public IMappingElement Search(Type searchType)
        {
            foreach (var elem in Elements)
            {
                var mapped = elem.Mapping.FirstOrDefault(x => x.ObjectType == searchType);
                if (mapped != null)
                {
                    return mapped;
                }
            }

            return new MappingElementUnknown(searchType);
        }
    }

    public class MappingMaybeEnum<T> : IMappingElement
        where T : IType, new()
    {
        public Type ObjectType => typeof(Maybe<T>);

        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            var maybe = (Maybe<T>)input;
            if (maybe.HasBeenMapped)
            {
                return maybe.Value.GetValue();
            }
            else
            {
                return maybe.Core.GetValue();
            }
        }
    }

    public class MappingElementU128 : IMappingElement
    {
        public Type ObjectType => typeof(U128);

        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return ((U128)input).Value;
        }
    }

    public class MappingElementU64 : IMappingElement
    {
        public Type ObjectType => typeof(U64);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return ((U64)input).Value;
        }
    }

    public class MappingElementU32 : IMappingElement
    {
        public Type ObjectType => typeof(U32);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return ((U32)input).Value;
        }
    }

    public class MappingElementU16 : IMappingElement
    {
        public Type ObjectType => typeof(U16);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return ((U16)input).Value;
        }
    }

    public class MappingElementU8 : IMappingElement
    {
        public Type ObjectType => typeof(U8);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return ((U8)input).Value;
        }
    }

    public class MappingElementBaseCom<T> : IMappingElement
    {
        public Type ObjectType => typeof(T);
        public bool IsIdentified => true;
        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return (ulong)input.Value;
        }
    }

    //public class MappingElementHash : IMappingElement
    //{
    //    public Type ObjectType => typeof(H256);
    //    public bool IsIdentified => true;

    //    dynamic IMappingElement.ToHuman(dynamic input) => Utils.Bytes2HexString(((H256)input).Value.Bytes);
    //}

    //public class MappingElementArr32U8 : IMappingElement
    //{
    //    public Type ObjectType => typeof(Arr32U8);
    //    public bool IsIdentified => true;

    //    dynamic IMappingElement.ToHuman(dynamic input) => Utils.Bytes2HexString(((Arr32U8)input).Bytes);
    //}

    //public class MappingElementArr64U8 : IMappingElement
    //{
    //    public Type ObjectType => typeof(Arr64U8);
    //    public bool IsIdentified => true;

    //    dynamic IMappingElement.ToHuman(dynamic input) => Utils.Bytes2HexString(((Arr64U8)input).Bytes);
    //}

    public class MappingElementHashByteArray : IMappingElement
    {
        //[SubstrateNodeType(TypeDefEnum.Array)]
        public Type ObjectType => typeof(BaseVec<U8>);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input) => Utils.Bytes2HexString(((BaseVec<U8>)input).Bytes);
    }

    public class MappingElementNameable : IMappingElement
    {
        public Type ObjectType => typeof(Nameable);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input) => ((Nameable)input).Display();
    }

    public class MappingElementFlexibleNameable : IMappingElement
    {
        public Type ObjectType => typeof(BaseVec<U8>);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input) => Utils.Bytes2HexString(((BaseVec<U8>)input).Bytes);
    }

    public class MappingElementNameableSize : IMappingElement
    {
        public Type ObjectType => typeof(BaseVec<U8>);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input) => Utils.Bytes2HexString(((BaseVec<U8>)input).Bytes);
    }

    public class MappingElementAccount : IMappingElement
    {
        public Type ObjectType => typeof(SubstrateAccount);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input) => ((SubstrateAccount)input).ToStringAddress();
    }

    //public class MappingElementAccount : IMappingElement
    //{
    //    public Type ObjectType => typeof(Contracts.Core.SubstrateAccount);
    //    public bool IsIdentified => true;

    //    dynamic IMappingElement.ToHuman(dynamic input) => new
    //    {
    //        PublicKey = Utils.GetPublicKeyFrom(Utils.GetAddressFrom((SubstrateAccount)input.)),
    //        Ss58Address = Utils.GetAddressFrom((Contracts.Core.SubstrateAccount)input.Bytes)
    //    };
    //}

    public class MappingElementEnumResult : IMappingElement
    {
        public Type ObjectType => typeof(EnumResult);

        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            var enumResult = (EnumResult)input;
            return (enumResult.Value, enumResult.Value2.ToString());
        }
    }

    //public class MappingElementText : IMappingElement
    //{
    //    public Type ObjectType => typeof(Arr4U8);

    //    public bool IsIdentified => true;

    //    public dynamic ToHuman(dynamic input)
    //    {
    //        return Encoding.UTF8.GetString(((Arr4U8)input).Encode());
    //    }
    //}

    //public class MappingElementDispatchInfo : IMappingElement
    //{
    //    public Type ObjectType => typeof(DispatchInfo);
    //    public bool IsIdentified => true;

    //    dynamic IMappingElement.ToHuman(dynamic input)
    //    {
    //        var dispatchInfo = (DispatchInfo)input;

    //        // Maybe better to use automapper ?

    //        var dispatchInfoDto = new DispatchInfoDto();
    //        dispatchInfoDto.PaysFee = dispatchInfo.PaysFee.Value;
    //        dispatchInfoDto.Class = dispatchInfo.Class.Value;
    //        dispatchInfoDto.Weight = dispatchInfo.Weight.RefTime.Value;

    //        return dispatchInfoDto;
    //    }
    //}

    //public class MappingElementModuleError : IMappingElement
    //{
    //    private readonly MetaData _metaData;

    //    public MappingElementModuleError(MetaData metaData)
    //    {
    //        _metaData = metaData;
    //    }
    //    public Type ObjectType => typeof(ModuleError);
    //    public bool IsIdentified => true;

    //    dynamic IMappingElement.ToHuman(dynamic input)
    //    {
    //        var moduleError = (ModuleError)input;
    //        //moduleError.Index
    //        //MetaData.CreateModuleDict()
    //        var palletError = _metaData.NodeMetadata.Modules[moduleError.Index.Value];
    //        //var fullQualifiedName = $"MoneyPot_NetApiExt.Generated.Storage.{palletError.Name}Errors, MoneyPot_NetApiExt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
    //        //Type palletErrorType = Type.GetType(fullQualifiedName);
    //        //var palletInstance = Activator.CreateInstance(palletErrorType);

    //        var result = new PalletErrorDto()
    //        {
    //            PalletName = palletError.Name,
    //            EventName = string.Empty,
    //            Message = String.Empty
    //        };

    //        return result;
    //    }
    //}

    public class MappingElementEnumExt : IMappingElement
    {
        public Type ObjectType => typeof(BaseEnumType);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            var enumResult = (BaseEnumType)input;
            return (enumResult.GetValue(), enumResult.GetValue2());
        }
    }
    public class MappingElementEnumRuntimeEvent : IMappingElement
    {
        public Type ObjectType => typeof(EnumRuntimeEvent);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            var enumResult = (EnumRuntimeEvent)input;
            return enumResult.Value;
        }
    }

    //// EventRecord
    //public class MappingElementEventRecord : IMappingElement
    //{
    //    public Type ObjectType => typeof(EventRecord);
    //    public bool IsIdentified => true;

    //    dynamic IMappingElement.ToHuman(dynamic input)
    //    {
    //        var enumResult = (EventRecord)input;
    //        return enumResult.;
    //    }
    //}

    public class MappingElementUnknown : IMappingElement
    {
        private readonly Type _objectType = typeof(object);
        public bool IsIdentified => false;
        public MappingElementUnknown() { }
        public MappingElementUnknown(Type unknownType)
        {
            _objectType = unknownType;
        }

        public Type ObjectType => _objectType;

        //public dynamic ToHuman(dynamic input) => input.ToString();
        public dynamic ToHuman(dynamic input) => input.Value.ToString();
    }

    public class EventMappingElem : IMappingCategory
    {
        public string CategoryName { get; set; }
        public IList<IMappingElement> Mapping { get; set; }

        //public EventDetailsResult ToEventDetailsResult(dynamic input, IMappingElement mapping)
        //{
        //    return new EventDetailsResult()
        //    {
        //        Title = CategoryName,
        //        ComponentName = $"Component_{mapping.ObjectType.Name}",
        //        Value = mapping.ToHuman(input)
        //    };
        //}

    }
}
