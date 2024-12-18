
using Microsoft.AspNetCore.SignalR;

namespace Polkanalysis.Hub
{
    public class PolkanalysisHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public const string ApiKeyPermission = "ApiKeyPermission";

        private readonly ILogger<PolkanalysisHub> _logger;

        public PolkanalysisHub(ILogger<PolkanalysisHub> logger)
        {
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            var context = Context.GetHttpContext();
            _logger.LogInformation("[PolkanalysisHub] New connection from {ConnectionId}", Context.ConnectionId);
            //if (context is null || context.Items.TryGetValue(ApiKeyPermission, out var permissions))
            //{
            //    _logger.LogWarning("[PolkanalysisHub] New connection from {ConnectionId} but permissions are not set", Context.ConnectionId);
            //    Context.Abort();
            //    return;
            //}

            //var allowedChannels = permissions as List<string>;
            //Context.Items["AllowedChannels"] = allowedChannels;

            await base.OnConnectedAsync();
        }

        public bool IsChannelAllowed(string channel)
        {
            if (Context.Items.TryGetValue("AllowedChannels", out var allowedChannelsObj))
            {
                var allowedChannels = allowedChannelsObj as List<string>;
                return allowedChannels?.Contains(channel) ?? false;
            }
            return false;
        }

        public async Task SendMessage(string user, string message)
        {
            _logger.LogInformation("[PolkanalysisHub] SendMessage - New message from {User}: {Message}", user, message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task BalancesTransfer(string blockchainName, uint blockId, string from, string to, double amount)
        {
            _logger.LogInformation("[PolkanalysisHub] BalanceTransfer - New message {methodName} from {blockchainName} / {blockId} / {from} / {to} / {amount}", "Balances.Transfer", blockchainName, blockId, from, to, amount);
            await Clients.All.SendAsync("Balances.Transfer", blockchainName, blockId, from, to, amount);
        }

        //public async Task BalancesTransferPwet(string blockchainName, uint blockId)
        //{
        //    _logger.LogInformation("[PolkanalysisHub] BalancesTransferPwet - New message {methodName} from {blockchainName} / {blockId}", methodName, blockchainName, blockId);
        //    await Clients.All.SendAsync("Balances.Transfer", blockchainName, blockId);
        //}
    }
}

