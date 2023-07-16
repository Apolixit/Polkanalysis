using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Substrate.NetApi.Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata
{
    /// <summary>
    /// Based on <see cref="Substrate.NetApi.Model.Meta.Entry"/>
    /// </summary>
    public abstract class StorageEntryMetadata
    {
        public required string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Storage.Modifier Modifier { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Storage.Type StorageType { get; set; }

        public (uint, TypeMap) TypeMap { get; set; }

        public required byte[] Default { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public required string[] Docs { get; set; }
    }
}
