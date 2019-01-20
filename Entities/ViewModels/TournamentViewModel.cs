using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Entities.ViewModels
{
    public class TournamentViewModel
    {
        public IEnumerable<SelectListItem> Teams { get; set; }
        [DisplayName("Team1")]
        public int Team1Id { get; set; }
        [DisplayName("Team2")]
        public int Team2Id { get; set; }
        public const int MaxNumOfTeams = 8;
    }
}
