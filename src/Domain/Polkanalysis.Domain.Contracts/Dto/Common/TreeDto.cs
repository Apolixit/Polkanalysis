using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Common
{
    public class TreeDto
    {
        public TreeDto(string name, string value, List<TreeDto> children)
        {
            Name = name;
            Value = value;
            Children = children;
        }

        public string Name { get; set; }
        public string Value { get; set; }
        public List<TreeDto> Children { get; set; }
    }
}
