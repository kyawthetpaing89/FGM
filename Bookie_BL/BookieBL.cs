using CommonFunction;
using FGM_DL;
using FGM_Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Bookie_BL
{
    public class BookieBL
    {
        public string BookieConfirm_Select(BookieModel BModel)
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            DateTime dt = DateTime.ParseExact(BModel.MatchDate.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-us"));
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@MatchDate", SqlDbType.Date) { Value = dt };
            DataTable DTBookieConfirm = bdl.SelectData("M_Match_BookieConfirm_Select", prms);
            return fun.DataTableToJSONWithJSONNet(DTBookieConfirm);
        }
    }
}
