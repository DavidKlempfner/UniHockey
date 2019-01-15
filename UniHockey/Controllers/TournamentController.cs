using Entities.Models;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniHockey.Controllers
{
    public class TournamentController : Controller
    {
        private IBusinessService _businessService;
        public TournamentController(IBusinessService businessService)
        {
            _businessService = businessService;
        }
        public ActionResult Index()
        {            
            Tournament tournament = CreateTournament();
            return View(tournament);
        }

        private Tournament CreateTournament()
        {            
            List<Team> teams = _businessService.GetAllTeams();
            Tournament tournament = new Tournament();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (Team team in teams)
            {
                selectListItems.Add(new SelectListItem { Text = team.Name, Value = team.Id.ToString() });
            }
            tournament.Teams = selectListItems;
            return tournament;
        }
    }
}