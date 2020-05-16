using System.Web.Mvc;
using User_BL;

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

        public ActionResult GotoLink(string URL)
        {
            string UserID = URL.Split('_')[0];
            string UserName = URL.Split('_')[1];
            if(Session["UserInfo"] == null)
                Session["UserInfo"] = UserID + "_" + UserName;
            string Link = URL.Split('_')[2];
            return Redirect(Link);
        }
    }
}