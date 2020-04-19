using FGM_DL;
using FGM_Model;
using CommonFunction;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace UserGambling_BL
{
    public class UserGamblingBL
    {
        public string GetUserGambling(MatchModel MModel)
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            DateTime dt = DateTime.ParseExact(MModel.MatchDate.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-us"));
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@MatchDate", SqlDbType.Date) { Value = dt };
            DataTable DTMatch = bdl.SelectData("M_Match_User_Gambling_Select", prms);
            return fun.DataTableToJSONWithJSONNet(DTMatch);
        }
    }
}
