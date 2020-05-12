using System.Web.Mvc;
using Bookie_BL;
using FGM_Model;

namespace FGM.Controllers
{
    public class BookieController : Controller
    {
        // GET: Bookie
        public ActionResult BookieConfirm()
        {
            return View();
        }

        [HttpGet]
        public string BookieConfirm_Select(string MatchDate)
        {
            BookieBL BBL = new BookieBL();
            BookieModel BModel = new BookieModel();
            BModel.MatchDate = MatchDate;
            return BBL.BookieConfirm_Select(BModel);
        }
    }
}