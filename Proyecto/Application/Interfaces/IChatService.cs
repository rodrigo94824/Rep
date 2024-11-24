using Proyecto.Domain.Entities;
using System.Threading.Tasks;

namespace Proyecto.Application.Interfaces
{
    public interface IChatService
    {
        Task<ChatResponse> GetResponseAsync(UserMessage message);
    }
}
