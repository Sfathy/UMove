using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.SharedShipment
{
    public partial class CreateSharedTrip : System.Web.UI.Page
    {
        string latlong1 = "";
        string latlong2 = "";
        string lat1 = "";
        string log1 = "";
        string lat2 = "";
        string log2 = "";
        string SourceLocationText = "";
        string DeliveryLocationText = "";
        protected void Page_Init(object sender, EventArgs e)
        {
            CalendarExtender1.StartDate = DateTime.Now;
            CalendarExtender2.StartDate = DateTime.Now;
            CalendarExtender3.StartDate = DateTime.Now;
            CalendarExtender4.StartDate = DateTime.Now;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            latlong1 = Request.Form["latn"];

            latlong2 = Request.Form["latn2"];
            SourceLocationText = Request.Form["origin-input"];
            DeliveryLocationText = Request.Form["destination-input"];
            if (Request.QueryString["alert"] == "success")
            {
                Response.Write("<script>alert('تم الحفظ بنجاح');</script>");
            }
            if (Request.QueryString["alert"] == "error")
            {
                Response.Write("<script>alert('لم يتم الحفظ تأكد من البيانات المدخلة');</script>");
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string lo1 = latlong1.ToString().Replace("(", "").Replace(")", "");
            String[] dates = lo1.Split(',');
            lat1 = dates[0];
            log1 = dates[1];
            string lo2 = latlong2.ToString().Replace("(", "").Replace(")", "");
            String[] dates2 = lo2.Split(',');
            lat2 = dates2[0];
            log2 = dates2[1];

            //    clsSharedTrip ctrip = new clsSharedTrip();
            SharedTrip trip = new SharedTrip();
            trip.SourceLag = Convert.ToDecimal(log1);
            trip.SourceLat = Convert.ToDecimal(lat1);
            trip.DestLag = Convert.ToDecimal(log2);
            trip.DestLat = Convert.ToDecimal(lat2);
            trip.SourceLocationText = SourceLocationText;
            trip.Name = txtTripName.Text;
            trip.DeliveryLocationText = DeliveryLocationText;
            trip.TripDuration = 0;

            if (txtprice.Text != null && txtprice.Text != "")
            {
                trip.Cost = Convert.ToDecimal(txtprice.Text);
            }
            else
            {
                trip.Cost = 0;
            }
            HttpCookie user = Request.Cookies["user"];
            trip.UserID = Convert.ToInt32(user.Values["userid"].ToString());
            trip.ItemsList = new List<Item>();
            clsUser us = new clsUser();
            if (us.getType(trip.UserID) == 0)
            {
                trip.CustomerID = trip.UserID;
                trip.DriverID = 0;
            }
            else
            {
                trip.CustomerID = 0;
                trip.DriverID = trip.UserID;
            }
            trip.Status = 0;
            trip.Note = txtdetais.Text;
            trip.PicUpType = "1";
            trip.DeliveryType = "1";
            trip.Country = "Egypt";
            List<TripService> services = new List<TripService>();

            TripService service = new TripService();

            service.ServiceID = Convert.ToInt32(RadioButtonList2.SelectedValue.ToString());
            services.Add(service);

            TripService service2 = new TripService();

            service2.ServiceID = Convert.ToInt32(RadioButtonList3.SelectedValue.ToString());
            services.Add(service2);

            trip.PicUpTime = ddlTimepic.SelectedValue.ToString() + " " + ddlPAMpic.SelectedValue.ToString();
            trip.DeliveryTime = ddlTimeDelivery.SelectedValue.ToString() + " " + ddlPAMdelivery.SelectedValue.ToString();
            trip.PicUpDate = Convert.ToDateTime(txtdatepic.Text);
            trip.DeliveryDate = Convert.ToDateTime(txtdatedelivery.Text);
            trip.tripService = services;
            trip.SharetripType = Convert.ToInt32(Request.QueryString["id"].ToString());
            clsSharedTrip t = new clsSharedTrip();
            int repeted = 1;
            if (cbRepeted.Checked)
            {
                if (RbLRepetedType.SelectedValue == "1")
                {
                    repeted = (int)(Convert.ToDateTime(txtEndDate.Text) - Convert.ToDateTime(txtStartDate.Text)).TotalDays;

                }
                else if (RbLRepetedType.SelectedValue == "2")
                {

                    repeted = (int)(Convert.ToDateTime(txtEndDate.Text) - Convert.ToDateTime(txtStartDate.Text)).TotalDays / 7;
                }
                else if (RbLRepetedType.SelectedValue == "3")
                {
                    repeted = (int)(Convert.ToDateTime(txtEndDate.Text) - Convert.ToDateTime(txtStartDate.Text)).TotalDays / 30;
                }

            }
            int tripid = 0;
            for (int i = 0; i < repeted; i++)
            {
                if (repeted > 1)
                {


                    if (RbLRepetedType.SelectedValue == "1")
                    {
                        trip.DeliveryDate.AddDays(i);
                        trip.PicUpDate.AddDays(i);

                    }
                    else if (RbLRepetedType.SelectedValue == "2")
                    {

                        trip.DeliveryDate.AddDays(i + 7);
                        trip.PicUpDate.AddDays(i + 7);
                    }
                    else if (RbLRepetedType.SelectedValue == "3")
                    {
                        trip.DeliveryDate.AddMonths(i);
                        trip.PicUpDate.AddDays(i);
                    }
                }
                tripid = t.insert(trip);

            }
            if (tripid > 0)
            {
                Response.Redirect("~/Shipments/CreateTirp.aspx?alert=success");
            }
            else
                Response.Redirect("~/Shipments/CreateTirp.aspx?alert=error");

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SharedTrips/");
        }


    }
}