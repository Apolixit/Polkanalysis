using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

        public List<string> ExtractAsList(string className)
        {
            var mapping = OriginClasses.ToList().Last();
            List<string> arguments = new List<string>();

            arguments = mapping.Split("/").ToList();
            if (arguments.Last().Contains(">>"))
            {
                var args = arguments.Last().Split(">>");
                arguments.Remove(arguments.Last());
                arguments.AddRange(args);
            }
            else
            {
                arguments.Add(className);
            }

            arguments = arguments.Select(x => x.Trim()).ToList();
            return arguments;
        }
    }
}
