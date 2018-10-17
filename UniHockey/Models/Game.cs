using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniHockey.Models
{
    public class Game
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public Team Winner
        {
            get
            {
                return Team1Score > Team2Score ? Team1 : Team2;
            }
        }
        public Team Loser
        {
            get
            {
                return Team2Score > Team1Score ? Team2 : Team1;
            }
        }
        public bool IsDraw
        {
            get
            {
                return Team1Score == Team2Score;
            }
        }
    }
}