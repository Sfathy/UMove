using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace UMoveNew.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult switchEn()
        {
            HttpCookie lang = new HttpCookie("lang");
            lang.Values.Add("lang", "en-GB");

            lang.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Add(lang);
          
            return Redirect((Request.UrlReferrer.ToString())); 
        }
        public ActionResult switchAr()
        {
            HttpCookie lang = new HttpCookie("lang");
            lang.Values.Add("lang", "ar-EG");

            lang.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Add(lang);

            return Redirect((Request.UrlReferrer.ToString()));
        }
    }
}