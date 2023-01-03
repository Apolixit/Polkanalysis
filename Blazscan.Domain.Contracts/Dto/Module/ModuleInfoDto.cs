using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Dto.Module
{
    public class ModuleInfoDto
    {
        public required string PalletName { get; set; }
        public string? Documentation { get; set; }
    }
}
