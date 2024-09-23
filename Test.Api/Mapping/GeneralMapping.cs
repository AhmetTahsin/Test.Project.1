using AutoMapper;
using Test.Api.Dto.CampaignDtos;
using Test.Api.Dto.MatchDtos;
using Test.Api.Dto.MovieDtos;
using Test.Api.Entities;

namespace Test.Api.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Movie,CreateMovieDto>().ReverseMap();
            CreateMap<Movie,ResultMovieDto>().ReverseMap();
            CreateMap<Movie,UpdateMovieDto>().ReverseMap();
            CreateMap<Movie,GetByIdMovieDto>().ReverseMap();

            CreateMap<Match,CreateMatchDto>().ReverseMap();
            CreateMap<Match,ResultMatchDto>().ReverseMap();

			CreateMap<Campaign, CreateCampaignDto>().ReverseMap();
			CreateMap<Campaign, ResultCampaignDto>().ReverseMap();
			CreateMap<Campaign, UpdateCampaignDto>().ReverseMap();
			CreateMap<Campaign, GetByIdCampaignDto>().ReverseMap();
		}
    }
}
