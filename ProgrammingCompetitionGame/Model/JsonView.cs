using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingCompetitionGame
{
    [JsonObject]
    [Serializable]
    public class JsonModel
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Script { get; set; }
        public string Language { get; set; }
        public string VersionIndex { get; set; }
    }
}
