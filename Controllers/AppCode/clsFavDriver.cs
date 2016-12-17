using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsFavDriver
    {
        public int insert(FavDriver driver)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DataAccess.AddParamter("@UserID", driver.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@DriverID", driver.DriverID, SqlDbType.Int, 50);

            string sql = "insert into FavDriver(UserID,DriverID) values (@UserID,@DriverID)";
            DataAccess.ExecuteSQLNonQuery(sql, param);

            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from FavDriver");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["MaxID"].ToString());
            }
            return 0;
        }
        
        public int Delete(int id)
        {
            string sql = "Delete From FavDriver Where  ID =" + id.ToString();
            return DataAccess.ExecuteSQLNonQuery(sql);
        }

        //public List<UserLocation> getList()
        //{
        //    List<UserLocation> userlocations = new List<UserLocation>();
        //    string sql = "select * from UserLocation";
        //    DataTable dt = DataAccess.ExecuteSQLQuery(sql);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        userlocations.Add(new UserLocation() { ID = int.Parse(dt.Rows[i]["ID"].ToString()), UserID = int.Parse(dt.Rows[i]["UserID"].ToString()), Latitude = decimal.Parse(dt.Rows[i]["Latitude"].ToString()), Longitude = decimal.Parse(dt.Rows[i]["Longitude"].ToString()), DateTime = DateTime.Parse(dt.Rows[i]["DateTime"].ToString()) });
        //    }
        //    return userlocations;
        //}
        public List<FavDriver> get(int UserID)
        {
            List<FavDriver> favDrivers = new List<FavDriver>();
            string sql = "select * from FavDriver inner join Users on DriverID = Users.ID inner join UserLocation on DriverID = UserLocation.UserID where FavDriver.UserID = " + UserID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                favDrivers.Add(new FavDriver() { ID = int.Parse(dt.Rows[i]["ID"].ToString()), UserID = int.Parse(dt.Rows[i]["UserID"].ToString()), DriverID = int.Parse(dt.Rows[i]["DriverID"].ToString()), DriverName = dt.Rows[i]["Name"].ToString(), DriverLat = decimal.Parse(dt.Rows[i]["latitude"].ToString()), DriverLng = decimal.Parse(dt.Rows[i]["longitude"].ToString()) });
            }
            return favDrivers;
        }
    }
}