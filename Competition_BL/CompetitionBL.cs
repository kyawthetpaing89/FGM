using FGM_Model;
using FGM_DL;
using CommonFunction;
using System.Data.SqlClient;
using System.Data;

namespace Competition_BL
{
    public class CompetitionBL
    {
        public string GetCompetition(CompetitionModel CModel)
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            SqlParameter[] prms = new SqlParameter[0];
            DataTable DtCompetition = bdl.SelectData("M_Competition_Select", prms);
            return fun.DataTableToJSONWithJSONNet(DtCompetition);
        }
    }
}
