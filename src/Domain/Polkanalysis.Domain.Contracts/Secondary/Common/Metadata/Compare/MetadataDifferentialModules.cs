using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare
{
    public class MetadataDifferentialModules<TStorageEntry, TCall, TEvent, TConstant, TError>
        where TStorageEntry : BaseType, IMetadataName, new()
        where TCall : BaseType, IMetadataName, new()
        where TEvent : BaseType, IMetadataName, new()
        where TConstant : BaseType, IMetadataName, new()
        where TError : BaseType, IMetadataName, new()
    {
        public string ModuleName { get; set; } = string.Empty;

        public CompareStatus CompareStatus { get; set; } = CompareStatus.AlreadyPresent;

        public IEnumerable<(string prefix, (CompareStatus status, TStorageEntry storage))> Storage { get; set; }
            = Enumerable.Empty<(string, (CompareStatus, TStorageEntry))>();
        public IEnumerable<(CompareStatus, TCall)> Calls { get; set; }
            = Enumerable.Empty<(CompareStatus, TCall)>();
        public IEnumerable<(CompareStatus, TEvent)> Events { get; set; }
            = Enumerable.Empty<(CompareStatus, TEvent)>();
        public IEnumerable<(CompareStatus, TConstant)> Constants { get; set; }
            = Enumerable.Empty<(CompareStatus, TConstant)>();
        public IEnumerable<(CompareStatus, TError)> Errors { get; set; }
            = Enumerable.Empty<(CompareStatus, TError)>();

        #region Has ...
        public bool HasStorageAdded(string name)
            => hasStorage(name, CompareStatus.Added);
        public bool HasStorageRemoved(string name)
            => hasStorage(name, CompareStatus.Removed);
        private bool hasStorage(string name, CompareStatus status)
        {
            return Storage.Any(x => x.Item2.status == status && x.Item2.storage.Name.Value == name);
        }

        public bool HasConstantAdded(string name)
            => hasConstant(name, CompareStatus.Added);
        public bool HasConstantRemoved(string name)
            => hasConstant(name, CompareStatus.Removed);
        private bool hasConstant(string name, CompareStatus status)
        {
            return Constants.Any(x => x.Item1 == status && x.Item2.Name.Value == name);
        }

        public bool HasCallAdded(string name)
            => hasCall(name, CompareStatus.Added);
        public bool HasCallRemoved(string name)
            => hasCall(name, CompareStatus.Removed);
        private bool hasCall(string name, CompareStatus status)
        {
            return Calls.Any(x => x.Item1 == status && x.Item2.Name.Value == name);
        }

        public bool HasEventAdded(string name)
            => hasEvent(name, CompareStatus.Added);
        public bool HasEventRemoved(string name)
            => hasEvent(name, CompareStatus.Removed);
        private bool hasEvent(string name, CompareStatus status)
        {
            return Events.Any(x => x.Item1 == status && x.Item2.Name.Value == name);
        }

        public bool HasErrorAdded(string name)
            => hasError(name, CompareStatus.Added);
        public bool HasErrorRemoved(string name)
            => hasError(name, CompareStatus.Removed);
        private bool hasError(string name, CompareStatus status)
        {
            return Errors.Any(x => x.Item1 == status && x.Item2.Name.Value == name);
        }
        #endregion
    }
}
