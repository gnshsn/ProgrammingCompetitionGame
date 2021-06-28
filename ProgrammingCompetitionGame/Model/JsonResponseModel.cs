using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingCompetitionGame.Views
{
    public class JsonResponseModel
    {
        public string Output { get; set; }
        public string StatusCode { get; set; }
        public string Memory { get; set; }
        public string CpuTime { get; set; }
    }
}
