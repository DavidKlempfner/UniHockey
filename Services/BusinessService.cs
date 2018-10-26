using AutoMapper;
using DataAccess.Abstract;
using Entities.DTO;
using Entities.Models;
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

        public List<Player> GetPlayers()
        {
            List<Player> players = Mapper.Map<List<Player>>(GetPlayerDtos());
            return players;
        }        

        public List<Team> GetTeams()
        {
            List<Team> teams = Mapper.Map<List<Team>>(GetTeamDtos());
            return teams;
        }        

        public List<Team> GetTeamsWithPlayers()
        {
            List<PlayerDto> playerDtos = GetPlayerDtos();
            List<TeamDto> teamDtos = _dataAccess.GetTeamDtos();
            foreach (TeamDto team in teamDtos)
            {
                var players = playerDtos.Where(x => x.TeamId == team.Id).ToList();
                team.Players = players;
            }
            
            List<Team> teams = Mapper.Map<List<Team>>(teamDtos);

            return teams;
        }

        private List<PlayerDto> GetPlayerDtos()
        {
            List<PlayerDto> playerDtos = _dataAccess.GetPlayerDtos();
            return playerDtos;
        }

        private List<TeamDto> GetTeamDtos()
        {
            List<TeamDto> teamDtos = _dataAccess.GetTeamDtos();
            return teamDtos;
        }
    }
}
