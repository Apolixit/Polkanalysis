using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Components.Dto
{
    public class BreadcrumbDto
    {
        public BreadcrumbDto(string name, string? url)
        {
            Name = name;
            Url = url;
        }

        public string Name { get; set; }
        public string? Url { get; set; }
    }
}
