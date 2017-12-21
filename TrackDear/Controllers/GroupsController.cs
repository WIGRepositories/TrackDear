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
    public class GroupsController : ApiController
    {
        [HttpGet]
        [Route("api/Groups/GetGroups")]
        public DataTable GetGroups(int Id)
        {
            
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetGroups";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            db.Fill(tbl);
            return tbl;
        }
        [HttpPost]
        [Route("api/Groups/Groups")]
        public int Groups(Groups gr)
        {
            
            SqlConnection Conn = new SqlConnection();
            try
            {
                Conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelGroups";

                SqlParameter id = new SqlParameter("Id", SqlDbType.Int);
                id.Value = gr.Id;
                cmd.Parameters.Add(id);

                SqlParameter na = new SqlParameter("Name", SqlDbType.VarChar, 50);
                na.Value = gr.Name;
                cmd.Parameters.Add(na);

                SqlParameter de = new SqlParameter("Description", SqlDbType.VarChar, 500);
                de.Value = gr.Description;
                cmd.Parameters.Add(de);

                SqlParameter ti = new SqlParameter("Title", SqlDbType.VarChar, 50);
                ti.Value = gr.Title;
                cmd.Parameters.Add(ti);

                SqlParameter ph = new SqlParameter("Photo", SqlDbType.VarChar);
                ph.Value = gr.photo;
                cmd.Parameters.Add(ph);

                SqlParameter ac = new SqlParameter("Active", SqlDbType.Int);
                ac.Value = gr.Active;
                cmd.Parameters.Add(ac);

                SqlParameter f1 = new SqlParameter("Flag", SqlDbType.VarChar);
                f1.Value = gr.flag;
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
                throw (Ex);
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
        [Route("api/Groups/GetGroupusers")]
        public DataTable GetGroupsForUser(string MobileNo)
        {
            
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetGroupusers";

            cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, 10).Value = MobileNo;

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            db.Fill(tbl);
            return tbl;
        }

        [HttpGet]
        [Route("api/Groups/GetGroupDetails")]
        public DataTable GetGroupDetails(int GroupId)
        {
            
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetGroupDetails";

            cmd.Parameters.Add("@GroupId", SqlDbType.VarChar, 10).Value = GroupId;

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            db.Fill(tbl);
            return tbl;
        }
    }
}
