using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.Module
{
    public class TypeFieldDto
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string TypeName { get; set; }
    }
}
