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

namespace DataAccess
{
    public class DataAccess : IDataAccess
    {
        public List<object> Test()
        {
            List<object> FriendList = new List<object>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["UniHockeyDbConnection"].ConnectionString))
            {
                FriendList = db.Query<object>("SELECT * FROM [UniHockey].[dbo].[Player]").ToList();
            }
            return FriendList;
        }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public int GoalsToDate { get; set; }
        public int GoalsForCurrentGame { get; set; }
    }
}
