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
    public partial class TripEdit : BasePage
    {
        List<string> s ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                Trip t = new clsTrip().getTrip(id);
                txtTripName.Text = t.Name;
              s=new List<string>{t.SourceLocationText,t.DeliveryLocationText,t.SourceLag.ToString(),t.SourceLat.ToString(),t.DestLag.ToString(),t.DestLat.ToString() };
              txtdatepic.Text = t.PicUpDate.ToString();
              DropDownList1.SelectedValue = t.PicUpType.ToString();
              txtdatedelivery.Text = t.DeliveryDate.ToString();
              DropDownList2.SelectedValue = t.DeliveryType.ToString();
              ASPxComboBox1.Value = t.Country;
              RadioButtonList1.SelectedValue = t.tripType.ToString();
              txtprice.Text = t.Cost.ToString();
              txtdetais.Text = t.Note;
              for (int i = 0; i < t.tripService.Count; i++)
              {
                  if (t.tripService[i].ServiceID.ToString()==RadioButtonList2.Items[0].Value)
                  {
                      RadioButtonList2.Items[0].Selected = true;
                  }
                  if (t.tripService[i].ServiceID.ToString() == RadioButtonList2.Items[1].Value)
                  {
                      RadioButtonList2.Items[1].Selected = true;
                  }
                  if (t.tripService[i].ServiceID.ToString() == RadioButtonList3.Items[0].Value)
                  {
                      RadioButtonList3.Items[0].Selected = true;
                  }
                  if (t.tripService[i].ServiceID.ToString() == RadioButtonList3.Items[1].Value)
                  {
                      RadioButtonList3.Items[1].Selected = true;
                  }
              }
            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            
        }
    }
}