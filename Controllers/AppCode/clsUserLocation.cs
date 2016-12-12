using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsUserLocation
    {
        public int insert(UserLocation loc)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@UserID", loc.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@latitude", loc.Latitude, SqlDbType.Decimal, 50);
            param[2] = DataAccess.AddParamter("@Longitude", loc.Longitude, SqlDbType.Decimal, 50);
            param[3] = DataAccess.AddParamter("@datetime", loc.DateTime, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@Angle", loc.Angle, SqlDbType.Decimal, 50);

            string sql = "insert into UserLocation(UserID,latitude,Longitude,datetime,Angle) values (@UserID,@Latitude,@Longitude,@DateTime,@Angle)";
            DataAccess.ExecuteSQLNonQuery(sql, param);

            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from UserLocation");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["MaxID"].ToString());
            }
            return 0;
        }
        public int update(int id, UserLocation loc)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DataAccess.AddParamter("@UserID", loc.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@latitude", loc.Latitude, SqlDbType.Decimal, 50);
            param[2] = DataAccess.AddParamter("@Longitude", loc.Longitude, SqlDbType.Decimal, 50);
            param[3] = DataAccess.AddParamter("@datetime", loc.DateTime, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            param[5] = DataAccess.AddParamter("@Angle", loc.Angle, SqlDbType.Decimal, 50);

            string sql = "update UserLocation set UserID = @UserID,latitude=@Latitude,Longitude=@Longitude,datetime=@DateTime,Angle = @Angle where ID = @ID";
            DataAccess.ExecuteSQLNonQuery(sql, param);


            return id;
        }

        public DataTable getNearestDrivers(decimal lat, decimal lon)
        {
            //SELECT TOP 5 Min(acos(sin(29.8263484) * sin(latitude) + cos(29.8263484) * cos(latitude) * cos(Longitude - (31.316185))))  as dis,UserID FROM UserLocation --WHERE
            //group by UserID

            //order by dis
            string sql = "SELECT TOP 5 Min(acos(sin(" + lat.ToString() + ") * sin(latitude) + cos(" + lat.ToString() + ") * cos(latitude) * cos(Longitude - (" + lon.ToString() + "))))  as dis,UserID,Users.Name,latitude,Longitude,[datetime],[type],deviceToken,CarType,Angle,5 as Time FROM UserLocation inner join Users on Users.ID =UserLocation.UserID inner join DeviceInstallation on Users.installationKey = DeviceInstallation.InstallationKey group by UserID,Users.Name,latitude,Longitude,[datetime],[type],deviceToken,CarType,Angle  having datetime > convert(VARCHAR(24),'" + DateTime.Now.AddMinutes(-30).ToString("yyyy-MM-dd hh:mm:ss") + "',120) and Users.Type = 1 order By dis";
            return DataAccess.ExecuteSQLQuery(sql);

        }
        public List<UserLocation> getList()
        {
            List<UserLocation> userlocations = new List<UserLocation>();
            string sql = "select * from UserLocation";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                userlocations.Add(new UserLocation() { ID = int.Parse(dt.Rows[i]["ID"].ToString()), UserID = int.Parse(dt.Rows[i]["UserID"].ToString()), Latitude = decimal.Parse(dt.Rows[i]["Latitude"].ToString()), Longitude = decimal.Parse(dt.Rows[i]["Longitude"].ToString()), DateTime = DateTime.Parse(dt.Rows[i]["DateTime"].ToString()), Angle = decimal.Parse(dt.Rows[i]["Angle"].ToString()) });
            }
            return userlocations;
        }
        public List<UserLocation> get(int UserID)
        {
            List<UserLocation> userlocations = new List<UserLocation>();
            string sql = "select * from UserLocation where UserID = " + UserID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                userlocations.Add(new UserLocation() { ID = int.Parse(dt.Rows[i]["ID"].ToString()), UserID = int.Parse(dt.Rows[i]["UserID"].ToString()), Latitude = decimal.Parse(dt.Rows[i]["Latitude"].ToString()), Longitude = decimal.Parse(dt.Rows[i]["Longitude"].ToString()), DateTime = DateTime.Parse(dt.Rows[i]["DateTime"].ToString()), Angle = decimal.Parse(dt.Rows[i]["Angle"].ToString()) });
            }
            return userlocations;
        }

    }
}