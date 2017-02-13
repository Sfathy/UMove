using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMoveNew.Shipments
{
    public partial class AllTrips : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void detailGrid_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["TripID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "BtnBid")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                Response.Redirect("~/Shipments/TripBids.aspx?id=" + id);


            }
        }
    }
}