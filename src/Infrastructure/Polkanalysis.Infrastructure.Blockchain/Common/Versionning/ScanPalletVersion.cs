using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Versionning;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Common.Versionning
{
    public class ScanAssemblyPalletVersion
    {
        private readonly ILogger<ScanAssemblyPalletVersion> _logger;
        public string SearchingAssembly { get; set; } = "Domain.Contracts";

        public ScanAssemblyPalletVersion(ILogger<ScanAssemblyPalletVersion> logger)
        {
            _logger = logger;
        }

        public virtual List<PalletVersionning> ScanAttribute()
        {
            _logger.LogInformation("Start scanning assembly {assemblyName}", SearchingAssembly);
            var versionned = new List<PalletVersionning>();

            // Get all type from given assembly
            var compatibleType = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName.Contains(SearchingAssembly))
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

            // Now we are sure type won't fail on CreateInstance, let's check if it PalletVersionAttribute is defined and if it implements IType
            foreach (var t in compatibleType)
            {
                var palletVersionAttribute = t.GetCustomAttributes<PalletVersionAttribute>();
                if (palletVersionAttribute is not null && palletVersionAttribute.Any())
                {
                    var substrateType = Activator.CreateInstance(t) as BaseType;
                    if (substrateType is not null)
                    {
                        palletVersionAttribute.ToList()
                            .ForEach(version => versionned.Add(new PalletVersionning(version, substrateType)));

                    }
                    else
                    {
                        throw new InvalidOperationException($"{nameof(PalletVersionAttribute)} has to be used on class that implement IType");
                    }
                }
            }

            _logger.LogDebug("End scanning assembly {assemblyName} give {nb} results", SearchingAssembly, versionned.Count);

            if (!versionned.Any())
                throw new InvalidOperationException($"No class in {SearchingAssembly} implement IVersion !?");

            return versionned;
        }

        //public virtual List<IVersion> Scan()
        //{
        //    _logger.LogInformation("Start scanning assembly {assemblyName}", SearchingAssembly);
        //    var versionned = new List<IVersion>();

        //    // Get all type from given assembly
        //    var compatibleType = AppDomain.CurrentDomain.GetAssemblies()
        //        .Where(assembly => assembly.FullName.Contains(SearchingAssembly))
        //        .SelectMany(x => x.GetTypes())
        //        .Where(x =>
        //        {
        //            // For each type, check if it is a class and got parameterless constructor
        //            return
        //                x.IsAssignableFrom(x) &&
        //                x.IsClass &&
        //                !x.ContainsGenericParameters &&
        //                x.GetConstructor(Type.EmptyTypes) is not null;
        //        });

        //    // Now we are sure type won't fail on CreateInstance, let's check if it implements IVersion
        //    foreach (var v in compatibleType)
        //    {
        //        var s = Activator.CreateInstance(v) as IVersion;
        //        if (s is not null)
        //        {
        //            versionned.Add(s);
        //        }
        //    }

        //    _logger.LogDebug("End scanning assembly {assemblyName} give {nb} results", SearchingAssembly, versionned.Count);

        //    if (!versionned.Any())
        //        throw new InvalidOperationException($"No class in {SearchingAssembly} implement IVersion !?");

        //    return versionned;
        //}
    }
}
