using Proyecto.Application.Interfaces;
using Proyecto.Domain.Entities;
using Proyecto.Infrastructure.Clients;
using System.Threading.Tasks;

namespace Proyecto.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly WhatsAppClient _whatsAppClient;
        private readonly OpenAIClient _openAIClient;

        public ChatService(WhatsAppClient whatsAppClient, OpenAIClient openAIClient)
        {
            _whatsAppClient = whatsAppClient;
            _openAIClient = openAIClient;
        }

        public async Task<ChatResponse> GetResponseAsync(UserMessage message)
        {
            // Obtener respuesta de ChatGPT a través del cliente de OpenAI
            var gptResponseText = await _openAIClient.GetChatResponseAsync(message.MessageText);

            // Enviar la respuesta a través de WhatsApp
            await _whatsAppClient.SendMessageAsync(message.UserId, gptResponseText);

            // Devolver la respuesta como objeto ChatResponse
            return new ChatResponse(gptResponseText);
        }
    }
}
