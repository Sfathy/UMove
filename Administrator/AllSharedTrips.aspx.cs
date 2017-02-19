using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMoveNew.Administrator
{
    public partial class AllSharedTrips : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["alert"] == "Accept")
            {
                Response.Write("<script>alert('تم قبول الرحلة');</script>");
            }
            if (Request.QueryString["alert"] == "Ignore")
            {
                Response.Write("<script>alert('تم تجاهل الرحلة');</script>");
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
            if (e.ButtonID == "BtnView")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                Response.Redirect("~/Administrator/SharedTripDetails.aspx?id=" + id);
            }
            else if (e.ButtonID == "btnAccept")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                string sql = "Update SharedTrip Set Puplished=1 Where ID=" + id.ToString();
                DataAccess.ExecuteSQLNonQuery(sql);
                Response.Redirect(Request.Url.AbsoluteUri + "?alert=Accept");
            }
            else if (e.ButtonID == "btnIgnore")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                string sql = "Update SharedTrip Set Puplished=3 Where ID=" + id.ToString();
                DataAccess.ExecuteSQLNonQuery(sql);
                Response.Redirect(Request.Url.AbsoluteUri + "?alert=Ignore");
            }
        }
    }
}