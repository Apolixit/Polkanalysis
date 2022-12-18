//using Ajuna.NetApi;
//using Ajuna.NetApi.Model.Meta;
//using Ajuna.NetApi.Model.Types.Base;
//using Ajuna.NetApi.Model.Types.Metadata.V14;
//using Ajuna.NetApi.Model.Types.Primitive;
//using Blazscan.Domain.Contracts.Repository;
//using Blazscan.SubstrateDecode.Event;
//using Org.BouncyCastle.Utilities.Encoders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Blazscan.SubstrateDecode.Extrinsic
//{
//    public class ExtrinsicDecode
//    {
//        private readonly ISubstrateNodeRepository _substrateRepository;
//        public ExtrinsicDecode(ISubstrateNodeRepository substrateNodeRepository)
//        {
//            _substrateRepository = substrateNodeRepository;
//        }

//        public async Task ReadExtrinsic(Ajuna.NetApi.Model.Extrinsics.Extrinsic extrinsic)
//        {
//            var nodeMetadata = _substrateRepository.Client.MetaData.NodeMetadata;
//            var metadataModules = _substrateRepository.Client.MetaData.NodeMetadata.Modules;
//            var metadataExtrinsic = _substrateRepository.Client.MetaData.NodeMetadata.Extrinsic;
//            var moduleName = metadataModules.FirstOrDefault(x => x.Value.Index == extrinsic.Method.ModuleIndex);

//            var extrinsicIndex = new U32();
//            extrinsicIndex.Create(0);
//            //var x = await _substrateService.Client.SystemStorage.ExtrinsicData(extrinsicIndex, CancellationToken.None);
//            //var moduleError = (ModuleError)input;
//            //moduleError.Index
//            //MetaData.CreateModuleDict()
//            var pallet = _substrateRepository.Client.MetaData.NodeMetadata.Modules[extrinsic.Method.ModuleIndex];
//            var palletCall = nodeMetadata.Types[pallet.Calls.TypeId];

//            // Si palletCall.Typedef == Variant => Accès aux enum Variants

//            // Index 3 = transfer_keep_alive
//            //BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128>>
//            var realCall = new BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128>>();
//            realCall.Create(extrinsic.Method.Parameters);

//            //var realCall = new Blazscan.NetApiExt.Generated.Model.pallet_balances.pallet.EnumCall();
//            //realCall.Create(extrinsic.Method.Parameters);

//            var realCallHex = Utils.Bytes2HexString(realCall.Encode());
//            var _eventDecode = new SubstrateDecode(new EventMapping(), _substrateRepository);
//            var nodeResult = _eventDecode.DecodeEvent(realCall);
//            var nodeResult2 = _eventDecode.DecodeEvent(realCallHex);

//            //var fullQualifiedName = $"Blazscan_NetApiExt.Generated.Storage.{pallet.Name}Errors, Blazscan_NetApiExt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
//            //Type palletErrorType = Type.GetType(fullQualifiedName);
//            //var palletInstance = Activator.CreateInstance(palletErrorType);

//            //var callName = metadataExtrinsic. extrinsic.Method.CallIndex);
//            //_substrateService.Client.MetaData.NodeMetadata.Types
//            var callName = true;


//        }

//        //public static Dictionary<uint, NodeType> CreateNodeTypeDict(PortableType[] types)
//        //{
//        //    Dictionary<uint, NodeType> dictionary = new Dictionary<uint, NodeType>();
//        //    foreach (PortableType portableType in types)
//        //    {
//        //        string[] path = ((portableType.Ty.Path.Value.Length == 0) ? null : portableType.Ty.Path.Value.Select((Str p) => p.Value).ToArray());
//        //        NodeTypeParam[] typeParams = ((portableType.Ty.TypeParams.Value.Length == 0) ? null : portableType.Ty.TypeParams.Value.Select((TypeParameter p) => new NodeTypeParam
//        //        {
//        //            Name = p.TypeParameterName.Value,
//        //            TypeId = p.TypeParameterType.Value?.Value
//        //        }).ToArray());
//        //        TypeDefEnum value = portableType.Ty.TypeDef.Value;
//        //        string[] docs = ((portableType.Ty.Docs == null || portableType.Ty.Docs.Value.Length == 0) ? null : portableType.Ty.Docs.Value.Select((Str p) => p.Value).ToArray());
//        //        NodeType nodeType = null;
//        //        switch (value)
//        //        {
//        //            case TypeDefEnum.Composite:
//        //                {
//        //                    TypeDefComposite typeDefComposite = portableType.Ty.TypeDef.Value2 as TypeDefComposite;
//        //                    nodeType = new NodeTypeComposite
//        //                    {
//        //                        Id = portableType.Id.Value,
//        //                        Path = path,
//        //                        TypeParams = typeParams,
//        //                        TypeDef = value,
//        //                        TypeFields = ((typeDefComposite.Fields.Value.Length == 0) ? null : typeDefComposite.Fields.Value.Select(delegate (Field p)
//        //                        {
//        //                            string[] docs4 = ((p.Docs == null || p.Docs.Value.Length == 0) ? null : p.Docs.Value.Select((Str q) => q.Value).ToArray());
//        //                            return new NodeTypeField
//        //                            {
//        //                                Name = p.FieldName.Value?.Value,
//        //                                TypeName = p.FieldTypeName.Value?.Value,
//        //                                TypeId = p.FieldTy.Value,
//        //                                Docs = docs4
//        //                            };
//        //                        }).ToArray()),
//        //                        Docs = docs
//        //                    };
//        //                    break;
//        //                }
//        //            case TypeDefEnum.Variant:
//        //                {
//        //                    TypeDefVariant typeDefVariant = portableType.Ty.TypeDef.Value2 as TypeDefVariant;
//        //                    nodeType = new NodeTypeVariant
//        //                    {
//        //                        Id = portableType.Id.Value,
//        //                        Path = path,
//        //                        TypeParams = typeParams,
//        //                        TypeDef = value,
//        //                        Variants = ((typeDefVariant.TypeParam.Value.Length == 0) ? null : typeDefVariant.TypeParam.Value.Select(delegate (Variant p)
//        //                        {
//        //                            string[] docs2 = ((p.Docs == null || p.Docs.Value.Length == 0) ? null : p.Docs.Value.Select((Str q) => q.Value).ToArray());
//        //                            return new TypeVariant
//        //                            {
//        //                                Name = p.VariantName.Value,
//        //                                TypeFields = ((p.VariantFields.Value.Length == 0) ? null : p.VariantFields.Value.Select(delegate (Field q)
//        //                                {
//        //                                    string[] docs3 = ((q.Docs == null || q.Docs.Value.Length == 0) ? null : q.Docs.Value.Select((Str r) => r.Value).ToArray());
//        //                                    return new NodeTypeField
//        //                                    {
//        //                                        Name = q.FieldName.Value?.Value,
//        //                                        TypeName = q.FieldTypeName.Value?.Value,
//        //                                        TypeId = q.FieldTy.Value,
//        //                                        Docs = docs3
//        //                                    };
//        //                                }).ToArray()),
//        //                                Index = p.Index.Value,
//        //                                Docs = docs2
//        //                            };
//        //                        }).ToArray()),
//        //                        Docs = docs
//        //                    };
//        //                    break;
//        //                }
//        //            case TypeDefEnum.Sequence:
//        //                {
//        //                    TypeDefSequence typeDefSequence = portableType.Ty.TypeDef.Value2 as TypeDefSequence;
//        //                    nodeType = new NodeTypeSequence
//        //                    {
//        //                        Id = portableType.Id.Value,
//        //                        Path = path,
//        //                        TypeParams = typeParams,
//        //                        TypeDef = value,
//        //                        TypeId = typeDefSequence.TypeParam.Value,
//        //                        Docs = docs
//        //                    };
//        //                    break;
//        //                }
//        //            case TypeDefEnum.Array:
//        //                {
//        //                    TypeDefArray typeDefArray = portableType.Ty.TypeDef.Value2 as TypeDefArray;
//        //                    nodeType = new NodeTypeArray
//        //                    {
//        //                        Id = portableType.Id.Value,
//        //                        Path = path,
//        //                        TypeParams = typeParams,
//        //                        TypeDef = value,
//        //                        TypeId = typeDefArray.TypeParam.Value,
//        //                        Length = typeDefArray.Len.Value,
//        //                        Docs = docs
//        //                    };
//        //                    break;
//        //                }
//        //            case TypeDefEnum.Tuple:
//        //                {
//        //                    TypeDefTuple typeDefTuple = portableType.Ty.TypeDef.Value2 as TypeDefTuple;
//        //                    nodeType = new NodeTypeTuple
//        //                    {
//        //                        Id = portableType.Id.Value,
//        //                        Path = path,
//        //                        TypeParams = typeParams,
//        //                        TypeDef = value,
//        //                        TypeIds = ((IEnumerable<TType>)typeDefTuple.Fields.Value).Select((Func<TType, uint>)((TType p) => p.Value)).ToArray(),
//        //                        Docs = docs
//        //                    };
//        //                    break;
//        //                }
//        //            case TypeDefEnum.Primitive:
//        //                {
//        //                    TypeDefPrimitive primitive = (TypeDefPrimitive)Enum.Parse(typeof(TypeDefPrimitive), portableType.Ty.TypeDef.Value2.ToString());
//        //                    nodeType = new NodeTypePrimitive
//        //                    {
//        //                        Id = portableType.Id.Value,
//        //                        Path = path,
//        //                        TypeParams = typeParams,
//        //                        TypeDef = value,
//        //                        Primitive = primitive,
//        //                        Docs = docs
//        //                    };
//        //                    break;
//        //                }
//        //            case TypeDefEnum.Compact:
//        //                {
//        //                    TypeDefCompact typeDefCompact = portableType.Ty.TypeDef.Value2 as TypeDefCompact;
//        //                    nodeType = new NodeTypeCompact
//        //                    {
//        //                        Id = portableType.Id.Value,
//        //                        Path = path,
//        //                        TypeParams = typeParams,
//        //                        TypeDef = value,
//        //                        TypeId = typeDefCompact.TypeParam.Value,
//        //                        Docs = docs
//        //                    };
//        //                    break;
//        //                }
//        //            case TypeDefEnum.BitSequence:
//        //                {
//        //                    TypeDefBitSequence typeDefBitSequence = portableType.Ty.TypeDef.Value2 as TypeDefBitSequence;
//        //                    nodeType = new NodeTypeBitSequence
//        //                    {
//        //                        Id = portableType.Id.Value,
//        //                        Path = path,
//        //                        TypeParams = typeParams,
//        //                        TypeDef = value,
//        //                        TypeIdOrder = typeDefBitSequence.BitOrderType.Value,
//        //                        TypeIdStore = typeDefBitSequence.BitStoreType.Value,
//        //                        Docs = docs
//        //                    };
//        //                    break;
//        //                }
//        //        }

//        //        if (nodeType != null)
//        //        {
//        //            dictionary.Add(nodeType.Id, nodeType);
//        //        }
//        //    }

//        //    return dictionary;
//        //}
//    }
//}
