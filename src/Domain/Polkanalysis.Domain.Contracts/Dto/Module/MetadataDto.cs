using Substrate.NetApi.Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Module
{
    public class MetadataDto
    {
        public string Origin { get; set; } = string.Empty;
        public string Magic { get; set; } = string.Empty;

        /// <summary>
        /// The metadata major version (v9 to v15)
        /// </summary>
        public Substrate.NET.Metadata.Base.MetadataVersion MajorVersion { get; set; }

        /// <summary>
        /// The metadata minor version
        /// </summary>
        public uint SpecVersion { get; set; }

        /// <summary>
        /// Number of pallets associated to the metadata
        /// </summary>
        public int NbPallets { get; set; }

        /// <summary>
        /// The duration this SpecVersion was active
        /// </summary>
        public TimeSpan Duration { get; set; }

        public string Hex { get; set; } = string.Empty;
    }
}
