using System.Web.Mvc;
using User_BL;
using UserGambling_BL;
using FGM_Model;

namespace FGM.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        [HttpGet]
        public string Get_User()
        {
            UserBL UBL = new UserBL();
            return UBL.GetGamblers();
        }

        [HttpGet]
        public string UserGamblingResult_Select(string MatchDate)
        {
            UserGamblingBL UGBL = new UserGamblingBL();
            MatchModel MModel = new MatchModel();
            MModel.MatchDate = MatchDate;
            return UGBL.UserGamblingResult_Select(MModel);
        }

        [HttpGet]
        public string BookieGamblingResult_Select(string MatchDate)
        {
            UserGamblingBL UGBL = new UserGamblingBL();
            MatchModel MModel = new MatchModel();
            MModel.MatchDate = MatchDate;
            return UGBL.BookieGamblingResult_Select(MModel);
        }

        public ActionResult GotoLink(string URL)
        {
            string UserID = URL.Split('_')[0];
            string UserName = URL.Split('_')[1];
            if(Session["UserInfo"] == null)
                Session["UserInfo"] = UserID + "_" + UserName;
            string Link = URL.Split('_')[2];
            return Redirect(Link);
        }

        public ActionResult UserGamblingResult()
        {
            return View();
        }

        public ActionResult UserGamblingResultDetail()
        {
            return View();
        }       

        [HttpGet]
        public string UserGamblingCalculate(string MatchDate)
        {
            if (Session["UserInfo"] == null)
                return "STO";
            string userInfo = Session["UserInfo"] as string;

            UserGamblingBL UGBL = new UserGamblingBL();
            MatchModel MModel = new MatchModel();
            MModel.MatchDate = MatchDate;
            MModel.UserID = userInfo.Split('_')[0];

            return UGBL.UserGambling_Calculate(MModel);
        }
    }
}