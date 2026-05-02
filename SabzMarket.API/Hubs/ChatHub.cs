using Microsoft.AspNetCore.SignalR;
using SabzMarket.Application.Interfaces.Services;

namespace SabzMarket.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IConnectionManager _connectionManager;
        public ChatHub(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
        public async Task SetUserId(string username)
        {
            string connectionId = Context.ConnectionId;
            Console.WriteLine($"Client connected with ID: {connectionId}, UserID: {username}");

            _connectionManager.AddOrUpdate(username, connectionId);
            await Clients.Others.SendAsync("UserStatusChanged", username, "online");
        }
        public bool IsOnlineUser(string username)
        {
            var a = _connectionManager.ExistUser(username);
            return a;
        }
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string connectionId = Context.ConnectionId;

            Console.WriteLine($"Client disconnected: {connectionId}");
            var userId = _connectionManager.GetUserId(connectionId);
            await Clients.Others.SendAsync("UserStatusChanged", userId, "Offline");
            _connectionManager.RemoveByConnectionId(connectionId);


            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendPrivateMessage(string receiverUserName, string messageText, string senderUsername)
        {
            string? receiverConnectionId = _connectionManager.GetConnectionId(receiverUserName);

            if (receiverConnectionId != null)
            {
                await Clients.Client(receiverConnectionId).SendAsync("ReceivePrivateMessage", messageText, senderUsername);
            }
            else
            {
                Console.WriteLine($"User {receiverUserName} not found or is offline.");
                await Clients.Caller.SendAsync("SystemMessage", $"User {receiverUserName} is not available.");
            }
        }
    }
}
