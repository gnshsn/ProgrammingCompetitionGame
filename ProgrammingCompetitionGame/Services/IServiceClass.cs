using ProgrammingCompetitionGame.Domain.Entities.DTOs;
using ProgrammingCompetitionGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingCompetitionGame.Services
{
    public interface IServiceClass
    {
        void RateSolution(JsonResponseModel rModel, ParticipantDTO model);
    }
}
