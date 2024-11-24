using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Proyecto.Infrastructure.Clients
{
    public class WhatsAppClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _accessToken;
        private readonly string _baseUrl;

        public WhatsAppClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _accessToken = configuration["WhatsAppAPI:AccessToken"];
            _baseUrl = configuration["WhatsAppAPI:BaseURL"];

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
        }

        public async Task<bool> SendMessageAsync(string phoneNumber, string messageText)
        {
            var requestUrl = $"{_baseUrl}{phoneNumber}/messages";

            var payload = new
            {
                messaging_product = "whatsapp",
                to = phoneNumber,
                text = new { body = messageText }
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requestUrl, content);
            return response.IsSuccessStatusCode;
        }
    }
}
