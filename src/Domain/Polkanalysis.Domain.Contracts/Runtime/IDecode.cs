using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.SystemCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Runtime
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
        INode Decode(IType elem);

        /// <summary>
        /// Build a tree from an event hexadecimal representation
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        IEventNode DecodeEvent(string hex);

        /// <summary>
        /// Build a tree from an event
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        IEventNode DecodeEvent(EventRecord ev);

        /// <summary>
        /// Build a tree from an extrinsic hexadecimal representation
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        INode DecodeExtrinsic(string hex);

        /// <summary>
        /// Build a tree from an extrinsic
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        INode DecodeExtrinsic(Extrinsic extrinsic);

        /// <summary>
        /// Build a tree from logs strings (hexadecimal)
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        INode DecodeLog(IEnumerable<string> logs);

        /// <summary>
        /// Build a tree from log enum
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        INode DecodeLog(IEnumerable<EnumDigestItem> logs);
    }
}
