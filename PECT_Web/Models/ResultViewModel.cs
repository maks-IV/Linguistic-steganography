using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PECT_Web.Models
{
    public class ResultViewModel
    {
        public string Output { get; set; }
        public string Status { get; set; }
        public double TimeMS { get; set; }
        public Dictionary<string, bool> Stages  = new Dictionary<string, bool>()
        {
                { "UTF-8 encoding completed", false },
                { "Cover text obtained", false },
                { "Security digits obtained", false },
                { "Algorithm execution completed", false },
                { "Verified data", false }
        };
        public string TextStatus { get; set; }
        public string BtnStatus { get; set; }
        public string BorderStatus { get; set; }
    }
}
