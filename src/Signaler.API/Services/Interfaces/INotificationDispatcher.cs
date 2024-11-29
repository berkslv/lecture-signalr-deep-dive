namespace Signaler.API.Services.Interfaces;

public interface INotificationDispatcher
{
    Task SendNotification(string content);
    Task SendNotificationToUser(string userId, string content);
    Task SendNotificationToGroup(string groupName, string content);
}
