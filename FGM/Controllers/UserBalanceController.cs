using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserBalance_BL;
using FGM_Model;

namespace FGM.Controllers
{
    public class UserBalanceController : Controller
    {
        // GET: UserBalance
        public ActionResult UserBalanceList()
        {
            return View();
        }

        [HttpGet]
        public string GetUserBalance()
        {
            UserBalanceBL ubbl = new UserBalanceBL();
            return ubbl.GetUserBalance();
        }

        [HttpPost]
        public string GetUserBalanceByDetailDate(string id)
        {
            UserBalanceBL ubbl = new UserBalanceBL();
            UserBalanceModel UBM = new UserBalanceModel();
            UBM.UserID = id.Split('_')[0];
            return ubbl.GetUserBalanceByDetailDate(UBM);
        }
    }
}