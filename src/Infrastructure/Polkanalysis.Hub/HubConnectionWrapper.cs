
using Microsoft.AspNetCore.SignalR.Client;

namespace Polkanalysis.Hub
{
    public class HubConnectionWrapper : IHubConnection
    {
        private readonly HubConnection _hubConnection;

        public HubConnectionWrapper(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
        }

        
        public Task InvokeAsync(string methodName, object[] args, CancellationToken cancellationToken)
        {
           return _hubConnection.InvokeAsync(methodName, args, cancellationToken);
        }

        public Task InvokeAsync(string methodName, object? arg1, CancellationToken cancellationToken)
        {
            return _hubConnection.InvokeAsync(methodName, arg1, cancellationToken);
        }

        public Task InvokeAsync(string methodName, object? arg1, object? arg2, CancellationToken cancellationToken)
        {
            return _hubConnection.InvokeAsync(methodName, arg1, arg2, cancellationToken);
        }

        public Task InvokeAsync(string methodName, object? arg1, object? arg2, object? arg3, CancellationToken cancellationToken)
        {
            return _hubConnection.InvokeAsync(methodName, arg1, arg2, arg3, cancellationToken);
        }

        public Task InvokeAsync(string methodName, object? arg1, object? arg2, object? arg3, object? arg4, CancellationToken cancellationToken)
        {
            return _hubConnection.InvokeAsync(methodName, arg1, arg2, arg3, arg4, cancellationToken);
        }

        public Task InvokeAsync(string methodName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, CancellationToken cancellationToken)
        {
            return _hubConnection.InvokeAsync(methodName, arg1, arg2, arg3, arg4, arg5, cancellationToken);
        }

        public Task InvokeAsync(string methodName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, CancellationToken cancellationToken)
        {
            return _hubConnection.InvokeAsync(methodName, arg1, arg2, arg3, arg4, arg5, arg6, cancellationToken);
        }

        public Task InvokeAsync(string methodName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, CancellationToken cancellationToken)
        {
            return _hubConnection.InvokeAsync(methodName, arg1, arg2, arg3, arg4, arg5, arg6, arg7, cancellationToken);
        }

        public Task InvokeAsync(string methodName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, CancellationToken cancellationToken)
        {
            return _hubConnection.InvokeAsync(methodName, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, cancellationToken);
        }
    }
}
