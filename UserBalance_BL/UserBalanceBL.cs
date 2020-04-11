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
            DataTable DtCountry = BDL.SelectData("UserBalance_Select", prms);
            return FUN.DataTableToJSONWithJSONNet(DtCountry);
        }

        public string GetUserBalanceByDetailDate(UserBalanceModel UBModel)
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@UserID", SqlDbType.VarChar) { Value = string.IsNullOrWhiteSpace(UBModel.UserID) ? (object)DBNull.Value : UBModel.UserID };
            DataTable DtCinemaIncome = bdl.SelectData("UserBalance_SelectByDetailDate", prms);
            return fun.DataTableToJSONWithJSONNet(DtCinemaIncome);
        }
    }
}
