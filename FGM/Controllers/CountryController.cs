using System.Web.Mvc;
using Country_BL;
using FGM_Model;

namespace FGM.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult CountryList()
        {
            return View();
        }

        [HttpGet]
        public string GetCountry()
        {
            CountryBL CBL = new CountryBL();
            CountryModel CModel = new CountryModel();
            return CBL.GetCountry(CModel);
        }
    }
}