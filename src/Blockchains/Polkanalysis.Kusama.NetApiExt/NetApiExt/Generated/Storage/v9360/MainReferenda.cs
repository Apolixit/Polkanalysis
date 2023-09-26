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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9360
{
    public sealed class ReferendaStorage
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
            return RequestGenerator.GetStorage("Referenda", "ReferendumCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
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
            return RequestGenerator.GetStorage("Referenda", "ReferendumInfoFor", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
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
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_referenda.types.EnumReferendumInfo> ReferendumInfoFor(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = ReferendumInfoForParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_referenda.types.EnumReferendumInfo>(parameters, blockHash, token);
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
            return RequestGenerator.GetStorage("Referenda", "TrackQueue", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
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
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>> TrackQueue(Substrate.NetApi.Model.Types.Primitive.U16 key, CancellationToken token)
        {
            string parameters = TrackQueueParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> DecidingCountParams
        ///  The number of referenda being decided currently.
        /// </summary>
        public static string DecidingCountParams(Substrate.NetApi.Model.Types.Primitive.U16 key)
        {
            return RequestGenerator.GetStorage("Referenda", "DecidingCount", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
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

        public ReferendaStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class ReferendaConstants
    {
        /// <summary>
        /// >> SubmissionDeposit
        ///  The minimum amount to be used as a deposit for a public referendum proposal.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 SubmissionDeposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x554DD2C2070000000000000000000000");
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
            result.Create("0x80130300");
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
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_referenda.types.TrackInfo>> Tracks()
        {
            var result = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_referenda.types.TrackInfo>>();
            result.Create("0x3C000010726F6F740100000020D33F25A6D70B000000000000000000B00400008013030040380000403800000290D73E0D000000005743DE13000000005443DE13000000000000CA9A3B000000000065CD1D01004877686974656C69737465645F63616C6C65726400000050C8EC362A2F010000000000000000002C01000080130300640000006400000002EC972510000000007B573C170000000042392F1200000000020E00840000000000D6E61F010000000039627902000000000A00347374616B696E675F61646D696E0A0000002864761B959700000000000000000000B004000080130300080700006400000000C94330240065CD1D00CA9A3B025D6F780000000000E82EED00000000008C6889FFFFFFFFFF0B00247472656173757265720A00000008147E05511E00000000000000000000B00400008013030008070000403800000290D73E0D000000005743DE13000000005443DE13000000000000CA9A3B000000000065CD1D0C002C6C656173655F61646D696E0A0000002864761B959700000000000000000000B004000080130300080700006400000000C94330240065CD1D00CA9A3B025D6F780000000000E82EED00000000008C6889FFFFFFFFFF0D004066656C6C6F77736869705F61646D696E0A0000002864761B959700000000000000000000B004000080130300080700006400000000C94330240065CD1D00CA9A3B025D6F780000000000E82EED00000000008C6889FFFFFFFFFF0E003467656E6572616C5F61646D696E0A0000002864761B959700000000000000000000B00400008013030008070000640000000290D73E0D000000005743DE13000000005443DE13000000000259A2F40200000000A3296B05000000002E6B4AFDFFFFFFFF0F003461756374696F6E5F61646D696E0A0000002864761B959700000000000000000000B00400008013030008070000640000000290D73E0D000000005743DE13000000005443DE13000000000259A2F40200000000A3296B05000000002E6B4AFDFFFFFFFF1400507265666572656E64756D5F63616E63656C6C6572E803000050C8EC362A2F01000000000000000000B0040000C0890100080700006400000000C94330240065CD1D00CA9A3B025D6F780000000000E82EED00000000008C6889FFFFFFFFFF1500447265666572656E64756D5F6B696C6C6572E803000090E99F12D3EB05000000000000000000B004000080130300080700006400000000C94330240065CD1D00CA9A3B025D6F780000000000E82EED00000000008C6889FFFFFFFFFF1E0030736D616C6C5F746970706572C8000000554DD2C20700000000000000000000000A000000C0890100640000000A00000000499149150065CD1D00CA9A3B02F9BA1800000000002A4D3100000000006B59E7FFFFFFFFFF1F00286269675F746970706572640000005205379C4D000000000000000000000064000000C0890100580200006400000000499149150065CD1D00CA9A3B02694F3F000000000035967D0000000000E534C1FFFFFFFFFF200034736D616C6C5F7370656E646572320000003435261A0803000000000000000000006009000080130300201C00004038000000C94330240065CD1D00CA9A3B025D6F780000000000E82EED00000000008C6889FFFFFFFFFF2100386D656469756D5F7370656E64657232000000686A4C3410060000000000000000000060090000801303004038000040380000005B01F6300065CD1D00CA9A3B021161DB0000000000BFD1AA010000000020972AFFFFFFFFFF22002C6269675F7370656E64657232000000D0D49868200C00000000000000000000600900008013030080700000403800000000CA9A3B0065CD1D00CA9A3B02413CB00100000000755D34030000000045D165FEFFFFFFFF");
            return result;
        }
    }

    public enum ReferendaErrors
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
        BadStatus
    }
}