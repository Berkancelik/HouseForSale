using HouseForSale_Api.DTOs.TestimonialDtos;

namespace HouseForSale_Api.Repositories.TestimonialRepository.Abstract
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
    }
}