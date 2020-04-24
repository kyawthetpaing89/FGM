﻿using FGM_DL;
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
            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = new SqlParameter("@MatchDate", SqlDbType.Date) { Value = dt };
            prms[1] = new SqlParameter("@UserID", SqlDbType.VarChar) { Value = MModel.UserID };
            DataTable DTMatch = bdl.SelectData("M_Match_User_Gambling_Select", prms);
            return fun.DataTableToJSONWithJSONNet(DTMatch);
        }

        public string UserGambling_Insert(MatchModel MModel)
        {
            BaseDL bdl = new BaseDL();
            DateTime dt = DateTime.ParseExact(MModel.MatchDate.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-us"));
            SqlParameter[] prms = new SqlParameter[4];
            prms[0] = new SqlParameter("@UserID", SqlDbType.VarChar) { Value = MModel.UserID };
            prms[1] = new SqlParameter("@MatchJson", SqlDbType.VarChar) { Value = MModel.MatchJson };
            prms[2] = new SqlParameter("@MatchDate", SqlDbType.Date) { Value = dt };
            prms[3] = new SqlParameter("@UserID1", SqlDbType.VarChar) { Value = MModel.UserID1 };

            if (bdl.InsertUpdateDeleteData("UserGambling_Insert", prms))
                return "true";
            return "false";
        }
        
    }
}
