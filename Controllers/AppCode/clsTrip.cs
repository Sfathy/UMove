using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsTrip
    {
        public int insert(Trip trip)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[21];
            param[0] = DataAccess.AddParamter("@UserID", trip.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@DestLat", trip.DestLat, SqlDbType.Decimal, 50);
            param[2] = DataAccess.AddParamter("@DestLag", trip.DestLag, SqlDbType.Decimal, 50);
            param[3] = DataAccess.AddParamter("@SourceLat", trip.SourceLat, SqlDbType.Decimal, 50);
            param[4] = DataAccess.AddParamter("@SourceLag", trip.SourceLag, SqlDbType.Decimal, 50);
            param[5] = DataAccess.AddParamter("@EstimatedCost", trip.Cost, SqlDbType.Decimal, 50);
            param[6] = DataAccess.AddParamter("@TripDuration", trip.TripDuration, SqlDbType.Decimal, 50);
            param[7] = DataAccess.AddParamter("@TripCost", trip.TripCost, SqlDbType.Decimal, 50);
            param[8] = DataAccess.AddParamter("@EstimatedDuration", trip.TripDuration, SqlDbType.Decimal, 50);
            param[9] = DataAccess.AddParamter("@DriverID", trip.DriverID, SqlDbType.Int, 50);
            param[10] = DataAccess.AddParamter("@PicUpDate", trip.PicUpDate, SqlDbType.DateTime, 50);
            param[11] = DataAccess.AddParamter("@DeliveryDate", trip.DeliveryDate, SqlDbType.DateTime, 50);
            param[12] = DataAccess.AddParamter("@Note", trip.Note, SqlDbType.NVarChar, 500);
            param[13] = DataAccess.AddParamter("@PicUpType", trip.PicUpType, SqlDbType.Int, 50);
            param[14] = DataAccess.AddParamter("@DeliveryType", trip.DeliveryType, SqlDbType.Int, 50);
            param[15] = DataAccess.AddParamter("@SourceLocationText", trip.SourceLocationText, SqlDbType.NVarChar, 500);
            param[16] = DataAccess.AddParamter("@DeliveryLocationText", trip.DeliveryLocationText, SqlDbType.NVarChar, 500);
            param[17] = DataAccess.AddParamter("@Name", trip.Name, SqlDbType.NVarChar, 500);
            param[18] = DataAccess.AddParamter("@CustomerID", trip.CustomerID, SqlDbType.Int, 500);
            param[19] = DataAccess.AddParamter("@Country", trip.Country, SqlDbType.Int, 500);
            param[20] = DataAccess.AddParamter("@TripType", trip.tripType, SqlDbType.Int, 50);
            //param[10] = DataAccess.AddParamter("@Cost", trip.Cost, SqlDbType.Decimal, 50);


            string sql = "insert into Trip([UserID],[DestLat],[DestLag],[SourceLat],[SourceLag],[EstimatedCost],[TripDuration],[TripCost],[EstimatedDuration],[DriverID],[PicUpDate],[DeliveryDate],[Note],[PicUpType],[DeliveryType],[SourceLocationText],[DeliveryLocationText],[Name],[CustomerID],[Country],[PaymentType],[Puplished]) values" +
                                         "(@UserID,@DestLat,@DestLag,@SourceLat,@SourceLag,@EstimatedCost,@TripDuration,@TripCost,@EstimatedDuration,@DriverID,@PicUpDate,@DeliveryDate,@Note,@PicUpType,@DeliveryType,@SourceLocationText,@DeliveryLocationText,@Name,@CustomerID,@Country,@TripType,2)";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            int tripID = 0;
            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from Trip");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                tripID = int.Parse(dt.Rows[0]["MaxID"].ToString());
                //add trip items
                SqlParameter[] param2 = new SqlParameter[10];
                for (int i = 0; i < trip.ItemsList.Count; i++)
                {
                    param2 = new SqlParameter[10];
                    param2[0] = DataAccess.AddParamter("@TripID", tripID, SqlDbType.Int, 50);
                    param2[1] = DataAccess.AddParamter("@ItemCatID", trip.ItemsList[i].CatID, SqlDbType.Int, 50);
                    param2[2] = DataAccess.AddParamter("@ItemSubCatID", trip.ItemsList[i].SubCatID, SqlDbType.Int, 50);
                    param2[3] = DataAccess.AddParamter("@ItemDesc", trip.ItemsList[i].Description, SqlDbType.NVarChar, 500);
                    param2[4] = DataAccess.AddParamter("@Width", trip.ItemsList[i].Width, SqlDbType.Decimal, 50);
                    param2[5] = DataAccess.AddParamter("@Height", trip.ItemsList[i].Height, SqlDbType.Decimal, 50);
                    param2[6] = DataAccess.AddParamter("@Length", trip.ItemsList[i].Length, SqlDbType.Decimal, 50);
                    param2[7] = DataAccess.AddParamter("@Wight", trip.ItemsList[i].Wight, SqlDbType.Decimal, 50);
                    param2[8] = DataAccess.AddParamter("@NoOfUnits", trip.ItemsList.Count, SqlDbType.Int, 50);
                    param2[9] = DataAccess.AddParamter("@ImageURL", trip.ItemsList[i].ImageURL, SqlDbType.NVarChar, 500);
                    sql = "insert into TripItems(TripID,ItemCatID,ItemSubCatID,ItemDesc,Width,Height,Length,Wight,NoOfUnits,ImageURL) values (@TripID,@ItemCatID,@ItemSubCatID,@ItemDesc,@Width,@Height,@Length,@Wight,@NoOfUnits,@ImageURL)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);

                }
                for (int i = 0; i < trip.tripService.Count; i++)
                {
                    param2 = new SqlParameter[2];
                    param2[0] = DataAccess.AddParamter("@TripID", tripID, SqlDbType.Int, 50);
                    param2[1] = DataAccess.AddParamter("@ServiceID", trip.tripService[i].ServiceID, SqlDbType.Int, 50);
                    sql = "INSERT INTO [Trip_Service] ([TripID],[ServiceID]) VALUES(@TripID,@ServiceID)";
                    DataAccess.ExecuteSQLNonQuery(sql, param2);
                }

            }
            sendmessage(trip);
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
        public int update(int id, Trip trip)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[22];
            param[0] = DataAccess.AddParamter("@UserID", trip.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@DestLat", trip.DestLat, SqlDbType.Decimal, 50);
            param[2] = DataAccess.AddParamter("@DestLag", trip.DestLag, SqlDbType.Decimal, 50);
            param[3] = DataAccess.AddParamter("@SourceLat", trip.SourceLat, SqlDbType.Decimal, 50);
            param[4] = DataAccess.AddParamter("@SourceLag", trip.SourceLag, SqlDbType.Decimal, 50);
            param[5] = DataAccess.AddParamter("@EstimatedCost", trip.Cost, SqlDbType.Decimal, 50);
            param[6] = DataAccess.AddParamter("@TripDuration", trip.TripDuration, SqlDbType.Decimal, 50);
            param[7] = DataAccess.AddParamter("@TripCost", trip.TripCost, SqlDbType.Decimal, 50);
            param[8] = DataAccess.AddParamter("@EstimatedDuration", trip.TripDuration, SqlDbType.Decimal, 50);
            param[9] = DataAccess.AddParamter("@DriverID", trip.DriverID, SqlDbType.Int, 50);
            param[10] = DataAccess.AddParamter("@PicUpDate", trip.PicUpDate, SqlDbType.DateTime, 50);
            param[11] = DataAccess.AddParamter("@DeliveryDate", trip.DeliveryDate, SqlDbType.DateTime, 50);
            param[12] = DataAccess.AddParamter("@Note", trip.Note, SqlDbType.NVarChar, 500);
            param[13] = DataAccess.AddParamter("@PicUpType", trip.PicUpType, SqlDbType.NVarChar, 500);
            param[14] = DataAccess.AddParamter("@DeliveryType", trip.DeliveryType, SqlDbType.NVarChar, 500);
            param[15] = DataAccess.AddParamter("@SourceLocationText", trip.SourceLocationText, SqlDbType.NVarChar, 500);
            param[16] = DataAccess.AddParamter("@DeliveryLocationText", trip.DeliveryLocationText, SqlDbType.NVarChar, 500);
            param[17] = DataAccess.AddParamter("@Name", trip.Name, SqlDbType.NVarChar, 500);
            param[18] = DataAccess.AddParamter("@CustomerID", trip.CustomerID, SqlDbType.Int, 500);
            param[19] = DataAccess.AddParamter("@Country", trip.Country, SqlDbType.NVarChar, 500);
            param[20] = DataAccess.AddParamter("@TripType", trip.tripType, SqlDbType.Int, 50);
            param[21] = DataAccess.AddParamter("@ID", trip.ID, SqlDbType.Int, 50);
            //param[10] = DataAccess.AddParamter("@Cost", trip.Cost, SqlDbType.Decimal, 50);


            string sql = "update Trip set UserID =@UserID ,DestLat = @DestLat,DestLag = @DestLag,SourceLat = @SourceLat,SourceLag = @SourceLag,EstimatedCost = @EstimatedCost,TripDuration = @TripDuration,TripCost = @TripCost,EstimatedDuration = @EstimatedDuration,DriverID = @DriverID"+
                ",PicUpDate=@PicUpDate,DeliveryDate=@DeliveryDate,Note=@Note,PicUpType=@PicUpType,DeliveryType=@DeliveryType,SourceLocationText=@SourceLocationText,DeliveryLocationText=@DeliveryLocationText,Name=@Name,CustomerID=@CustomerID,PaymentType=@TripType" +
                ")  where ID = @ID";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            int tripID = trip.ID;
            //DataTable dt = DataAccess.ExecuteSQLQuery("delete from TripItems where TripID = " + id.ToString());
            ////add trip items
            //SqlParameter[] param2 = new SqlParameter[10];
            //for (int i = 0; i < trip.ItemsList.Count; i++)
            //{
            //    param2 = new SqlParameter[9];
            //    param2[0] = DataAccess.AddParamter("@TripID", tripID, SqlDbType.Int, 50);
            //    param2[1] = DataAccess.AddParamter("@ItemCatID", trip.ItemsList[i].CatID, SqlDbType.Int, 50);
            //    param2[2] = DataAccess.AddParamter("@ItemSubCatID", trip.ItemsList[i].SubCatID, SqlDbType.Int, 50);
            //    param2[3] = DataAccess.AddParamter("@ItemDesc", trip.ItemsList[i].Description, SqlDbType.NVarChar, 500);
            //    param2[4] = DataAccess.AddParamter("@Width", trip.ItemsList[i].Width, SqlDbType.Decimal, 50);
            //    param2[5] = DataAccess.AddParamter("@Height", trip.ItemsList[i].Height, SqlDbType.Decimal, 50);
            //    param2[6] = DataAccess.AddParamter("@Length", trip.ItemsList[i].Length, SqlDbType.Decimal, 50);
            //    param2[7] = DataAccess.AddParamter("@Wight", trip.ItemsList[i].Wight, SqlDbType.Decimal, 50);
            //    param2[8] = DataAccess.AddParamter("@NoOfUnits", trip.ItemsList[i].NoOfUnits, SqlDbType.Decimal, 50);
            //    sql = "insert into TripItems(TripID,ItemCatID,ItemSubCatID,ItemDesc,Width,Height,Length,Wight,NoOfUnits) values (@TripID,@ItemCatID,@ItemSubCatID,@ItemDesc,@Width,@Height,@Length,@Wight,@NoOfUnits)";
            //    DataAccess.ExecuteSQLNonQuery(sql, param2);

            //}

            return tripID;
        }
        public List<Trip> getList()
        {
            List<Trip> trips = new List<Trip>();
            string sql = "select * from Trip";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                trips.Add(new Trip()
                {
                    ID = int.Parse(dt.Rows[i]["ID"].ToString()),
                    UserID = int.Parse(dt.Rows[i]["UserID"].ToString()),
                    TripCost = decimal.Parse(dt.Rows[i]["TripCost"].ToString()),
                });
            }
            return trips;
        }
     
        public Trip getTrip(int TripID)
        {
            string sql = "SELECT Trip.Name AS TripName,Trip.Country,Trip.PaymentType,Trip.SourceLocationText, Trip.DeliveryLocationText, Trip.PicUpDate, Trip.DeliveryDate,Trip.TripCost ,DATEDIFF(hh, Trip.PicUpDate, Trip.DeliveryDate) AS Ending,Trip.Note,Trip.PicUpType,Trip.DriverID,Trip.DeliveryType,Trip.CustomerID, Trip.ID,Trip.UserID as UserID,Trip.DestLat,Trip.DestLag,Trip.SourceLag,Trip.SourceLat ,ACOS(SIN(Trip.SourceLat) * SIN(Trip.DestLat) + COS(Trip.SourceLat) * COS(Trip.DestLat) * COS(Trip.DestLag - Trip.DestLag)) AS Dis from Trip where ID=" + TripID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            Trip t = new Trip();
            //sql = "select * from TripItems where TripID=" + TripID.ToString();
            //DataTable dt2 = DataAccess.ExecuteSQLQuery(sql);
            //List<Item> Items = new List<Item>();

            //foreach (DataRow dr in dt2.Rows)
            //{
            //    Item item = new Item();
            //    item.CatID = Convert.ToInt32(dr["ItemCatID"].ToString());
            //    item.Description = dr["ItemDesc"].ToString();
            //    item.ImageURL = dr["ImageURL"].ToString();
            //    if (dr["Height"].ToString()==""||dr["Height"].ToString()=="0.000")
            //    {
            //        item.Height = 0;
            //    }
            //    else
            //    item.Height = Convert.ToInt32(dr["Height"].ToString());
            //    if (dr["Length"].ToString() == "" || dr["Length"].ToString() == "0.000")
            //    {
            //        item.Length = 0;
            //    }
            //    else
            //     item.Length = Convert.ToInt32(dr["Length"].ToString());
            //    if (dr["Width"].ToString() == "" || dr["Width"].ToString() == "0.000")
            //    {
            //        item.Width = 0;
            //    }
            //    else
            //        item.Width = Convert.ToInt32(dr["Wight"].ToString());
            //    if (dr["Wight"].ToString() == "" || dr["Wight"].ToString() == "0.000")
            //    {
            //        item.Wight = 0;
            //    }
            //    else
            //        item.Wight = Convert.ToInt32(dr["Length"].ToString());
                
            //    item.ItemType =0;
                
            //    item.SubCatID = Convert.ToInt32(dr["ItemSubCatID"].ToString());
               
            //    item.NoOfUnits = dt2.Rows.Count;
            //    Items.Add(item);
            //}
            //t.ItemsList = Items;
            //sql = "select * from Trip_Service where TripID=" + TripID.ToString();
            //DataTable dt3 = DataAccess.ExecuteSQLQuery(sql);
            //List<TripService> Services = new List<TripService>();
            //foreach (DataRow dr in dt3.Rows)
            //{
            //    TripService Service = new TripService();
            //    Service.ServiceID = Convert.ToInt32(dr["ServiceID"].ToString());
            //    Service.TripID = TripID;
            //    Services.Add(Service);
            //}
            //t.tripService = Services;
            //sql = "select * from TripQuestions where TripID=" + TripID.ToString();
            //DataTable dt4 = DataAccess.ExecuteSQLQuery(sql);
            //List<TripQuestions> Questions = new List<TripQuestions>();
            //foreach (DataRow dr in dt4.Rows)
            //{
            //    TripQuestions Question = new TripQuestions();
            //    Question.QuestionUserID = Convert.ToInt32(dr["QuestionUserID"].ToString());
            //    Question.Question = dr["Question"].ToString();
            //    Question.Answer = dr["Answer"].ToString();
            //    Question.AnswerUserID = Convert.ToInt32(dr["AnswerUserID"].ToString());
            //    Question.QuestionTime = Convert.ToDateTime(dr["QuestionTime"].ToString());
            //    Question.AnswerTime = Convert.ToDateTime(dr["AnswerTime"].ToString());
            //    Question.TripID = TripID;
            //    Questions.Add(Question);
            //}
            //t.TripQuestionsList = Questions;
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
            
            t.tripType = Convert.ToInt32(dt.Rows[0]["PaymentType"].ToString());
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
        public List<UserLocation> get(int UserID)
        {
            List<UserLocation> userlocations = new List<UserLocation>();
            string sql = "select * from UserLocation where UserID = " + UserID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                userlocations.Add(new UserLocation() { ID = int.Parse(dt.Rows[i]["ID"].ToString()), UserID = int.Parse(dt.Rows[i]["UserID"].ToString()), Latitude = decimal.Parse(dt.Rows[i]["Latitude"].ToString()), Longitude = decimal.Parse(dt.Rows[i]["Lagnitude"].ToString()), DateTime = DateTime.Parse(dt.Rows[i]["DateTime"].ToString()) });
            }
            return userlocations;
        }
        public string getCategoryName(int catID)
        {
            string sql = "select Name from SubCategory where ID = " + catID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            return dt.Rows[0]["Name"].ToString();
        }
    }
}