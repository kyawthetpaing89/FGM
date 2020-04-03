using CommonFunction;
using FGM_DL;
using System;
using System.Data;
using System.Data.SqlClient;
using FGM_Model;

namespace Country_BL
{
    public class CountryBL
    {
        public string GetCountry(CountryModel CModel)
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            SqlParameter[] prms = new SqlParameter[0];
            DataTable DtCountry = bdl.SelectData("M_Country_Select", prms);
            return fun.DataTableToJSONWithJSONNet(DtCountry);
        }
    }
}
