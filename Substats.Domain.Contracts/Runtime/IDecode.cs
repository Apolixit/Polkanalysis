using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Secondary.Pallet.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Runtime
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
        INode DecodeEvent(string hex);

        /// <summary>
        /// Build a tree from an event
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        INode DecodeEvent(EventRecord ev);

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
