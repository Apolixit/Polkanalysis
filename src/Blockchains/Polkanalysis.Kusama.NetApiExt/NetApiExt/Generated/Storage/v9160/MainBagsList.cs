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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9160
{
    public sealed class BagsListStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> ListNodesParams
        ///  A single node, within some bag.
        /// 
        ///  Nodes store links forward and back within their respective bags.
        /// </summary>
        public static string ListNodesParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("BagsList", "ListNodes", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ListNodesDefault
        /// Default value as hex string
        /// </summary>
        public static string ListNodesDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ListNodes
        ///  A single node, within some bag.
        /// 
        ///  Nodes store links forward and back within their respective bags.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.pallet_bags_list.list.Node> ListNodes(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = ListNodesParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.pallet_bags_list.list.Node>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CounterForListNodesParams
        /// Counter for the related counted storage map
        /// </summary>
        public static string CounterForListNodesParams()
        {
            return RequestGenerator.GetStorage("BagsList", "CounterForListNodes", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CounterForListNodesDefault
        /// Default value as hex string
        /// </summary>
        public static string CounterForListNodesDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> CounterForListNodes
        /// Counter for the related counted storage map
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> CounterForListNodes(CancellationToken token)
        {
            string parameters = CounterForListNodesParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ListBagsParams
        ///  A bag stored in storage.
        /// 
        ///  Stores a `Bag` struct, which stores head and tail pointers to itself.
        /// </summary>
        public static string ListBagsParams(Substrate.NetApi.Model.Types.Primitive.U64 key)
        {
            return RequestGenerator.GetStorage("BagsList", "ListBags", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ListBagsDefault
        /// Default value as hex string
        /// </summary>
        public static string ListBagsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ListBags
        ///  A bag stored in storage.
        /// 
        ///  Stores a `Bag` struct, which stores head and tail pointers to itself.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.pallet_bags_list.list.Bag> ListBags(Substrate.NetApi.Model.Types.Primitive.U64 key, CancellationToken token)
        {
            string parameters = ListBagsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.pallet_bags_list.list.Bag>(parameters, blockHash, token);
            return result;
        }

        public BagsListStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class BagsListConstants
    {
        /// <summary>
        /// >> BagThresholds
        ///  The list of thresholds separating the various bags.
        /// 
        ///  Ids are separated into unsorted bags according to their vote weight. This specifies the
        ///  thresholds separating the bags. An id's bag is the largest bag for which the id's weight
        ///  is less than or equal to its upper threshold.
        /// 
        ///  When ids are iterated, higher bags are iterated completely before lower bags. This means
        ///  that iteration is _semi-sorted_: ids of higher weight tend to come before ids of lower
        ///  weight, but peer ids within a particular bag are sorted in insertion order.
        /// 
        ///  # Expressing the constant
        /// 
        ///  This constant must be sorted in strictly increasing order. Duplicate items are not
        ///  permitted.
        /// 
        ///  There is an implied upper limit of `VoteWeight::MAX`; that value does not need to be
        ///  specified within the bag. For any two threshold lists, if one ends with
        ///  `VoteWeight::MAX`, the other one does not, and they are otherwise equal, the two lists
        ///  will behave identically.
        /// 
        ///  # Calculation
        /// 
        ///  It is recommended to generate the set of thresholds in a geometric series, such that
        ///  there exists some constant ratio such that `threshold[k + 1] == (threshold[k] *
        ///  constant_ratio).max(threshold[k] + 1)` for all `k`.
        /// 
        ///  The helpers in the `/utils/frame/generate-bags` module can simplify this calculation.
        /// 
        ///  # Examples
        /// 
        ///  - If `BagThresholds::get().is_empty()`, then all ids are put into the same bag, and
        ///    iteration is strictly in insertion order.
        ///  - If `BagThresholds::get().len() == 64`, and the thresholds are determined according to
        ///    the procedure given above, then the constant ratio is equal to 2.
        ///  - If `BagThresholds::get().len() == 200`, and the thresholds are determined according to
        ///    the procedure given above, then the constant ratio is approximately equal to 1.248.
        ///  - If the threshold list begins `[1, 2, 3, ...]`, then an id with weight 0 or 1 will fall
        ///    into bag 0, an id with weight 2 will fall into bag 1, etc.
        /// 
        ///  # Migration
        /// 
        ///  In the event that this list ever changes, a copy of the old bags list must be retained.
        ///  With that `List::migrate` can be called, which will perform the appropriate migration.
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U64> BagThresholds()
        {
            var result = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U64>();
            result.Create("0x210355A0FC0100000000DAA64602000000006E739B02000000007997FC0200000000D0DE6B03000000003358EB03000000000D5F7D04000000009AA6240500000000B146E4050000000067CABF0600000000D640BB07000000005350DB0800000000714C250A00000000364F9F0B000000000056500D000000009862400F000000001BA17811000000006593031400000000CD42ED16000000002079431A00000000E401161E000000001EF5762200000000F90C7B2700000000E0073A2D00000000E818CF33000000008C68593B000000002EA8FC43000000000ABBE14D00000000C3773759000000001986336600000000E85C13750000000018651D8600000000E846A29900000000BE67FEAF00000000849F9BC900000000AD2DF3E60000000028F78F0801000000D817112F01000000BED32C5B01000000C2F5B38D010000000AAC95C7010000002BF4E3090200000022ACD855020000001060DBAC020000002EF08710030000007C2EB682030000002B988205040000001754589B040000009DA5FC4605000000FF099C0B060000006C3ED9EC06000000C475DEEE07000000960F711609000000AA2D08690A000000F892E6EC0B0000008C4638A90D000000978634A60F0000006DAC44ED1100000078B93089140000001660528617000000E479CFF21A0000004000DDDE1E000000FFC30B5D23000000824FA082280000002793F7672E000000A638FA283500000048BFA0E53C00000047D28AC245000000C5A5ACE94F000000F68E158B5B0000009083D3DD6800000066B5F72078000000CF1BC19C89000000FC6FF2A39D0000001EEF5995B4000000C02092DDCE000000B2ED03F9EC000000078933760F010000D30E63F8360100001252973A64010000E1230D1398010000A0722F77D301000078012180170200006533EF6F65020000428586B7BE02000028E784FD24030000B13F0A269A030000D016AC5B2004000022C8B619BA04000079C7EC376A050000E092FBF7330600003D05E6141B070000F701ADD423080000D8108A1C53090000C8AB1B88AE0A0000B2EFF0833C0C0000E858F26B040E00000F7D37AE0E100000D5A7EEF264120000583F134A121500001753CB5F231800005C3664B8A61B0000A61A0AF5AC1F000033F27F22492400004B3A4C1391290000288805C79D2F000037D3A7E08B360000FFA1222E7C3E0000F0C4A14394470000E5AD6F2DFF510000076EBB3BEE5D0000ABF006EC996B00008C6C8EF4427B00003AD69A76338D0000BA57695DC0A100005DDA24F04AB90000B66F609E42D400007655960F27F30000258D6C7F8A1601005169EB71143F0100B9BE72CC846D01003C4B1762B7A20100CC2F3404A8DF0100F7276E2A77250200480B33486F7502001D5CF5E80AD102000F6410B0FB390300A904775D32B203002DE121FDE73B040030AFB76CA8D90400FB753E695E8E05003C44E45D615D06002CB93B35854A0700A8F8CB772C5A08007A48B90D5D9109003D3DC705D8F50A000D1E42D2348E0C001CB0BE7C00620E0024796364E17910001B8DED2FC0DF1200D3E942B5F69E1500E8CA99B485C41800D0C88C65525F1C00C2F577F96C8020000ABCE260613B250074BD4DD293A62A00EC4B61C8AADB300048B0376D08F83700C01384B1551D4000DC2BFDA12172490070B645ED972254006CFC51FA516160006C93086D46686E009CAAE886DB797E00C036837621E29000A0649B653AF8A50028A34CEEF61FBE00385AA297AECBD900483335165D7EF900D0CAE4520ECE1D010090A7AEA4664701E09D92A5060D770130778EDCC2A2AD01D00BB8D53B2AEC0140B18C096FCB3302805193026ED98502A0F6D663A3D8E30260BBCB8701864F03A045F8B63CDFCA0340816DE8372C5804405E20A9D009FA04808D72453D76B30580F35BC037DF8706804EECA838327B0700B198A10EEF9108800B2F9B2A3DD10980A2489405043F0B00724C5A1307E20C00D8F897C605C20E009890BE3DE0E71000434F6546C15D1300D61CFF7D4E2F16009B32B873DF691900008775D0BC1C1D00DA56EBAF68592100DACB4281F13326003C889EF750C32B000AB7E6CBD8213200346DAD52AF6D39005047E9335EC9410024EE18E8755C4B0038D4B40049545600087D76B2C2E46200981C03995C497100881E553F38C68100B0CB90A161A99400284FE59E404CAA00C0E54A304015C30060CD7437B379DFFFFFFFFFFFFFFFFF");
            return result;
        }
    }

    public enum BagsListErrors
    {
        /// <summary>
        /// >> NotInSameBag
        /// Attempted to place node in front of a node in another bag.
        /// </summary>
        NotInSameBag,
        /// <summary>
        /// >> IdNotFound
        /// Id not found in list.
        /// </summary>
        IdNotFound,
        /// <summary>
        /// >> NotHeavier
        /// An Id does not have a greater vote weight than another Id.
        /// </summary>
        NotHeavier
    }
}