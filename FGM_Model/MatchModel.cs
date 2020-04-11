using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGM_Model
{
    public class MatchModel : BaseModel
    {
        public string MatchDate { get; set; }
        public string MatchTime { get; set; }
        public string TeamID1 { get; set; }
        public string TeamID2 { get; set; }

        public string MatchJson { get; set; }
    }
}
