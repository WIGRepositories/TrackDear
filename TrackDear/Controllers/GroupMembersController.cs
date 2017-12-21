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
    public class GroupMembersController : ApiController
    {
        [HttpGet]
        [Route("api/GroupMembers/GroupMembers")]
        public DataTable GetGroupMembers(string name)
        {
            
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetGroupMembers";

            cmd.Parameters.Add("@gname", SqlDbType.VarChar, 50).Value = name;


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            db.Fill(tbl);
            return tbl;
        }
        [HttpPost]
        [Route("api/GroupMembers/GroupMembers")]
        public int GroupMembers(GroupMembers gm)
        {

            
            SqlConnection Conn = new SqlConnection();
            try
            {
                Conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelGroupMembers";

                SqlParameter gi = new SqlParameter("GroupId", SqlDbType.Int);
                gi.Value = gm.GroupId;
                cmd.Parameters.Add(gi);

                SqlParameter oi = new SqlParameter("OwnerId", SqlDbType.Int);
                oi.Value = gm.OwnerId;
                cmd.Parameters.Add(oi);

                SqlParameter mi = new SqlParameter("MemberId", SqlDbType.Int);
                mi.Value = gm.memberId;
                cmd.Parameters.Add(mi);

                SqlParameter fi = new SqlParameter("FCMID", SqlDbType.VarChar, 50);
                fi.Value = gm.FCMID;
                cmd.Parameters.Add(fi);

                SqlParameter id = new SqlParameter("Id", SqlDbType.Int);
                id.Value = gm.Id;
                cmd.Parameters.Add(id);

                SqlParameter fl = new SqlParameter("flag", SqlDbType.VarChar);
                fl.Value = gm.flag;
                cmd.Parameters.Add(fl);

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

        [HttpGet]
        [Route("api/GroupMembers/GroupMemberDetails")]
        public DataTable GroupMemberDetails(int MemberId)
        {
            
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GroupMemberDetails";

            cmd.Parameters.Add("@MemberId", SqlDbType.VarChar, 50).Value = MemberId;


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            db.Fill(tbl);
            return tbl;

        }
    }
}
