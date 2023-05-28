using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.User
{
    public class PublicDto
    {
        public string Name { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public KeyType KeyType { get; set; }
    }
}
