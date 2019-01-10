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
        public int Team1Goals { get; set; }
        public int Team2Goals { get; set; }
    }
}