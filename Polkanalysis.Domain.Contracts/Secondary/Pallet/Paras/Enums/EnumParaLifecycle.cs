using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras.Enums
{
    public enum ParaLifecycle
    {

        Onboarding = 0,

        Parathread = 1,

        Parachain = 2,

        UpgradingParathread = 3,

        DowngradingParachain = 4,

        OffboardingParathread = 5,

        OffboardingParachain = 6,
    }

    /// <summary>
    /// >> 670 - Variant[polkadot_runtime_parachains.paras.ParaLifecycle]
    /// </summary>
    public sealed class EnumParaLifecycle : BaseEnum<ParaLifecycle>
    {
    }
}
