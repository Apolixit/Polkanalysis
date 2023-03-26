using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.Common
{
    public class DateDto
    {
        /// <summary>
        /// Exact date when happen
        /// </summary>
        public required DateTime Date { get; set; }

        /// <summary>
        /// Time from now
        /// </summary>
        public required TimeSpan When { get; set; }

        public string DisplayTime { get; set; } = string.Empty;
    }
}
