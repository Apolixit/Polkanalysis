using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.SubstrateDecode.Abstract
{
    /// <summary>
    /// Decode and build a tree from Substrate interaction
    /// </summary>
    public interface ISubstrateDecoding
    {
        //INode DecodeBlock(Block block);
        //INode DecodeBlock(BlockData blockData);

        INode DecodeExtrinsic(Extrinsic extrinsic);

        INode DecodeEvent(string hex);
        INode DecodeEvent(IType ev);

        INode DecodeLog(IList<string> logs);
    }
}
