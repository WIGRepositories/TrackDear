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
    public class TypesController : ApiController
    {
        [HttpGet]

        public DataTable GetTypes()
        {
            

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            cmd.CommandText = "GetTypes";

            SqlDataAdapter db= new SqlDataAdapter(cmd);

            DataTable tbl = new DataTable();

            db.Fill(tbl);

            return tbl;
        }
  
        
        [HttpPost]
        [Route("api/Types/InsUpdDelTypes")]
        public int InsUpdDelTypes(Types typ)
     {    
            
            SqlConnection conn = new SqlConnection();

            try
            {

                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelTypes";

                SqlParameter id = new SqlParameter("Id",SqlDbType.Int);
                id.Value = typ.Id;
                cmd.Parameters.Add(id);

                SqlParameter nam = new SqlParameter("Name",SqlDbType.VarChar,50);
                nam.Value = typ.Name;
                cmd.Parameters.Add(nam);

                SqlParameter des = new SqlParameter("Description",SqlDbType.VarChar,500);
                des.Value = typ.Description;
                cmd.Parameters.Add(des);

                SqlParameter act = new SqlParameter("Active",SqlDbType.Int);
                act.Value = typ.Active;
                cmd.Parameters.Add(act);

                SqlParameter tgp = new SqlParameter("TypeGroupId",SqlDbType.Int);
                tgp.Value = typ.TypeGroupId;
                cmd.Parameters.Add(tgp);

                SqlParameter lik = new SqlParameter("ListKey", SqlDbType.VarChar, 50);
                lik.Value = typ.ListKey;
                cmd.Parameters.Add(lik);

                SqlParameter liv = new SqlParameter("ListValue", SqlDbType.VarChar, 50);
                liv.Value = typ.ListValue;
                cmd.Parameters.Add(liv);

                SqlParameter fla = new SqlParameter("flag", SqlDbType.VarChar);
                fla.Value = typ.flag;
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
    
   





    

