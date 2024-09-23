using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Test.Api.Entities
{
    public class Campaign
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string CampaignId { get; set; }
		public string Title { get; set; }
		public string Descreption { get; set; }
		public string ImageUrl { get; set; }
		public string LinkUrl { get; set; }

    }
}
