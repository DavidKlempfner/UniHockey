using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entities.DTO;

namespace DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["UniHockeyDbConnection"].ConnectionString;
        public List<PlayerDto> GetAllPlayerDtos()
        {
            List<PlayerDto> players = new List<PlayerDto>();
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                players = db.Query<PlayerDto>("SELECT * FROM [UniHockey].[dbo].[Player]").ToList();
            }
            return players;
        }

        public List<PlayerDto> GetPlayerDtos(int teamId)
        {
            List<PlayerDto> players = new List<PlayerDto>();
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                players = db.Query<PlayerDto>($"SELECT * FROM [UniHockey].[dbo].[Player] WHERE TeamId = {teamId}").ToList();
            }
            return players;
        }

        public List<TeamDto> GetAllTeamDtos()
        {
            List<TeamDto> teams = new List<TeamDto>();
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                teams = db.Query<TeamDto>("SELECT * FROM [UniHockey].[dbo].[Team]").ToList();
            }
            return teams;
        }

        public TeamDto GetTeamDto(int id)
        {
            TeamDto team = new TeamDto();
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                team = db.Query<TeamDto>($"SELECT * FROM [UniHockey].[dbo].[Team] WHERE Id = {id}").FirstOrDefault();
            }
            return team;
        }

        public void SaveGame(GameDto gameDto)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute($"INSERT INTO [UniHockey].[dbo].[Game] ([Team1Id], [Team2Id], [Team1GoalsForCurrentGame], [Team2GoalsForCurrentGame]) VALUES ({gameDto.Team1.Id}, {gameDto.Team2.Id}, {gameDto.Team1.GoalsForCurrentGame}, {gameDto.Team2.GoalsForCurrentGame})");
            }
        }
    }
}
