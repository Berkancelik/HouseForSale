﻿namespace HouseForSale_Api.DTOs.PopularLocationDTOs
{
    public class CreatePopularLocationDto
    {
        public string CityName { get; set; }
        public string ImageUrl { get; set; }
        public int PropertyCount { get; set; }
    }
}