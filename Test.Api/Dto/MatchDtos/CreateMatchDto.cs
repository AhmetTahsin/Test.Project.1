namespace Test.Api.Dto.MatchDtos
{
    public class CreateMatchDto
    {
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Team1LogoUrl { get; set; }
        public string Team2LogoUrl { get; set; }
        public DateTime MatchTime { get; set; }
    }
}
