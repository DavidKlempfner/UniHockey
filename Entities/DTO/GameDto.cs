using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.DTO
{
    public class GameDto
    {
        public TeamDto Team1 { get; set; }
        public TeamDto Team2 { get; set; }
        //public int Team1Score { get; set; }
        //public int Team2Score { get; set; }
        public TeamDto Winner
        {
            get
            {
                return Team1.GoalsForCurrentGame > Team2.GoalsForCurrentGame ? Team1 : Team2;
            }
        }
        public TeamDto Loser
        {
            get
            {
                return Team2.GoalsForCurrentGame > Team1.GoalsForCurrentGame ? Team2 : Team1;
            }
        }
        public bool IsDraw
        {
            get
            {
                return Team1.GoalsForCurrentGame == Team2.GoalsForCurrentGame;
            }
        }
    }
}