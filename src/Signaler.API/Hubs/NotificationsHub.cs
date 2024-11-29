using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Signaler.API.Hubs;

public class NotificationsHub : Hub
{
    public async Task SendNotification(string content)
    {
        await Clients.All.SendAsync("ReceiveNotification", content);
    }

    public async Task SendNotificationToUser(string userId, string content)
    {
        await Clients.User(userId).SendAsync("ReceiveNotification", content);
    }

    public async Task SendNotificationToGroup(string groupName, string content)
    {
        await Clients.Group(groupName).SendAsync("ReceiveNotification", content);
    }

    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
    }
}