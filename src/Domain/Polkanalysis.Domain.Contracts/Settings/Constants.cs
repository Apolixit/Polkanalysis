using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Settings
{
    /// <summary>
    /// Constants elements shared between the project
    /// </summary>
    public static class Constants
    {
        public static ConstantsPagination Pagination = new ConstantsPagination();

        public static ConstantsCache Cache = new ConstantsCache();
    }

    public class ConstantsCache
    {
        /// <summary>
        /// 1 minute
        /// </summary>
        public int VeryFastCache { get; internal set; } = 1;

        /// <summary>
        /// 10 minutes
        /// </summary>
        public int FastCache { get; internal set; } = 10;

        /// <summary>
        /// One hour
        /// </summary>
        public int MediumCache { get; internal set; } = 60;

        /// <summary>
        /// One day
        /// </summary>
        public int LongCache { get; internal set; } = 60 * 24;
    }

    public class ConstantsPagination
    {
        public const int DefaultPageSize = 10;
        public const int DefaultPageNumber = 1;
    }
}
