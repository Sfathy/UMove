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
    public class InstallationController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] Installation Inst)
        {
            if (ModelState.IsValid)
            {
                clsInstallation inst = new clsInstallation();
                DataTable dt = inst.insert(Inst);
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID");
                dt2.Columns.Add("InstallationKey");
                DataRow dr = dt2.NewRow();
                dr["ID"] = dt.Rows[0]["ID"];
                dr["InstallationKey"] = dt.Rows[0]["InstallationKey"];
                dt2.Rows.Add(dr);
                string jsonString = string.Empty;
                jsonString = JsonConvert.SerializeObject(dt2);
                return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
            }
            else
            {
                string err = "{ \"error\": { \"code\": 1, \"message\": \"InValid Paramters\"  } }";
                return new HttpResponseMessage() { Content = new StringContent(err, System.Text.Encoding.UTF8, "application/jason") };
            }



        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody] Installation Inst)
        {
            if (ModelState.IsValid)
            {
                clsInstallation inst = new clsInstallation();
                DataTable dt = inst.update(Inst);
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID");
                dt2.Columns.Add("InstallationKey");
                DataRow dr = dt2.NewRow();
                dr["ID"] = dt.Rows[0]["ID"];
                dr["InstallationKey"] = dt.Rows[0]["InstallationKey"];
                dt2.Rows.Add(dr);
                string jsonString = string.Empty;
                jsonString = JsonConvert.SerializeObject(dt2);
                return jsonString;
            }
            else
            {
                return "{ \"error\": { \"code\": 1, \"message\": \"InValid Paramters\"  } }";
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}