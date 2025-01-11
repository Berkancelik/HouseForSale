namespace HouseForSale_Api.DTOs.PopularLocationDTOs
{
    public class GetByIDPopularLocationDto
    {
        public int LocationId { get; set; }
        public string CityName { get; set; }
        public string ImageUrl { get; set; }
        public int PropertyCount { get; set; }
    }
}