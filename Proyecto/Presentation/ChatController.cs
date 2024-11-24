using Microsoft.AspNetCore.Mvc;
using Proyecto.Application.Interfaces;
using Proyecto.Domain.Entities;
using System.Threading.Tasks;

namespace Proyecto.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("receive-message")]
        public async Task<IActionResult> ReceiveMessage([FromBody] UserMessage userMessage)
        {
            if (userMessage == null || string.IsNullOrEmpty(userMessage.MessageText))
            {
                return BadRequest("El mensaje no puede estar vacío.");
            }

            // Llamar a ChatService para procesar el mensaje y obtener la respuesta de ChatGPT
            var chatResponse = await _chatService.GetResponseAsync(userMessage);

            // Devolver la respuesta como JSON
            return Ok(new { response = chatResponse.ResponseText });
        }
    }
}
