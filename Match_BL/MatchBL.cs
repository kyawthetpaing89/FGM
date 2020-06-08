using FGM_DL;
using System.Data;
using System.Data.SqlClient;
using FGM_Model;
using System;
using System.Globalization;
using CommonFunction;

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
                return "1";
            return "0";
        }

        public string Match_OddsUpdate(MatchModel MModel)
        {
            BaseDL bdl = new BaseDL();
            DateTime dt = DateTime.ParseExact(MModel.MatchDate.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-us"));
            SqlParameter[] prms = new SqlParameter[3];
            prms[0] = new SqlParameter("@UserID", SqlDbType.VarChar) { Value = MModel.UserID };
            prms[1] = new SqlParameter("@MatchJson", SqlDbType.VarChar) { Value = MModel.MatchJson };
            prms[2] = new SqlParameter("@MatchDate", SqlDbType.Date) { Value = dt };

            if (bdl.InsertUpdateDeleteData("M_Match_OddsUpdate", prms))
                return "1";
            return "0";
        }

        public string MatchResult_Update(MatchModel MModel)
        {
            BaseDL bdl = new BaseDL();
            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = new SqlParameter("@UserID", SqlDbType.VarChar) { Value = MModel.UserID };
            prms[1] = new SqlParameter("@MatchJson", SqlDbType.VarChar) { Value = MModel.MatchJson };

            if (bdl.InsertUpdateDeleteData("M_Match_ResultUpdate", prms))
                return "1";
            return "0";
        }

        public string GetMatch(MatchModel MModel)
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            DateTime dt = DateTime.ParseExact(MModel.MatchDate.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-us"));
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@MatchDate", SqlDbType.Date) { Value = dt };
            DataTable DTMatch = bdl.SelectData("M_Match_Select", prms);
            return fun.DataTableToJSONWithJSONNet(DTMatch);
        }

        public string GetLastMatchDate(MatchModel MModel)
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            DateTime dt = DateTime.ParseExact(MModel.MatchDate.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-us"));
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@MatchDate", SqlDbType.Date) { Value = dt };
            DataTable DTMatch = bdl.SelectData("M_Match_SelectLastMatchDate", prms);
            return fun.DataTableToJSONWithJSONNet(DTMatch);
        }

        public string GetPrevMatchDate(MatchModel MModel)
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            DateTime dt = DateTime.ParseExact(MModel.MatchDate.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-us"));
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@MatchDate", SqlDbType.Date) { Value = dt };
            DataTable DTMatch = bdl.SelectData("M_Match_SelectPrevMatchDate", prms);
            return fun.DataTableToJSONWithJSONNet(DTMatch);
        }

        public string GetNextMatchDate(MatchModel MModel)
        {
            BaseDL bdl = new BaseDL();
            Function fun = new Function();
            DateTime dt = DateTime.ParseExact(MModel.MatchDate.Replace("-", "/"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-us"));
            SqlParameter[] prms = new SqlParameter[1];
            prms[0] = new SqlParameter("@MatchDate", SqlDbType.Date) { Value = dt };
            DataTable DTMatch = bdl.SelectData("M_Match_SelectNextMatchDate", prms);
            return fun.DataTableToJSONWithJSONNet(DTMatch);
        }
    }
}
