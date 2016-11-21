using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.Shipments
{
    public partial class TripBids : BasePage
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
                DataTable dt = user.get(trip.DriverID);
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

        protected void rblBidExpiration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblBidExpiration.SelectedValue == "2")
            {
                txtBidExpiration.Visible = true;
                lblExpiration.Visible = true;
            }
            else
            {
                txtBidExpiration.Visible = false;
                lblExpiration.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bid b = new Bid();
            b.Price = Convert.ToDecimal(txtPrice.Text);
            b.TruckType = Convert.ToInt32(ddlTruckType.Value);
            b.PickupDate = Convert.ToDateTime(txtPickupDate.Text);
            b.DeliveryDate = Convert.ToDateTime(txtDeliverDate.Text);
            HttpCookie user = Request.Cookies["user"];
            b.UserID = Convert.ToInt32(user.Values["userid"].ToString());
            b.TripID = Convert.ToInt32(Request.QueryString["id"].ToString());

            if (rblBidExpiration.SelectedValue == "1")
            {
                b.BidExpiration = b.DeliveryDate.AddDays(1);
            }
            else if (rblBidExpiration.SelectedValue == "2")
            {
                b.BidExpiration = Convert.ToDateTime(txtBidExpiration.Text);
            }
            b.Note = txtnote.Text;
            b.TermCondition = txtTermCondition.Text;
            clsBids cb = new clsBids();
            int BidID=  cb.insert(b);
            if (BidID>0)
            {
                Response.Redirect("~/Shipments/TripBids.aspx?id=" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "&&alert=success");
            }
        }

        protected void btnAskQuestion_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Response.Redirect("~/Shipments/AskQuestion.aspx?id="+id);
        }

       
    }
}