using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingCompetitionGame.Domain.Entities
{
    public class Participant
    {
        public string Name { get; set; }
        public int Result { get; set; }
        public string SolutionCode { get; set; }
    }
}
