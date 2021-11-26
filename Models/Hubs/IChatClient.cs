using System.Threading.Tasks;

namespace the_other_balloon_widget.Models.Clients
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}