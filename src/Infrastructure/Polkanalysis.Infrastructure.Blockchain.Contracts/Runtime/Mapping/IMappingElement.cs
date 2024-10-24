using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Mapping
{
    public interface IMappingElement
    {
        /// <summary>
        /// Substrate class
        /// </summary>
        public Type ObjectType { get; }

        /// <summary>
        /// Is this class mapped to friendly class ?
        /// </summary>
        public bool IsIdentified { get; }

        /// <summary>
        /// Convert to friendly value
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public dynamic ToHuman(dynamic input);
    }
}
