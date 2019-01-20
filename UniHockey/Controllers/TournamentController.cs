using Entities.Models;
using Entities.ViewModels;
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
            TournamentViewModel tournament = CreateTournamentViewModel();
            return View(tournament);
        }

        private TournamentViewModel CreateTournamentViewModel()
        {            
            List<Team> teams = _businessService.GetAllTeams();
            TournamentViewModel tournament = new TournamentViewModel();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (Team team in teams)
            {
                selectListItems.Add(new SelectListItem { Text = team.Name, Value = team.Id.ToString() });
            }
            tournament.Teams = selectListItems;
            return tournament;
        }

        [HttpGet]
        public JsonResult GetPointsBrought()
        {
            var result = _businessService.GetTeamsWithPointsBroughtToNextTournament();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}