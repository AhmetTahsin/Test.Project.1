using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test.Dto.Layer.CampaignDtos;

namespace Test.Project.ViewComponents.DefaultViewComponents
{
    public class _CampaignDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CampaignDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
