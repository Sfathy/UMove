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
    public partial class AddCar : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["alert"] == "success")
            {
                Response.Write("<script>alert('تم الحفظ بنجاح');</script>");
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            Cars car = new Cars();
            car.CarType = txtCarType.Text;
            car.CarModel = txtCarModel.Text;
            car.CarYear = txtYear.Text;
            car.Active =Convert.ToInt32(rblActive.SelectedValue.ToString());
            car.CarCondition = ddlStatus.SelectedValue.ToString();
            car.hight =Convert.ToInt32(txthight.Text);
            car.MaxWidth = Convert.ToInt32(txtMaxWidth.Text);
            car.NumOFSeats = Convert.ToInt32(txtNumOFSeats.Text);
            HttpCookie user = Request.Cookies["user"];
            car.UserID = Convert.ToInt32(user.Values["userid"].ToString());
            clsCars clsc = new clsCars();
            int id =clsc.insert(car);
            if (id>0)
            {
                Response.Redirect("~/Shipments/AddCar.aspx?alert=success");
            }
        }
    }
}