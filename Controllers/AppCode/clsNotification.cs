using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsNotification
    {
        public int insert(Notification not)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[3];
            param[0] = DataAccess.AddParamter("@UserID", not.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@Description", not.Description, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@NotDate", not.NotDate, SqlDbType.DateTime, 50);

            string sql = "insert into Notifications(UserID,Description,NotDate) values (@UserID,@Description,@NotDate)";
            DataAccess.ExecuteSQLNonQuery(sql, param);

            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from Notifications");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["MaxID"].ToString());
            }
            return 0;
        }



        public List<Notification> get(int UserID)
        {
            List<Notification> userNotifications = new List<Notification>();
            string sql = "select * from Notifications where UserID = " + UserID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                userNotifications.Add(new Notification() { ID = int.Parse(dt.Rows[i]["ID"].ToString()), UserID = int.Parse(dt.Rows[i]["UserID"].ToString()), Description = dt.Rows[i]["Description"].ToString(), NotDate = DateTime.Parse(dt.Rows[i]["NotDate"].ToString()) });
            }
            return userNotifications;
        }
    }
}