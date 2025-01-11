﻿namespace HouseForSale_Api.DTOs.ProductDTOs
{
    public class ResultLast3ProductWithCategoryDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }
        public int ProductCategory { get; set; }
        public string CategoryName { get; set; }
        public DateTime AdvertisementDate { get; set; }
    }
}