using System;
using System.Data;
using System.Data.SqlClient;
using CommonFunction;
using FGM_DL;
using FGM_Model;

namespace User_BL
{
    public class UserBL
    {
        public string GetGamblers()
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            SqlParameter[] prms = new SqlParameter[0];
            DataTable DTGamblers = bdl.SelectData("M_User_Select", prms);
            return fun.DataTableToJSONWithJSONNet(DTGamblers);
        }
    }
}
