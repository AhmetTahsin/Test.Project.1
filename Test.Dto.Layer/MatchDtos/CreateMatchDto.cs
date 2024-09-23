using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Dto.Layer.MatchDtos
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
