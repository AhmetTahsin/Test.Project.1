using AutoMapper;
using MongoDB.Driver;
using Test.Api.Dto.MatchDtos;
using Test.Api.Entities;
using Test.Api.Settings;

namespace Test.Api.Services.MatchServices
{
    public class MatchService : IMatchService
    {
        private readonly IMongoCollection<Match> _matchCollection;
        private readonly IMapper _mapper;
        public MatchService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//Bağlantı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);   //Database
            _matchCollection = database.GetCollection<Match>(_databaseSettings.MatchCollectionName);  //Tablo
            _mapper = mapper;
        }

        /// <summary>
        /// sadece 1 maç olması için her güncellendiğinde eski verilerin hepsini siler
        /// </summary>
        /// <param name="createMatchDto"></param>
        /// <returns></returns>
        public async Task CreateMatchAsync(CreateMatchDto createMatchDto)
        {
            var matchs = await _matchCollection.Find(x => true).ToListAsync();
            foreach (var match in matchs) 
            {
                await _matchCollection.DeleteOneAsync(x => x.MatchId == match.MatchId);
            }
            var value = _mapper.Map<Match>(createMatchDto);
            await _matchCollection.InsertOneAsync(value);
        }

        public async Task<List<ResultMatchDto>> GetAllMatchAsync()
        {
            var values = await _matchCollection.Find(x => true).ToListAsync(); //x=>true hepsini listelemek için
            return _mapper.Map<List<ResultMatchDto>>(values);
        }
    }
}
