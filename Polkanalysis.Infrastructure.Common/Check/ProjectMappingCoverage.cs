using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Common.Check
{
    /// <summary>
    /// Check if every class of NetApiExt has their correspondance in Domain.Contracts
    /// Check if every class of NetApiExt has been mapped in Domain.Contracts
    /// </summary>
    public class ProjectMappingCoverage
    {
        public void CheckStructure(string namespaceSource, string namespaceDestination)
        {
            if(namespaceSource == null) { throw new ArgumentNullException(nameof(namespaceDestination)); }
            if(namespaceDestination == null) { throw new ArgumentNullException(nameof(namespaceDestination)); }

            /*
             * NetApiExt / Generated / Model -> Domain.Contracts.Secondary.Pallet
             * 
             * NetApiExt / Generated / Storage -> X
             * NetApiExt / Generated / Type -> X
             */
        }
    }
}
