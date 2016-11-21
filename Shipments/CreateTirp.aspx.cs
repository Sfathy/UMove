using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.Shipments
{
    public partial class CreateTirp : BasePage
    {

        string latlong1 = "";
        string latlong2 = "";
        string lat1 = "";
        string log1 = "";
        string lat2 = "";
        string log2 = "";
        string SourceLocationText = "";
        string DeliveryLocationText = "";
        DataTable dt = new DataTable();

        int userType;
        protected void Page_Load(object sender, EventArgs e)
        {

            latlong1 = Request.Form["latn"];

            latlong2 = Request.Form["latn2"];
            SourceLocationText = Request.Form["pac-input"];
            DeliveryLocationText = Request.Form["pac-input2"];
            dt = (DataTable)Session["Items"];
            int count = dt.Rows.Count;
            clsTrip t = new clsTrip();
            string name = t.getCategoryName(Convert.ToInt32(dt.Rows[0]["SubCatID"].ToString()));
            txtTripName.Text = count.ToString() + " " + name;
            if (!IsPostBack)
            {

            }
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
            List<Item> Items = new List<Item>();

            clsTrip ctrip = new clsTrip();
            Trip trip = new Trip();
            trip.SourceLag = Convert.ToDecimal(log1);
            trip.SourceLat = Convert.ToDecimal(lat1);
            trip.DestLag = Convert.ToDecimal(log1);
            trip.DestLat = Convert.ToDecimal(lat1);
            trip.SourceLocationText = SourceLocationText;
            trip.Name = txtTripName.Text;
            trip.DeliveryLocationText = DeliveryLocationText;
            trip.TripDuration = 0;
            foreach (DataRow dr in dt.Rows)
            {
                Item i = new Item();
                i.Description = dr["ItemDesc"].ToString();
                i.ImageURL = dr["ImageURL"].ToString();
                i.CatID = Convert.ToInt32(dr["CatID"].ToString());
                i.SubCatID = Convert.ToInt32(dr["SubCatID"].ToString());
                i.ItemType = Convert.ToInt32(dr["SubCatID"].ToString());

                if (dt.Columns.Contains("Length"))
                {
                    i.Length = Convert.ToDecimal(dr["Length"].ToString());
                }
                else
                {
                    i.Length = 0;
                }
                if (dt.Columns.Contains("Width"))
                {
                    i.Width = Convert.ToDecimal(dr["Width"].ToString());
                }
                else
                {
                    i.Width = 0;
                }
                if (dt.Columns.Contains("Height"))
                {
                    i.Height = Convert.ToDecimal(dr["Height"].ToString());
                }
                else
                {
                    i.Height = 0;
                }
                if (dt.Columns.Contains("Weight"))
                {
                    i.Wight = Convert.ToDecimal(dr["Weight"].ToString());
                }
                else
                {
                    i.Wight = 0;
                }
                Items.Add(i);
            }
            trip.tripType = Convert.ToInt32(RadioButtonList1.SelectedValue.ToString());
            if (txtprice.Text != null)
            {
                trip.Cost = Convert.ToDecimal(txtprice.Text);
            }
            else
            {
                trip.Cost = 0;
            }
            HttpCookie user = Request.Cookies["user"];
            trip.UserID = Convert.ToInt32(user.Values["userid"].ToString());
            trip.ItemsList = Items;
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
            trip.PicUpType = DropDownList1.SelectedValue.ToString();
            trip.DeliveryType = DropDownList2.SelectedValue.ToString();
            trip.Country = ASPxComboBox1.Value.ToString();
            List<TripService> services = new List<TripService>();

            TripService service = new TripService();

            service.ServiceID = Convert.ToInt32(RadioButtonList2.SelectedValue.ToString());
            services.Add(service);

            TripService service2 = new TripService();

            service2.ServiceID = Convert.ToInt32(RadioButtonList3.SelectedValue.ToString());
            services.Add(service2);



            trip.PicUpDate = Convert.ToDateTime(txtdatepic.Text);
            trip.DeliveryDate = Convert.ToDateTime(txtdatedelivery.Text);
            trip.tripService = services;
            clsTrip t = new clsTrip();
            int tripid = t.insert(trip);
            if (tripid > 0)
            {
                Response.Redirect("~/Shipments/CreateTirp.aspx?alert=success");
            }
            else
                Response.Redirect("~/Shipments/CreateTirp.aspx?alert=error");
        }



        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Trips");
        }

    }
}