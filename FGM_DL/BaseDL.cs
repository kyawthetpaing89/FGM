using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FGM_DL
{
    public class BaseDL
    {
        public string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public DataTable SelectData(string sSQL, params SqlParameter[] para)
        {
            DataTable dt = new DataTable();
            var newCon = new SqlConnection(conStr);
            using (var adapt = new SqlDataAdapter(sSQL, newCon))
            {
                newCon.Open();
                adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    adapt.SelectCommand.Parameters.AddRange(para);
                adapt.Fill(dt);
                newCon.Close();
            }
            return dt;
        }

        public bool InsertUpdateDeleteData(string sSQL, params SqlParameter[] para)
        {
            var newCon = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sSQL, newCon)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {

                cmd.Parameters.AddRange(para);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
