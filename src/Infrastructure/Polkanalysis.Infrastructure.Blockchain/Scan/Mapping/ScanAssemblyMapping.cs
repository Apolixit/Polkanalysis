using Ardalis.GuardClauses;
using System.Reflection;
using System.Runtime.CompilerServices;
using Substrate.NET.Utils;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

[assembly: InternalsVisibleTo("Polkanalysis.Architecture.Tests")]
namespace Polkanalysis.Infrastructure.Blockchain.Scan.Mapping
{
    internal static class ScanAssemblyMapping
    {
        //public static IEnumerable<ScanMappingResult> ScanMappings(string netApiExtAssembly, string domainAssembly)
        //{

        //}

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

            var assemblyDomain = LoadEnumDomainType(domainAssembly);
            var assemblyExt = LoadEnumNetApiExtType(netApiExtAssembly);

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

        public static IEnumerable<IType> LoadEnumNetApiExtType(string netApiExtAssembly)
        {
            Guard.Against.NullOrEmpty(netApiExtAssembly, nameof(netApiExtAssembly));

            var loadedAssembly = Assembly.Load(netApiExtAssembly);

            if (loadedAssembly is null)
                throw new InvalidOperationException($"Unable to load assembly {netApiExtAssembly}");

            var enumSource = new List<IType>();

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
                try
                {
                    enumSource.Add(foundedEnum.Instanciate<IType>());
                } catch(Exception ex)
                {
                    
                }
                
            }

            return enumSource;
        }

        public static IEnumerable<EnumAssemblyResult> LoadEnumDomainType(string domainAssembly)
        {
            Guard.Against.NullOrEmpty(domainAssembly, nameof(domainAssembly));

            var loadedAssembly = Assembly.Load(domainAssembly);

            if (loadedAssembly is null)
                throw new InvalidOperationException($"Unable to load assembly {domainAssembly}");

            var enumsDomain = new List<EnumAssemblyResult>();

             var compatibleType = loadedAssembly.GetTypes()
                .Where(x =>
                {
                    // For each type, check if it is a class and got parameterless constructor
                   return   x.IsAssignableFrom(x) &&
                           x.IsClass &&
                           !x.ContainsGenericParameters &&
                           x.GetConstructor(Type.EmptyTypes) is not null &&
                           x.Name.StartsWith("Enum") &&
                           (!x.Name.EndsWith("EnumCall") || !x.Name.EndsWith("EnumRuntimeCall"));
                });

            foreach (var foundedWrapperEnum in compatibleType)
            {
                // Bad hack here, we get the EnumXXXX and we want to get the underlying enum, so we go to the mother class and get the first generic property
                var foundedEnum = foundedWrapperEnum.BaseType.GetProperties().First(x => x.PropertyType.IsEnum).PropertyType;
                var typeSearched = foundedWrapperEnum;
                if (foundedEnum.IsEnum)
                {
                    string fullName = $"{typeSearched.Namespace}.Enum{foundedEnum.Name}";
                    typeSearched = loadedAssembly.GetTypes().FirstOrDefault(x => x.FullName == fullName);

                    if (typeSearched is null)
                        throw new InvalidOperationException($"{fullName} does not exist in {domainAssembly} types");
                }

                var enumExt = typeSearched.Instanciate<IType>();
                var enumDomain = new EnumAssemblyResult()
                {
                    Enum = enumExt.GetEnumValue(),
                    EnumExt = enumExt,
                    FullName = foundedWrapperEnum.FullName
                };

                var attribute = foundedEnum.GetCustomAttribute<DomainMappingAttribute>();
                if (attribute is not null)
                {
                    enumDomain.MappingAttribute = attribute;
                }

                enumsDomain.Add(enumDomain);
            }

            return enumsDomain;
        }
    }
}
