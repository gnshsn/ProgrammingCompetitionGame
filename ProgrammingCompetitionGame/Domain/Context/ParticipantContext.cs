using Microsoft.EntityFrameworkCore;
using ProgrammingCompetitionGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingCompetitionGame.Domain.Context
{
    public class ParticipantContext:DbContext
    {
        public ParticipantContext() : base()
        {

        }

        public DbSet<Participant> Participants { get; set; }
    }
}
