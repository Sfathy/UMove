using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace UMoveNew
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (Request.Cookies["lang"] != null)
            {
                HttpCookie mylang = Request.Cookies["lang"];
                var name = "";
                if (mylang.Values["lang"] == null)
                {
                    name = "ar-EG";
                }
                else
                {
                    name = Convert.ToString(mylang.Values["lang"].ToString());
                }

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(name);
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            }
            else {

                HttpCookie lang = new HttpCookie("lang");
                lang.Values.Add("lang", "ar-EG");
            }
            
           
        }

          
    }
}
