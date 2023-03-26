using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Babe.Enums
{
    public enum AllowedSlots
    {

        PrimarySlots = 0,

        PrimaryAndSecondaryPlainSlots = 1,

        PrimaryAndSecondaryVRFSlots = 2,
    }

    public sealed class EnumAllowedSlots : BaseEnum<AllowedSlots>
    {
    }
}
