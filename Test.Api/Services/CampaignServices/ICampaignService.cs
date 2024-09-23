using Test.Api.Dto.CampaignDtos;

namespace Test.Api.Services.CampaignServices
{
	public interface ICampaignService
	{
		Task<List<ResultCampaignDto>> GetAllCampaignAsync();
		Task CreateCampaignAsync(CreateCampaignDto createCampaignDto);
		Task UpdateCampaignAsync(UpdateCampaignDto updateCampaignDto);
		Task DeleteCampaignAsync(string id);
		Task<GetByIdCampaignDto> GetByIdCampaignAsync(string id);
	}
}
