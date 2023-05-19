using Substrate.NetApi.Model.Meta;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Module
{
    public class ModuleStorageDto
    {
        public required string Name { get; set; }
        public required StorageType StorageType { get; set; }
        public required StorageModifier StorageModifier { get; set; }
        public string? Default { get; set; }
        public string? Documentation { get; set; }
    }

    public enum StorageType
    {
        Plain,
        Map,
        DoubleMap,
        NMap
    }

    public enum StorageModifier
    {
        Optional,
        Default
    }
}
