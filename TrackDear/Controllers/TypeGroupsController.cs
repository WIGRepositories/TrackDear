using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using TrackDear.Models;

namespace TrackDear.Controllers
{
    public class TypeGroupsController : ApiController
    {
        [HttpGet]
        [Route("api/TypeGroups/GetTypeGroups")]
        public DataTable GetTypeGroups()
        {          

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "GetTypeGroups";

            SqlDataAdapter db = new SqlDataAdapter(cmd);

            DataTable tbl = new DataTable();

            db.Fill(tbl);

            return tbl;

        } 


            [HttpPost]
            [Route("api/TypeGroups/TypeGroups")]
            public int TypeGroups(Group grp)
{
            
            SqlConnection conn = new SqlConnection();
            try
            {

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelTypeGroups";

                SqlParameter id = new SqlParameter("Id",SqlDbType.Int);
                id.Value = grp.Id;
                cmd.Parameters.Add(id);

                SqlParameter nam = new SqlParameter("Name",SqlDbType.VarChar,50);
                nam.Value = grp.Name;
                cmd.Parameters.Add(nam);

                SqlParameter des = new SqlParameter("Description",SqlDbType.VarChar,500);
                des.Value = grp.Description;
                cmd.Parameters.Add(des);

                SqlParameter act = new SqlParameter("Active",SqlDbType.Int);
                act.Value = grp.Active;
                cmd.Parameters.Add(act);

                SqlParameter fla = new SqlParameter("flag", SqlDbType.VarChar);
                fla.Value = grp.flag;
                cmd.Parameters.Add(fla);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

         }
          catch(Exception Ex)
            {
              if(conn.State == ConnectionState.Open)
              {
                  conn.Close();
              }
              throw Ex;
            }
                finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return 1;

}


}

}  
    
   






