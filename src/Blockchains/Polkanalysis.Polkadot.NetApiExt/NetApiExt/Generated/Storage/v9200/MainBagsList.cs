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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9200
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
        public static string ListNodesParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32 key)
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
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_bags_list.list.Node> ListNodes(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = ListNodesParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_bags_list.list.Node>(parameters, blockHash, token);
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
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_bags_list.list.Bag> ListBags(Substrate.NetApi.Model.Types.Primitive.U64 key, CancellationToken token)
        {
            string parameters = ListBagsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_bags_list.list.Bag>(parameters, blockHash, token);
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
        ///  Ids are separated into unsorted bags according to their score. This specifies the
        ///  thresholds separating the bags. An id's bag is the largest bag for which the id's score
        ///  is less than or equal to its upper threshold.
        /// 
        ///  When ids are iterated, higher bags are iterated completely before lower bags. This means
        ///  that iteration is _semi-sorted_: ids of higher score tend to come before ids of lower
        ///  score, but peer ids within a particular bag are sorted in insertion order.
        /// 
        ///  # Expressing the constant
        /// 
        ///  This constant must be sorted in strictly increasing order. Duplicate items are not
        ///  permitted.
        /// 
        ///  There is an implied upper limit of `Score::MAX`; that value does not need to be
        ///  specified within the bag. For any two threshold lists, if one ends with
        ///  `Score::MAX`, the other one does not, and they are otherwise equal, the two
        ///  lists will behave identically.
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
        ///  - If the threshold list begins `[1, 2, 3, ...]`, then an id with score 0 or 1 will fall
        ///    into bag 0, an id with score 2 will fall into bag 1, etc.
        /// 
        ///  # Migration
        /// 
        ///  In the event that this list ever changes, a copy of the old bags list must be retained.
        ///  With that `List::migrate` can be called, which will perform the appropriate migration.
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U64> BagThresholds()
        {
            var result = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U64>();
            result.Create("0x210300E40B5402000000F39E809702000000A8B197E20200000094492E3603000000279C3A930300000003BCCEFA0300000042C01B6E040000001B4775EE04000000385E557D0500000046DC601C0600000089386CCD06000000B6EE809207000000FE7EE36D08000000E81B1A6209000000B019F4710A000000103592A00B000000CFC96FF10C00000041146D680E000000E79BDA0910000000CEE885DA1100000028A9C7DF13000000BB70931F160000008E4089A018000000810A096A1B000000366A48841E0000005BD36AF821000000807C9CD025000000C95530182A000000BD63C1DB2E00000071E0572934000000689092103A000000EDC4D4A240000000699379F3470000008FD80C18500000004BAF8A28590000006A16A63F630000000995177B6E00000078C5F4FB7A00000062C811E78800000051BF6D6598000000048EABA4A9000000544698D7BC00000091CAC036D2000000175F1801EA000000BD15B27C0401000043358FF721010000B8FC84C84201000099673C506701000007E44EFA8F010000B341833EBD010000027F2EA2EF0100009883BCB927020000164D652A66020000B49513ACAB0200002D8E820BF9020000A1E6982C4F030000A616080DAF030000CC9D37C719040000A0D584959004000042E7E0D514050000028CD70DA80500000F750AEF4B060000EA8D2E5C02070000C3CB996ECD070000B1E5717CAF080000AA2B8E1FAB090000B5C1203DC30A000026D03D0EFB0B000070C75929560D0000EBADDA8CD80E0000F797DBAA86100000CFF04476651200001F2660717A14000009A611BECB1600001DFBE82F60190000943A3C603F1C00008AFE89C4711F0000CED963C70023000003A92AE4F6260000FE72EEC55F2B000036C9CC6948300000DAE33245BF350000062A7470D43B00007C9732D69942000084A32468234A0000571AD45987520000E7F10262DE5B00000DB8760344660000AE0401DED67100007D9EB308B97E00001E044A76108D00003A1DF064079D0000E04FAFDACCAE00005679F02F95C2000095C3AAA99AD80000967C05251EF10000177A66D6670C010028CB1F1EC82A0100FA282F75984C0100D57DC8743C7201007DC4B3FB229C0100365CDE74C7CA01009EB8E142B3FE01000C31AE547F3802005FE101E8D57802006373DA7E74C0020051D1A60D2E100300C7E9A468ED68030061C091F7B7CB0300BF27A1B7B03904007B1499941BB404008523ED22613C050069A5D4C512D40500EC8C934DEF7C0600F5AA901BE83807008CBE5DDB260A080002978CE113F30800FAE314435DF60900DDF12DBAFE160B002EBADC6F4A580C000C5518C4F2BD0D00F0BB5431154C0F00498E866B46071100B2C153DE9FF41200278A2FB2CE191500B2399F84247D1700E199E704AA251A00BA13F5AB331B1D00264785CC7866200088BF803F2D1124001C9823F81D262800CCC422D450B12C00F088820528C03100367C6D7E896137006E9329D30AA63D008CBC6C1322A044000070F32A5C644C00B43B84699909550080B4ABE450A95E00A0CDA979DB5F69004CC27F4CC74C7500D0AC0EBA34938200483E0CCF3D5A910068C68E7469CDA100281E6FA52B1DB40098A92326747FC800F09A74634D30DF0080CDFC4B8D72F8009014602D9A901401F0B413D945DD330120973596C1B4560150DCFBAEAD7D7D01E01198B947AAA80130C7EE16BBB9D801206E488697390E02A0FA4B1D72C74902C0117170B5128C02808A1643A6DED502C0F823B1A204280380AF5970A2768303C06F2D87FF41E90340937FAC8F925A040091097117B6D804400FDF5B212065050049C149446E0106008EBCA6E56CAF0600595686851C71078068AA34A4B7480880A1E29E52B9380900BDABE880E4430A002A72B4204C6D0B80F1C013335CB80C00A03CCBDCE3280E80B8629A9E20C30F00DE5693D2CA8B11005D7F4C93238813001A87DF3504BE1500A7CE4B84EF3318000110FBEA24F11A00802AE5D1B5FD1D0022A134609D62210044216BF0DA2925000261F1828F5E29006620CF851E0D2E008410195252433300A0C18FCA8410390026AD1493CC853F00D0CD24662FB646009CE19A1CDAB64E0058CCC20C5F9F5700200A7578FB89610030BBBBD6E4936C0060CBA7DC9EDD7800B83BC0425B8B8600B886236164C59500F8F15FDC93B8A600206A91C0D696B900D8EFE28FC097CE0068299BF52EF9E5FFFFFFFFFFFFFFFF");
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
        /// An Id does not have a greater score than another Id.
        /// </summary>
        NotHeavier
    }
}