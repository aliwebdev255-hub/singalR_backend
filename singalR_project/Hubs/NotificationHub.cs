using Microsoft.AspNetCore.SignalR;

namespace singalR_project.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync(
                "ReceiveNotification",
                message
            );
        }

        // NEW CHAT METHOD
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync(
                "ReceiveMessage",   
                user,
                message
            );
        }
    }
}