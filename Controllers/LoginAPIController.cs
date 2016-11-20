using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.Controllers
{
    public class LoginAPIController : ApiController
    {
        string restPasswordLink = "";
        //UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new IUser<ApplicationUser> i);
        // GET api/<controller>
       /* public string Get()
        {
            return "hi";
        }*/

        // GET api/<controller>/5
        public bool Get(string email, string InstallationKey)
        {
            MailMessage msg = new MailMessage();
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            try
            {
                msg.Subject = "Reset Password";
                msg.Body = "to reset your password follow the following link:" + restPasswordLink;
                msg.From = new MailAddress("semsem9000@gmail.com");
                msg.To.Add(email);
                msg.IsBodyHtml = true;
                client.Host = "smtp.gmail.com";
                System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("semsem9000@gmail.com", "Hfmmza1987");
                client.Port = int.Parse("587");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicauthenticationinfo;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(msg);
            }
            // MailMessage mailObj = new MailMessage("semsem9000@gmail.com",email,"Reset Password","to reset your password follow the following link:"+restPasswordLink);

           // SmtpClient SMTPServer = new SmtpClient("127.0.0.1");
            // try
            //   {
            // SMTPServer.Send(mailObj);
            //   }
            catch (Exception ex)
            {
                //   Label1.Text = ex.ToString();
            }
            return true;

        }

        // POST api/<controller>


        public HttpResponseMessage Post([FromBody] LoginModel Login)
        {
            clsInstallation inst = new clsInstallation();
            string jsonString = string.Empty;
            DataTable dt2 = inst.get(Login.InstallationKey);
            clsUser user = new clsUser();
            if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
            {
               int id= user.login(Login.Email, Login.Password);
               if (id > 0)
                {
                    DataTable dt = user.get(id);
                   // dt.Columns.Add("ID");
                    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    {
                        dt.Columns.Add("AccessToken");
                        //check user type with the installation device type
                        if (int.Parse(dt.Rows[0]["Type"].ToString()) == 1)
                        {
                            //driver
                            //the device token should be FVPqlAoQyHPDY5gfcGis
                            if (dt2.Rows[0]["apiKey"].ToString() != "FVPqlAoQyHPDY5gfcGis")
                                jsonString =  "{ \"error\": { \"code\": 3, \"message\": \"Driver can't loggin with user application\"  } }";
                        }
                        else
                        {
                            //user
                            //the device token should be CvJrXfU7rSqF6VTokGSD
                            if (dt2.Rows[0]["apiKey"].ToString() != "CvJrXfU7rSqF6VTokGSD")
                                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"User can't loggin with driver application\"  } }";
                        }
                        //DataRow dr = dt.Rows[0];
                        // dr["ID"] = id;

                        dt.Rows[0]["AccessToken"] = dt2.Rows[0]["InstallationKey"].ToString() + id.ToString();

                        //dt.Rows[0] = dr;
                        
                        jsonString = JsonConvert.SerializeObject(dt);
                        //return jsonString;
                    }
                    else
                    {
                        jsonString = "{ \"error\": { \"code\": 1, \"message\": \"User Not Exist\"  } }";
                    }
                }
                else
                {
                    jsonString = "{ \"error\": { \"code\": 1, \"message\": \"User Not Exist\"  } }";
                }
            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 1, \"message\": \"InValid InstallationKey\"  } }";
            }

            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };


        }

        // PUT api/<controller>/5

    }
}