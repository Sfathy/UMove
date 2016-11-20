using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace UMoveNew.Shipments
{
    public partial class CreateHouse : BasePage
    {
        DataTable dt = new DataTable();
        int UserID;
        protected void Page_Load(object sender, EventArgs e)
        { 
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            if (!IsPostBack)
            {

                Session["Image"] = null;
                gvbind();
                AddSubmitEvent();
            }
            dt.Columns.Add("ID");
            dt.Columns.Add("ItemDesc");
            dt.Columns.Add("ImageURL");
            dt.Columns.Add("UserID");
            dt.Columns.Add("CatID");
            dt.Columns.Add("SubCatID");
            dt.Columns.Add("Length");
            dt.Columns.Add("Width");
            dt.Columns.Add("Height");
            dt.Columns.Add("Weight");
            HttpCookie user = Request.Cookies["user"];
            UserID = Convert.ToInt32(user.Values["userid"].ToString());



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
            dr["CatID"] = 2;
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            dr["SubCatID"] = id;
            dr["Length"] = txtLength.Text + "." + txtLength2.Text;
            dr["Width"] = txtWidth.Text + "." + txtWidth2.Text;
            dr["Height"] = txtHeight.Text + "." + txtHeight2.Text;
            dr["Weight"] = txtWeight.Text;
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string fileLocation = Server.MapPath("~/images/Upload/" + fileName);
                FileUpload1.SaveAs(fileLocation);
                Bitmap bi = CreateThumbnail(fileLocation, 50, 50);

                bi.Save(fileLocation);

                dr["ImageURL"] = "~/images/Upload/" + fileName;


            }
            else
            {
                dr["ImageURL"] = "~/images/measurement-tooltip.png";
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
        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shipments/CreateTirp.aspx");
        }

    }
}