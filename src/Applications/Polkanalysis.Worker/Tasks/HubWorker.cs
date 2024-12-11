using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Polkanalysis.Hub;

namespace Polkanalysis.Worker.Tasks
{
    internal class HubWorker : BackgroundService
    {
        private readonly IHubContext<PolkanalysisHub> _hubContext;
        private HubConnection _connection;
        private readonly ILogger<HubWorker> _logger;

        public HubWorker(IHubContext<PolkanalysisHub> hubContext, ILogger<HubWorker> logger)
        {
            _hubContext = hubContext;
            _logger = logger;

            _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7020/polkanalysishub")
                .WithAutomaticReconnect()
                .Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _connection.StartAsync(stoppingToken);
            _logger.LogInformation($"{_connection.State} to SignalR hub ({_connection.ConnectionId})");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    //await _connection.InvokeAsync("SendMessage", "WorkerService", "Hello from Worker", cancellationToken: stoppingToken);
                    //await _hubContext.Clients.All.SendAsync("SendMessage", "WorkerService", "Hello from Worker");

                    await _connection.InvokeAsync("BalancesTransfer", "Polkadot", 1_000, "xx", "yy", 1_000_000, cancellationToken: stoppingToken);
                    //await _connection.InvokeAsync("BalancesTransferPwet", "Polkadot", 1_000,cancellationToken: stoppingToken);

                    //await _connection.InvokeAsync("SendMessage", "WorkerService", "Hello from Worker");

                    _logger.LogInformation("Worker is sending message to SignalR hub");

                    
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Error in SignalR connection: {ex.Message}");
                }

                await Task.Delay(10_000, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await _connection.DisposeAsync();
            await base.StopAsync(cancellationToken);
        }
    }
}
