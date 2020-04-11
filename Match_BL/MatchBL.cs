﻿using FGM_DL;
using System.Data;
using System.Data.SqlClient;
using FGM_Model;
using System;
using System.Globalization;

namespace Match_BL
{
    public class MatchBL
    {
        public string Match_Save(MatchModel MModel)
        {
            BaseDL bdl = new BaseDL();
            DateTime dt = DateTime.ParseExact(MModel.MatchDate.Replace("-","/"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-us"));
            SqlParameter[] prms = new SqlParameter[3];
            prms[0] = new SqlParameter("@UserID", SqlDbType.VarChar) { Value = MModel.UserID };
            prms[1] = new SqlParameter("@MatchJson", SqlDbType.VarChar) { Value = MModel.MatchJson };
            prms[2] = new SqlParameter("@MatchDate", SqlDbType.Date) { Value = dt };

            if (bdl.InsertUpdateDeleteData("M_Match_Insert", prms))
                return "true";
            return "false";
        }
    }
}