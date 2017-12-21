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
    public class AcceptRequestController : ApiController
    {
        [HttpPost]
        [Route("api/AcceptRequest/AcceptRejectRequest")]
        public int AcceptRejectRequest(AcceptRequest ar)
        {

            
            SqlConnection Conn = new SqlConnection();
            try
            {
                Conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AcceptRejectRequest";

                SqlParameter ac = new SqlParameter("AcceptRejectRequest", SqlDbType.Int);
                ac.Value = ar.AcceptRejectRequest;
                cmd.Parameters.Add(ac);

                SqlParameter ri = new SqlParameter("RequestNo", SqlDbType.VarChar, 10);
                ri.Value = ar.RequestNo;
                cmd.Parameters.Add(ri);

                SqlParameter mn = new SqlParameter("MobileNo", SqlDbType.VarChar, 10);
                mn.Value = ar.RequestNo;
                cmd.Parameters.Add(mn);

                SqlParameter f1 = new SqlParameter("flag", SqlDbType.VarChar);
                f1.Value = ar.RequestNo;
                cmd.Parameters.Add(f1);

                Conn.Open();
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception Ex)
            {

                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                throw Ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
            return 1;
        }
    }
}
