using System.Collections.Generic;
using System.Web.Mvc;
using FGM_Model;
using Match_BL;

namespace FGM.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        public ActionResult MatchEntry()
        {
            return View();
        }

        public ActionResult BookieOddsEntry()
        {
            return View();
        }

        [HttpPost]
        public string Match_Save(string Table, string MatchDate)
        {
            if (Session["UserInfo"] == null)
                return "false";

            string userInfo = Session["UserInfo"] as string;

            MatchBL MBL = new MatchBL();
            MatchModel MModel = new MatchModel();
            MModel.MatchDate = MatchDate;
            MModel.MatchJson = Table;
            MModel.UserID = userInfo.Split('_')[0];

            return MBL.Match_Save(MModel);        
        }

        [HttpGet]
        public string GetMatch(string MatchDate)
        {
            MatchBL MBL = new MatchBL();
            MatchModel MModel = new MatchModel();
            MModel.MatchDate = MatchDate;
            return MBL.GetMatch(MModel);
        }
    }
}