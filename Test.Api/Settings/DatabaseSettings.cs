namespace Test.Api.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }


        public string MovieCollectionName { get; set; }
        public string MatchCollectionName { get; set; }
		public string CampaignCollectionName { get; set; }



	}
}
