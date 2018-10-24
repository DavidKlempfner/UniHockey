using DataAccess.Abstract;
using Entities.DTO;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BusinessService : IBusinessService
    {
        private IDataAccess _dataAccess;
        public BusinessService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<PlayerDto> GetPlayers()
        {
            List<PlayerDto> players = _dataAccess.GetPlayers();
            return players;
        }

        public List<TeamDto> GetTeams()
        {
            List<TeamDto> teams = _dataAccess.GetTeams();
            return teams;
        }

        public List<TeamDto> GetTeamsWithPlayers()
        {
            List<PlayerDto> playerDtos = GetPlayers();
            List<TeamDto> teams = _dataAccess.GetTeams();
            foreach (TeamDto team in teams)
            {
                var players = playerDtos.Where(x => x.TeamId == team.Id).ToList();
                team.Players = players;
            }

            return teams;
        }
    }
}
