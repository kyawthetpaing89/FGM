using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Odds_BL;

namespace FGM.Controllers
{
    public class OddsController : Controller
    {
        // GET: Odds
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserOddsHistory()
        {
            return View();
        }

        [HttpGet]
        public string GetOdds()
        {
            OddsBL OBL = new OddsBL();
            return OBL.GetOdds();
        }
    }
}