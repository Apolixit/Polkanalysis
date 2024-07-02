using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Components.Components.Search
{
    public class ComponentParameter
    {
        public required Type ComponentType { get; init; }
        public required string ComponentName { get; init; }
        public required string ComponentLabel { get; set; }
        public required Dictionary<string, object> Parameters { get; init; }

        public ComponentParameter Clone()
        {
            return new ComponentParameter()
            {
                ComponentType = ComponentType,
                ComponentName = ComponentName,
                ComponentLabel = ComponentLabel,
                Parameters = new Dictionary<string, object>(Parameters)
            };
        }
    }
}
