using hash_game_api.Models.Requests;
using hash_game_api.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace hash_game_api.Core
{
    public class MainHub : Hub<IMainHub>
    {

        public async Task SendMessage(SendMessageRequest message, string roomId)
        {
            await Clients.Group(roomId).ReceiveMessage(message);
        }

        public async Task JoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            Console.WriteLine($"Entity {Context.ConnectionId} Sucessfuly conneced to {roomName}");
        }
    }
}
