using ProgrammingCompetitionGame.Domain.Context;
using ProgrammingCompetitionGame.Domain.Entities;
using ProgrammingCompetitionGame.Domain.Entities.DTOs;
using ProgrammingCompetitionGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingCompetitionGame.Services
{
    public class ServiceClass : IServiceClass
    {
        public void SavetoDB(Participant participant)
        {
            using (var ctx = new ParticipantContext())
            {
                try
                {
                    ctx.Participants.Add(participant);
                    ctx.SaveChanges();
                    string a = "a";
                }
                catch (Exception e)
                {

                    throw e;
                }

                
            }
        }

        public void RateSolution(JsonResponseModel rModel, ParticipantDTO model)
        {
            Participant participant = new Participant();
            if (rModel.Output != null & (rModel.Memory!=null || rModel.CpuTime != null))
            {
                participant.Name = model.Name;
                participant.SolutionCode = model.SolutionCode;
                participant.Result = 100;
            }
            else
            {
                participant.Name = model.Name;
                participant.SolutionCode = model.SolutionCode;
                participant.Result = 0;
            }
            SavetoDB(participant);
        }
    }
}
