using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using TrackDear.Models;
namespace TrackDear.Controllers
{
    public class MVerificationController : ApiController
    {
        [HttpPost]
        [Route("api/MVerification/MVerification")]
        public int MVerification(Email ema)
        {

            
            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString(); 
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "InsUpdMVerification";

                SqlParameter id = new SqlParameter("MobileNo", SqlDbType.VarChar,50);
                id.Value = ema.MobileNo;
                cmd.Parameters.Add(id);                

                SqlParameter lon = new SqlParameter("MobileOtp", SqlDbType.VarChar,10);
                lon.Value = ema.MobileOtp;
                cmd.Parameters.Add(lon);



                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }

            catch (Exception Ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                throw Ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            return 1;
        }
    }
}
