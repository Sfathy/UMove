using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMoveNew.SharedShipment
{
    public partial class MySharedTrips : System.Web.UI.Page
    {
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["user"];
            userid = Convert.ToInt32(myCookie.Values["userid"].ToString());

            Gbind();
        }
        public void Gbind()
        {
            string sql = "SELECT Name AS TripName, SourceLocationText, DeliveryLocationText, PicUpDate, DeliveryDate, DATEDIFF(hh, PicUpDate, DeliveryDate) AS Ending, ID, UserID FROM dbo.SharedTrip WHERE (Puplished = 1) And (SharedTrip.UserID = " + userid + ")";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            ASPxGridView1.DataSource = dt;
            ASPxGridView1.DataBind();
        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "BtnBid")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                Response.Redirect("~/SharedShipment/MySharedTripBids.aspx?id=" + id);
            }
        }
    }
}