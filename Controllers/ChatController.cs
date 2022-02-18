using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using the_other_balloon_widget.Models.Hubs;
using the_other_balloon_widget.Models.Clients;
using the_other_balloon_widget.Models;

namespace the_other_balloon_widget.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub, IChatClient> _chatHub;

        public ChatController(IHubContext<ChatHub, IChatClient> chatHub)
        {
            _chatHub = chatHub;
        }

        [HttpPost("messages")]
        public async Task Post(ChatMessage message)
        {
            // run some logic...
            await _chatHub.Clients.All.ReceiveMessage(message);
        }
    }
}
