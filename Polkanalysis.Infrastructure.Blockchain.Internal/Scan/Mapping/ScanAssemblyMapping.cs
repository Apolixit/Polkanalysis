using Ardalis.GuardClauses;
using Substrate.NetApi.Model.Types.Base.Abstraction;
using System.Reflection;
using System.Runtime.CompilerServices;
using Substrate.NET.Utils;

[assembly: InternalsVisibleTo("Polkanalysis.Architecture.Tests")]
namespace Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping
{
    internal static class ScanAssemblyMapping
    {
        public static IEnumerable<ScanMappingResult> ScanMappings(string netApiExtAssembly, string domainAssembly)
        {

        }

        /// <summary>
        /// Do a diff between enum from NetApiExt and Domain
        /// </summary>
        /// <param name="netApiExtAssembly"></param>
        /// <param name="domainAssembly"></param>
        /// <returns></returns>
        public static IEnumerable<ScanMappingResult> ScanEnumMappings(string netApiExtAssembly, string domainAssembly)
        {
            Guard.Against.NullOrEmpty(netApiExtAssembly, nameof(netApiExtAssembly));

            var result = new List<ScanMappingResult>();

            var assemblyExt = LoadEnumNetApiExtType(netApiExtAssembly);
            var assemblyDomain = LoadEnumDomainType(domainAssembly);

            if (!assemblyExt.Any()) return result;

            foreach (var aExt in assemblyExt)
            {
                var foundInDomain = assemblyDomain.FirstOrDefault(x => aExt.GetType().FullName.EndsWith(x.ExtNameBuilder));

                string destinationClass = foundInDomain?.FullName;
                var scan = new ScanMappingResult(aExt.GetType())
                {
                    DestinationClass = destinationClass,
                };

                if (foundInDomain is not null)
                {
                    var sourceEnumNames = aExt.GetValue().GetType().GetEnumNames();
                    var destinationEnumNames = foundInDomain.Enum.GetType().GetEnumNames();

                    scan.MapProperties(sourceEnumNames, destinationEnumNames);
                }

                result.Add(scan);
            }

            return result;
        }

        private static IEnumerable<IBaseEnum> LoadEnumNetApiExtType(string netApiExtAssembly)
        {
            Guard.Against.NullOrEmpty(netApiExtAssembly, nameof(netApiExtAssembly));

            var loadedAssembly = Assembly.Load(netApiExtAssembly);

            if (loadedAssembly is null)
                throw new InvalidOperationException($"Unable to load assembly {netApiExtAssembly}");

            var enumSource = new List<IBaseEnum>();

            var compatibleType = loadedAssembly.GetTypes().Where(x =>
            {
                // For each type, check if it is a class and got parameterless constructor
                return
                    x.IsAssignableFrom(x) &&
                    x.IsClass &&
                    !x.ContainsGenericParameters &&
                    x.GetConstructor(Type.EmptyTypes) is not null &&
                    x.Name.StartsWith("Enum") &&
                    (!x.Name.EndsWith("EnumCall") || !x.Name.EndsWith("EnumRuntimeCall"));
            });

            foreach (var foundedEnum in compatibleType)
            {
                enumSource.Add(foundedEnum.Instanciate<IBaseEnum>());
            }

            return enumSource;
        }

        private static IEnumerable<EnumAssemblyResult> LoadEnumDomainType(string domainAssembly)
        {
            Guard.Against.NullOrEmpty(domainAssembly, nameof(domainAssembly));

            var loadedAssembly = Assembly.Load(domainAssembly);

            if (loadedAssembly is null)
                throw new InvalidOperationException($"Unable to load assembly {domainAssembly}");

            var enumDomain = new List<EnumAssemblyResult>();

            var compatibleType = loadedAssembly.GetTypes()
                .Where(x =>
                {
                    // For each type, check if it is a class and got parameterless constructor
                    return
                        x.GetCustomAttribute<DomainMappingAttribute>() is not null;
                });

            foreach (var foundedEnum in compatibleType)
            {
                var typeSearched = foundedEnum;
                if (foundedEnum.IsEnum)
                {
                    string fullName = $"{typeSearched.Namespace}.Enum{typeSearched.Name}";
                    typeSearched = loadedAssembly.GetTypes().FirstOrDefault(x => x.FullName == fullName);

                    if (typeSearched is null)
                        throw new InvalidOperationException($"{fullName} does not exist in {domainAssembly} types");
                }

                var attribute = foundedEnum.GetCustomAttribute<DomainMappingAttribute>();
                if (attribute is not null)
                {
                    var enumExt = typeSearched.Instanciate<IBaseEnum>();
                    enumDomain.Add(new EnumAssemblyResult()
                    {
                        Enum = enumExt.GetValue(),
                        EnumExt = enumExt,
                        MappingAttribute = attribute,
                        FullName = foundedEnum.FullName
                    });
                }
            }

            return enumDomain;
        }
    }
}
