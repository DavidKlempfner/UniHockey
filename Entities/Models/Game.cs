﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Game
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Team1Goals { get; set; }
        public int Team2Goals { get; set; }
    }
}