using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.Administrator
{
    public partial class TripDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "success")
                {
                    Response.Write("<script>alert('تم الحفظ بنجاح.');</script>");
                }

                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                Session["ID"] = id;
                clsTrip t = new clsTrip();
                Trip trip = t.getTrip(id);
                lblTitle.Text = trip.Name;
                lblID.Text = trip.ID.ToString();
                clsUser user = new clsUser();
                DataTable dt = user.get(trip.UserID);
                lblCustomer.Text = dt.Rows[0]["Name"].ToString();
                lblPicUpDate.Text = trip.PicUpDate.ToString();
                lblDeliveryDate.Text = trip.DeliveryDate.ToString();
                string sql = "SELECT COUNT(*) AS co, MIN(Price) AS low FROM dbo.Bid Where TripID=" + id;
                DataTable dt2 = DataAccess.ExecuteSQLQuery(sql);
                if (trip.Cost == 0)
                {
                    lblBudget.Text = "Place Bid";
                }
                else
                {
                    lblBudget.Text = trip.Cost.ToString();
                }
                if (dt2.Rows.Count > 0 || dt2.Rows[0] != null)
                {
                    lbllowbid.Text = dt2.Rows[0]["low"].ToString();
                    lblnumbid.Text = dt2.Rows[0]["co"].ToString();
                }
                else
                {
                    lbllowbid.Text = "0";
                    lblnumbid.Text = "0";
                }
                lblOrigin.Text = trip.SourceLocationText;
                lblDestination.Text = trip.DeliveryLocationText;
            }
        }

        protected void btnaccept_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            string sql = "Update Trip Set Puplished=1 Where ID=" + id.ToString();
            DataAccess.ExecuteSQLNonQuery(sql);
            Response.Redirect("~/Administrator/AllTrips.aspx?alert=success");
        }
    }
}