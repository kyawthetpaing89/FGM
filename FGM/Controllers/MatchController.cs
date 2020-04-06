using System.Web.Mvc;

namespace FGM.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        public ActionResult MatchEntry()
        {
            return View();
        }
    }
}