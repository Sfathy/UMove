using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsPaymentMethod
    {
        public int insert(paymentMethodDetails card)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[6];
            param[0] = DataAccess.AddParamter("@UserID", card.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@MethodName", card.MethodName, SqlDbType.NVarChar, 250);
            param[2] = DataAccess.AddParamter("@ExpiryDate", card.ExpiryDate, SqlDbType.Date, 50);
            param[3] = DataAccess.AddParamter("@CardType", card.CardType, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@CardNumber", card.CardType, SqlDbType.NVarChar, 250);
            param[5] = DataAccess.AddParamter("@CardUserName", card.CardUserName, SqlDbType.NVarChar, 250);


            string sql = "insert into PaymentMethodDetails(UserID,MethodName,ExpiryDate,CardType,CardNumber,CardUserName) values (@UserID,@MethodName,@ExpiryDate,@CardType,@CardNumber,@CardUserName)";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            if (res > 0)
            {
                DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from PaymentMethodDetails");
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    return int.Parse(dt.Rows[0]["MaxID"].ToString());
                }
            }
            return 0;
        }

        public int updtate(int id,paymentMethodDetails card)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[7];
            param[0] = DataAccess.AddParamter("@UserID", card.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@MethodName", card.MethodName, SqlDbType.NVarChar, 250);
            param[2] = DataAccess.AddParamter("@ExpiryDate", card.ExpiryDate, SqlDbType.Date, 50);
            param[3] = DataAccess.AddParamter("@CardType", card.CardType, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@CardNumber", card.CardType, SqlDbType.NVarChar, 250);
            param[5] = DataAccess.AddParamter("@CardUserName", card.CardUserName, SqlDbType.NVarChar, 250);
            param[6] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);


            string sql = "update PaymentMethodDetails set UserID =@UserID ,MethodName = @MethodName,ExpiryDate = @ExpiryDate,CardType = @CardType,CardNumber= @CardNumber,CardUserName = @CardUserName where id = @ID";
            int res = DataAccess.ExecuteSQLNonQuery(sql, param);
            if (res > 0)
            {
                return id;
            }
            return 0;
        }

        public DataTable get(int id)
        {
            string sql = "select * from PaymentMethodDetails where UserID = " + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                return dt;
            return null;
        }

        public int delete(int id)
        {
            string sql = "delete from PaymentMethodDetails where ID = " + id.ToString();
            return DataAccess.ExecuteSQLNonQuery(sql);
            
        }

    }
}