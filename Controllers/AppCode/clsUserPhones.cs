using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsUserPhones
    {
        public List<UserPhones> get(int userID) 
        {
            List<UserPhones> userPhones = new List<UserPhones>();
            string sql = "Select * from UserPhones Where UserID="+userID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserPhones userphone = new UserPhones();
                userphone.ID =Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                userphone.UserID = Convert.ToInt32(dt.Rows[i]["UserID"].ToString());
                userphone.PhoneNo = dt.Rows[i]["Phone"].ToString();
                userPhones.Add(userphone);
            }
            return userPhones;
        }
        public int insert(UserPhones userPhone) 
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = DataAccess.AddParamter("@UserID", userPhone.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@Phone", userPhone.PhoneNo, SqlDbType.NVarChar, 500);


            string sql = "insert into UserPhones(UserID,Phone) values (@UserID,@Phone)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            if (res > 0)
            {
                DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from UserPhones");
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    return int.Parse(dt.Rows[0]["MaxID"].ToString());
                }
            }
            return 0;
        }
        public int update(int id, UserPhones userPhone) 
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = DataAccess.AddParamter("@UserID", userPhone.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@Phone", userPhone.PhoneNo, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);

            string sql = "Update UserPhones Set UserID=@UserID,Phone=@Phone Where ID=@ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            if (res > 0)
            {
                DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from UserPhones");
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    return int.Parse(dt.Rows[0]["MaxID"].ToString());
                }
            }
            return 0;
        }
        public int Delete(int id)
        {
            string sql = "Delete From UserPhones Where  ID =" + id.ToString();
            return DataAccess.ExecuteSQLNonQuery(sql);
        }
    }
}