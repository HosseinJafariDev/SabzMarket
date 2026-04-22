using Microsoft.AspNetCore.SignalR;
using SabzMarket.Application.Interfaces.Services;

namespace SabzMarket.API.Hubs
{
    public class ChatHub: Hub
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

            // اینجا userId را با connectionId در ConnectionManager ذخیره می‌کنیم
            // فرض بر این است که userId در سیستم شما منحصر به فرد است
            _connectionManager.AddOrUpdate(username, connectionId);
            await Clients.Others.SendAsync("UserStatusChanged", username, "online");
            // ممکن است بخواهید به کاربر یک پیام خوشامدگویی ارسال کنید
            // await Clients.Caller.SendAsync("ReceiveMessage", new ChatMessage { SenderName = "System", MessageText = $"Welcome, {userId}!", Timestamp = DateTime.Now });

            // اگر نیاز دارید که لیست کاربران آنلاین را به بقیه یا خود کاربر ارسال کنید، اینجا می‌توانید آن را فراخوانی کنید
            // var onlineUsers = _connectionManager.GetAllUserIds(); // نیاز به پیاده‌سازی این متد در ConnectionManager
            // await Clients.All.SendAsync("UpdateOnlineUsers", onlineUsers);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            // می‌توانید در اینجا کاربر را به یک گروه خاص اضافه کنید یا کارهای دیگری انجام دهید
            // Clients.Caller.SendAsync("ReceiveMessage", new ChatMessage { SenderName = "System", MessageText = "You are connected!", Timestamp = DateTime.Now });
            return base.OnConnectedAsync();
        }

        // متد Hub که وقتی یک کلاینت قطع می‌شود، فراخوانی می‌شود
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string connectionId = Context.ConnectionId;

            Console.WriteLine($"Client disconnected: {connectionId}");
            // می‌توانید اینجا عملیات مربوط به قطع ارتباط کاربر را انجام دهید
            var userId = _connectionManager.GetUserId(connectionId);
            await Clients.Others.SendAsync("UserStatusChanged", userId, "Offline");
            _connectionManager.RemoveByConnectionId(connectionId);


            await base.OnDisconnectedAsync(exception);
        }

        // متدی که کلاینت‌ها برای ارسال پیام فراخوانی می‌کنند
        // نام این متد باید با نامی که در InvokeAsync کلاینت استفاده می‌کنید، مطابقت داشته باشد
        public async Task SendMessage(string senderName, string messageText)
        {
            // می‌توانید پیام را به همه کلاینت‌ها ارسال کنید
            await Clients.All.SendAsync("ReceiveMessage", senderName, messageText);

            // یا اگر می‌خواهید پیام فقط به کلاینت‌های خاصی ارسال شود:
            // Clients.Others.SendAsync("ReceiveMessage", message); // ارسال به همه به جز فرستنده
            // await Groups.AddToGroupAsync(Context.ConnectionId, "MyGroup"); // اضافه کردن به گروه
            // await Clients.Group("MyGroup").SendAsync("ReceiveMessage", message); // ارسال به اعضای یک گروه
        }
        public async Task SendPrivateMessage(string receiverUserName, string messageText, string senderUsername)
        {
            string? receiverConnectionId = _connectionManager.GetConnectionId(receiverUserName);

            if (receiverConnectionId != null)
            {
                // پیام را فقط به گیرنده ارسال می‌کنیم
                // 'ReceivePrivateMessage' نام متدی است که در کلاینت باید فراخوانی شود
                await Clients.Client(receiverConnectionId).SendAsync("ReceivePrivateMessage", messageText, senderUsername);
                // اگر لازم است نام فرستنده را هم بفرستید (می‌توانید آن را از Context.ConnectionId پیدا کنید اگرچه کمی پیچیده‌تر است)
                // یا فرض کنید فرستنده خودش نامش را می‌داند و در کلاینت اضافه می‌کند
                // await Clients.Client(receiverConnectionId).SendAsync("ReceivePrivateMessage", "SenderName", messageText);
            }
            else
            {
                // گیرنده آفلاین است یا userId پیدا نشد
                Console.WriteLine($"User {receiverUserName} not found or is offline.");
                // می‌توانید پیام خطا را به فرستنده برگردانید
                await Clients.Caller.SendAsync("SystemMessage", $"User {receiverUserName} is not available.");
            }
        }

        // مثال: متدی برای پیوستن به یک گروه (اگر نیاز دارید)
        //public async Task JoinGroup(string groupName)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        //    await Clients.Group(groupName).SendAsync("ReceiveMessage", new ChatMessage { SenderName = "System", MessageText = $"{Context.ConnectionId} has joined the group {groupName}.", Timestamp = DateTime.Now });
        //}
    }
}
