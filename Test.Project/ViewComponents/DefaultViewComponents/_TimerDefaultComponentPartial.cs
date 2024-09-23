using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test.Dto.Layer.MatchDtos;

namespace Test.Project.ViewComponents.DefaultViewComponents
{
    public class _TimerDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TimerDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7006/api/Matchs");
            if (responseMessage.IsSuccessStatusCode) //200 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMatchDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
