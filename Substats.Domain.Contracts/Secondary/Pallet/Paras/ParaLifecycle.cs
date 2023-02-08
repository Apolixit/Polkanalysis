using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Paras
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
}
