using System.Web.Mvc;
using Bookie_BL;
using FGM_Model;
using UserGambling_BL;

namespace FGM.Controllers
{
    public class BookieController : Controller
    {
        // GET: Bookie
        public ActionResult BookieConfirm()
        {
            return View();
        }
        public ActionResult BookieGamblingResultDetail()
        {
            return View();
        }

        [HttpGet]
        public string Get_Bookie()
        {
            BookieBL BBL = new BookieBL();
            return BBL.GetBookie();
        }

        [HttpGet]
        public string BookieConfirm_Select(string MatchDate)
        {
            BookieBL BBL = new BookieBL();
            BookieModel BModel = new BookieModel();
            BModel.MatchDate = MatchDate;
            return BBL.BookieConfirm_Select(BModel);
        }

        [HttpGet]
        public string UserGambling_Select(string MatchID)
        {
            UserGamblingBL UGBL = new UserGamblingBL();
            MatchModel MModel = new MatchModel();
            MModel.MatchID = MatchID ;
            return UGBL.UserGambling_Select(MModel);
        }

        [HttpPost]
        public string BookieConfirmSave(string Table,string MatchDate)
        {
            if (Session["UserInfo"] == null)
                return "2";//session time out
            string userInfo = Session["UserInfo"] as string;

            BookieBL BBL = new BookieBL();
            BookieModel BModel = new BookieModel();
            BModel.MatchDate = MatchDate;
            BModel.BookieConfirmJson = Table;
            BModel.UserID = userInfo.Split('_')[0];

            return BBL.BookieConfirm_Insert(BModel);
        }
    }
}