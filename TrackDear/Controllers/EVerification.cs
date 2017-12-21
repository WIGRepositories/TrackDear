using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackDear.Models;

namespace TrackDear.Controllers
{
    public class EVerificationController : ApiController
    {      

        [HttpPost]
        public int  EmailVerification(Email ema)
        {
            
            
            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "InsUpdEVerification";

                SqlParameter id = new SqlParameter("Email", SqlDbType.VarChar,50);
                id.Value = ema.EmailId;
                cmd.Parameters.Add(id);               

                SqlParameter lon = new SqlParameter("EmailOtp", SqlDbType.VarChar,150);
                lon.Value = ema.EmailOtp;
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

    
   




   