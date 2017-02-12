using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMoveNew.Administrator
{
    public partial class AllBids : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["alert"] == "Accept")
            {
                Response.Write("<script>alert('تم قبول المذايدة');</script>");
            }
            if (Request.QueryString["alert"] == "Ignore")
            {
                Response.Write("<script>alert('تم تجاهل المذايدة');</script>");
            }
        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnAccept")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                string sql = "Update Bid Set Puplished=1 Where ID =" + id.ToString();
                DataAccess.ExecuteSQLNonQuery(sql);
                Response.Redirect("~/Administrator/AllBids.aspx?alert=Accept");
            }
            if (e.ButtonID == "btnIgnore")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                string sql = "Update Bid Set Puplished=3 Where ID =" + id.ToString();
                DataAccess.ExecuteSQLNonQuery(sql);
                Response.Redirect("~/Administrator/AllBids.aspx?alert=Ignore");
            }
        }
    }
}