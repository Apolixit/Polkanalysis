﻿using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Meta;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime
{
    /// <summary>
    /// Decode and build a tree from Substrate interaction
    /// </summary>
    public interface ISubstrateDecoding
    {
        /// <summary>
        /// Build a "friendly" tree from Ajuna IType
        /// </summary>
        /// <param name="ev"></param>
        /// <returns></returns>
        Task<INode> DecodeAsync(IType elem, MetaData metadata, CancellationToken cancellationToken);

        /// <summary>
        /// Build a tree from an event hexadecimal representation
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        Task<IEventNode> DecodeEventAsync(string hex, CancellationToken cancellationToken, Hash? blockHash = null);

        /// <summary>
        /// Build a tree from an event
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        Task<IEventNode> DecodeEventAsync(EventRecord ev, CancellationToken cancellationToken, Hash? blockHash = null);
        Task<IEventNode> DecodeEventAsync(EventRecord ev, MetaData metadata, CancellationToken cancellationToken);

        /// <summary>
        /// Build a tree from an extrinsic hexadecimal representation
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        Task<INode> DecodeExtrinsicAsync(string hex, Hash blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Build a tree from an extrinsic
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        Task<INode> DecodeExtrinsicAsync(IExtrinsic extrinsic, Hash blockHash, CancellationToken cancellationToken);
        Task<INode> DecodeExtrinsicAsync(IExtrinsic extrinsic, MetaData metadata, CancellationToken cancellationToken);


        /// <summary>
        /// Build a tree from logs strings (hexadecimal)
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        Task<INode> DecodeLogAsync(IEnumerable<string> logs, CancellationToken cancellationToken, Hash? blockHash = null);

        /// <summary>
        /// Build a tree from log enum
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        Task<INode> DecodeLogAsync(IEnumerable<EnumDigestItem> logs, CancellationToken cancellationToken, Hash? blockHash = null);
        //Task<(string callModule, string callEvent)> GetCallFromExtrinsicAsync(Extrinsic extrinsic, Hash blockHash, CancellationToken token);
    }
}
