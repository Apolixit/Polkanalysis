using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Database.Contracts.Model;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Repository.Events;
using Substrate.NetApi.Model.Types;
using System.Reflection;

namespace Polkanalysis.Infrastructure.Database.Repository
{
    public class EventsFactory : IEventsFactory
    {
        public IEnumerable<EventElementFactory> Mapped { get; private set; }
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<IEventsFactory> _logger;

        public EventsFactory(IServiceProvider serviceProvider, ILogger<IEventsFactory> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;

            Mapped = ScanBindsEventAttribute();

            _logger.LogDebug("[{className}] instanciated. {eventMappedCount} events link to database found", nameof(EventsFactory), Mapped.Count());
        }

        private string BindingRepositoriesAssembly { get; set; } = "Polkanalysis.Infrastructure.Database";
        private string BlockchainInfrastructureAssembly { get; set; } = "Polkanalysis.Infrastructure.Blockchain.Contracts";

        /// <summary>
        /// Scan Polkanalysis.Infrastructure.Database.Contracts to get events repositories bind on runtime events
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private List<EventElementFactory> ScanBindsEventAttribute()
        {
            _logger.LogInformation("Start scanning assembly {assemblyName}", BindingRepositoriesAssembly);
            var versionned = new List<EventElementFactory>();

            // Get all type from given assembly
            var compatibleType = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName!.Contains(BindingRepositoriesAssembly))
                .SelectMany(x => x.GetTypes())
                .Where(t => typeof(IDatabaseInsert).IsAssignableFrom(t) && !t.IsInterface)
                ;

            // Now we are sure type won't fail on CreateInstance, let's check if it BindEvents is defined and if it implements IType
            foreach (var databaseInsertType in compatibleType)
            {
                var bindEventsAttribute = databaseInsertType.GetCustomAttributes<BindEventsAttribute>();
                if (bindEventsAttribute is not null && bindEventsAttribute.Any())
                {
                    foreach (var bindEvent in bindEventsAttribute)
                    {

                        var optionalRepo = _serviceProvider.GetService(databaseInsertType);

                        if(optionalRepo is null)
                        {
                            _logger.LogWarning(
                                "[{className}] The repository {repositoryName} is bind with {bindEventAttribute} but not register into service collection (please check {registerCollectionName})",
                                nameof(EventsFactory),
                                databaseInsertType,
                                nameof(BindEventsAttribute),
                                nameof(DatabaseServiceCollectionsExtensions));
                            continue;
                        }

                        var repoType = optionalRepo.GetType();
                        //var repo = (EventDatabaseRepository<,>)optionalRepo;

                        var repoService = (IDatabaseInsert)optionalRepo!;
                        var eventName = (INameableEvent)optionalRepo!;
                        var namableEvent = (INameableEvent)optionalRepo!;
                        var searchEventType = GetSearchType(optionalRepo!, namableEvent.SearchCriterias);
                        var modelEvent = GetEventModelType(repoType!);
                        versionned.Add(new EventElementFactory(optionalRepo,
                                                                repoService,
                                                               bindEvent.RuntimeEvent,
                                                               bindEvent.EventValue,
                                                               eventName.SearchName,
                                                               namableEvent.SearchCriterias,
                                                               searchEventType,
                                                               modelEvent));
                    }
                }
            }

            _logger.LogDebug("End scanning assembly {assemblyName} give {nb} results", BindingRepositoriesAssembly, versionned.Count);

            if (versionned.Count == 0)
                throw new InvalidOperationException($"No class in {BindingRepositoriesAssembly} implement {nameof(BindEventsAttribute)} !?");

            return versionned;
        }

        private static Type GetEventModelType(Type type)
        {
            // Obtenir le type de base générique de la classe
            var baseType = type.BaseType;

            if (baseType == null || !baseType.IsGenericType)
            {
                throw new InvalidOperationException("The provided type does not have a generic base type.");
            }

            // Obtenir les arguments génériques du type de base
            var genericArguments = baseType.GetGenericArguments();

            if (genericArguments.Length < 1)
            {
                throw new InvalidOperationException("The generic base type does not have the expected number of generic arguments.");
            }

            // Récupérer le premier argument générique (TModel)
            var modelGenericTypeArgument = genericArguments[0];

            // Vérifier que le type hérite de EventModel
            if (!typeof(EventModel).IsAssignableFrom(modelGenericTypeArgument))
            {
                throw new InvalidOperationException($"The type {modelGenericTypeArgument} does not inherit from EventModel.");
            }

            return modelGenericTypeArgument;

            // Créer une instance du type générique
            //var instance = Activator.CreateInstance(firstGenericTypeArgument) as EventModel;

            //if (instance == null)
            //{
            //    throw new InvalidOperationException($"Failed to create an instance of {firstGenericTypeArgument}.");
            //}

            //return instance;
        }

        private static Type GetSearchType(object instance, Type criteriaType)
        {
            // Obtenir les types d'interfaces que l'instance implémente
            var interfaces = instance.GetType().GetInterfaces();

            // Trouver l'interface ISearchEvent<T> que l'instance implémente
            var searchEventType = interfaces.FirstOrDefault(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISearchEvent<>));

            if (searchEventType is null)
            {
                throw new InvalidOperationException("The provided instance does not implement ISearchEvent<T>.");
            }

            // Obtenir le type de critère générique T
            var genericArgument = searchEventType.GetGenericArguments()[0];

            if (!genericArgument.IsAssignableFrom(criteriaType))
            {
                throw new InvalidOperationException($"The criteria type {criteriaType} is not compatible with {genericArgument}.");
            }

            return searchEventType;
        }

        public async Task<IEnumerable<EventModel>> InvokeSearchAsync(
            EventElementFactory eventElementFactory, SearchCriteria criteria, CancellationToken token)
        {
            // Get SearchAsync method from interface
            var searchMethod = eventElementFactory.SearchEventType.GetMethod("SearchAsync");

            if (searchMethod is null)
            {
                throw new InvalidOperationException("The SearchAsync method could not be found.");
            }

            // Call SearchAsync method dynamically
            var task = (Task<IEnumerable<EventModel>>)searchMethod.Invoke(eventElementFactory.Repository, [criteria, token]);

            // Wait and return the result
            return await task;
        }

        public async Task ExecuteInsertAsync(RuntimeEvent runtimeEvent, Enum eventValue, EventModel eventModel, IType details, CancellationToken token)
        {
            var databaseLinked = TryFind(runtimeEvent, eventValue);

            if (databaseLinked == null) { return; }

            await databaseLinked.DatabaseInsert.InsertAsync(eventModel, details, token);
        }

        public EventElementFactory? TryFind(RuntimeEvent runtimeEvent, Enum eventValue)
        {
            return Mapped.FirstOrDefault(x =>
            x.EventName.Equals($"{runtimeEvent}.{eventValue}"));
            //return Mapped.FirstOrDefault(x =>
            //x.RuntimeEvent.Equals(runtimeEvent) &&
            //x.EventValue.ToString().Equals(eventValue.ToString()));
        }
        public bool Has(RuntimeEvent runtimeEvent, Enum eventValue)
        {
            return TryFind(runtimeEvent, eventValue) != null;
        }

        public IEnumerable<(string name, string filter)> GetSearchCriteriasParameters(Type searchCriteria)
        {
            if(!searchCriteria.IsSubclassOf(typeof(SearchCriteria)))
                throw new InvalidOperationException("Unable to get search criteria from a class that does not inherit from SearchCriteria");

            foreach (var prop in searchCriteria.GetProperties())
            {
                yield return (prop.Name, ExtractPropertyName(prop));
            }
        }

        public string ExtractPropertyName(PropertyInfo prop)
        {
            if(prop.PropertyType.Name.StartsWith("NumberCriteria"))
            {
                var genericTypeName = prop.PropertyType.GetGenericArguments().First().Name switch
                {
                    "UInt32" => "uint",
                    "Double" => "double",
                    _ => prop.PropertyType.GetGenericArguments().First().Name
                };

                return $"{prop.PropertyType.Name.Remove(prop.PropertyType.Name.Length - 2)}<{genericTypeName}>";
            }

            if (prop.PropertyType.Name.StartsWith("Nullable"))
            {
                return $"{prop.PropertyType.GetGenericArguments().First()}";
            }
            return prop.PropertyType.Name;
        }
    }
}
