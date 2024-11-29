using Microsoft.AspNetCore.SignalR;
using Signaler.API.Hubs;
using Signaler.API.Services;
using Signaler.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
// .AddStackExchangeRedis("localhost:6379", options =>
// {
//     options.Configuration.ChannelPrefix = "SignalR";
// });

builder.Services.AddSingleton<IUserIdProvider, UserIdProvider>();

builder.Services.AddSingleton<INotificationDispatcher, NotificationDispatcher>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapHub<NotificationsHub>("hubs/notification");

app.MapControllers();

app.Run();

