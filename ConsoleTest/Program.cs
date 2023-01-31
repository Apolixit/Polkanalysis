using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Substats.Polkadot.NetApiExt.Generated;
using Substats.Polkadot.NetApiExt.Generated.Model.frame_system;
using Substats.Polkadot.NetApiExt.Generated.Storage;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

public static class Program
{
    public static async Task Main(string[] args)
    {
        /*
         * dotnet new ajuna --sdk_version 0.1.25 --rest_service MoneyPot_RestService --net_api MoneyPot_NetApiExt --rest_client MoneyPot_RestClient --metadata_websocket ws://127.0.0.1:9944 --force --allow-scripts yes
         */
        var client = new SubstrateClientExt(new Uri("wss://rpc.polkadot.io"), ChargeTransactionPayment.Default());

        // Display Client Connection Status before connecting
        Console.WriteLine($"Client Connection Status: {GetClientConnectionStatus(client)}");

        await client.ConnectAsync();

        // Display Client Connection Status after connecting
        Console.WriteLine(client.IsConnected ? "Client connected successfully" : "Failed to connect to node. Exiting...");

        //var r = client.State.GetStorageHashAtAsync()

        var meta = client.MetaData;

        var errors = client.MetaData.NodeMetadata.Modules[9].Errors;

       
        await SubscribeAllEventAsync(client);
        Console.ReadLine();
    }

    
    public static async Task SubscribeAllEventAsync(SubstrateClientExt client)
    {
        //var x = await client.SystemStorage.Events(CancellationToken.None);
        var requestEvent = SystemStorage.EventsParams();
        //var requestEvent = RequestGenerator.GetStorage("MoneyPot", "Events", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        //var requestEvent = RequestGenerator.GetStorage("Balances", "Events", Ajuna.NetApi.Model.Meta.Storage.Type.Plain);
        Console.WriteLine("Ready to listen events");
        Console.WriteLine($"{client.StorageKeyDict.Count}");
        await client.SubscribeStorageKeyAsync(requestEvent, async (string subscriptionId, StorageChangeSet storageChangeSet) =>
        {
            if (storageChangeSet.Changes == null
                    || storageChangeSet.Changes.Length == 0
                    || storageChangeSet.Changes[0].Length < 2)
            {
                Debug.WriteLine("Couldn't update account information. Please check 'CallBackAccountChange'");
                return;
            }


            var hexString = storageChangeSet.Changes[0][1];

            if (string.IsNullOrEmpty(hexString))
            {
                return;
            }
            var eventsReceived = new BaseVec<EventRecord>();
            eventsReceived.Create(hexString);

            foreach (EventRecord eventReceived in eventsReceived.Value)
            {

                var eventPhase = eventReceived.Phase;
                var eventCore = eventReceived.Event;
                var eventTopic = eventReceived.Topics;

                if(eventTopic.Value.Length > 0)
                {
                    var topicDetails = await client.SystemStorage.EventTopics(eventTopic.Value.First(), CancellationToken.None);
                }
                var mainEvent = eventCore.Value;
                var secondaryEvent = string.Empty;
                var details = string.Empty;

                var mainEventString = eventCore.Value.ToString();
                if (eventCore.Value != Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.RuntimeEvent.Scheduler)
                {
                    var hex = Utils.Bytes2HexString(eventReceived.Encode());
                }
            }

        }, CancellationToken.None);
    }

    private static string GetClientConnectionStatus(SubstrateClientExt client)
    {
        return client.IsConnected ? "Connected" : "Not connected";

    }

    public static async Task XX(SubstrateClientExt client)
    {
        //var accountId32 = new AccountId32();
        //accountId32.Create(Utils.GetPublicKeyFrom(accountAddress));

        //var res = await _substrateNodeRepository.Client.BalancesStorage.Account(accountId32, cancellationToken);
        //var res1 = await _substrateNodeRepository.Client.BalancesStorage.Locks(accountId32, cancellationToken);

        //var res2 = await _substrateNodeRepository.Client.BalancesStorage.Reserves(accountId32, cancellationToken);
        //var res3 = await _substrateNodeRepository.Client.BalancesStorage.StorageVersion(cancellationToken);
        //var res4 = await _substrateNodeRepository.Client.BalancesStorage.TotalIssuance(cancellationToken);

        //var res5 = await _substrateNodeRepository.Client.SystemStorage.Account(accountId32, cancellationToken);
        //var res6 = await _substrateNodeRepository.Client.SystemStorage.Digest(cancellationToken);
        //var res7 = await _substrateNodeRepository.Client.SystemStorage.ExecutionPhase(cancellationToken);
        //var res8 = await _substrateNodeRepository.Client.System.NodeRolesAsync(cancellationToken);
        //var res9 = await _substrateNodeRepository.Client.System.ChainAsync(cancellationToken);
        //var res10 = await _substrateNodeRepository.Client.System.NameAsync(cancellationToken);
        //var res11 = await _substrateNodeRepository.Client.System.ChainTypeAsync(cancellationToken);
        //var res12 = await _substrateNodeRepository.Client.System.AccountNextIndexAsync(accountAddress, cancellationToken);
        //var res13 = await _substrateNodeRepository.Client.System.HealthAsync(cancellationToken);
        //var res14 = await _substrateNodeRepository.Client.System.SyncStateAsync(cancellationToken);
        //var res15 = await _substrateNodeRepository.Client.System.VersionAsync(cancellationToken);
        //var res16 = await _substrateNodeRepository.Client.System.NodeRolesAsync(cancellationToken);
        //var res17 = await _substrateNodeRepository.Client.State.GetRuntimeVersionAsync();

        //var res18 = await _substrateNodeRepository.Client.StakingStorage.Bonded(accountId32, cancellationToken);
        //var res19 = await _substrateNodeRepository.Client.StakingStorage.BondedEras(cancellationToken);
        //var res20 = await _substrateNodeRepository.Client.StakingStorage.CurrentEra(cancellationToken);
        //var res21 = await _substrateNodeRepository.Client.StakingStorage.Nominators(accountId32, cancellationToken);
        //var res22 = await _substrateNodeRepository.Client.StakingStorage.Payee(accountId32, cancellationToken);
        //var res23 = await _substrateNodeRepository.Client.StakingStorage.Validators(accountId32, cancellationToken);
        //var res24 = await _substrateNodeRepository.Client.ParasStorage.Parachains(cancellationToken);
        //var res25 = await _substrateNodeRepository.Client.IdentityStorage.IdentityOf(accountId32, cancellationToken);
    }
}