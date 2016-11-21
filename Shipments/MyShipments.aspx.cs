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
    public partial class MyShipments : BasePage
    {
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["user"];
             userid = Convert.ToInt32(myCookie.Values["userid"].ToString());
           
            Gbind();
        }
        public void Gbind() {
            string sql = "SELECT Trip.Name AS TripName, Trip.SourceLocationText, Trip.DeliveryLocationText, Trip.PicUpDate, Trip.DeliveryDate, DATEDIFF(hh, Trip.PicUpDate, Trip.DeliveryDate) AS Ending, Trip.ID, TripItems.ItemCatID, TripItems.ItemSubCatID, Trip.UserID FROM Trip INNER JOIN TripItems ON Trip.ID = TripItems.ID WHERE (Trip.UserID = "+userid+")";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            ASPxGridView1.DataSource = dt;
            ASPxGridView1.DataBind();
        }
        protected void detailGrid_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["TripID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnBid")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                Response.Redirect("~/Shipments/MyTripBids.aspx?id=" + id);


            }
        }

        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int id = Convert.ToInt32(e.EditingKeyValue.ToString());   
            Response.Redirect("~/Shipments/TripEdit.aspx?id=" + id);
        }
    }
}