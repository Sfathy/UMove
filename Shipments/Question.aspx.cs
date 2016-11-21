using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMoveNew.Shipments
{
    public partial class Question : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAskQuestion_Click(object sender, EventArgs e)
        {
            HttpCookie user = Request.Cookies["user"];
            int UserID = Convert.ToInt32(user.Values["userid"].ToString());

            int id = Convert.ToInt32(Session["ID"].ToString());
            string sql = "INSERT INTO [TripQuestions] ([TripID],[QuestionUserID],[Question],[QuestionTime]) VALUES(" +
                id.ToString() + "," + UserID.ToString() + ",N'" + txtQuestion.Text + "','" + DateTime.Now.ToShortDateString() + "')";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
            base.Response.Write(close);
        }
    }
}