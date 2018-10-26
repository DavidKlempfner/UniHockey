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
        private const string ConnectionName = "UniHockeyDbConnection";
        public List<PlayerDto> GetPlayerDtos()
        {
            List<PlayerDto> players = new List<PlayerDto>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString))
            {
                players = db.Query<PlayerDto>("SELECT * FROM [UniHockey].[dbo].[Player]").ToList();
            }
            return players;
        }

        public List<TeamDto> GetTeamDtos()
        {
            List<TeamDto> teams = new List<TeamDto>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString))
            {
                teams = db.Query<TeamDto>("SELECT * FROM [UniHockey].[dbo].[Team]").ToList();
            }
            return teams;
        }

        public void SaveGame(GameDto gameDto)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString))
            {
                db.Execute($"INSERT INTO [UniHockey].[dbo].[Game] ([Team1Id], [Team2Id], [Team1GoalsForCurrentGame], [Team2GoalsForCurrentGame]) VALUES ({gameDto.Team1.Id}, {gameDto.Team2.Id}, {gameDto.Team1.GoalsForCurrentGame}, {gameDto.Team2.GoalsForCurrentGame})");
            }
        }
    }
}
