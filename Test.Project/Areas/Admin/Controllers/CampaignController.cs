using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Test.Dto.Layer.CampaignDtos;

namespace Test.Project.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	[Route("Admin/Campaign")]
	public class CampaignController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CampaignController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[Route("Index")]
		public async Task<IActionResult> Index()
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7006/api/Campaigns");
			if (responseMessage.IsSuccessStatusCode) //200 
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCampaignDto>>(jsonData);

				return View(values);
			}

			return View();
		}

		[HttpGet]
		[Route("CreateCampaign")]
		public IActionResult CreateCampaign()
		{
			return View();
		}

		[HttpPost]
		[Route("CreateCampaign")]
		public async Task<IActionResult> CreateCampaign(CreateCampaignDto createCampaignDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCampaignDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7006/api/Campaigns", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Campaign", new { area = "Admin" });
			}

			return View();
		}

		[Route("DeleteCampaign/{id}")]
		public async Task<IActionResult> DeleteCampaign(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7006/api/Campaigns?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Campaign", new { area = "Admin" });
			}
			return View();
		}

		[Route("UpdateCampaign/{id}")]
		[HttpGet]
		public async Task<IActionResult> UpdateCampaign(string id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7006/api/Campaigns/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateCampaignDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[Route("UpdateCampaign/{id}")]
		[HttpPost]
		public async Task<IActionResult> UpdateCampaign(UpdateCampaignDto updateCampaignDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateCampaignDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7006/api/Campaigns/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Campaign", new { area = "Admin" });
			}
			return View();
		}
	}
}
