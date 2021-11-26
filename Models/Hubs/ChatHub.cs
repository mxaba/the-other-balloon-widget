using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using the_other_balloon_widget.Models.Clients;

namespace the_other_balloon_widget.Models.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
        }
    }
}