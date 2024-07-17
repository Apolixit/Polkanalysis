﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Errors
{
    public class SubstrateErrorModel : BlockchainModel
    {
        [Key]
        public uint Id { get; set; }

        public required uint BlockNumber { get; set; }

        /// <summary>
        /// Error date
        /// </summary>
        public required DateTime Date { get; set; }

        public required TypeErrorModel TypeError { get; set; }

        public uint? ElementId { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public required string Message { get; set; }
    }

    public enum TypeErrorModel
    {
        Blocks,
        Events,
        Extrinsics
    }
}
