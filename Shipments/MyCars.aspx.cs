using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMoveNew.Shipments
{
    public partial class MyCars : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie user = Request.Cookies["user"];
           int id = Convert.ToInt32(user.Values["userid"].ToString());
           string sql = "SELECT [ID],[CarType], [CarModel], [CarYear], [CarCondition], [NumOFSeats], [MaxWidth], [hight],[Active] FROM [Cars] Where UserID=" + id + " And Active=1";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);

            ASPxGridView1.DataSource = dt;
            ASPxGridView1.DataBind();
        }

        protected void btnAddCar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shipments/AddCar.aspx");
        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "BtnActive")
            {
                int Gid = Convert.ToInt32(e.VisibleIndex.ToString());
                DataRow dr = ASPxGridView1.GetDataRow(Gid);
                int id = Convert.ToInt32(dr["id"].ToString());
                string sql = "UPDATE [Cars] set [Active]=0 Where ID=" +id;


            }
        }
    }
}