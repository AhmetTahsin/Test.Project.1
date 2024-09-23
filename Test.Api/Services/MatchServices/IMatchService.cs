using Test.Api.Dto.MatchDtos;

namespace Test.Api.Services.MatchServices
{
    public interface IMatchService
    {
        Task<List<ResultMatchDto>> GetAllMatchAsync();
        Task CreateMatchAsync(CreateMatchDto createMovieDto);
    }
}
