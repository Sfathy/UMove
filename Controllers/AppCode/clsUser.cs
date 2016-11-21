using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsUser
    {
        public  int insert(Users user)
        {
            //check if the user name exist before
            string sql = " select * from Users where UserName ='" + user.UserName + "' or Email = '" + user.Email +"'";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if(dt != null && dt.Rows != null && dt.Rows.Count>0)
            {
                return -1;
            }
            if (user.InstallationKey == "")
            {
                sql = "insert into Users([Name],[UserName],[Email],[Password],[Type],[Phone],[Address],CarType)" +
                    "values ('" + user.Name + "','" + user.UserName + "','" + user.Email + "','" + user.Password + "'," + user.Type + ",'" + user.Phone + "','" + user.Address + "'," + user.CarType.ToString()+")";
            }
            else
            {
                sql = "insert into Users([Name],[UserName],[Email],[Password],[Type],[Phone],[Address],installationKey,CarType)" +
                    "values ('" + user.Name + "','" + user.UserName + "','" + user.Email + "','" + user.Password + "'," + user.Type + ",'" + user.Phone + "','" + user.Address + "','" + user.InstallationKey + "'," + user.CarType.ToString() + ")";
            }
            DataAccess.ExecuteSQLNonQuery(sql);
            
            dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from Users");
            if(dt!= null && dt.Rows != null && dt.Rows.Count>0)
            {
                return int.Parse(dt.Rows[0]["MaxID"].ToString());
            }
            return 0;
        }
        public int update(int id, Users user)
        {
            string sql = "update Users set Name=  '" + user.Name + "',Password = '" + user.Password + "',Phone= '" + user.Phone + "' ,Address= '" + user.Address + "', CarType = "+user.CarType.ToString()+"  where ID = " + id.ToString();
            DataAccess.ExecuteSQLNonQuery(sql);
            return id;
        }
        public List<Users> getList()
        {
            List<Users> users = new List<Users>();
            string sql = "select * from Users";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                users.Add(new Users() { UserName = dt.Rows[i]["UserName"].ToString(), UserID = int.Parse(dt.Rows[i]["ID"].ToString()), Password = dt.Rows[i]["Password"].ToString(), Email = dt.Rows[i]["Email"].ToString(), CarType = int.Parse(dt.Rows[i]["CarType"].ToString()) });
            }
            return users;
        }
        public DataTable get(int ID)
        {
            Users user = new Users();
            string sql = "select * from Users where ID=" + ID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            return new DataTable();

        }
        public int getType(int userID) {
            string sql = "select Type from Users where ID=" + userID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["Type"].ToString());
            }
            return 0;
        }
        public int login(string email,string pass)
        {
            string sql = "select * from users where Email = '" + email + "' and Password ='" + pass + "'";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if(dt != null && dt.Rows != null && dt.Rows.Count>0)
            {

             return Convert.ToInt32(int.Parse(dt.Rows[0]["ID"].ToString()));
                
            }
            return 0;
        }
        public DataTable restPassword(string email) {
            string sql = "select Password from users where Email = '" + email + "'";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return dt;

            }
            return new DataTable();
        }

        public  string getUserDeviceToken(int userID)
        {
            string sql = "select deviceToken from DeviceInstallation inner join Users on Users.installationKey = DeviceInstallation.installationKey where Users.ID = " + userID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                return dt.Rows[0]["deviceToken"].ToString();
            return "";
        }
    }
}