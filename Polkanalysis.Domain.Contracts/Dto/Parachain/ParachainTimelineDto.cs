using Polkanalysis.Domain.Contracts.Dto.Common;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Parachain
{
    public class ParachainTimelineDto
    {
        public required ExtrinsicDto Extrinsic { get; set; }
        public required DateDto Date { get; set; }
    }
}
