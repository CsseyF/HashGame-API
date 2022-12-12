using hash_game_api.Core;
using hash_game_api.Services;
using hash_game_api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            //.AllowAnyOrigin()
            .WithOrigins("https://hash-game-wine.vercel.app")
            .AllowCredentials();
    });
});

builder.Services.AddScoped<ISocketService, SocketService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var webSocketOptions = new WebSocketOptions()
{
    KeepAliveInterval = TimeSpan.FromMinutes(1)
};

app.UseCors("ClientPermission");

app.UseWebSockets(webSocketOptions);

app.UseAuthorization();

app.MapControllers();

app.MapHub<MainHub>("/hashgame");

app.Run();
