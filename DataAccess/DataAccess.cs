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

        public void SaveGame(GameDto gameDto)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute("INSERT INTO Game ([Team1Id], [Team2Id], [Team1Goals], [Team2Goals]) VALUES (@Team1Id, @Team2Id, @Team1Goals, @Team2Goals)", new { Team1Id = gameDto.Team1.Id, Team2Id = gameDto.Team2.Id, gameDto.Team1Goals, gameDto.Team2Goals });
                /*
             * Save the following:
            Player ID,
            GoalsForCurrentGame
            Team1Score
            Team2Score
             */
            }
        }
    }
}
