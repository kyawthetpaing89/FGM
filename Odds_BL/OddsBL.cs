using System.Data;
using System.Data.SqlClient;
using FGM_DL;
using CommonFunction;

namespace Odds_BL
{
    public class OddsBL
    {
        public string GetOdds()
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            SqlParameter[] prms = new SqlParameter[0];
            DataTable DtOdds = bdl.SelectData("M_Odds_Select", prms);
            return fun.DataTableToJSONWithJSONNet(DtOdds);
        }
    }
}
