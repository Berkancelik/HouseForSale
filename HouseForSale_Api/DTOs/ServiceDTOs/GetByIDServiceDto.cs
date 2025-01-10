namespace HouseForSale_Api.DTOs.ServiceDTOs
{
    public class GetByIDServiceDto
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}