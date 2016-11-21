using DevExpress.Utils;
using DevExpress.Web;
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
    public partial class MyTripBids : BasePage
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

        protected void ASPxGridView3_CustomButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCustomButtonEventArgs e)
        {
           
             object row = ASPxGridView3.GetRow(e.VisibleIndex);
            if (((DataRowView)row)["Answer"].ToString() != "")
                e.Visible = DefaultBoolean.False;

            if (((DataRowView)row)["Answer"].ToString() == "")
                e.Visible = DefaultBoolean.True;
        }

        protected void ASPxGridView2_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
           
            object row = ASPxGridView2.GetRow(e.VisibleIndex);
            if (e.ButtonID == "BtnAccept" && ((DataRowView)row)["Accepted"].ToString() != "0")
                e.Visible = DefaultBoolean.False;

            if (e.ButtonID == "BtnAccept" && ((DataRowView)row)["Accepted"].ToString() == "0")
                e.Visible = DefaultBoolean.True;
        }

        protected void ASPxGridView3_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "btnAnswer")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["QuestionID"].ToString());
                Response.Redirect("~/Shipments/QuestionAnswer.aspx?id="+id);
            }
        }
       
        protected void ASPxGridView2_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            int Tripid = Convert.ToInt32(Request.QueryString["id"].ToString());
            int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
            DataRow dr = ASPxGridView1.GetDataRow(Gid);
            int id = Convert.ToInt32(dr["ID"].ToString());
            string sql;
            if (e.ButtonID == "BtnAccept")
            {
               
                 sql = "Update Bid SET [Accepted]=0 where [TripID]=" + Tripid;
                DataAccess.ExecuteSQLQuery(sql);
                sql = "Update Bid SET [Accepted]=1 where [TripID]=" + Tripid+" And ID="+id;
                DataAccess.ExecuteSQLQuery(sql);
            }
            if (e.ButtonID == "btnCancel")
            {
                sql = "Update Bid SET [Accepted]=0 where [TripID]=" + Tripid + " And ID=" + id;
                DataAccess.ExecuteSQLQuery(sql);
            }
        }

        protected void ASPxGridView3_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
          
            int id = Convert.ToInt32(e.Keys[0].ToString());
            HttpCookie user = Request.Cookies["user"];
            int UserID = Convert.ToInt32(user.Values["userid"].ToString());
            string sql = "UPDATE [TripQuestions] Set [Answer] = '" + e.NewValues["Answer"] + "'," +
                         "[AnswerUserID] =" + UserID + ",[AnswerTime] ='" + DateTime.Now.ToShortDateString() + "' WHERE QuestionID=" + id;
            DataAccess.ExecuteSQLQuery(sql);
            e.Cancel=true;
        }
      

      



    }
}