using AutoMapper;
using MongoDB.Driver;
using Test.Api.Dto.MovieDtos;
using Test.Api.Entities;
using Test.Api.Settings;

namespace Test.Api.Services.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly IMongoCollection<Movie> _movieCollection;
        private readonly IMapper _mapper;
        public MovieService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//Bağlantı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);   //Database
            _movieCollection = database.GetCollection<Movie>(_databaseSettings.MovieCollectionName);  //Tablo
            _mapper = mapper;
        }

        public async Task CreateMovieAsync(CreateMovieDto createMovieDto)
        {
            var value = _mapper.Map<Movie>(createMovieDto);
            await _movieCollection.InsertOneAsync(value);
        }

        public async Task DeleteMovieAsync(string id)
        {
            await _movieCollection.DeleteOneAsync(x => x.MovieId == id);
        }

        public async Task<List<ResultMovieDto>> GetAllMovieAsync()
        {
            var values = await _movieCollection.Find(x => true).ToListAsync(); //x=>true hepsini listelemek için
            return _mapper.Map<List<ResultMovieDto>>(values);
        }

        public async Task<GetByIdMovieDto> GetByIdMovieAsync(string id)
        {
            var values = await _movieCollection.Find<Movie>(x => x.MovieId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdMovieDto>(values);
        }

        public async Task UpdateMovieAsync(UpdateMovieDto updateMovieDto)
        {
            var values = _mapper.Map<Movie>(updateMovieDto);
            await _movieCollection.FindOneAndReplaceAsync(x => x.MovieId == updateMovieDto.MovieId, values);
        }
    }
}
