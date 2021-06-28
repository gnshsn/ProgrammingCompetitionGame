using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingCompetitionGame.Domain.Entities.DTOs
{
    public class ParticipantDTO
    {
        public string Name { get; set; }
        public  string Task { get; set; }
        public string SolutionCode { get; set; }
    }
}
