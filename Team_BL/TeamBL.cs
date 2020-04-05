using System.Data;
using System.Data.SqlClient;
using FGM_DL;
using CommonFunction;

namespace Team_BL
{
    public class TeamBL
    {
        public string GetTeam()
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            SqlParameter[] prms = new SqlParameter[0];
            DataTable DtCountry = bdl.SelectData("M_Team_Select", prms);
            return fun.DataTableToJSONWithJSONNet(DtCountry);
        }
    }
}
