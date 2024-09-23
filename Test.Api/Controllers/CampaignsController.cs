using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Api.Dto.CampaignDtos;
using Test.Api.Services.CampaignServices;

namespace Test.Api.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class CampaignsController : ControllerBase
	{
		private readonly ICampaignService _campaignService;

		public CampaignsController(ICampaignService campaignService)
		{
			_campaignService = campaignService;
		}

		[HttpGet]
		public async Task<IActionResult> CampaignList()
		{
			var values = await _campaignService.GetAllCampaignAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCampaignById(string id)
		{
			var values = await _campaignService.GetByIdCampaignAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCampaign(CreateCampaignDto createCampaignDto)
		{
			await _campaignService.CreateCampaignAsync(createCampaignDto);
			return Ok("Kampanya basari ile eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteCampaign(string id)
		{
			await _campaignService.DeleteCampaignAsync(id);
			return Ok("Kampanya basari ile Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCampaign(UpdateCampaignDto updateCampaignDto)
		{
			await _campaignService.UpdateCampaignAsync(updateCampaignDto);
			return Ok("Kampanya basari ile güncellendi");
		}
	}
}
