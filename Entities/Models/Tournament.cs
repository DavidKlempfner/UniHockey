﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entities.Models
{
    public class Tournament
    {
        public IEnumerable<SelectListItem> Teams { get; set; }

        public List<TeamWithPointsBroughtForward> SelectedTeams { get; set; }

        [DisplayName("Team1")]
        public int Team1Id { get; set; }
        [DisplayName("Team2")]
        public int Team2Id { get; set; }
    }

    public class TeamWithPointsBroughtForward
    {
        public string Team { get; set; }
        public int Points { get; set; }
    }
}