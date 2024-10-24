using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module
{
    public class TypeProperty
    {
        public TypeProperty(string name, string param, ParamType typeParam)
        {
            Name = name;
            Param = param;
            TypeParam = typeParam;
        }

        public string Name { get; set; }
        public string Param { get; set; }
        public ParamType TypeParam { get; set; }
        public List<TypeProperty> SubProperties { get; set; } = new List<TypeProperty>();

        public enum ParamType
        {
            Primitive,
            EnumSimple,
            EnumComplex,
            AccountId,
            Composite
        }
    }
}
