using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniHockey.Models;

namespace UniHockey.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Tournament tournament = new Tournament { Winner = "David", Loser = "Steve" }; //
            return View(tournament);
        }
    }
}