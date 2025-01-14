using Dapper;
using HouseForSale_Api.DTOs.SubFeatureDtos;
using HouseForSale_Api.Models.DapperContext;
using HouseForSale_Api.Repositories.SubFeatureRepository.Abstract;

namespace HouseForSale_Api.Repositories.SubFeatureRepository.Concrete
{
	public class SubFeatureRepository : ISubFeatureRepository
	{
		private readonly Context _context;
		public SubFeatureRepository(Context context)
		{
			_context = context;
		}
		public async Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync()
		{
			string query = "Select * From SubFeature";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultSubFeatureDto>(query);
				return values.ToList();
			}
		}
	}
}