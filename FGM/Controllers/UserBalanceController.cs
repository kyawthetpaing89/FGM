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

        public ActionResult DaliyUserBalanceList()
        {
            return View();
        }

        public ActionResult UserTransitionEntry()
        {
            return View();
        }

        [HttpGet]
        public string GetUserBalance()
        {
            UserBalanceBL ubbl = new UserBalanceBL();
            return ubbl.GetUserBalance();
        }
        [HttpGet]
        public string GetUser()
        {
            UserBalanceBL ubbl = new UserBalanceBL();
            return ubbl.GetUser();
        }
        [HttpPost]
        public string GetUserBalanceByDetailDate(string id)
        {
            UserBalanceBL ubbl = new UserBalanceBL();
            UserBalanceModel UBM = new UserBalanceModel();
            UBM.UserID = id.Split('_')[0];
            return ubbl.GetUserBalanceByDetailDate(UBM);
        }
        [HttpPost]
        public string GetUserBalanceUser()
        {
            if (Session["UserInfo"] == null)
                return "false";

            string userInfo = Session["UserInfo"] as string;
            string UserID= userInfo.Split('_')[0];
            string UserName= userInfo.Split('_')[1];
            

            UserBalanceBL ubbl = new UserBalanceBL();
            return ubbl.DailyUserBalance_UserSelectBind();
        }
        [HttpPost]
        public string GetDailyUserBalance_List(string UserID)
        {
            UserBalanceModel ubm = new UserBalanceModel();
            ubm.UserID = UserID.ToString();
            UserBalanceBL ubbl = new UserBalanceBL();
            return ubbl.GetDailyUserBalance_List(ubm);
        }
        [HttpPost]
        public string GetUserTranstionEntry(string usEntry)
        {
            UserBalanceModel ubm = new UserBalanceModel();
            UserBalanceBL ubbl = new UserBalanceBL();
            if (Session["UserInfo"] == null)
                return "false";

            string userInfo = Session["UserInfo"] as string;
            string UserID = userInfo.Split('_')[0];

            string[] USEntry = usEntry.Split('/');
            ubm.PayDate =USEntry[0].ToString();
            ubm.UserID = USEntry[1].ToString();
            ubm.TransitionType = USEntry[2].ToString();
            ubm.Amount = USEntry[3].ToString();
            ubm.OperatorMode = UserID;
            return ubbl.GetUserTranstionEntry(ubm);
        }
    }
}