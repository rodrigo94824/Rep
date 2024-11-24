namespace Proyecto.Domain.Entities
{
    public class UserMessage
    {
        public string UserId { get; set; }
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }

        public UserMessage(string userId, string messageText)
        {
            UserId = userId;
            MessageText = messageText;
            Timestamp = DateTime.Now;
        }
    }
}
