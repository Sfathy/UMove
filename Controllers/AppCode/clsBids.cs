using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsBids
    {
        public int insertShareBid(Bid bid)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = DataAccess.AddParamter("@UserID", bid.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@Price", bid.Price, SqlDbType.Decimal, 50);
            param[2] = DataAccess.AddParamter("@TripID", bid.TripID, SqlDbType.Decimal, 50);
            param[3] = DataAccess.AddParamter("@TruckType", bid.TruckType, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@PickupDate", bid.PickupDate, SqlDbType.DateTime, 50);
            param[5] = DataAccess.AddParamter("@DeliveryDate", bid.DeliveryDate, SqlDbType.DateTime, 50);
            param[6] = DataAccess.AddParamter("@BidExpiration", bid.BidExpiration, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@Note", bid.Note, SqlDbType.NVarChar, 500);
            param[8] = DataAccess.AddParamter("@TermCondition", bid.TermCondition, SqlDbType.NVarChar, 500);
            param[9] = DataAccess.AddParamter("@Accepted", bid.Accepted, SqlDbType.Int, 50);
            //param[10] = DataAccess.AddParamter("@Cost", trip.Cost, SqlDbType.Decimal, 50);
            string sql = "insert into [SharedTripsBid](UserID,Price,SharedTripID,TruckType,PickupDate,DeliveryDate,BidExpiration,Note,TermCondition,Accepted,Puplished) values" +
                "(@UserID,@Price,@TripID,@TruckType,@PickupDate,@DeliveryDate,@BidExpiration,@Note,@TermCondition,@Accepted,2)";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            int bidID = 0;
            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from Bid");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                sendmessage(bid);
                bidID = int.Parse(dt.Rows[0]["MaxID"].ToString());
            }
            return bidID;
        }
        public int insert(Bid bid)
        {
              //check if the user name exist before
            SqlParameter[] param = new SqlParameter[10];
            param[0] = DataAccess.AddParamter("@UserID", bid.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@Price", bid.Price, SqlDbType.Decimal, 50);
            param[2] = DataAccess.AddParamter("@TripID", bid.TripID, SqlDbType.Decimal, 50);
            param[3] = DataAccess.AddParamter("@TruckType", bid.TruckType, SqlDbType.Int, 50);
            param[4] = DataAccess.AddParamter("@PickupDate", bid.PickupDate, SqlDbType.DateTime, 50);
            param[5] = DataAccess.AddParamter("@DeliveryDate", bid.DeliveryDate, SqlDbType.DateTime, 50);
            param[6] = DataAccess.AddParamter("@BidExpiration", bid.BidExpiration, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@Note", bid.Note, SqlDbType.NVarChar, 500);
            param[8] = DataAccess.AddParamter("@TermCondition", bid.TermCondition, SqlDbType.NVarChar, 500);
            param[9] = DataAccess.AddParamter("@Accepted", bid.Accepted, SqlDbType.Int, 50);
            
            //param[10] = DataAccess.AddParamter("@Cost", trip.Cost, SqlDbType.Decimal, 50);


            string sql = "insert into Bid(UserID,Price,TripID,TruckType,PickupDate,DeliveryDate,BidExpiration,Note,TermCondition,Accepted,Puplished) values" +
                "(@UserID,@Price,@TripID,@TruckType,@PickupDate,@DeliveryDate,@BidExpiration,@Note,@TermCondition,@Accepted,2)";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            int bidID = 0;
            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from Bid");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                sendmessage(bid);
                bidID = int.Parse(dt.Rows[0]["MaxID"].ToString());
            }
            return bidID;
        }
        public void sendmessage(Bid bid)
        {
            SqlParameter[] param2 = new SqlParameter[6];
            clsTrip clt = new clsTrip();

            Trip t = clt.getTrip(bid.TripID);
            clsUser u = new clsUser();
            DataTable dt3 = u.get(bid.UserID);
            string Message = dt3.Rows[0]["Name"].ToString() + " Bid " + t.Name + " By " + bid.Price.ToString() +"Pound";
            string Message_AR = dt3.Rows[0]["Name"].ToString() + "N' عرض '" + t.Name + " N'بمبلغ' " + bid.Price.ToString() + "N'جنيه'";
            param2[0] = DataAccess.AddParamter("@Message", Message, SqlDbType.NChar, 500);
            param2[1] = DataAccess.AddParamter("@ToUser", t.UserID, SqlDbType.Int, 50);
            param2[2] = DataAccess.AddParamter("@Sender", bid.UserID, SqlDbType.Int, 50);
            param2[3] = DataAccess.AddParamter("@Date", DateTime.Now, SqlDbType.DateTime, 50);
            param2[4] = DataAccess.AddParamter("@TripID", bid.TripID, SqlDbType.Int, 50);
            param2[5] = DataAccess.AddParamter("@Message_AR", Message_AR, SqlDbType.NChar, 500);
            string sql = "insert into Inbox(Message,ToUserID,SenderID,MessageDate,TripID,Message_AR) values (@Message,@ToUser,@Sender,@Date,@TripID,@Message_AR) ";
            DataAccess.ExecuteSQLNonQuery(sql, param2);
        }
        public int update(int id,Bid bid)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[8];
           
            param[0] = DataAccess.AddParamter("@Price", bid.Price, SqlDbType.Decimal, 50);
            param[1] = DataAccess.AddParamter("@TruckType", bid.TruckType, SqlDbType.Int, 50);
            param[2] = DataAccess.AddParamter("@PickupDate", bid.PickupDate, SqlDbType.DateTime, 50);
            param[3] = DataAccess.AddParamter("@DeliveryDate", bid.DeliveryDate, SqlDbType.DateTime, 50);
            param[4] = DataAccess.AddParamter("@BidExpiration", bid.BidExpiration, SqlDbType.DateTime, 50);
            param[5] = DataAccess.AddParamter("@Note", bid.Note, SqlDbType.NVarChar, 500);
            param[6] = DataAccess.AddParamter("@TermCondition", bid.TermCondition, SqlDbType.NVarChar, 500);
            param[7] = DataAccess.AddParamter("@ID", id, SqlDbType.Int, 50);
            //param[10] = DataAccess.AddParamter("@Cost", trip.Cost, SqlDbType.Decimal, 50);


            string sql = "update Bid set Price = @Price,TruckType = @TruckType,PickupDate = @PickupDate,DeliveryDate = @DeliveryDate,BidExpiration = @BidExpiration,Note = @Note,TermCondition = @TermCondition where ID = @ID";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            return id;
        }

        public List<Bid> getList(int tripID)
        {
            List<Bid> bids = null;
            string sql = "select * from bid where TripID = " + tripID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                bids = dt.DataTableToList<Bid>();
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    bids.Add(new Bid()
                //    {
                //        ID = int.Parse(dt.Rows[i]["ID"].ToString()),
                //        UserID = int.Parse(dt.Rows[i]["UserID"].ToString()),
                //        Price = decimal.Parse(dt.Rows[i]["Price"].ToString()),
                //        TripID = int.Parse(dt.Rows[i]["TripID"].ToString()),
                //        TruckType = int.Parse(dt.Rows[i]["TruckType"].ToString()),
                //        PickupDate = DateTime.Parse(dt.Rows[i]["PickupDate"].ToString()),
                //        DeliveryDate = DateTime.Parse(dt.Rows[i]["DeliveryDate"].ToString()),
                //        BidExpiration = DateTime.Parse(dt.Rows[i]["BidExpiration"].ToString()),
                //        Note = dt.Rows[i]["Note"].ToString(),
                //        TermCondition = dt.Rows[i]["TermCondition"].ToString(),
                //        Accepted = int.Parse(dt.Rows[i]["Accepted"].ToString())

                //    });
            }
           return bids;
            
        }
        public Bid get(int id) {
            string sql = "select * from bid where ID = " + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                Bid bid = new Bid();

                bid.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                bid.UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
                bid.Price = decimal.Parse(dt.Rows[0]["Price"].ToString());
                bid.TripID = int.Parse(dt.Rows[0]["TripID"].ToString());
                bid.TruckType = int.Parse(dt.Rows[0]["TruckType"].ToString());
                bid.PickupDate = DateTime.Parse(dt.Rows[0]["PickupDate"].ToString());
                bid.DeliveryDate = DateTime.Parse(dt.Rows[0]["DeliveryDate"].ToString());
                bid.BidExpiration = DateTime.Parse(dt.Rows[0]["BidExpiration"].ToString());
                bid.Note = dt.Rows[0]["Note"].ToString();
                bid.TermCondition = dt.Rows[0]["TermCondition"].ToString();
                bid.Accepted = int.Parse(dt.Rows[0]["Accepted"].ToString());



                return bid;
            }
            return null;
        }
        /*public List<UserLocation> get(int UserID)
        {
            List<UserLocation> userlocations = new List<UserLocation>();
            string sql = "select * from UserLocation where UserID = " + UserID.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                userlocations.Add(new UserLocation() { ID = int.Parse(dt.Rows[i]["ID"].ToString()), UserID = int.Parse(dt.Rows[i]["UserID"].ToString()), Latitude = decimal.Parse(dt.Rows[i]["Latitude"].ToString()), Longitude = decimal.Parse(dt.Rows[i]["Lagnitude"].ToString()), DateTime = DateTime.Parse(dt.Rows[i]["DateTime"].ToString()) });
            }
            return userlocations;
        }*/
    }
}