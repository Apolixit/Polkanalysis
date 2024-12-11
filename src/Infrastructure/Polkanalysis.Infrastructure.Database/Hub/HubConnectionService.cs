//using Microsoft.AspNetCore.SignalR.Client;
//using Microsoft.Extensions.Logging;
//using Polkanalysis.Infrastructure.Database.Contracts.Hub;

//namespace Polkanalysis.Infrastructure.Database.Hub
//{
//    public class HubConnectionService : IHubConnectionService
//    {
//        private readonly ILogger<HubConnectionService> _logger;
//        private readonly string _hubUrl;
//        private readonly string _token;

//        public HubConnectionService(ILogger<HubConnectionService> logger, string hubUrl, string token)
//        {
//            _logger = logger;
//            _hubUrl = hubUrl;
//            _token = token;
//        }

//        private void ConfigureConnection()
//        {
//            Connection = new HubConnectionBuilder()
//                .WithUrl(_hubUrl, options =>
//                {
//                    options.AccessTokenProvider = () => Task.FromResult(_token);
//                })
//                .WithAutomaticReconnect()
//                .Build();
//        }

//        public HubConnection Connection { get; private set; }

//        public Task StartConnectionAsync(CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
