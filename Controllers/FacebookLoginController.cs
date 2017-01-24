using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Models;

namespace UMoveNew.Controllers
{
    public class FacebookLoginController : ApiController
    {
        // GET api/facebooklogin
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/facebooklogin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/facebooklogin
        public HttpResponseMessage Post([FromBody]Users user)
        {
            LoginModel log = new LoginModel();
            log.Email = user.Email;
            log.Password = user.Password;
            log.InstallationKey = user.InstallationKey;
            LoginAPIController l = new LoginAPIController();
            HttpResponseMessage m = l.Post(log);
            if(m.StatusCode == HttpStatusCode.OK)
            {
                return m;
            }
            else
            {
                UsersController u = new UsersController();
                return u.Post(user);
            }
        }

        // PUT api/facebooklogin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/facebooklogin/5
        public void Delete(int id)
        {
        }
    }
}
