using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events
{
    public class EventsInformationModel : EventModel
    {
        [SetsRequiredMembers]
        public EventsInformationModel() : base("", 0, DateTime.Now, 0, "", "")
        {
            this.JsonParameters = "";
        }

        [SetsRequiredMembers]
        public EventsInformationModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, string json) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            if(!string.IsNullOrEmpty(json))
            {
                var jsonObject = JsonSerializer.Deserialize<object>(json);
                JsonParameters = JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions
                {
                    WriteIndented = false
                });
            }
        }

        public string JsonParameters { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent}";
        }
    }
}
