using Microsoft.AspNetCore.SignalR;
using Signaler.API.Hubs;
using Signaler.API.Services.Interfaces;

namespace Signaler.API.Services;

public class NotificationDispatcher(IHubContext<NotificationsHub> hubContext) : INotificationDispatcher
{
    public async Task SendNotification(string content)
    {
        await hubContext.Clients.All.SendAsync("ReceiveNotification", content);
    }

    public async Task SendNotificationToUser(string userId, string content)
    {
        await hubContext.Clients.User(userId).SendAsync("ReceiveNotification", content);
    }

    public async Task SendNotificationToGroup(string groupName, string content)
    {
        await hubContext.Clients.Group(groupName).SendAsync("ReceiveNotification", content);
    }
}
