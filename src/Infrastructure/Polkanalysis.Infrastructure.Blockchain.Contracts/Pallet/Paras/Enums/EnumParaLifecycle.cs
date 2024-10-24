using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums
{
    [DomainMapping("polkadot_runtime_parachains/paras")]
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
