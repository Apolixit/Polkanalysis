using Ajuna.NetApi.Model.Meta;
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
        public required Storage.Type Type { get; set; }
        public required Storage.Modifier Modifier { get; set; }
        public string? Default { get; set; }
        public string? Documentation { get; set; }
    }
}
