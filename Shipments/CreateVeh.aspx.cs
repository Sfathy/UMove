using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMoveNew.Shipments
{
    public partial class CreateVeh : BasePage
    {
        DataTable dt = new DataTable();
        int UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            if (!IsPostBack)
            {
                if (Request.QueryString["alert"] == "wronextention")
                {
                    Response.Write("<script>alert(' الصيغة المدخلة غير مفعلة ');</script>");
                }
                Session["Image"] = null;
                switch (id)
                {
                    case 1:
                    case 2:
                        lbldimensions.Visible = false;
                        lblLength.Visible = false;
                        txtLength.Visible = false;
                        txtLength2.Visible = false;
                        lblWidth.Visible = false;
                        txtWidth.Visible = false;
                        txtWidth2.Visible = false;
                        lblHeight.Visible = false;
                        txtHeight.Visible = false;
                        txtHeight2.Visible = false;
                        lblWeight.Visible = false;
                        txtWeight.Visible = false;
                        break;

                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        lbldimensions.Visible = true;
                        lblLength.Visible = true;
                        txtLength.Visible = true;
                        txtLength2.Visible = true;
                        lblWidth.Visible = true;
                        txtWidth.Visible = true;
                        txtWidth2.Visible = true;
                        lblHeight.Visible = true;
                        txtHeight.Visible = true;
                        txtHeight2.Visible = true;
                        lblWeight.Visible = true;
                        txtWeight.Visible = true;
                       BoundField nameColumn = new BoundField();
                       BoundField nameColumn2 = new BoundField();
                       BoundField nameColumn3 = new BoundField();
                       BoundField nameColumn4 = new BoundField();
                nameColumn.DataField = "Length";
                nameColumn.HeaderText = "Length";
                GridView1.Columns.Add(nameColumn);
                nameColumn2.DataField = "Width";
                nameColumn2.HeaderText = "Width";
                GridView1.Columns.Add(nameColumn2);
                nameColumn3.DataField = "Height";
                nameColumn3.HeaderText = "Height";
                GridView1.Columns.Add(nameColumn3);
                nameColumn4.DataField = "Weight";
                nameColumn4.HeaderText = "Weight";
                GridView1.Columns.Add(nameColumn4);
                        break;

                    default:

                        break;
                }
            }
            dt.Columns.Add("ID");
            dt.Columns.Add("ItemDesc");
            dt.Columns.Add("ImageURL");
            dt.Columns.Add("UserID");
            dt.Columns.Add("CatID");
            dt.Columns.Add("SubCatID");
            if (id==3 ||id==4 ||id==5 ||id==6 )
            {
                dt.Columns.Add("Length");
                dt.Columns.Add("Width");
                dt.Columns.Add("Height");
                dt.Columns.Add("Weight");
                
            }
            HttpCookie user = Request.Cookies["user"];
            UserID = Convert.ToInt32(user.Values["userid"].ToString());
            gvbind();
            AddSubmitEvent();
         
          
        }

        private void gvbind()
        {
            if (Session["Items"] != null)
            {
              
                dt = (DataTable)Session["Items"];
                DataView dv = new DataView(dt);
                dv.RowFilter = ("(UserID =" + UserID.ToString() + ")");
                GridView1.DataSource = dv;

                GridView1.DataBind();

                //  Session["Items"] = dv;
            }
            else
            {
                //dt.Rows.Add(dt.NewRow());
                //GridView1.DataSource = dt;
                //GridView1.DataBind();
                //int columncount = GridView1.Rows[0].Cells.Count;
                //GridView1.Rows[0].Cells.Clear();
                //GridView1.Rows[0].Cells.Add(new TableCell());
                //GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                //GridView1.Rows[0].Cells[0].Text = "No Records Found";
            }
        }

        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("ShipUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = btnSave.UniqueID;
            updatePanel.Triggers.Add(trigger);
        }
        public Int32 GetLastKey()
        {
            DataTable table = dt;

            Int32 max = 0;
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["ID"]) > max)
                    max = Convert.ToInt32(row["ID"]);
            }
            return max;
        }
        public static Bitmap CreateThumbnail(string lcFilename, int lnWidth, int lnHeight)
        {

            System.Drawing.Bitmap bmpOut = null;

            try
            {
                Bitmap loBMP = new Bitmap(lcFilename);
                ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)
                    return loBMP;

                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;
                    lnNewWidth = lnWidth;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;
                    lnNewHeight = lnHeight;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }


                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

                loBMP.Dispose();
            }
            catch
            {
                return null;
            }
            return bmpOut;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            dr["ItemDesc"] = txtDescription.Text;
            dr["ID"] = GetLastKey() + 1;
            dr["UserID"] = UserID;
            dr["CatID"] = 1;
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            dr["SubCatID"] = id;
            switch (id)
            {
                case 1:
                case 2:
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                    dr["Length"] = txtLength.Text + "." + txtLength2.Text;
                    dr["Width"] = txtWidth.Text + "." + txtWidth2.Text;
                    dr["Height"] = txtHeight.Text + "." + txtHeight2.Text;
                    dr["Weight"] = txtWeight.Text;
                  
                    break;
            }
            if (FileUpload1.HasFile)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss")  +Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string fileLocation = Server.MapPath("~/images/Upload/"  +fileName);
                FileUpload1.SaveAs(fileLocation);
                Bitmap bi =  CreateThumbnail(fileLocation, 50, 50);
                if (fileExtension == ".Jpeg" || fileExtension == ".jpeg" || fileExtension == ".gif" || fileExtension == ".GIF")
                {
                    bi.Save(fileLocation, System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                    Response.Redirect("~/Shipments/CreateVeh.aspx?id=" + id + "&&alert=wronextention");

                dr["ImageURL"] = "~/images/Upload/" + fileName;


            }
            else
            {

                switch (id)
                {
                    case 1:
                        dr["ImageURL"] = "~/images/4-98x73.png";
                        break;
                    case 2:
                        dr["ImageURL"] = "~/images/146-98x73.png";
                        break;
                    case 3:
                        dr["ImageURL"] = "~/images/boat.jpg";
                        break;
                    case 4:
                        dr["ImageURL"] = "~/images/track.jpg";
                        break;
                    case 5:
                        dr["ImageURL"] = "~/images/basckel.jpg";
                        break;
                    case 6:
                        dr["ImageURL"] = "~/images/fireequ.jpg";
                        break;
                    default:
                        dr["ImageURL"] = "~/images/146-98x73.png";
                        break;
                }

            }
            dt.Rows.Add(dr);
            Session["Items"] = dt;
            gvbind();
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];

            Label lblid = (Label)row.FindControl("lblID");
            int GStuffID = Convert.ToInt32(lblid.Text.ToString()) - 1;
            DataRow dr = dt.Rows[GStuffID];
            dt.Rows.Remove(dr);
            Session["Items"] = dt;
            gvbind();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shipments/CreateTirp.aspx");
        }




    }
}