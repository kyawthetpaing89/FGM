using System.Web.Mvc;
using Competition_BL;
using FGM_Model;

namespace FGM.Controllers
{
    public class CompetitionController : Controller
    {
        // GET: Competition
        public ActionResult CompetitionList()
        {
            return View();
        }

        [HttpGet]
        public string GetCompetition()
        {
            CompetitionBL CBL = new CompetitionBL();
            CompetitionModel CModel = new CompetitionModel();
            return CBL.GetCompetition(CModel);
        }
    }
}