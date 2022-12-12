using hash_game_api.Models.Requests;

namespace hash_game_api.Services.Interfaces
{
    public interface IMainHub
    {
        Task ReceiveMessage(SendMessageRequest message);
        Task JoinRoom(string roomId);
    }
}
