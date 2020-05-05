using System.Collections.Generic;
using System.Web.Mvc;
using FGM_Model;
using Match_BL;
using UserGambling_BL;

namespace FGM.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        public ActionResult MatchEntry()
        {
            return View();
        }

        public ActionResult MatchResultEntry()
        {
            return View();
        }

        public ActionResult BookieOddsEntry()
        {
            return View();
        }

        public ActionResult UserOddsEntry()
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

        [HttpPost]
        public string Match_OddsUpdate(string Table, string MatchDate)
        {
            if (Session["UserInfo"] == null)
                return "false";

            string userInfo = Session["UserInfo"] as string;

            MatchBL MBL = new MatchBL();
            MatchModel MModel = new MatchModel();
            MModel.MatchDate = MatchDate;
            MModel.MatchJson = Table;
            MModel.UserID = userInfo.Split('_')[0];

            return MBL.Match_OddsUpdate(MModel);
        }
     
        [HttpGet]
        public string GetMatch(string MatchDate)
        {
            MatchBL MBL = new MatchBL();
            MatchModel MModel = new MatchModel();
            MModel.MatchDate = MatchDate;
            return MBL.GetMatch(MModel);
        }

        [HttpGet]
        public string GetMatch_UserGambling(string Param)
        {
            UserGamblingBL UGBL = new UserGamblingBL();
            MatchModel MModel = new MatchModel();
            MModel.MatchDate = Param.Split('_')[0];
            MModel.UserID = Param.Split('_')[1];
            return UGBL.GetUserGambling(MModel);
        }

        [HttpPost]
        public string UserGambling_Insert(string Table, string Param)
        {
            if (Session["UserInfo"] == null)
                return "false";

            string userInfo = Session["UserInfo"] as string;

            UserGamblingBL UGBL = new UserGamblingBL();
            MatchModel MModel = new MatchModel();
            MModel.MatchDate = Param.Split('_')[0];
            MModel.MatchJson = Table;
            MModel.UserID = userInfo.Split('_')[0];
            MModel.UserID1 = Param.Split('_')[1];

            return UGBL.UserGambling_Insert(MModel);
        }

        [HttpPost]
        public string MatchResult_Update(string Table)
        {
            if (Session["UserInfo"] == null)
                return "false";
            string userInfo = Session["UserInfo"] as string;

            MatchBL MBL = new MatchBL();
            MatchModel MModel = new MatchModel();
            MModel.MatchJson = Table;
            MModel.UserID = userInfo.Split('_')[0];

            return MBL.MatchResult_Update(MModel);
        }
    }
}