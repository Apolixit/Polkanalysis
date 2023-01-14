using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Runtime
{
    public interface IPalletInformation
    {
        /// <summary>
        /// Get the list of Calls associated to given module name
        /// </summary>
        /// <param name="palletName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public INode GetModuleCalls(string palletName, CancellationToken cancellationToken);
        public INode GetModuleEvents(string palletName, CancellationToken cancellationToken);
        public INode GetModuleErrors(string palletName, CancellationToken cancellationToken);
        public INode GetModuleConstants(string palletName, CancellationToken cancellationToken);
        public INode GetModuleStorage(string palletName, CancellationToken cancellationToken);
    }
}
