using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UMoveNew.Controllers.AppCode
{
    public class clsUserBalance
    {
        public  DataTable getBalance(int userID)
        {
            string sql = "select KMBalance as Km,MoneyBalance as Money,PointsBalance as Point from UserBalance where UserID = " + userID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if(dt == null || dt.Rows == null || dt.Rows.Count==0)
            {
                dt = new DataTable();
                dt.Columns.Add("Km");
                dt.Columns.Add("Money");
                dt.Columns.Add("Point");
                DataRow dr = dt.NewRow();
                dr["Point"] = 0;
                dr["Money"] = 0;
                dr["Km"] = 0;
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}