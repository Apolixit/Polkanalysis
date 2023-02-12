using Ajuna.NetApi.Model.Rpc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Rpc
{
    /// <summary>
    /// Extract from <see cref="Ajuna.NetApi.Modules.State"/>
    /// </summary>
    public interface IState
    {
        public Task<JArray> GetKeysPagedAsync(byte[] keyPrefix, uint pageCount, byte[] startKey, CancellationToken token);
        public Task<JArray> GetKeysPagedAtAsync(byte[] keyPrefix, byte[] blockHash, uint pageCount, byte[] startKey, CancellationToken token);
        public Task<string> GetMetaDataAsync(CancellationToken token);
        public Task<JArray> GetPairsAsync(byte[] keyPrefix, CancellationToken token);
        public Task<object> GetQueryStorageAsync(byte[] parameters, CancellationToken token);
        public Task<StorageChangeSet> GetQueryStorageAtAsync(List<byte[]> keysList, byte[] blockHash, CancellationToken token);
        public Task<RuntimeVersion> GetRuntimeVersionAsync(CancellationToken token);
        public Task<object> GetStorageAsync(byte[] parameters, byte[] blockHash, CancellationToken token);
        public Task<object> GetStorageAtAsync(byte[] parameters, CancellationToken token);
        public Task<object> GetStorageHashAsync(byte[] key, byte[] blockHash, CancellationToken token);
        public Task<object> GetStorageHashAtAsync(byte[] parameters, CancellationToken token);
        public Task<object> GetStorageSizeAsync(byte[] parameters, CancellationToken token);
        public Task<object> GetStorageSizeAtAsync(byte[] parameters, CancellationToken token);
        public Task<object> GetTraceBlockAsync(byte[] parameters, CancellationToken token);
        public Task<string> SubscribeRuntimeVersionAsync(CancellationToken token);
        public Task<string> SubscribeStorageAsync(JArray keys, Action<string, StorageChangeSet> callback, CancellationToken token);
        public Task<bool> UnsubscribeRuntimeVersionAsync(string subscriptionId, CancellationToken token);
        public Task<bool> UnsubscribeStorageAsync(string subscriptionId, CancellationToken token);
    }
}
