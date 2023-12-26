using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Versionning;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Polkanalysis.Architecture.Tests")]
namespace Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping
{
    internal static class ScanAssemblyMapping
    {
        public static IEnumerable<ScanMappingResult> ScanEnumMappings(string netApiExtAssembly, string domainAssembly)
        {
            Guard.Against.NullOrEmpty(netApiExtAssembly, nameof(netApiExtAssembly));

            var result = new List<ScanMappingResult>();

            var assemblyExt = LoadEnumNetApiExtType(netApiExtAssembly);
            var assemblyDomain = LoadEnumDomainType(domainAssembly);


            return result;

        }

        private static IEnumerable<Type> LoadEnumNetApiExtType(string netApiExtAssembly)
        {
            var x1 = Assembly.Load(netApiExtAssembly);

            var compatibleType = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName.Contains(netApiExtAssembly))
                .SelectMany(x => x.GetTypes())
                .Where(x =>
                {
                    // For each type, check if it is a class and got parameterless constructor
                    return
                        x.IsAssignableFrom(x) &&
                        x.IsClass &&
                        !x.ContainsGenericParameters &&
                        x.GetConstructor(Type.EmptyTypes) is not null &&
                        x.Name.StartsWith("Enum") ;
                });

            return compatibleType;
        }

        private static IEnumerable<Type> LoadEnumDomainType(string domainAssembly)
        {
            var compatibleType = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName.Contains(domainAssembly))
                .SelectMany(x => x.GetTypes())
                .Where(x =>
                {
                    // For each type, check if it is a class and got parameterless constructor
                    return
                        x.IsAssignableFrom(x) &&
                        x.IsClass &&
                        !x.ContainsGenericParameters &&
                        x.GetConstructor(Type.EmptyTypes) is not null;
                });

            foreach (var t in compatibleType)
            {
                var palletAttribute = t.GetCustomAttributes<DomainMappingAttribute>();
                if (palletAttribute is not null && palletAttribute.Any())
                {
                    yield return t;
                }
            }
        }
    }
}
