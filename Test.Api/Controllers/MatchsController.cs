using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Api.Dto.MatchDtos;
using Test.Api.Services.MatchServices;
using Test.Api.Services.MatchServices;

namespace Test.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class MatchsController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchsController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public async Task<IActionResult> MatchList()
        {
            var values = await _matchService.GetAllMatchAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch(CreateMatchDto createMatchDto)
        {
            await _matchService.CreateMatchAsync(createMatchDto);
            return Ok("Maç basari ile eklendi Eski Maç Silindi");
        }

    }
}
