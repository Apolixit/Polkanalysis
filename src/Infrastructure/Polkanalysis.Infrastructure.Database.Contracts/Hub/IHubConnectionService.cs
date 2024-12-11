﻿using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Hub
{
    public interface IHubConnectionService
    {
        HubConnection Connection { get; }
        Task StartConnectionAsync(CancellationToken cancellationToken);

    }
}
