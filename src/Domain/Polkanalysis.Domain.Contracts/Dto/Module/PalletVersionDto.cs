using MediatR.NotificationPublishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Module
{
    public class PalletVersionDto
    {
        public string PalletName { get; set; }
        public int PalletVersion { get; set; }
    }
}
