using Test.Api.Dto.MovieDtos;

namespace Test.Api.Services.MovieServices
{
    public interface IMovieService
    {
        Task<List<ResultMovieDto>> GetAllMovieAsync();
        Task CreateMovieAsync(CreateMovieDto createMovieDto);
        Task UpdateMovieAsync(UpdateMovieDto updateMovieDto);
        Task DeleteMovieAsync(string id);
        Task<GetByIdMovieDto> GetByIdMovieAsync(string id);
    }
}
