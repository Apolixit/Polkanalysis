using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base.Portable;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare.TypeDef;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare
{
    public class LookupDifferential
    {
        public IList<(CompareStatus status, U32 id)> Id { get; set; }
        = new List<(CompareStatus, U32)>();
        public IList<(CompareStatus status, BaseVec<Str> path)> Path { get; set; } 
            = new List<(CompareStatus, BaseVec<Str>)>();

        public IList<(CompareStatus status, BaseVec<TypeParameter> param)> Params { get; set; }
            = new List<(CompareStatus, BaseVec<TypeParameter>)>();

        public LookupDifferentialTypeDef LookupDifferentialType { get; set; } = new LookupDifferentialTypeDef();

        public IList<(CompareStatus status, BaseVec<Str> docs)> Docs { get; set; }
            = new List<(CompareStatus, BaseVec<Str>)>();

        public bool HasChanges()
        {
            return  Id.Count > 0 || 
                    Path.Count > 0 || 
                    Params.Count > 0 || 
                    LookupDifferentialType.HasChanges() ||
                    Docs.Count > 0;
        }

        public static PortableType FindType(PortableRegistry lookup, TType callType)
        {
            return lookup.Value.Single(x => x.Id.Value == (uint)callType.Value.Value);
        }

        public static LookupDifferential FromLookup(CompareStatus status, PortableType typeSource)
        {
            var lookupDifferential = new LookupDifferential();

            lookupDifferential.Path = new List<(CompareStatus, BaseVec<Str>)>() {
                (status, typeSource.Ty.Path)
            };

            lookupDifferential.Params = new List<(CompareStatus, BaseVec<TypeParameter>)>() {
                (status, typeSource.Ty.TypeParams)
            };

            AddTypeDefAction(lookupDifferential.LookupDifferentialType, status, typeSource);

            lookupDifferential.Docs = new List<(CompareStatus, BaseVec<Str>)>() {
                (status, typeSource.Ty.Docs)
            };

            return lookupDifferential;
        }

        public static void AddTypeDefAction(LookupDifferentialTypeDef result, CompareStatus status, PortableType typeSource)
        {
            switch (typeSource.Ty.TypeDef.Value)
            {
                case TypeDefEnum.Composite:
                    result.TypeComposite = DifferentialComposite.From(status, (TypeDefComposite)typeSource.Ty.TypeDef.Value2);
                    break;
                case TypeDefEnum.Variant:
                    result.TypeVariant = DifferentialVariant.From(status, (TypeDefVariant)typeSource.Ty.TypeDef.Value2);
                    break;
                case TypeDefEnum.Sequence:
                    result.TypeSequence.Add((status, (TypeDefSequence)typeSource.Ty.TypeDef.Value2));
                    break;
                case TypeDefEnum.Array:
                    result.TypeArray.Add((status, (TypeDefArray)typeSource.Ty.TypeDef.Value2));
                    break;
                case TypeDefEnum.Primitive:
                    result.TypePrimitive.Add((status, (BaseEnum<TypeDefPrimitive>)typeSource.Ty.TypeDef.Value2));
                    break;
                case TypeDefEnum.Compact:
                    result.TypeCompact.Add((status, (TypeDefCompact)typeSource.Ty.TypeDef.Value2));
                    break;
                case TypeDefEnum.BitSequence:
                    result.TypeBitSequence.Add((status, (TypeDefBitSequence)typeSource.Ty.TypeDef.Value2));
                    break;
                case TypeDefEnum.Tuple:
                    result.TypeTuple = DifferentialTuple.From(status, (TypeDefTuple)typeSource.Ty.TypeDef.Value2);
                    break;
                default:
                    throw new NotImplementedException("TypeDefEnum not implemented !?");
            }
        }
    }

    public class LookupDifferentialTypeDef
    {
        public DifferentialComposite TypeComposite { get; set; } = new DifferentialComposite();

        public DifferentialVariant TypeVariant { get; set; } = new DifferentialVariant();

        public IList<(CompareStatus status, TypeDefSequence typeDef)> TypeSequence { get; set; }
            = new List<(CompareStatus, TypeDefSequence)>();

        public IList<(CompareStatus status, TypeDefArray typeDef)> TypeArray { get; set; }
            = new List<(CompareStatus, TypeDefArray)>();

        public IList<(CompareStatus status, BaseEnum<TypeDefPrimitive> typeDef)> TypePrimitive { get; set; }
            = new List<(CompareStatus, BaseEnum<TypeDefPrimitive>)>();

        public IList<(CompareStatus status, TypeDefCompact typeDef)> TypeCompact { get; set; }
            = new List<(CompareStatus, TypeDefCompact)>();

        public IList<(CompareStatus status, TypeDefBitSequence typeDef)> TypeBitSequence { get; set; }
            = new List<(CompareStatus, TypeDefBitSequence)>();

        public DifferentialTuple TypeTuple { get; set; } = new DifferentialTuple();

        public bool HasChanges()
        {
            return TypeComposite.HasChanges() ||
                    TypeVariant.HasChanges() ||
                    TypeSequence.Any() ||
                    TypeArray.Any() ||
                    TypePrimitive.Any() ||
                    TypeCompact.Any() ||
                    TypeBitSequence.Any() ||
                    TypeTuple.HasChanges();
        }
    }
}
