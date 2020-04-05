using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team_BL;

namespace FGM.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult TeamList()
        {
            return View();
        }
        [HttpGet]
        public string GetTeam()
        {
            TeamBL TBL = new TeamBL();
            return TBL.GetTeam();
        }
    }
}