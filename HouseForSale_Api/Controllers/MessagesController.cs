using HouseForSale_Api.Repositories.MessageRepository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetInBoxLast3MessageListByReceiver(int id)
        {
            var values = await _messageRepository.GetInBoxLast3MessageListByReceiver(id);
            return Ok(values);
        }
    }
}