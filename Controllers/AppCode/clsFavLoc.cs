﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsFavLoc
    {
        public int insert(UserLocation loc)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[5];
            param[0] = DataAccess.AddParamter("@UserID", loc.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@latitude", loc.Latitude, SqlDbType.Decimal, 50);
            param[2] = DataAccess.AddParamter("@Longitude", loc.Longitude, SqlDbType.Decimal, 50);
            param[3] = DataAccess.AddParamter("@Description", loc.Description, SqlDbType.VarChar, 250);
            param[4] = DataAccess.AddParamter("@Address", loc.Address, SqlDbType.VarChar, 500);

            string sql = "insert into UserFavLocation(UserID,latitude,Longitude,Description,Address) values (@UserID,@Latitude,@Longitude,@Description,@Address)";
            DataAccess.ExecuteSQLNonQuery(sql, param);

            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from UserFavLocation");
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
            param[3] = DataAccess.AddParamter("@Description", loc.Description, SqlDbType.VarChar , 250);
            param[4] = DataAccess.AddParamter("@Address", loc.Address, SqlDbType.VarChar, 500);
            param[5] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);

            string sql = "update UserFavLocation set UserID = @UserID,latitude=@Latitude,Longitude=@Longitude,Description=@Description,Address=@Address where ID = @ID";
            DataAccess.ExecuteSQLNonQuery(sql, param);


            return id;
        }
        public int Delete(int id) 
        {
            string sql = "Delete From UserFavLocation Where  ID =" + id.ToString();
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
        public List<UserLocation> get(int UserID)
        {
            List<UserLocation> userlocations = new List<UserLocation>();
            string sql = "select * from UserFavLocation where UserID = " + UserID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                userlocations.Add(new UserLocation() { ID = int.Parse(dt.Rows[i]["ID"].ToString()), UserID = int.Parse(dt.Rows[i]["UserID"].ToString()), Latitude = decimal.Parse(dt.Rows[i]["Latitude"].ToString()), Longitude = decimal.Parse(dt.Rows[i]["Longitude"].ToString()), Description = dt.Rows[i]["Description"].ToString(), Address=dt.Rows[i]["Address"].ToString() });
            }
            return userlocations;
        }
    }
}