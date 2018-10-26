using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Models;
using Services.Abstract;
using AutoMapper;
using Entities.DTO;

namespace UniHockey.Controllers
{
    public class GameController : Controller
    {
        private IBusinessService _businessService;
        public GameController(IBusinessService businessService)
        {
            _businessService = businessService;
        }
        public ActionResult Index(Tournament tournament)
        {
            List<Team> teams = _businessService.GetTeamsWithPlayers();
            Game game = new Game
            {
                Team1 = teams.Where(x => x.Id == tournament.Team1Id).FirstOrDefault(),
                Team2 = teams.Where(x => x.Id == tournament.Team2Id).FirstOrDefault()
            };

            return View(game);
        }

        public string SaveGame(Game game)
        {
            /*
             * Save the following:
            Player ID,
            GoalsForCurrentGame
            Team1Score
            Team2Score
             */
            return "";
        }
    }
}