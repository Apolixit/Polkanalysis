using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Meta;

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
        INode Decode(IType elem, Hash? blockHash = null);

        /// <summary>
        /// Build a tree from an event hexadecimal representation
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        IEventNode DecodeEvent(string hex, Hash? blockHash = null);

        /// <summary>
        /// Build a tree from an event
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        IEventNode DecodeEvent(EventRecord ev, Hash? blockHash = null);
        IEventNode DecodeEvent(EventRecord ev, MetaData metadata);

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
        Task<INode> DecodeExtrinsicAsync(Extrinsic extrinsic, Hash blockHash, CancellationToken cancellationToken);
        INode DecodeExtrinsic(Extrinsic extrinsic, MetaData metadata);


        /// <summary>
        /// Build a tree from logs strings (hexadecimal)
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        INode DecodeLog(IEnumerable<string> logs, Hash? blockHash = null);

        /// <summary>
        /// Build a tree from log enum
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        INode DecodeLog(IEnumerable<EnumDigestItem> logs, Hash? blockHash = null);
        //Task<(string callModule, string callEvent)> GetCallFromExtrinsicAsync(Extrinsic extrinsic, Hash blockHash, CancellationToken token);
    }
}
