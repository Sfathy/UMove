using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UMoveNew.Controllers.AppCode
{
    public sealed class clsSettings
    {
        private  static clsSettings  setting = null;
        public  decimal DriverCancelFee { get; set; }
        public  decimal UserCancelFee { get; set; }

        public  decimal UserPointRate { get; set; }

        public   decimal DriverPointRate { get; set; }

        public  decimal CompanyRate { get; set; }
        public int PageSize { get; set; }

        public  static clsSettings  Setting
        {
            get
            {
                if (setting == null)
                {
                    string sql = "select * from Settings";
                    DataTable dt = DataAccess.ExecuteSQLQuery(sql);
                    setting = new clsSettings();
                    if(dt != null && dt.Rows != null && dt.Rows.Count>0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            switch (dt.Rows[i]["ParamterName"].ToString())
                            {
                                case "DriverCancelFee":
                                    setting.DriverCancelFee = decimal.Parse(dt.Rows[i]["ParamterValue"].ToString());
                                    break;
                                case "UserCancelFee":
                                    setting.UserCancelFee = decimal.Parse(dt.Rows[i]["ParamterValue"].ToString());
                                    break;
                                case "UserPointRate":
                                    setting.UserPointRate = decimal.Parse(dt.Rows[i]["ParamterValue"].ToString());
                                    break;
                                case "DriverPointRate":
                                    setting.DriverPointRate = decimal.Parse(dt.Rows[i]["ParamterValue"].ToString());
                                    break;
                                case "CompanyRate":
                                    setting.CompanyRate = decimal.Parse(dt.Rows[i]["ParamterValue"].ToString());
                                    break;
                                case "PageSize":
                                    setting.PageSize = int.Parse(dt.Rows[i]["PageSize"].ToString());
                                    break;
                                
                            }
                        }
                    }
                }
                return setting;
            }
        }
        
    }
}