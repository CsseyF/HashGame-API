using hash_game_api.Models.Requests;
using hash_game_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hash_game_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StarterController : ControllerBase
    {
        private readonly ISocketService _service;
        public StarterController(ISocketService service)
        {
            _service = service;
        }


        [HttpPost("/ws/hashgame")]
        public async Task Get([FromBody]SendMessageRequest request)
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await _service.Echo(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
}
