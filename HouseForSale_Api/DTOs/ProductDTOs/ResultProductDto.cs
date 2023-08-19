namespace HouseForSale_Api.DTOs.ProductDTOs
{
    public class ResultProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal  Price { get; set; }
        public string City  { get; set; }
        public int ProductCategory { get; set; }
     }
}
