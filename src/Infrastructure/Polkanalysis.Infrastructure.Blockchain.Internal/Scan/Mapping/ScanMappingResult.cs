using Substrate.NET.Utils;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping
{
    internal class ScanMappingResult
    {
        public ScanMappingResult(Type sourceClass) 
        {
            SourceClass = sourceClass.FullName;

            var sourceInstance = sourceClass.Instanciate<IBaseEnum>();
            SourceEnumName = sourceInstance.GetValue().GetType().GetEnumNames();
        }

        public string SourceClass { get; set; }
        public IEnumerable<IBaseEnum> SourceInstances { get; internal set; }
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
        public IBaseEnum EnumExt { get; set; }
        public string FullName { get; set; }
        public DomainMappingAttribute MappingAttribute { get; set; }

        public string ExtNameBuilder => $"{MappingAttribute.OriginClasses.First().Replace("/", ".")}.{EnumExt.GetType().Name}";
    }
}
