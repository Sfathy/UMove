using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsInstallation
    {
        public DataTable insert(Installation inst)
        {
            
            string sql = "INSERT INTO [DeviceInstallation]([apiKey],[appIdentifier],[appVersion],[deviceType],[deviceToken],[timezone],[InstallationKey])"+
            " VALUES ('" + inst.apiKey.ToString() + "','" + inst.appIdentifier + "','" + inst.appVersion + "','" + inst.deviceType + "','" + inst.deviceToken + "','" + inst.timezone + "','" + DateTime.Now.ToString("yyyyMMddHHmmss") +"')";
            DataAccess.ExecuteSQLNonQuery(sql);
            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from DeviceInstallation");
            if(dt!= null && dt.Rows != null && dt.Rows.Count>0)
            {
                DataTable dt2 = DataAccess.ExecuteSQLQuery("select * from DeviceInstallation Where ID=" + dt.Rows[0]["MaxID"].ToString());
                return dt2;
            }
            return new DataTable();
            
        }
        public DataTable update( Installation inst)
        {
            string sql = "update DeviceInstallation set apiKey = " + inst.apiKey.ToString() + ",appIdentifier = '" + inst.appIdentifier + "',appVersion = '" + inst.appVersion + "',deviceType = '" + inst.deviceType + "',deviceToken = '" + inst.deviceToken + "',timezone = '" + inst.deviceToken + "' where InstallationKey = '" + inst.InstallationKey.ToString() + "'";
            
           DataAccess.ExecuteSQLNonQuery(sql);


           DataTable dt2 = DataAccess.ExecuteSQLQuery("select * from DeviceInstallation Where InstallationKey='" + inst.InstallationKey.ToString()+"'");
           if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
           {
               return dt2;
           }
           else
           {
               return new DataTable();
           }
          
          
        }
        public List<Installation> getList()
        {
            List<Installation> insts = new List<Installation>();
            /*string sql = "select * from users";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                users.Add(new Users() { UserNmae = dt.Rows[i]["userName"].ToString(), UserID = int.Parse(dt.Rows[i]["ID"].ToString()), Password = dt.Rows[i]["userPass"].ToString() });
            }*/
            return insts;
        }
        public DataTable get(string InstallationKey)
        {
            DataTable dt = DataAccess.ExecuteSQLQuery("select * from DeviceInstallation Where InstallationKey='" + InstallationKey.ToString()+"'");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return new DataTable();
            }
        }
        
    }
}