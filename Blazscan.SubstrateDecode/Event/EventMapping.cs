using Ajuna.NetApi;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Blazscan.AjunaExtension;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Helpers;
using Blazscan.NetApiExt.Generated.Model.frame_support.dispatch;
using Blazscan.NetApiExt.Generated.Model.primitive_types;
using Blazscan.NetApiExt.Generated.Model.sp_core.crypto;
using Blazscan.NetApiExt.Generated.Model.sp_runtime;
using Blazscan.NetApiExt.Generated.Types.Base;

namespace Blazscan.SubstrateDecode.Event
{
    public class EventMapping
    {
        protected IList<EventMappingElem> Elements { get; set; }

        public EventMapping(MetaData metaData) : this()
        {
            Elements.Add(new EventMappingElem()
            {
                Name = "ModuleError",
                Mapping = new List<IMappingElement>() { new MappingElementModuleError(metaData) }
            });
        }

        public EventMapping()
        {
            Elements = new List<EventMappingElem>();
            Elements.Add(new EventMappingElem()
            {
                Name = "Amount",
                Mapping = new List<IMappingElement>() { 
                    new MappingElementU128(),
                    new MappingElementU64(),
                    new MappingElementU32(),
                    new MappingElementU16(),
                    new MappingElementU8(),
                }
            });

            Elements.Add(new EventMappingElem()
            {
                Name = "Account",
                Mapping = new List<IMappingElement>() { new MappingElementAccount() }
            });

            Elements.Add(new EventMappingElem()
            {
                Name = "Hash",
                Mapping = new List<IMappingElement>() { new MappingElementHash(), new MappingElementHashByteArray() }
            });

            Elements.Add(new EventMappingElem()
            {
                Name = "Result",
                Mapping = new List<IMappingElement>() { new MappingElementEnumResult() }
            });
            Elements.Add(new EventMappingElem()
            {
                Name = "DispatchInfo",
                Mapping = new List<IMappingElement>() { new MappingElementDispatchInfo() }
            });
        }

        public IMappingElement Search(Type searchType)
        {
            foreach(var elem in Elements)
            {
                var mapped = elem.Mapping.FirstOrDefault(x => x.ObjectType == searchType);
                if(mapped != null)
                {
                    return mapped;
                }
            }

            return new MappingElementUnknown(searchType);
        }
    }

    public interface IMappingElement
    {
        public Type ObjectType { get; }
        public bool IsIdentified { get; }
        public dynamic ToHuman(dynamic input);
    }

    public class MappingElementU128 : IMappingElement
    {
        public Type ObjectType => typeof(U128);

        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            return (uint)((U128)input).Value;
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

    public class MappingElementHash : IMappingElement
    {
        //[AjunaNodeType(TypeDefEnum.Array)]
        public Type ObjectType => typeof(H256);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input) => Utils.Bytes2HexString(((H256)input).Value.Bytes);
    }

    public class MappingElementHashByteArray : IMappingElement
    {
        //[AjunaNodeType(TypeDefEnum.Array)]
        public Type ObjectType => typeof(BaseVec<U8>);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input) => Utils.Bytes2HexString(((BaseVec<U8>)input).Bytes);
    }

    public class MappingElementAccount : IMappingElement
    {
        public Type ObjectType => typeof(AccountId32);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input) => AccountHelper.BuildAddress((AccountId32)input);
    }

    public class MappingElementEnumResult : IMappingElement
    {
        public Type ObjectType => typeof(EnumResult);

        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            var enumResult = ((EnumResult)input);
            //enumResult.Value2;
            return (enumResult.Value, enumResult.Value2.ToString());
        }
    }

    public class MappingElementDispatchInfo : IMappingElement
    {
        public Type ObjectType => typeof(DispatchInfo);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            var dispatchInfo = (DispatchInfo)input;

            // Maybe better to use automapper ?

            var dispatchInfoDto = new DispatchInfoDto();
            dispatchInfoDto.PaysFee = dispatchInfo.PaysFee.Value;
            dispatchInfoDto.Class = dispatchInfo.Class.Value;
            dispatchInfoDto.Weight = dispatchInfo.Weight.RefTime.Value;

            return dispatchInfoDto;
        }
    }

    public class MappingElementModuleError : IMappingElement
    {
        private readonly MetaData _metaData;

        public MappingElementModuleError(MetaData metaData)
        {
            _metaData = metaData;
        }
        public Type ObjectType => typeof(ModuleError);
        public bool IsIdentified => true;

        dynamic IMappingElement.ToHuman(dynamic input)
        {
            var moduleError = (ModuleError)input;
            //moduleError.Index
            //MetaData.CreateModuleDict()
            var palletError = _metaData.NodeMetadata.Modules[moduleError.Index.Value];
            var fullQualifiedName = $"MoneyPot_NetApiExt.Generated.Storage.{palletError.Name}Errors, MoneyPot_NetApiExt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            Type palletErrorType = Type.GetType(fullQualifiedName);
            var palletInstance = Activator.CreateInstance(palletErrorType);
            
            var result = new PalletErrorDto()
            {
                PalletName = palletError.Name,
                EventName = string.Empty,
                Message = String.Empty
            };

            return result;
        }
    }

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

    public class MappingElementUnknown : IMappingElement
    {
        private Type _objectType = typeof(object);
        public bool IsIdentified => false;
        public MappingElementUnknown() { }
        public MappingElementUnknown(Type unknownType)
        {
            _objectType = unknownType;
        }

        public Type ObjectType => _objectType;

        public dynamic ToHuman(dynamic input) => input.ToString();
    }

    public class EventMappingElem
    {
        public string Name { get; set; }
        public IList<IMappingElement> Mapping { get; set; }

        public EventDetailsResult ToEventDetailsResult(dynamic input, IMappingElement mapping)
        {
            return new EventDetailsResult()
            {
                Title = Name,
                ComponentName = $"Component_{mapping.ObjectType.Name}",
                Value = mapping.ToHuman(input)
            };
        }

    }
}
