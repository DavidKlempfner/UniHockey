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
        public List<PlayerDto> GetPlayers()
        {
            List<PlayerDto> players = new List<PlayerDto>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["UniHockeyDbConnection"].ConnectionString))
            {
                players = db.Query<PlayerDto>("SELECT * FROM [UniHockey].[dbo].[Player]").ToList();
            }
            return players;
        }

        public List<TeamDto> GetTeams()
        {
            List<TeamDto> teams = new List<TeamDto>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["UniHockeyDbConnection"].ConnectionString))
            {
                teams = db.Query<TeamDto>("SELECT * FROM [UniHockey].[dbo].[Team]").ToList();
            }
            return teams;
        }
    }
}
