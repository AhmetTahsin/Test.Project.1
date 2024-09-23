using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Api.Dto.MovieDtos;
using Test.Api.Services.MovieServices;

namespace Test.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var values = await _movieService.GetAllMovieAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(string id)
        {
            var values = await _movieService.GetByIdMovieAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieDto createMovieDto)
        {
            await _movieService.CreateMovieAsync(createMovieDto);
            return Ok("Film basari ile eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(string id)
        {
            await _movieService.DeleteMovieAsync(id);
            return Ok("Film basari ile Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieDto updateMovieDto)
        {
            await _movieService.UpdateMovieAsync(updateMovieDto);
            return Ok("Film basari ile güncellendi");
        }
    }
}
