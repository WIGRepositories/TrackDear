using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using TrackDear.Models;

namespace TrackDear.Controllers
{
    public class AppUsersController : ApiController
    {
        [HttpGet]
        public DataTable GetAppUsers(string MobileNo)
        {
           
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();

            SqlCommand cmd= new SqlCommand();
            cmd.Connection=Conn;
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            cmd.CommandText="GetAppUsers";

            cmd.Parameters.Add("MobileNo", SqlDbType.VarChar, 20).Value = MobileNo;
            SqlDataAdapter db= new SqlDataAdapter(cmd);
            DataTable tbl= new DataTable();
            db.Fill(tbl);
            return tbl;
        }

    [HttpPost]
         [Route("api/AppUsers/AppUsers")]
        public DataTable AppUsers(AppUsers au)
        {

            
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection();
            try
            {
                Conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelAppUsers";

             

                SqlParameter fn = new SqlParameter("FirstName", SqlDbType.VarChar, 50);
                fn.Value = au.FirstName;
                cmd.Parameters.Add(fn);

                SqlParameter ln = new SqlParameter("LastName", SqlDbType.VarChar, 50);
                ln.Value = au.LastName;
                cmd.Parameters.Add(ln);

                SqlParameter em = new SqlParameter("Email", SqlDbType.VarChar, 150);
                em.Value = au.Email;
                cmd.Parameters.Add(em);

                SqlParameter mn = new SqlParameter("MobileNo", SqlDbType.VarChar, 10);
                mn.Value = au.MobileNo;
                cmd.Parameters.Add(mn);               

                SqlParameter add = new SqlParameter("Address", SqlDbType.VarChar, 500);
                add.Value = au.Address;
                cmd.Parameters.Add(add);

                SqlParameter ph = new SqlParameter("Photo", SqlDbType.VarChar);
                ph.Value = au.Photo;
                cmd.Parameters.Add(ph);

                SqlParameter id = new SqlParameter("Id", SqlDbType.Int);
                id.Value = au.Id;
                cmd.Parameters.Add(id);

                SqlParameter fl = new SqlParameter("flag", SqlDbType.VarChar);
                fl.Value = au.flag;
                cmd.Parameters.Add(fl);


                
                SqlDataAdapter ds = new SqlDataAdapter(cmd);
                ds.Fill(dt);

                #region Mobile OTP
                string motp = dt.Rows[0]["MobileOtp"].ToString();
                if (motp != null)
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        string emailserver = System.Configuration.ConfigurationManager.AppSettings["emailserver"].ToString();

                        string username = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
                        string pwd = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
                        string fromaddress = System.Configuration.ConfigurationManager.AppSettings["fromaddress"].ToString();
                        string port = System.Configuration.ConfigurationManager.AppSettings["port"].ToString();

                        SmtpClient SmtpServer = new SmtpClient(emailserver);

                        mail.From = new MailAddress(fromaddress);
                        mail.To.Add(fromaddress);
                        mail.Subject = "User registration - Mobile OTP";
                        mail.IsBodyHtml = true;

                        string verifcodeMail = @"<table>
                                                            <tr>
                                                                <td>
                                                                    <h2>Thank you for registering with TrackDear APP</h2>
                                                                    <table width=\""760\"" align=\""center\"">
                                                                        <tbody style='background-color:#F0F8FF;'>
                                                                            <tr>
                                                                                <td style=\""font-family:'Zurich BT',Arial,Helvetica,sans-serif;font-size:15px;text-align:left;line-height:normal;background-color:#F0F8FF;\"" >
    <div style='padding:10px;border:#0000FF solid 2px;'>    <br /><br />
                                                                                 
                                                           Your Mobile OTP is:<h3>" + motp + @" </h3>
    
                                                            If you didn't make this request, <a href='http://154.120.237.198:52800'>click here</a> to cancel.
    
                                                                                    <br/>
                                                                                    <br/>             
                                                                           
                                                                                    Warm regards,<br>
                                                                                    PAYSMART Customer Service Team<br/><br />
    </div>
                                                                                </td>
                                                                            </tr>
    
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
    
                                                        </table>";


                        mail.Body = verifcodeMail;
                        //SmtpServer.Port = 465;
                        //SmtpServer.Port = 587;
                        SmtpServer.Port = Convert.ToInt32(port);
                        SmtpServer.UseDefaultCredentials = false;

                        SmtpServer.Credentials = new System.Net.NetworkCredential(username, pwd);
                        SmtpServer.EnableSsl = true;
                        //SmtpServer.TargetName = "STARTTLS/smtp.gmail.com";
                        SmtpServer.Send(mail);
                        //Status = 1;

                    }
                    catch (Exception ex)
                    {
                        //throw ex;
                    }
                }
                #endregion Mobile OTP

                #region Email OTP
                string eotp = dt.Rows[0]["EmailOtp"].ToString();
                if (motp != null)
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        string emailserver = System.Configuration.ConfigurationManager.AppSettings["emailserver"].ToString();

                        string username = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
                        string pwd = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
                        string fromaddress = System.Configuration.ConfigurationManager.AppSettings["fromaddress"].ToString();
                        string port = System.Configuration.ConfigurationManager.AppSettings["port"].ToString();

                        SmtpClient SmtpServer = new SmtpClient(emailserver);

                        mail.From = new MailAddress(fromaddress);
                        mail.To.Add(fromaddress);
                        mail.Subject = "User registration - Mobile OTP";
                        mail.IsBodyHtml = true;

                        string verifcodeMail = @"<table>
                                                            <tr>
                                                                <td>
                                                                    <h2>Thank you for registering with TrackDear APP</h2>
                                                                    <table width=\""760\"" align=\""center\"">
                                                                        <tbody style='background-color:#F0F8FF;'>
                                                                            <tr>
                                                                                <td style=\""font-family:'Zurich BT',Arial,Helvetica,sans-serif;font-size:15px;text-align:left;line-height:normal;background-color:#F0F8FF;\"" >
    <div style='padding:10px;border:#0000FF solid 2px;'>    <br /><br />
                                                                                 
                                                           Your Mobile OTP is:<h3>" + eotp + @" </h3>
    
                                                            If you didn't make this request, <a href='http://154.120.237.198:52800'>click here</a> to cancel.
    
                                                                                    <br/>
                                                                                    <br/>             
                                                                           
                                                                                    Warm regards,<br>
                                                                                    PAYSMART Customer Service Team<br/><br />
    </div>
                                                                                </td>
                                                                            </tr>
    
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
    
                                                        </table>";


                        mail.Body = verifcodeMail;
                        //SmtpServer.Port = 465;
                        //SmtpServer.Port = 587;
                        SmtpServer.Port = Convert.ToInt32(port);
                        SmtpServer.UseDefaultCredentials = false;

                        SmtpServer.Credentials = new System.Net.NetworkCredential(username, pwd);
                        SmtpServer.EnableSsl = true;
                        //SmtpServer.TargetName = "STARTTLS/smtp.gmail.com";
                        SmtpServer.Send(mail);
                        //Status = 1;

                    }
                    catch (Exception ex)
                    {
                        //throw ex;
                    }
                }
                #endregion Email OTP
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
                return dt;
        }
    }
}
