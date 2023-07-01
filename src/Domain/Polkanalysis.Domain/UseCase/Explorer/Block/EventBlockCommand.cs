using MediatR;
using Polkanalysis.Domain.Contracts.Dto.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Explorer.Block
{
    public class BlockNotification : INotification
    {
        public BlockLightDto blockLight { get; set; }
    }
}
