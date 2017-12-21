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
    public class MemberLocationController : ApiController
    {
        [HttpGet]
        [Route("api/MemberLocation/GetMemberLocation")]
        public DataTable GetMemberLocation(int Id)

        {           

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "GetMemberLocation";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            DataTable tbl = new DataTable();

            db.Fill(tbl);

            return tbl;
        }
        
        [HttpPost]
        [Route("api/MemberLocation/MemberLocation")]
        public int MemberLocation(Execute exe)
        {
            
           
            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "InsUpdDelMemberLocation";

                SqlParameter id = new SqlParameter("Id", SqlDbType.Int);
                id.Value = exe.Id;
                cmd.Parameters.Add(id);

                SqlParameter lat= new SqlParameter("Latitude", SqlDbType.VarChar, 150);
                lat.Value = exe.Latitude;
                cmd.Parameters.Add(lat);

                SqlParameter lon = new SqlParameter("Longitude", SqlDbType.VarChar,150);
                lon.Value = exe.Longitude;
                cmd.Parameters.Add(lon);

                SqlParameter fcm = new SqlParameter("FCMID", SqlDbType.VarChar, 150);
                fcm.Value = exe.FCMID;
                cmd.Parameters.Add(fcm);

                SqlParameter pla = new SqlParameter("PlaceId",SqlDbType.VarChar,150);
                pla.Value = exe.PlaceId;
                cmd.Parameters.Add(pla);

                SqlParameter loc= new SqlParameter("LocationDesc", SqlDbType.VarChar);
                loc.Value = exe.LocationDesc;
                cmd.Parameters.Add(loc);

                SqlParameter cit = new SqlParameter("City", SqlDbType.VarChar);
                cit.Value = exe.City;
                cmd.Parameters.Add(cit);

                SqlParameter sta = new SqlParameter("State", SqlDbType.VarChar);
                sta.Value = exe.State;
                cmd.Parameters.Add(sta);

                SqlParameter pl = new SqlParameter("Place", SqlDbType.VarChar);
                pl.Value = exe.Place;
                cmd.Parameters.Add(pl);

                SqlParameter fl = new SqlParameter("flag", SqlDbType.VarChar);
                fl.Value = exe.flag;
                cmd.Parameters.Add(fl);

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

    
   


