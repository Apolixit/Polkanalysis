﻿using Substats.Domain.Contracts.Dto.Parachain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary
{
    public interface IParachainRepository
    {
        public Task<ParachainDto> GetParachainDetailAsync(uint parachainId, CancellationToken cancellationToken);
    }
}
