using Dapper;
using HouseForSale_Api.DTOs.TestimonialDtos;
using HouseForSale_Api.Models.DapperContext;
using HouseForSale_Api.Repositories.TestimonialRepository.Abstract;

namespace HouseForSale_Api.Repositories.TestimonialRepository.Concrete
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;
        public TestimonialRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * From Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }
    }
}