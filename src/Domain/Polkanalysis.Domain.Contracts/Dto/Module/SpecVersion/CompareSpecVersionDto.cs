using Substrate.NET.Metadata.Compare;

namespace Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion
{
    public class CompareSpecVersionDto
    {
        public CompareSpecVersionDto(MetadataDiffV9 metadata)
        {

        }

        public CompareSpecVersionDto(MetadataDiffV10 metadata)
        {

        }

        public CompareSpecVersionDto(MetadataDiffV11 metadata)
        {

        }

        public CompareSpecVersionDto(MetadataDiffV12 metadata)
        {

        }

        public CompareSpecVersionDto(MetadataDiffV13 metadata)
        {

        }

        public CompareSpecVersionDto(MetadataDiffV14 metadata)
        {
            ModulesAdded = metadata.AddedModules.Select(x => x.ModuleName).ToList();
            ModulesRemoved = metadata.RemovedModules.Select(x => x.ModuleName).ToList();

            ModulesChanged = metadata.ChangedModules.Select(x => {
                var dto = new ChangedModuleDto()
                {
                    ModuleName = x.ModuleName
                };

                if (x.Storage.Any())
                {
                    dto.Changes.AddRange(x.Storage.Select(y => new ChangedElement()
                    {
                        ElementType = "Storage",
                        ElementName = y.Item2.storage.Name,
                        Status = y.Item2.status
                    }).ToList());
                }

                if (x.Constants.Any())
                {
                    dto.Changes.AddRange(x.Constants.Select(y => new ChangedElement()
                    {
                        ElementType = "Constants",
                        ElementName = y.Item2.Name,
                        Status = y.Item1
                    }).ToList());
                }

                return dto;
            }).ToList();
        }

        public List<string> ModulesAdded { get; set; }
        public List<string> ModulesRemoved { get; set; }
        public List<ChangedModuleDto> ModulesChanged { get; set; }
        
        public class ChangedModuleDto
        {
            public string ModuleName { get; set; } = string.Empty;
            public List<ChangedElement> Changes { get; set; } = new List<ChangedElement>();
        }

        public class ChangedElement
        {
            public string ElementType { get; set; } = string.Empty;
            public string ElementName { get; set; } = string.Empty;
            public Substrate.NET.Metadata.Base.CompareStatus Status { get; set; }
        }
    }
}
