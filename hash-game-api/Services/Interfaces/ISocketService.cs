using System.Net.WebSockets;

namespace hash_game_api.Services.Interfaces
{
    public interface ISocketService
    {
        Task Echo(WebSocket websocket);
    }
}
