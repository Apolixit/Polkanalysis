using Polkanalysis.Components.Components.Search;
using Polkanalysis.Domain.Contracts.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polkanalysis.Components.Substrate.Explorer.Event.SearchEvents;

namespace Polkanalysis.Components.Shared
{
    public static class Constants
    {
        public static DateTime? DefaultDate => null;
        public static DateTime? DefaultTime => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static int DefaultPageSize => ConstantsPagination.DefaultPageSize;

        public static Dictionary<string, ComponentParameter> DeclaredComponents => new()
        {
            ["NumberCriteria<uint>"] = new ComponentParameter()
            {
                ComponentType = typeof(NumberCriteriaFilterUint),
                ComponentName = "NumberFilterUint",
                ComponentLabel = "",
                Parameters = new Dictionary<string, object>
                {
                    [nameof(NumberCriteriaFilterUint.Label)] = "",
                }
            },
            ["NumberCriteria<double>"] = new ComponentParameter()
            {
                ComponentType = typeof(NumberCriteriaFilterDouble),
                ComponentName = "NumberFilterDouble",
                ComponentLabel = "",
                Parameters = new Dictionary<string, object>
                {
                    [nameof(NumberCriteriaFilterDouble.Label)] = "",
                }
            },
            ["String"] = new ComponentParameter()
            {
                ComponentType = typeof(TextCriteriaFilter),
                ComponentName = "TextFilter",
                ComponentLabel = "",
                Parameters = new Dictionary<string, object>
                {
                    [nameof(TextCriteriaFilter.Label)] = "",
                }
            },
            ["NumberCriteria<DateTime>"] = new ComponentParameter()
            {
                ComponentType = typeof(DateCriteriaFilter),
                ComponentName = "DateFilter",
                ComponentLabel = "",
                Parameters = new Dictionary<string, object>
                {
                    [nameof(DateCriteriaFilter.Label)] = "",
                }
            },
        };
    }
}
