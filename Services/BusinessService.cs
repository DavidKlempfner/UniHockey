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

        public List<Player> GetAllPlayers()
        {
            List<PlayerDto> playerDtos = _dataAccess.GetAllPlayerDtos();
            List<Player> players = Mapper.Map<List<Player>>(playerDtos);
            return players;
        }

        public List<Player> GetPlayers(int teamId)
        {
            List<PlayerDto> playerDtos = _dataAccess.GetPlayerDtos(teamId);
            List<Player> players = Mapper.Map<List<Player>>(playerDtos);
            return players;
        }

        public List<Team> GetAllTeams()
        {
            List<TeamDto> teamDtos = _dataAccess.GetAllTeamDtos();
            List<Team> teams = Mapper.Map<List<Team>>(teamDtos);
            return teams;
        }        

        public List<Team> GetAllTeamsWithPlayers()
        {
            List<PlayerDto> playerDtos = _dataAccess.GetAllPlayerDtos();
            List<TeamDto> teamDtos = _dataAccess.GetAllTeamDtos();
            foreach (TeamDto team in teamDtos)
            {
                var players = playerDtos.Where(x => x.TeamId == team.Id).ToList();
                team.Players = players;
            }
            
            List<Team> teams = Mapper.Map<List<Team>>(teamDtos);

            return teams;
        }

        public Team GetTeamWithPlayers(int teamId)
        {
            List<PlayerDto> playerDtos = _dataAccess.GetPlayerDtos(teamId);
            TeamDto teamDto = _dataAccess.GetTeamDto(teamId);
            teamDto.Players = playerDtos;

            Team team = Mapper.Map<Team>(teamDto);

            return team;
        }

        public void SaveGame(Game game)
        {
            GameDto gameDto = Mapper.Map<GameDto>(game);
            _dataAccess.SaveGame(gameDto);
        }       
    }
}
