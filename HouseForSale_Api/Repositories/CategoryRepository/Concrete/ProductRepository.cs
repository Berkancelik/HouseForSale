﻿using Dapper;
using HouseForSale_Api.DTOs.CategoryDTOs;
using HouseForSale_Api.DTOs.ProductDTOs;
using HouseForSale_Api.Models.DapperContext;
using HouseForSale_Api.Repositories.CategoryRepository.Abstract;

namespace HouseForSale_Api.Repositories.CategoryRepository.Concrete
{
    public class ProductRepository : IProductRepository
    {

        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();

            }
        }

		public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
		{
			string query = "Select ProductId,Title,Price,City,District,CategoryName,CoverImage,Type,Address From Product inner join Category on Product.ProductCategory=Category.CategoryId";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
				return values.ToList();
			}
		}

	}
}
