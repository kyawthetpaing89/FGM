using System.Data;
using System.Data.SqlClient;
using FGM_DL;
using CommonFunction;
using FGM_Model;
using System;

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
    }
}
