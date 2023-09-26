//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Meta;
using System.Threading;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Extrinsics;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9430
{
    public sealed class FellowshipReferendaStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> ReferendumCountParams
        ///  The next free referendum index, aka the number of referenda started so far.
        /// </summary>
        public static string ReferendumCountParams()
        {
            return RequestGenerator.GetStorage("FellowshipReferenda", "ReferendumCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> ReferendumCountDefault
        /// Default value as hex string
        /// </summary>
        public static string ReferendumCountDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> ReferendumCount
        ///  The next free referendum index, aka the number of referenda started so far.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> ReferendumCount(CancellationToken token)
        {
            string parameters = ReferendumCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ReferendumInfoForParams
        ///  Information concerning any given referendum.
        /// </summary>
        public static string ReferendumInfoForParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("FellowshipReferenda", "ReferendumInfoFor", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ReferendumInfoForDefault
        /// Default value as hex string
        /// </summary>
        public static string ReferendumInfoForDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ReferendumInfoFor
        ///  Information concerning any given referendum.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_referenda.types.EnumReferendumInfo> ReferendumInfoFor(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ReferendumInfoForParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_referenda.types.EnumReferendumInfo>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> TrackQueueParams
        ///  The sorted list of referenda ready to be decided but not yet being decided, ordered by
        ///  conviction-weighted approvals.
        /// 
        ///  This should be empty if `DecidingCount` is less than `TrackInfo::max_deciding`.
        /// </summary>
        public static string TrackQueueParams(Substrate.NetApi.Model.Types.Primitive.U16 key)
        {
            return RequestGenerator.GetStorage("FellowshipReferenda", "TrackQueue", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> TrackQueueDefault
        /// Default value as hex string
        /// </summary>
        public static string TrackQueueDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> TrackQueue
        ///  The sorted list of referenda ready to be decided but not yet being decided, ordered by
        ///  conviction-weighted approvals.
        /// 
        ///  This should be empty if `DecidingCount` is less than `TrackInfo::max_deciding`.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>> TrackQueue(Substrate.NetApi.Model.Types.Primitive.U16 key, CancellationToken token)
        {
            string parameters = TrackQueueParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> DecidingCountParams
        ///  The number of referenda being decided currently.
        /// </summary>
        public static string DecidingCountParams(Substrate.NetApi.Model.Types.Primitive.U16 key)
        {
            return RequestGenerator.GetStorage("FellowshipReferenda", "DecidingCount", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> DecidingCountDefault
        /// Default value as hex string
        /// </summary>
        public static string DecidingCountDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> DecidingCount
        ///  The number of referenda being decided currently.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> DecidingCount(Substrate.NetApi.Model.Types.Primitive.U16 key, CancellationToken token)
        {
            string parameters = DecidingCountParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> MetadataOfParams
        ///  The metadata is a general information concerning the referendum.
        ///  The `PreimageHash` refers to the preimage of the `Preimages` provider which can be a JSON
        ///  dump or IPFS hash of a JSON file.
        /// 
        ///  Consider a garbage collection for a metadata of finished referendums to `unrequest` (remove)
        ///  large preimages.
        /// </summary>
        public static string MetadataOfParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("FellowshipReferenda", "MetadataOf", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> MetadataOfDefault
        /// Default value as hex string
        /// </summary>
        public static string MetadataOfDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> MetadataOf
        ///  The metadata is a general information concerning the referendum.
        ///  The `PreimageHash` refers to the preimage of the `Preimages` provider which can be a JSON
        ///  dump or IPFS hash of a JSON file.
        /// 
        ///  Consider a garbage collection for a metadata of finished referendums to `unrequest` (remove)
        ///  large preimages.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.primitive_types.H256> MetadataOf(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = MetadataOfParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.primitive_types.H256>(parameters, blockHash, token);
            return result;
        }

        public FellowshipReferendaStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class FellowshipReferendaConstants
    {
        /// <summary>
        /// >> SubmissionDeposit
        ///  The minimum amount to be used as a deposit for a public referendum proposal.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 SubmissionDeposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00000000000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> MaxQueued
        ///  Maximum size of the referendum queue for a single track.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxQueued()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }

        /// <summary>
        /// >> UndecidingTimeout
        ///  The number of blocks after submission that a referendum must begin being decided by.
        ///  Once this passes, then anyone may cancel the referendum.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 UndecidingTimeout()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xC0890100");
            return result;
        }

        /// <summary>
        /// >> AlarmInterval
        ///  Quantization level for the referendum wakeup scheduler. A higher number will result in
        ///  fewer storage reads/writes needed for smaller voters, but also result in delays to the
        ///  automatic referendum status changes. Explicit servicing instructions are unaffected.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 AlarmInterval()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x01000000");
            return result;
        }

        /// <summary>
        /// >> Tracks
        ///  Information concerning the different referendum tracks.
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_referenda.types.TrackInfo>> Tracks()
        {
            var result = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_referenda.types.TrackInfo>>();
            result.Create("0x2800002863616E646964617465730A0000003435261A0803000000000000000000002C010000C08901002C0100000A0000000000CA9A3B0065CD1D00CA9A3B0000CA9A3B000000000065CD1D01001C6D656D626572730A0000005205379C4D00000000000000000000002C010000C08901002C0100000A0000000000CA9A3B0065CD1D00CA9A3B0000CA9A3B000000000065CD1D02002C70726F66696369656E74730A0000005205379C4D00000000000000000000002C010000C08901002C0100000A0000000000CA9A3B0065CD1D00CA9A3B0000CA9A3B000000000065CD1D03001C66656C6C6F77730A0000005205379C4D00000000000000000000002C010000C08901002C0100000A0000000000CA9A3B0065CD1D00CA9A3B0000CA9A3B000000000065CD1D04003873656E696F722066656C6C6F77730A0000005205379C4D00000000000000000000002C010000C08901002C0100000A0000000000CA9A3B0065CD1D00CA9A3B0000CA9A3B000000000065CD1D05001C657870657274730A000000554DD2C20700000000000000000000002C010000C08901002C0100000A0000000000CA9A3B0065CD1D00CA9A3B0000CA9A3B000000000065CD1D06003873656E696F7220657870657274730A000000554DD2C20700000000000000000000002C010000C08901002C0100000A0000000000CA9A3B0065CD1D00CA9A3B0000CA9A3B000000000065CD1D07001C6D6173746572730A000000554DD2C20700000000000000000000002C010000C08901002C0100000A0000000000CA9A3B0065CD1D00CA9A3B0000CA9A3B000000000065CD1D08003873656E696F72206D6173746572730A000000554DD2C20700000000000000000000002C010000C08901002C0100000A0000000000CA9A3B0065CD1D00CA9A3B0000CA9A3B000000000065CD1D0900346772616E64206D6173746572730A000000554DD2C20700000000000000000000002C010000C08901002C0100000A0000000000CA9A3B0065CD1D00CA9A3B0000CA9A3B000000000065CD1D");
            return result;
        }
    }

    public enum FellowshipReferendaErrors
    {
        /// <summary>
        /// >> NotOngoing
        /// Referendum is not ongoing.
        /// </summary>
        NotOngoing,
        /// <summary>
        /// >> HasDeposit
        /// Referendum's decision deposit is already paid.
        /// </summary>
        HasDeposit,
        /// <summary>
        /// >> BadTrack
        /// The track identifier given was invalid.
        /// </summary>
        BadTrack,
        /// <summary>
        /// >> Full
        /// There are already a full complement of referenda in progress for this track.
        /// </summary>
        Full,
        /// <summary>
        /// >> QueueEmpty
        /// The queue of the track is empty.
        /// </summary>
        QueueEmpty,
        /// <summary>
        /// >> BadReferendum
        /// The referendum index provided is invalid in this context.
        /// </summary>
        BadReferendum,
        /// <summary>
        /// >> NothingToDo
        /// There was nothing to do in the advancement.
        /// </summary>
        NothingToDo,
        /// <summary>
        /// >> NoTrack
        /// No track exists for the proposal origin.
        /// </summary>
        NoTrack,
        /// <summary>
        /// >> Unfinished
        /// Any deposit cannot be refunded until after the decision is over.
        /// </summary>
        Unfinished,
        /// <summary>
        /// >> NoPermission
        /// The deposit refunder is not the depositor.
        /// </summary>
        NoPermission,
        /// <summary>
        /// >> NoDeposit
        /// The deposit cannot be refunded since none was made.
        /// </summary>
        NoDeposit,
        /// <summary>
        /// >> BadStatus
        /// The referendum status is invalid for this operation.
        /// </summary>
        BadStatus,
        /// <summary>
        /// >> PreimageNotExist
        /// The preimage does not exist.
        /// </summary>
        PreimageNotExist
    }
}