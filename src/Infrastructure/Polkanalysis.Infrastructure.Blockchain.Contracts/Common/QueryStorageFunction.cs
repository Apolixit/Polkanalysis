using Substrate.NetApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Common
{
    public class QueryStorageFunctionGeneric<TSourceKey, TStorageKey> : QueryStorageFunction
    {
        public QueryStorageFunctionGeneric(string moduleName, string methodName) : base(moduleName, methodName, typeof(TSourceKey), typeof(TStorageKey))
        {

        }
    }

    public class QueryStorageFunction
    {
        /// <summary>
        /// Pallet name
        /// </summary>
        public string ModuleName { get; init; }

        /// <summary>
        /// Method name to call
        /// </summary>
        public string MethodName { get; init; }

        /// <summary>
        /// Key type return by storage call
        /// </summary>
        public Type SourceKeyType { get; init; }

        /// <summary>
        /// Storage type return by storage call
        /// </summary>
        public Type StorageKeyType { get; init; }

        /// <summary>
        /// Storage call parameters
        /// </summary>
        public string StorageParam { get; init; }
        public int KeyParamSize { get; init; }

        public QueryStorageFunction(string moduleName, string methodName, Type sourceKeyType, Type storageKeyType)
        {
            ModuleName = moduleName;
            MethodName = methodName;
            SourceKeyType = sourceKeyType;
            StorageKeyType = storageKeyType;
            StorageParam = Utils.Bytes2HexString(RequestGenerator.GetStorageKeyBytesHash(ModuleName, MethodName));
        }

        public QueryStorageFunction(string moduleName, string methodName, Type sourceKeyType, Type storageKeyType, int keyParamSize) : this(moduleName, methodName, sourceKeyType, storageKeyType)
        {
            KeyParamSize = keyParamSize;
        }

        public QueryStorageFunction(string moduleName, string methodName, Type sourceKeyType, Type storageKeyType, int keyParamSize, string storageParam) : this(moduleName, methodName, sourceKeyType, storageKeyType, keyParamSize)
        {
            StorageParam = storageParam;
        }
    }
}
