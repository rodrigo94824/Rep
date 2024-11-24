namespace Proyecto.Domain.Entities
{
    public class ChatResponse
    {
        public string ResponseText { get; set; }
        public DateTime Timestamp { get; set; }

        public ChatResponse(string responseText)
        {
            ResponseText = responseText;
            Timestamp = DateTime.Now;
        }
    }
}
