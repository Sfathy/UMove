using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsSharedTrip
    {
        public int insert(SharedTrip sharedTrip)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[24];
            param[0] = DataAccess.AddParamter("@UserID", sharedTrip.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@DestLat", sharedTrip.DestLat, SqlDbType.Decimal, 50);
            param[2] = DataAccess.AddParamter("@DestLag", sharedTrip.DestLag, SqlDbType.Decimal, 50);
            param[3] = DataAccess.AddParamter("@SourceLat", sharedTrip.SourceLat, SqlDbType.Decimal, 50);
            param[4] = DataAccess.AddParamter("@SourceLag", sharedTrip.SourceLag, SqlDbType.Decimal, 50);
            param[5] = DataAccess.AddParamter("@EstimatedCost", sharedTrip.Cost, SqlDbType.Decimal, 50);
            param[6] = DataAccess.AddParamter("@TripDuration", sharedTrip.TripDuration, SqlDbType.Decimal, 50);
            param[7] = DataAccess.AddParamter("@TripCost", sharedTrip.TripCost, SqlDbType.Decimal, 50);
            param[8] = DataAccess.AddParamter("@EstimatedDuration", sharedTrip.TripDuration, SqlDbType.Decimal, 50);
            param[9] = DataAccess.AddParamter("@DriverID", sharedTrip.DriverID, SqlDbType.Int, 50);
            param[10] = DataAccess.AddParamter("@PicUpDate", sharedTrip.PicUpDate, SqlDbType.DateTime, 50);
            param[11] = DataAccess.AddParamter("@DeliveryDate", sharedTrip.DeliveryDate, SqlDbType.DateTime, 50);
            param[12] = DataAccess.AddParamter("@Note", sharedTrip.Note, SqlDbType.NVarChar, 500);
            param[13] = DataAccess.AddParamter("@PicUpType", sharedTrip.PicUpType, SqlDbType.NVarChar, 50);
            param[14] = DataAccess.AddParamter("@DeliveryType", sharedTrip.DeliveryType, SqlDbType.NVarChar, 50);
            param[15] = DataAccess.AddParamter("@SourceLocationText", sharedTrip.SourceLocationText, SqlDbType.NVarChar, 500);
            param[16] = DataAccess.AddParamter("@DeliveryLocationText", sharedTrip.DeliveryLocationText, SqlDbType.NVarChar, 500);
            param[17] = DataAccess.AddParamter("@Name", sharedTrip.Name, SqlDbType.NVarChar, 500);
            param[18] = DataAccess.AddParamter("@CustomerID", sharedTrip.CustomerID, SqlDbType.Int, 500);
            param[19] = DataAccess.AddParamter("@Country", sharedTrip.Country, SqlDbType.NVarChar, 500);
            param[20] = DataAccess.AddParamter("@TripType", sharedTrip.tripType, SqlDbType.Int, 50);
            param[21] = DataAccess.AddParamter("@PicUpTime", sharedTrip.PicUpTime, SqlDbType.NVarChar, 50);
            param[22] = DataAccess.AddParamter("@DeliveryTime", sharedTrip.DeliveryTime, SqlDbType.NVarChar, 50);
            param[23] = DataAccess.AddParamter("@SharedTripType", sharedTrip.SharetripType, SqlDbType.NVarChar, 50);
            //param[10] = DataAccess.AddParamter("@Cost", trip.Cost, SqlDbType.Decimal, 50);


            string sql = "INSERT INTO [dbo].[SharedTrip]([UserID],[DestLat],[DestLag],[SourceLat],[SourceLag],[EstimatedCost],[TripDuration],[TripCost],[EstimatedDuration],[DriverID],[PicUpDate],[DeliveryDate],[Note],[PicUpType],[PicUpTime],[DeliveryType],[DeliveryTime],[SourceLocationText],[DeliveryLocationText],[Name],[CustomerID],[Country],[PaymentType],[Puplished],[SharedTripType]) values" +
                                         "(@UserID,@DestLat,@DestLag,@SourceLat,@SourceLag,@EstimatedCost,@TripDuration,@TripCost,@EstimatedDuration,@DriverID,@PicUpDate,@DeliveryDate,@Note,@PicUpType,@PicUpTime,@DeliveryType,@DeliveryTime,@SourceLocationText,@DeliveryLocationText,@Name,@CustomerID,@Country,@TripType,2,@SharedTripType)";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            int tripID = 0;
            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from SharedTrip");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                tripID = int.Parse(dt.Rows[0]["MaxID"].ToString());
                //add trip items
                for (int i = 0; i < sharedTrip.tripService.Count; i++)
                {
                    SqlParameter[] param2 = new SqlParameter[2];
                    param2[0] = DataAccess.AddParamter("@TripID", tripID, SqlDbType.Int, 50);
                    param2[1] = DataAccess.AddParamter("@ServiceID", sharedTrip.tripService[i].ServiceID, SqlDbType.Int, 50);
                    sql = "INSERT INTO [SharedTrip_Service] ([SharedTripID],[ServiceID]) VALUES(@TripID,@ServiceID)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
                }

            }
            sendmessage(sharedTrip);
            return tripID;
        }
        public void sendmessage(Trip trip)
        {
            SqlParameter[] param2 = new SqlParameter[6];

            clsUser u = new clsUser();
            DataTable dt3 = u.get(trip.UserID);
            string Message = " You Have Request Trip by Name" + trip.Name + "";
            string Message_AR = " N'تم عمل رحلة بأسم' " + trip.Name + " فى انتظار موافقة مدير الموقع ";
            param2[0] = DataAccess.AddParamter("@Message", Message, SqlDbType.NChar, 500);
            param2[1] = DataAccess.AddParamter("@ToUser", trip.UserID, SqlDbType.Int, 50);
            param2[2] = DataAccess.AddParamter("@Sender", trip.UserID, SqlDbType.Int, 50);
            param2[3] = DataAccess.AddParamter("@Date", DateTime.Now, SqlDbType.DateTime, 50);
            param2[4] = DataAccess.AddParamter("@TripID", trip.ID, SqlDbType.Int, 50);
            param2[5] = DataAccess.AddParamter("@Message_AR", Message_AR, SqlDbType.NChar, 500);
            string sql = "insert into Inbox(Message,ToUserID,SenderID,MessageDate,TripID,Message_AR) values (@Message,@ToUser,@Sender,@Date,@TripID,@Message_AR) ";
            DataAccess.ExecuteSQLNonQuery(sql, param2);
        }
        public SharedTrip getTrip(int TripID)
        {
            string sql = "SELECT Name AS TripName, Country, PaymentType, SourceLocationText, DeliveryLocationText, PicUpDate, DeliveryDate, TripCost, DATEDIFF(hh, PicUpDate, DeliveryDate) AS Ending, Note, PicUpType,DriverID, DeliveryType, CustomerID, ID, UserID, DestLat, DestLag, SourceLag, SourceLat, ACOS(SIN(SourceLat) * SIN(DestLat) + COS(SourceLat) * COS(DestLat) * COS(DestLag - DestLag)) AS Dis,PicUpTime, DeliveryTime,SharedTripType FROM dbo.SharedTrip where ID=" + TripID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            SharedTrip t = new SharedTrip();
            t.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
            t.DestLat = Convert.ToDecimal(dt.Rows[0]["DestLat"].ToString());
            t.DestLag = Convert.ToDecimal(dt.Rows[0]["DestLag"].ToString());
            t.SourceLag = Convert.ToDecimal(dt.Rows[0]["SourceLag"].ToString());
            t.SourceLat = Convert.ToDecimal(dt.Rows[0]["SourceLat"].ToString());
            t.Cost = Convert.ToDecimal(dt.Rows[0]["TripCost"].ToString());
            t.Name = dt.Rows[0]["TripName"].ToString();
            t.SourceLocationText = dt.Rows[0]["SourceLocationText"].ToString();
            t.DeliveryLocationText = dt.Rows[0]["DeliveryLocationText"].ToString();
            t.DeliveryDate = Convert.ToDateTime(dt.Rows[0]["DeliveryDate"].ToString());
            t.PicUpDate = Convert.ToDateTime(dt.Rows[0]["PicUpDate"].ToString());
            t.TripDuration = Convert.ToDecimal(dt.Rows[0]["Ending"].ToString());
            t.destination = Convert.ToDecimal(dt.Rows[0]["Dis"].ToString());
            t.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
            t.DeliveryType = dt.Rows[0]["DeliveryType"].ToString();
            t.DriverID = Convert.ToInt32(dt.Rows[0]["DriverID"].ToString());
            t.Note = dt.Rows[0]["Note"].ToString();
            t.PicUpType = dt.Rows[0]["PicUpType"].ToString();
            t.Country = dt.Rows[0]["Country"].ToString();
            t.PicUpTime = dt.Rows[0]["PicUpTime"].ToString();
            t.DeliveryTime = dt.Rows[0]["DeliveryTime"].ToString();
            t.tripType = Convert.ToInt32(dt.Rows[0]["PaymentType"].ToString());
            t.SharetripType = Convert.ToInt32(dt.Rows[0]["SharedTripType"].ToString());
            sql = "Select [TripID],[ServiceID] From [Trip_Service] Where TripID=" + TripID;
            DataTable dt3 = DataAccess.ExecuteSQLQuery(sql);
            List<TripService> Services = new List<TripService>();
            foreach (DataRow dr in dt3.Rows)
            {
                TripService Service = new TripService();
                Service.ServiceID = Convert.ToInt32(dr["ServiceID"].ToString());
                Service.TripID = TripID;
                Services.Add(Service);
            }
            t.tripService = Services;
            return t;

        }
    }
}