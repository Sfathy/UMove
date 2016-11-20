using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.Shipments
{
    public partial class BidEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                Bid bid = new clsBids().get(id);
                Trip t = new clsTrip().getTrip(bid.TripID);
                lblTripName.Text = t.Name;
                txtPrice.Text = bid.Price.ToString();
                ddlTrackType.SelectedValue = bid.TruckType.ToString();
                txtBidExpiration.Text = bid.BidExpiration.ToString();
                txtPicUp.Text = bid.PickupDate.ToString();
                txtDelivery.Text = bid.DeliveryDate.ToString();
                txtNote.Text = bid.Note;
                txtTerm.Text = bid.TermCondition;
            }

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
             int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            clsBids clb = new clsBids();
            Bid b = new Bid();
            b.ID = id;
            b.Price =Convert.ToDecimal(txtPrice.Text);
            b.TruckType =Convert.ToInt32(ddlTrackType.SelectedValue.ToString());
            b.BidExpiration=Convert.ToDateTime(txtBidExpiration.Text);
            b.PickupDate = Convert.ToDateTime(txtPicUp.Text);
            b.DeliveryDate = Convert.ToDateTime(txtDelivery.Text);
            b.Note = txtNote.Text;
            b.TermCondition = txtTerm.Text;
            clb.update(id, b);
            Response.Redirect("~/Shipments/MyBids.aspx?alert=success");
            
        }
    }
}