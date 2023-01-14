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


        var meta = client.MetaData;

        var errors = client.MetaData.NodeMetadata.Modules[9].Errors;

       
        //await SubscribeAllEventAsync(client);
        await SubscribeFinalizedBlockAsync(client);
        Console.ReadLine();
    }

    
    public static async Task SubscribeAllEventAsync(SubstrateClientExt client)
    {
        var x = await client.SystemStorage.Events(CancellationToken.None);
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
                if (eventCore.Value == Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.RuntimeEvent.Scheduler)
                {
                    var hex = Utils.Bytes2HexString(eventReceived.Encode());
                }
            }

        }, CancellationToken.None);
    }

    public static async Task SubscribeFinalizedBlockAsync(SubstrateClientExt client)
    {
        await client.Chain.SubscribeFinalizedHeadsAsync((string s, Header h) =>
        {
                Console.WriteLine(h.StateRoot);
            //var blockAuthor = await client.GetStorageAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>(AuthorshipStorage.AuthorParams(), blockHash.Value, cancellationToken);
        });
    }
    private static string GetClientConnectionStatus(SubstrateClientExt client)
    {
        return client.IsConnected ? "Connected" : "Not connected";

    }
}