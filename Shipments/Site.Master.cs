using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMoveNew.Shipments
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            HttpCookie myCookie = Request.Cookies["user"];

         
            if (myCookie == null)
            {
                Response.Redirect("~/");
            }
            else
            {
                if (Page.Culture == "English (United Kingdom)")
                {
                    UserName.Text = "Welcome " + myCookie.Values["username"].ToString() + " !";
                }
                else
                {
                    UserName.Text = "مرحباً " + myCookie.Values["username"].ToString() + " !";
                }
            }
        }
        protected void btnArabic_Click(object sender, EventArgs e)
        {

            HttpCookie lang = new HttpCookie("lang");
            lang.Values.Add("lang", "ar-EG");

            lang.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Add(lang);
            //   Session["lang"] = "ar-EG";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void btnEnglish_Click(object sender, EventArgs e)
        {

            HttpCookie lang = new HttpCookie("lang");
            lang.Values.Add("lang", "en-GB");

            lang.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Add(lang);

            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void lpro_Click(object sender, EventArgs e)
        {
              HttpCookie myCookie = Request.Cookies["user"];
              Response.Redirect("~/user/Details/" + myCookie.Values["userid"].ToString());
        }
    }
}