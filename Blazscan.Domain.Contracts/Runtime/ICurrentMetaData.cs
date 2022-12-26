using Ajuna.NetApi.Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Runtime
{
    public interface ICurrentMetaData
    {
        /// <summary>
        /// Get current MetaData pallet module from pallet name
        /// </summary>
        /// <param name="palletName"></param>
        /// <returns></returns>
        public PalletModule GetPalletModule(string palletName);
    }
}
