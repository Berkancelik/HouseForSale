using HouseForSale_Api.DTOs.SubFeatureDtos;

namespace HouseForSale_Api.Repositories.SubFeatureRepository.Abstract
{
	public interface ISubFeatureRepository
	{
		Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync();
	}
}