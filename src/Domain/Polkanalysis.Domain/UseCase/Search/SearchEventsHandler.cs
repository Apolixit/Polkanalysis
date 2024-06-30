﻿using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Search;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Search;
using Polkanalysis.Domain.UseCase.Monitored;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Substrate.NET.Utils;

namespace Polkanalysis.Domain.UseCase.Search
{
    public class SearchEventsQueryValidator : AbstractValidator<SearchEventsQuery>
    {
        public SearchEventsQueryValidator()
        {
            RuleFor(x => x.DateBlockFilter!.Value)
                .LessThanOrEqualTo(DateTime.Now.ToUniversalTime())
                .When(x => x.DateBlockFilter is not null);

            RuleFor(x => x.DateBlockFilter!.Value2)
                .LessThanOrEqualTo(DateTime.Now.ToUniversalTime())
                .When(x => x.DateBlockFilter is not null);

            RuleFor(x => x.DateBlockFilter!.Value)
                .Must((x, y) => y < x.DateBlockFilter!.Value2)
                .When(x => x.DateBlockFilter is not null);
        }
    }
    public class SearchEventsHandler : Handler<SearchEventsHandler, IQueryable<EventsResultDto>, SearchEventsQuery>
    {
        private readonly ISubstrateService _polkadotRepository;
        private readonly SubstrateDbContext _dbContext;
        private readonly IEventsFactory _eventFactory;

        public SearchEventsHandler(ILogger<SearchEventsHandler> logger, IDistributedCache cache, ISubstrateService polkadotRepository, SubstrateDbContext dbContext, IEventsFactory eventFactory) : base(logger, cache)
        {
            _polkadotRepository = polkadotRepository;
            _dbContext = dbContext;
            _eventFactory = eventFactory;
        }

        public override async Task<Result<IQueryable<EventsResultDto>, ErrorResult>> HandleInnerAsync(SearchEventsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<EventsResultDto> result = new List<EventsResultDto>().AsQueryable();

            // First we got all the mapped events
            var mapped = _eventFactory.Mapped;
            
            // Apply modules filters if needed
            if (request.SelectedModules.Any())
            {
                mapped = mapped.Where(x => request.SelectedModules.Contains(x.GetModule().moduleName));
            }

            // Apply events filters if needed
            if (request.SelectedEvents.Any())
            {
                mapped = mapped.Where(x => request.SelectedEvents.Contains(x.GetModule().moduleEvent));
            }

            // For each event we instanciate the associated SearchCriteria instance and search for the event in the associated table
            foreach(var eventElem in mapped)
            {
                // Instanciate search criteria and apply filters
                var criteriaInstance = eventElem.SearchCriteriaType.Instanciate<SearchCriteria>();
                if (request.DateBlockFilter is not null)
                {
                    criteriaInstance.BlockDate = request.DateBlockFilter;
                }

                if (request.NumberBlockFilter is not null)
                {
                    criteriaInstance.BlockNumber = request.NumberBlockFilter;
                }

                // Invoke search method
                var searchRes = await _eventFactory.InvokeSearchAsync(eventElem, criteriaInstance, cancellationToken);

                // Map the result to the DTO
                if(searchRes is not null)
                {
                    var localResult = searchRes.Select(x => new EventsResultDto() {
                        BlockDate = x.BlockDate,
                        BlockId = x.BlockId,
                        EventId = x.EventId,
                        EventName = x.ModuleEvent,
                        PalletName = x.ModuleName,
                    }).AsQueryable();

                    result = result.Concat(localResult);
                }
            }
            

            return Helpers.Ok(result);
        }
    }
}
