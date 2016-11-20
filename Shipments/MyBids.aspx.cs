using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMoveNew.Shipments
{
    public partial class MyBids : BasePage
    {
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["user"];
            userid = Convert.ToInt32(myCookie.Values["userid"].ToString());

            Gbind();
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "success")
                {
                    Response.Write("<script>alert('تم الحفظ بنجاح.');</script>");
                }
            }
           
        }

        private void Gbind()
        {
            HttpCookie myCookie = Request.Cookies["user"];
           int userid = Convert.ToInt32(myCookie.Values["userid"].ToString());
           string sql = "SELECT Trip.Name,Bid.ID, Bid.Price, Bid.TruckType, Bid.PickupDate, Bid.DeliveryDate, Bid.BidExpiration, Bid.Accepted FROM Bid INNER JOIN Trip ON Bid.TripID = Trip.ID Where Bid.UserID=" + userid;
           DataTable dt = DataAccess.ExecuteSQLQuery(sql);
           ASPxGridView1.DataSource = dt;
           ASPxGridView1.DataBind();
        }

       


        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            int id = Convert.ToInt32(e.EditingKeyValue.ToString());
            Response.Redirect("~/Shipments/BidEdit.aspx?id="+id);
        }
    }
}