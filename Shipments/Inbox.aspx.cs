using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMoveNew.Shipments
{
    public partial class Inbox : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie user = Request.Cookies["user"];
           int userid= Convert.ToInt32(user.Values["userid"].ToString());
           string sql = "SELECT Inbox.ID as ID,Inbox.Message, Users.Name AS ToUser, Users_1.Name AS Sender, Inbox.MessageDate, Trip.Name AS trip_name, Inbox.Message_AR FROM Inbox INNER JOIN Users ON Inbox.ToUserID = Users.ID INNER JOIN Users AS Users_1 ON Inbox.SenderID = Users_1.ID INNER JOIN Trip ON Inbox.TripID = Trip.ID WHERE (Inbox.ToUserID = " + userid + ")";
           DataTable dt = DataAccess.ExecuteSQLQuery(sql);
           ASPxGridView1.DataSource = dt;
           ASPxGridView1.DataBind();
        }

    

        protected void ASPxGridView1_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
         
            int id = Convert.ToInt32(e.Keys[0].ToString());
            string sql = "DELETE FROM [Inbox] WHERE ID="+id.ToString();
            DataAccess.ExecuteSQLQuery(sql);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}