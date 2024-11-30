using MediatR;
using NetArchTest.Rules;
using OperationResult;
using Polkanalysis.Domain.Contracts.Common;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Architecture.Tests
{
    public class NamingConventionTests : ArchiBaseTests
    {
        [Test]
        public void MediatorUseCaseHandler_ShouldHaveValidSuffix()
        {
            var useCasesHandler = Types
                .InAssembly(DomainAssembly)
                .That().Inherit(typeof(Handler<,,>))
                .Should().HaveNameEndingWith("Handler")
                .GetResult();

            Assert.That(useCasesHandler.IsSuccessful, Is.True);
        }

        [Test]
        public void MediatorQuery_ShouldHaveValidSuffix()
        {
            var useCasesHandler = Types
                .InAssembly(DomainContractAssembly)
                .That().Inherit(typeof(IRequest<>))
                .Should().HaveNameEndingWith("Query")
                .GetResult();

            Assert.That(useCasesHandler.IsSuccessful, Is.True);
        }

        [Test]
        public void MediatorCommand_ShouldHaveValidSuffix()
        {
            var useCasesHandler = Types
                .InAssembly(DomainContractAssembly)
                .That().Inherit(typeof(IRequest<Result<bool, ErrorResult>>))
                .Should().HaveNameEndingWith("Command")
                .GetResult();

            Assert.That(useCasesHandler.IsSuccessful, Is.True);
        }

        [Test]
        public void Interface_ShouldHaveValidPrefix()
        {
            var interfacesName = Types
                .InAssembly(DomainContractAssembly)
                .That().AreInterfaces()
                .Should().HaveNameStartingWith("I")
                .GetResult();

            Assert.That(interfacesName.IsSuccessful, Is.True);
        }

        [Test]
        public void Queries_WhenImplementingCache_ShouldHaveValidParameters()
        {
            var results = Types
                .InAssembly(DomainContractAssembly)
                .That().ImplementInterface(typeof(ICached))
                .GetTypes();

            if (!results.Any())
                Assert.Ignore("No class implement ICached in the assembly");

            foreach (var type in results)
            {
                var instance = CreateInstanceWithDefaults(type) as ICached;
                Assert.That(instance, Is.Not.Null, $"Impossible to create instance of typr {type.Name}.");

                // Vérifier que CacheDurationInMinutes > 0
                Assert.That(instance.CacheDurationInMinutes, Is.GreaterThan(0),
                    $"{type.Name} should have CacheDurationInMinutes > 0.");

                // Vérifier que GenerateCacheKey() ne retourne pas une chaîne vide
                var cacheKey = instance.GenerateCacheKey();
                Assert.That(string.IsNullOrEmpty(cacheKey), Is.False,
                    $"{type.Name} should have valid key cache.");
            }
        }

        /// <summary>
        /// Crée une instance de la classe donnée en remplissant automatiquement les paramètres de son constructeur.
        /// </summary>
        private object? CreateInstanceWithDefaults(Type type)
        {
            // Récupérer le constructeur public avec le plus grand nombre de paramètres
            var constructor = type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .FirstOrDefault();

            if (constructor == null)
                throw new InvalidOperationException($"Aucun constructeur public trouvé pour {type.Name}.");

            // Générer des valeurs par défaut pour chaque paramètre du constructeur
            var parameters = constructor.GetParameters()
                .Select(p => GetDefaultValue(p.ParameterType))
                .ToArray();

            // Créer l'instance
            return constructor.Invoke(parameters);
        }

        /// <summary>
        /// Renvoie une valeur par défaut pour un type donné.
        /// </summary>
        private object? GetDefaultValue(Type type)
        {
            // Fournir des valeurs par défaut pour les types courants
            if (type.IsValueType)
            {
                // Pour les types valeur, utiliser Activator.CreateInstance
                return Activator.CreateInstance(type);
            }

            // Pour les types référence, retourner null
            return null;
        }
    }
}
