using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace UMoveNew
{
    public class BasePage : Page
    {
        protected override void InitializeCulture()
        {
            HttpCookie mylang = Request.Cookies["lang"];

            if (Request.Cookies["lang"] != null)
            {
                string lang = Convert.ToString(mylang.Values["lang"].ToString());
                Culture = lang;
                UICulture = lang;
            }
            base.InitializeCulture();
        }
    }
}