using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Runtime.Module
{
    public class VariantProperty
    {
        public VariantProperty(string name, string param, ParamType typeParam)
        {
            Name = name;
            Param = param;
            TypeParam = typeParam;
        }

        public string Name { get; set; }
        public string Param { get; set; }
        public ParamType TypeParam { get; set; }

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
