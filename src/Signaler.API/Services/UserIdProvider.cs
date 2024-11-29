using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Signaler.API.Services;

public class UserIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection)
    {
        return "user";
    }
}
