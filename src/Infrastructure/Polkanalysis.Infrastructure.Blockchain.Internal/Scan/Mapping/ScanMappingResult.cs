using Substrate.NET.Utils;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping
{
    internal class ScanMappingResult
    {
        public ScanMappingResult(Type sourceClass) 
        {
            SourceClass = sourceClass.FullName;

            var sourceInstance = sourceClass.Instanciate<IType>();
            SourceEnumName = sourceInstance.GetEnumValue().GetType().GetEnumNames();
        }

        public string SourceClass { get; set; }
        public IEnumerable<IType> SourceInstances { get; internal set; }
        public string[]  SourceEnumName { get; internal set; }

        public string? DestinationClass { get; set; }

        public List<string> UnmappedProperties = new List<string>();
        public bool IsClassMapped => DestinationClass is not null;
        public bool AreAllPropertiesMapped => !UnmappedProperties.Any();

        public void MapProperties(string[] source, string[] destination)
        {
            UnmappedProperties.AddRange(source.Except(destination));
        }
    }

    internal class EnumAssemblyResult
    {
        public Enum Enum { get; set; }
        public IType EnumExt { get; set; }
        public string FullName { get; set; }
        public DomainMappingAttribute MappingAttribute { get; set; }

        public string ExtNameBuilder => $"{MappingAttribute.OriginClasses.First().Replace("/", ".")}.{EnumExt.GetType().Name}";
    }
}
