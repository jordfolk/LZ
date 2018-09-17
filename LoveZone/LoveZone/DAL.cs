using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveZone
{
    class DAL
    {
        public static DataTable ExecSP(string spName, List<SqlParameter> sqlParams = null)
        {
            string strConnect = "Server=tcp:lovezone.database.windows.net,1433;Initial Catalog=LoveZone;Persist Security Info=False;User ID=LoveZoneAdmin;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlConnection conn = new SqlConnection();

            DataTable dt = new DataTable();

            try
            {
                conn = new SqlConnection(strConnect);
                conn.Open();

                SqlCommand cmd = new SqlCommand(spName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddRange(sqlParams.ToArray());

                SqlCommand command = conn.CreateCommand();
                SqlDataReader dr = cmd.ExecuteReader();

                dt.Load(dr);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
    }
}
