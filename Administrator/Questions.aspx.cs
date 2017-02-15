using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMoveNew.Administrator
{
    public partial class Questions : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["alert"] == "Accept")
            {
                Response.Write("<script>alert('تم قبول السؤال');</script>");
            }
            if (Request.QueryString["alert"] == "Ignore")
            {
                Response.Write("<script>alert('تم تجاهل السؤال');</script>");
            }
            AddSubmitEvent();
        }
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("AdminUpdatePanel") as UpdatePanel;
            //  UpdatePanelControlTrigger trigger = new PostBackTrigger();

        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnAccept")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["QuestionID"].ToString());
                string sql = "Update TripQuestions Set QuestionPuplished=1 Where QuestionID =" + id.ToString();
                DataAccess.ExecuteSQLNonQuery(sql);
                Response.Redirect(Request.Url.AbsoluteUri + "?alert=Accept");
            }
            if (e.ButtonID == "btnIgnore")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["QuestionID"].ToString());
                string sql = "Update TripQuestions Set QuestionPuplished=3 Where QuestionID =" + id.ToString();
                DataAccess.ExecuteSQLNonQuery(sql);
                Response.Redirect(Request.Url.AbsoluteUri + "?alert=Ignore");
            }
        }
    }
}