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
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<PlayerDto>("SELECT * FROM Player").ToList();
            }
        }

        public List<PlayerDto> GetPlayerDtos(int teamId)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<PlayerDto>($"SELECT * FROM Player WHERE TeamId = @teamId", new { teamId }).ToList();
            }
        }

        public List<TeamDto> GetAllTeamDtos()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TeamDto>("SELECT * FROM Team").ToList();
            }
        }

        public TeamDto GetTeamDto(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<TeamDto>("SELECT * FROM Team WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public int SaveGame(int team1Id, int team2Id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string sql = @"INSERT INTO Game (Team1Id, Team2Id) VALUES (@Team1Id, @Team2Id);
                               SELECT CAST(SCOPE_IDENTITY() as int)";
                int gameId = db.Query<int>(sql, new { team1Id, team2Id }).Single();
                return gameId;
            }
        }
    }
}