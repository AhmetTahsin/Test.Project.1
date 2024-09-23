using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Dto.Layer.CampaignDtos
{
	public class ResultCampaignDto
	{
		public string CampaignId { get; set; }
		public string Title { get; set; }
		public string Descreption { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }
	}
}
