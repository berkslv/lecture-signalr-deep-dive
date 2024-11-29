using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Signaler.API.Hubs;
using Signaler.API.Services.Interfaces;

namespace Signaler.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController(INotificationDispatcher notificationDispatcher) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> SendNotification([FromQuery] string content)
    {
        await notificationDispatcher.SendNotification(content);
        return Ok();
    }

    [HttpGet("user")]
    public async Task<IActionResult> SendNotificationToUser([FromQuery] string userId, [FromQuery] string content)
    {
        await notificationDispatcher.SendNotificationToUser(userId, content);
        return Ok();
    }

    [HttpGet("group")]
    public async Task<IActionResult> SendNotificationToGroup([FromQuery] string groupName, [FromQuery] string content)
    {
        await notificationDispatcher.SendNotificationToGroup(groupName, content);
        return Ok();
    }
}
