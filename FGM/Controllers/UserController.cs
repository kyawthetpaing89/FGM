using System.Web.Mvc;
using User_BL;

namespace FGM.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Get_User()
        {
            UserBL UBL = new UserBL();
            return UBL.GetGamblers();
        }
    }
}