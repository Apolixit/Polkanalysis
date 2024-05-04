using Substrate.NET.Metadata.Compare;

namespace Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion
{
    public class CompareSpecVersionDto
    {
        public CompareSpecVersionDto()
        {
            ModulesAdded = new List<string>();
            ModulesRemoved = new List<string>();
            ModulesChanged = new List<ChangedModuleDto>();
        }
        public CompareSpecVersionDto(MetadataDiffV9 metadata)
        {
            ModulesAdded = metadata.AddedModules.Select(x => x.ModuleName).ToList();
            ModulesRemoved = metadata.RemovedModules.Select(x => x.ModuleName).ToList();
        }

        public CompareSpecVersionDto(MetadataDiffV10 metadata)
        {
            ModulesAdded = metadata.AddedModules.Select(x => x.ModuleName).ToList();
            ModulesRemoved = metadata.RemovedModules.Select(x => x.ModuleName).ToList();
        }

        public CompareSpecVersionDto(MetadataDiffV11 metadata)
        {
            ModulesAdded = metadata.AddedModules.Select(x => x.ModuleName).ToList();
            ModulesRemoved = metadata.RemovedModules.Select(x => x.ModuleName).ToList();
        }

        public CompareSpecVersionDto(MetadataDiffV12 metadata)
        {
            ModulesAdded = metadata.AddedModules.Select(x => x.ModuleName).ToList();
            ModulesRemoved = metadata.RemovedModules.Select(x => x.ModuleName).ToList();
        }

        public CompareSpecVersionDto(MetadataDiffV13 metadata)
        {
            ModulesAdded = metadata.AddedModules.Select(x => x.ModuleName).ToList();
            ModulesRemoved = metadata.RemovedModules.Select(x => x.ModuleName).ToList();
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

        public List<string> ModulesAdded { get; set; } = new List<string>();
        public List<string> ModulesRemoved { get; set; } = new List<string>();
        public List<ChangedModuleDto> ModulesChanged { get; set; } = new List<ChangedModuleDto>();
        
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
