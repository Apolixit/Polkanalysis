using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.BagsList.Enums
{
    [DomainMapping("pallet_bags_list/list")]
    public enum ListError
    {

        Duplicate = 0,

        NotHeavier = 1,

        NotInSameBag = 2,

        NodeNotFound = 3,
    }

    /// <summary>
    /// >> 616 - Variant[pallet_bags_list.list.ListError]
    /// </summary>
    public sealed class EnumListError : BaseEnum<ListError>
    {
    }
}
