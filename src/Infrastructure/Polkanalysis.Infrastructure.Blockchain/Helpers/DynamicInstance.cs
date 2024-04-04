using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Helpers
{
    public static class DynamicInstance
    {
        public static T CreateInstance<T>(Type source)
        {
            var activator = Activator.CreateInstance(source);

            if (activator is null)
                throw new InvalidOperationException($"Unable to create dynamic instance from type {source}");

            return (T)activator;
        }
    }
}
