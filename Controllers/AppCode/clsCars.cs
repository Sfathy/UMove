using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsCars
    {
        public int insert(Cars car)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = DataAccess.AddParamter("@UserID", car.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@CarType", car.CarType, SqlDbType.NVarChar, 500);
            param[2] = DataAccess.AddParamter("@CarModel", car.CarModel, SqlDbType.NVarChar, 500);
            param[3] = DataAccess.AddParamter("@CarYear", car.CarYear, SqlDbType.NVarChar, 500);
            param[4] = DataAccess.AddParamter("@CarCondition", car.CarCondition, SqlDbType.NVarChar, 500);
            param[5] = DataAccess.AddParamter("@NumOFSeats", car.NumOFSeats, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@MaxWidth", car.MaxWidth, SqlDbType.Int, 50);
            param[7] = DataAccess.AddParamter("@hight", car.hight, SqlDbType.Int, 50);
            param[8] = DataAccess.AddParamter("@Active", car.Active, SqlDbType.Int, 50);

            string sql = "INSERT INTO [Cars]([CarType],[CarModel],[CarYear],[CarCondition],[NumOFSeats],[MaxWidth],[hight],[UserID],[Active]) VALUES" +
              "(@CarType,@CarModel,@CarYear,@CarCondition,@NumOFSeats,@MaxWidth,@hight,@UserID,@Active)";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            int CarID = 0;
            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from Cars");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {

                CarID = int.Parse(dt.Rows[0]["MaxID"].ToString());
            }
            return CarID;
        }
    }
}