namespace Polkanalysis.Hub
{
    /// <summary>
    /// Wrapper for <see cref="Microsoft.AspNetCore.SignalR.HubConnection"/> mostly for testing purposes
    /// </summary>
    public interface IHubConnection
    {
        Task InvokeAsync(string methodName, object[] args, CancellationToken cancellationToken);
        Task InvokeAsync(string methodName, object? arg1, CancellationToken cancellationToken);
        Task InvokeAsync(string methodName, object? arg1, object? arg2, CancellationToken cancellationToken);
        Task InvokeAsync(string methodName, object? arg1, object? arg2, object? arg3, CancellationToken cancellationToken);
        Task InvokeAsync(string methodName, object? arg1, object? arg2, object? arg3, object? arg4, CancellationToken cancellationToken);
        Task InvokeAsync(string methodName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, CancellationToken cancellationToken);
        Task InvokeAsync(string methodName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, CancellationToken cancellationToken);
        Task InvokeAsync(string methodName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, CancellationToken cancellationToken);
        Task InvokeAsync(string methodName, object? arg1, object? arg2, object? arg3, object? arg4, object? arg5, object? arg6, object? arg7, object? arg8, CancellationToken cancellationToken);
    }
}
