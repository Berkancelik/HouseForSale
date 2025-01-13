using HouseForSale_Api.DTOs.MessageDtos;

namespace HouseForSale_Api.Repositories.MessageRepository.Abstract
{
    public interface IMessageRepository
    {
        Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessageListByReceiver(int id);

    }
}
