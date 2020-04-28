using System.Data;
using System.Data.SqlClient;
using FGM_DL;
using CommonFunction;
using FGM_Model;
using System;
using System.Globalization;

namespace UserBalance_BL
{
    public class UserBalanceBL
    {
        public string GetUserBalance()
        {
            BaseDL BDL = new BaseDL();
            Function FUN = new Function();
            SqlParameter[] prms = new SqlParameter[0];
            DataTable DtUserBalance = BDL.SelectData("UserBalance_Select", prms);
            return FUN.DataTableToJSONWithJSONNet(DtUserBalance);
        }

        public string GetUser()
        {
            BaseDL BDL = new BaseDL();
            Function FUN = new Function();
            SqlParameter[] prms = new SqlParameter[0];
            DataTable DtUser = BDL.SelectData("M_User_Select", prms);
            return FUN.DataTableToJSONWithJSONNet(DtUser);
        }

        public string GetUserBalanceByDetailDate(UserBalanceModel UBModel)
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@UserID", SqlDbType.VarChar) { Value = string.IsNullOrWhiteSpace(UBModel.UserID) ? (object)DBNull.Value : UBModel.UserID };
            DataTable DtCinemaIncome = bdl.SelectData("M_UserBalance_DetailSelect", prms);
            return fun.DataTableToJSONWithJSONNet(DtCinemaIncome);
        }

        public string DailyUserBalance_UserSelectBind()
        {
            BaseDL BDL = new BaseDL();
            Function FUN = new Function();
            SqlParameter[] prms = new SqlParameter[0];
            DataTable DtUserSelect = BDL.SelectData("M_UserBalance_Select", prms);
            return FUN.DataTableToJSONWithJSONNet(DtUserSelect);
        }

        public string GetDailyUserBalance_List(UserBalanceModel UBModel)
        {            
            BaseDL BDL = new BaseDL();
            Function FUN = new Function();
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@UserID", SqlDbType.VarChar) { Value = string.IsNullOrWhiteSpace(UBModel.UserID) ? (object)DBNull.Value : UBModel.UserID };
            DataTable DtBLList = BDL.SelectData("M_UserBalance_BalanceSelect", prms);
            return FUN.DataTableToJSONWithJSONNet(DtBLList);
        }

        public string GetUserTranstionEntry(UserBalanceModel UBModel)
        {
            BaseDL BDL = new BaseDL();
            Function FUN = new Function();
            SqlParameter[] prms = new SqlParameter[5];
            DateTime dt = DateTime.ParseExact(UBModel.PayDate.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-us"));
            prms[0] = new SqlParameter("@PayDate", SqlDbType.Date) { Value = dt };
            prms[1] = new SqlParameter("@UserID", SqlDbType.VarChar) { Value = string.IsNullOrWhiteSpace(UBModel.UserID) ? (object)DBNull.Value : UBModel.UserID };
            prms[2] = new SqlParameter("@TransitionType", SqlDbType.TinyInt) { Value = string.IsNullOrWhiteSpace(UBModel.TransitionType) ? (object)DBNull.Value : UBModel.TransitionType };
            prms[3] = new SqlParameter("@Amount", SqlDbType.Int) { Value = string.IsNullOrWhiteSpace(UBModel.Amount) ? (object)DBNull.Value : UBModel.Amount };
            prms[4] = new SqlParameter("@OperatorMode", SqlDbType.VarChar) { Value = string.IsNullOrWhiteSpace(UBModel.OperatorMode) ? (object)DBNull.Value : UBModel.OperatorMode };

            if (BDL.InsertUpdateDeleteData("User_Transition_Insert", prms))
                return "true";
            return "false";
        }

        public string DataIsExists(UserBalanceModel UBModel)
        {
            BaseDL BDL = new BaseDL();
            Function FUN = new Function();
            SqlParameter[] prms = new SqlParameter[2];

            DateTime dt = DateTime.ParseExact(UBModel.PayDate.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-us"));
            prms[0] = new SqlParameter("@PayDate", SqlDbType.Date) { Value = dt };
            prms[1] = new SqlParameter("@UserID", SqlDbType.VarChar) { Value = string.IsNullOrWhiteSpace(UBModel.UserID) ? (object)DBNull.Value : UBModel.UserID };
            DataTable DtResult = BDL.SelectData("User_Transition_DataExists", prms);
            if (DtResult.Rows.Count > 0)
                return "true";
            return "false";
        }
    }
}
