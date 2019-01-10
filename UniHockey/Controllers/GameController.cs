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
            Team team1 = _businessService.GetTeamWithPlayers(tournament.Team1Id);
            Team team2 = _businessService.GetTeamWithPlayers(tournament.Team2Id);

            Game game = new Game
            {
                Team1 = team1,
                Team2 = team2
            };

            return View(game);
        }

        public void SaveGame(Game game)
        {            
            _businessService.SaveGame(game);            
        }
    }
}