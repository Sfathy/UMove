using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/<controller>
        /*public string Get()
        {
            clsUser user = new clsUser();
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(user.getList());
            return jsonString;
        }*/

        // GET api/<controller>/5



        public HttpResponseMessage Get(int InstallationKey, int id)
        {
            Users user = new Users();
            clsInstallation inst = new clsInstallation();
            clsUser us = new clsUser();
            DataTable dt2 = inst.get(user.InstallationKey);
            string err = "";
            if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
            {
                string jsonString = string.Empty;
                jsonString = JsonConvert.SerializeObject(us.get(id));
                return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
                
            }
            else
            {
                err = "{ \"error\": { \"code\": 1, \"message\": \"Error message\"  } }";
                return new HttpResponseMessage() { Content = new StringContent(err, System.Text.Encoding.UTF8, "application/jason") };
            }
            
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] Users user)
        {
            string err = "";
            if (ModelState.IsValid)
            {
                
                clsInstallation inst = new clsInstallation();
                DataTable dt2 = inst.get(user.InstallationKey);
                if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
                {
                    clsUser User = new clsUser();
                    DataTable dt = new DataTable();
                    //dt.Columns.Add("ID");
                    DataRow dr = dt.NewRow();
                    int id = User.insert(user);
                    if (id != -1)
                    {
                        dt = User.get(id);
                        dt.Columns.Add("AccessToken");
                        dt.Rows[0]["AccessToken"] = user.InstallationKey.ToString() + id.ToString();
                     //   dt.Rows.Add(dr);
                        string jsonString = string.Empty;
                        jsonString = JsonConvert.SerializeObject(dt);
                        return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
                    }
                    else
                    {
                        err = "{ \"error\": { \"code\": 1, \"message\": \"User name or mail exist\"  } }";
                    }
                }
                else
                {
                    err = "{ \"error\": { \"code\": 1, \"message\": \"Installation Key not exist\"  } }";
                }
            }
            else
            {
                err = "{ \"error\": { \"code\": 1, \"message\": \"InValid Paramters\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(err, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] Users user)
        {
            string err = "";
            if (ModelState.IsValid)
            {
                 clsInstallation inst = new clsInstallation();
                 
                DataTable dt2 = inst.get(user.InstallationKey);
                if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
                {
                    clsUser User = new clsUser();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ID");
                    DataRow dr = dt.NewRow();
                    dr["ID"] = User.insert(user);
                    if (dr["ID"].ToString() != "-1")
                    {
                        dt.Rows.Add(dr);
                        string jsonString = string.Empty;
                        jsonString = JsonConvert.SerializeObject(dt);
                        return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };

                        //return jsonString;
                    }
                    else
                    {
                        err = "{ \"error\": { \"code\": 1, \"message\": \"User name or mail exist\"  } }";
                    }
                }
                else
                {
                    err = "{ \"error\": { \"code\": 1, \"message\": \"Installation Key not exist\"  } }";
                }
            }
            else
            {
                err =  "{ \"error\": { \"code\": 1, \"message\": \"Error message\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(err, System.Text.Encoding.UTF8, "application/jason") };
        }


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}