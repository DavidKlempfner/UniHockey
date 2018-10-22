using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniHockey.Models;
using Services.Abstract;

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
            List<Team> teams = GetTeams();            
            Game game = new Game
            {
                Team1 = teams.Where(x => x.Id == tournament.Team1Id).FirstOrDefault(),
                Team2 = teams.Where(x => x.Id == tournament.Team2Id).FirstOrDefault()
            };

            return View(game);
        }

        public ActionResult SaveGame(Game game)
        {
            /*
             * Save the following:
            Player ID,
            GoalsForCurrentGame
            Team1Score
            Team2Score
             */
            _businessService.TestMethod();
            return View();
        }

        private List<Team> GetTeams()
        {
            //TODO: use a DAL
            Player steve = new Player { Id = 1, Name = "Steve", TeamId = 1, GoalsToDate = 42 };
            Player dave = new Player { Id = 2, Name = "Dave", TeamId = 1, GoalsToDate = 2 };
            Player nicho = new Player { Id = 3, Name = "Nicho", TeamId = 1, GoalsToDate = 5 };

            Team communists = new Team { Id = 1, Name = "Communists", Players = new List<Player> { steve, dave, nicho } };

            Player jack = new Player { Id = 4, Name = "Jack", TeamId = 2, GoalsToDate = 1 };
            Player scott = new Player { Id = 5, Name = "Scott", TeamId = 2, GoalsToDate = 3 };
            Player travis = new Player { Id = 6, Name = "Travis", TeamId = 2, GoalsToDate = 6 };

            Team wombats = new Team { Id = 2, Name = "Wombats", Players = new List<Player> { jack, scott, travis } };

            return new List<Team> { communists, wombats };
        }
    }
}