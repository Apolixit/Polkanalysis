﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events;

public abstract class SearchCriteria
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public uint? FromBlock { get; set; }
    public uint? ToBlock { get; set; }
}

public interface ISearchEvent<T>
    where T : SearchCriteria
{
    /// <summary>
    /// The search name to identify the event (and maybe display it on frontend)
    /// </summary>
    public string SearchName { get; }

    /// <summary>
    /// The search query parameter
    /// </summary>
    /// <returns></returns>
    public Type GetSearchCriterias();

    /// <summary>
    /// The search query function
    /// </summary>
    /// <param name="criteria"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<IEnumerable<EventModel>> SearchAsync(T criteria, CancellationToken token);

}
