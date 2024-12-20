﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Version
{
    public class SpecVersionModel : BlockchainModel
    {
        public uint SpecVersion { get; set; }
        public uint BlockStart { get; set; }
        public DateTime BlockStartDateTime { get; set; }
        public uint? BlockEnd { get; set; }
        public DateTime? BlockEndDateTime { get; set; }
        public uint MetadataVersion { get; set; }
        public string Metadata { get; set; } = string.Empty;
    }
}
