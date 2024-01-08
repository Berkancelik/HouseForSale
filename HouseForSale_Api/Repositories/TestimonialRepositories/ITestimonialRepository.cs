using HouseForSale_Api.DTOs.TestimonialDtos;

namespace HouseForSale_Api.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
    }
}