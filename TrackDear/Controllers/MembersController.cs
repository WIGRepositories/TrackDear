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
    public class MembersController : ApiController
    {
        [HttpGet]
        [Route("api/Members/GetMembers")]
        public DataTable GetMembers(int ownerid)
        {
            
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetMembers";
            cmd.Parameters.Add("ownerid", SqlDbType.Int).Value = ownerid;
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            db.Fill(tbl);
            return tbl;
        }
        [HttpPost]
        [Route("api/Members/Members")]
        public int Members(Members mem)
        {
            
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelMembers";
               

                SqlParameter id = new SqlParameter("Id", SqlDbType.Int);
                id.Value = mem.Id;
                cmd.Parameters.Add(id);

                SqlParameter fn = new SqlParameter("FirstName", SqlDbType.VarChar, 50);
                fn.Value = mem.FirstName;
                cmd.Parameters.Add(fn);

                SqlParameter ln = new SqlParameter("LastName", SqlDbType.VarChar,50);
                ln.Value = mem.LastName;
                cmd.Parameters.Add(ln);

                SqlParameter em = new SqlParameter("Email", SqlDbType. VarChar,150);
                em.Value = mem.Email;
                cmd.Parameters.Add(em);

                SqlParameter mn = new SqlParameter("MobileNo", SqlDbType. VarChar,10);
                mn.Value = mem.MobileNo;
                cmd.Parameters.Add(mn);
               
                SqlParameter add = new SqlParameter("Address", SqlDbType. VarChar,500);
                add.Value = mem.Address;
                cmd.Parameters.Add(add);

                SqlParameter ph = new SqlParameter("Photo", SqlDbType. VarChar);
                ph.Value = mem.Photo;
                cmd.Parameters.Add(ph);

                SqlParameter oi = new SqlParameter("Ownerid", SqlDbType.Int);
                oi.Value = mem.Ownerid;
                cmd.Parameters.Add(oi);

                SqlParameter fi = new SqlParameter("FCMID", SqlDbType. VarChar,50);
                fi.Value = mem.FCMID;
                cmd.Parameters.Add(fi);

                 SqlParameter ac = new SqlParameter("Active", SqlDbType.Int);
                ac.Value = mem.Active;
                cmd.Parameters.Add(ac);

                 SqlParameter si = new SqlParameter("statusId", SqlDbType.Int);
                si.Value = mem.statusId;
                cmd.Parameters.Add(si);                

                SqlParameter fl = new SqlParameter("flag", SqlDbType. VarChar);
                fl.Value = mem.flag;
                cmd.Parameters.Add(fl);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception Ex)

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
