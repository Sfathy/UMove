using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsUserRate
    {
        public RateDriver get(int UserID)
        {
            RateDriver rateDriver = new RateDriver();
            string sql = "SELECT dbo.UserRate.UserID, dbo.Users.Name As UserName, AVG(dbo.UserRate.Rate) AS AvgRate FROM dbo.UserRate INNER JOIN dbo.Users ON dbo.UserRate.UserID = dbo.Users.ID Where UserID=" + UserID + " GROUP BY dbo.UserRate.UserID, dbo.Users.Name ";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                rateDriver.UserID = UserID;
                rateDriver.Name = dt.Rows[0]["UserName"].ToString();
                if (dt.Rows[0]["AvgRate"].ToString() == "" || dt.Rows[0]["AvgRate"].ToString() == "Null")
                    rateDriver.Rate = 0;
                else
                    rateDriver.Rate = Convert.ToDecimal(dt.Rows[0]["AvgRate"].ToString());
            }
            else
            {
                rateDriver.UserID = UserID;
                sql = "select Name From Users Where ID=" + UserID;
                dt = DataAccess.ExecuteSQLQuery(sql);
                rateDriver.Name = dt.Rows[0]["Name"].ToString();
                rateDriver.Rate = 0;
            }
            return rateDriver;
        }
        public int insert_DriverRate(RateDriver rateDriver)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@TripID", rateDriver.TripID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@UserID", rateDriver.DriverID, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@Rate", rateDriver.Rate, SqlDbType.Decimal, 50);
            param[3] = DataAccess.AddParamter("@ByUserID", rateDriver.UserID, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@Feedback", rateDriver.Feedback, SqlDbType.NVarChar, 500);
            string sql = "Insert Into dbo.UserRate([TripID],[UserID],[Rate],[ByUserID],[Feedback]) Values (@TripID,@UserID,@Rate,@ByUserID,@Feedback)";
            DataAccess.ExecuteSQLNonQuery(sql, param);

            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from UserRate");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["MaxID"].ToString());
            }
            return 0;
        }
        public int insert_UserRate(RateDriver rateDriver)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@TripID", rateDriver.TripID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@UserID", rateDriver.UserID, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@Rate", rateDriver.Rate, SqlDbType.Decimal, 50);
            param[3] = DataAccess.AddParamter("@ByUserID", rateDriver.DriverID, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@Feedback", rateDriver.Feedback, SqlDbType.NVarChar, 500);
            string sql = "Insert Into dbo.UserRate([TripID],[UserID],[Rate],[ByUserID],[Feedback]) Values (@TripID,@UserID,@Rate,@ByUserID,@Feedback)";
            DataAccess.ExecuteSQLNonQuery(sql, param);

            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from UserRate");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["MaxID"].ToString());
            }
            return 0;
        }
    }

}