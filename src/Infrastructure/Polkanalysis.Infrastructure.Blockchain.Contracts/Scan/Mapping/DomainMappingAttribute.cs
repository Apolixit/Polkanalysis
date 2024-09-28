using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = true)]
    public class DomainMappingAttribute : Attribute
    {
        public IEnumerable<string> OriginClasses { get; set; }

        public DomainMappingAttribute(IEnumerable<string> originClasses)
        {
            OriginClasses = originClasses;
        }

        public DomainMappingAttribute(string originClass)
        {
            OriginClasses = new List<string>() { originClass };
        }

        public DomainMappingAttribute(string originClass1, string originClass2)
        {
            OriginClasses = new List<string>() { originClass1, originClass2 };
        }

        public DomainMappingAttribute(string originClass1, string originClass2, string originClass3)
        {
            OriginClasses = new List<string>() { originClass1, originClass2, originClass3 };
        }

        public DomainMappingAttribute(string originClass1, string originClass2, string originClass3, string originClass4)
        {
            OriginClasses = new List<string>() { originClass1, originClass2, originClass3, originClass4 };
        }
    }
}
