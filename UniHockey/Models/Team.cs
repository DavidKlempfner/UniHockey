using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniHockey.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }        
        public int GoalsToDate { get; set; }
        public int GoalsForCurrentGame { get; set; }
    }
}