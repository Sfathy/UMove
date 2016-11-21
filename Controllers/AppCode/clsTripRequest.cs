using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UMoveNew.Models;

namespace UMoveNew.Controllers.AppCode
{
    public class clsTripRequest
    {
        public enum TripStatus
        {
            Request = 1,
            Accepted = 2,
            InProgress = 3,
            Ended = 4
        }
        public int insert(TripRequest trip)
        {
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[9];
            param[0] = DataAccess.AddParamter("@UserID", trip.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@DestLat", trip.DestLat, SqlDbType.Decimal, 50);
            param[2] = DataAccess.AddParamter("@DestLong", trip.DestLong, SqlDbType.Decimal, 50);
            param[3] = DataAccess.AddParamter("@SourceLat", trip.SourceLat, SqlDbType.Decimal, 50);
            param[4] = DataAccess.AddParamter("@SourceLong", trip.Sourcelong, SqlDbType.Decimal, 50);
            param[5] = DataAccess.AddParamter("@DriverID", trip.DriverID, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@PicUpDate", trip.PicUpDate, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@PaymentMethod", trip.PaymentMethod, SqlDbType.Int, 50);
            param[8] = DataAccess.AddParamter("@CarCategory", trip.CarCategory, SqlDbType.Int, 50);
            
            //param[10] = DataAccess.AddParamter("@Cost", trip.Cost, SqlDbType.Decimal, 50);


            string sql = "insert into TripRequest([UserID],[DestLat],[DestLong],[SourceLat],[SourceLong],[DriverID],[PicUpDate],PaymentMethod,CarCategory) values" +
                "(@UserID,@DestLat,@DestLong,@SourceLat,@SourceLong,@DriverID,@PicUpDate,@PaymentMethod,@CarCategory)";
            DataAccess.ExecuteSQLNonQuery(sql, param);
            int tripID = 0;
            DataTable dt = DataAccess.ExecuteSQLQuery("select Max(ID) as MaxID from TripRequest");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                tripID = int.Parse(dt.Rows[0]["MaxID"].ToString());
                
            }
            return tripID;
        }
        public TripRequest get(int id)
        {
            string sql = "select * from TripRequest where ID = " + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if(dt != null && dt.Rows!=null && dt.Rows.Count>0)
                return new TripRequest() { UserID = int.Parse(dt.Rows[0]["UserID"].ToString()), DestLat = decimal.Parse(dt.Rows[0]["DestLat"].ToString()), DestLong = decimal.Parse(dt.Rows[0]["DestLong"].ToString()), DriverID = int.Parse(dt.Rows[0]["DriverID"].ToString()), PicUpDate = DateTime.Parse(dt.Rows[0]["PicUpDate"].ToString()), SourceLat = decimal.Parse(dt.Rows[0]["SourceLat"].ToString()), Sourcelong = decimal.Parse(dt.Rows[0]["SourceLong"].ToString()), Status = int.Parse(dt.Rows[0]["Status"].ToString()), PaymentMethod = int.Parse(dt.Rows[0]["PaymentMethod"].ToString()), CarCategory = int.Parse(dt.Rows[0]["CarCategory"].ToString()) };
            return null;
        }

        public int Accept(int tripID,int driverID)
        {
            string sql = "update TripRequest set Status = " + ((int)TripStatus.Accepted).ToString() + ", DriverID = " + driverID.ToString() + " Where ID = " + tripID.ToString();
            DataAccess.ExecuteSQLNonQuery(sql);
            return tripID;
        }

        public int Start(int tripID)
        {
            string sql = "update TripRequest set Status = " + ((int)TripStatus.InProgress).ToString() + " Where ID = " + tripID.ToString();
            DataAccess.ExecuteSQLNonQuery(sql);
            return tripID;
        }

        public int End(int tripID,decimal waitingTime,decimal distance,decimal cost)
        {
            string sql = "update TripRequest set Status = " + ((int)TripStatus.Ended).ToString() + ",WaitingTime = "+ waitingTime.ToString()+", Distance = " + distance.ToString() +", Cost = " + cost.ToString() +" Where ID = " + tripID.ToString();
            DataAccess.ExecuteSQLNonQuery(sql);
            return tripID;
        }

        public decimal calcCost(decimal distance, decimal waitTime,int carCategory)
        {
            decimal _WaitTimeRate = 0.1M;
            decimal _KMRate = 0.4M;
            switch(carCategory)
            {
                case 2:
                    {
                        _WaitTimeRate = 0.2M;
                        _KMRate = 0.5M;
                        break;
                    }
                case 3:
                    {
                        _WaitTimeRate = 0.1M;
                        _KMRate = 0.4M;
                        break;
                    }
            }
            decimal cost = _WaitTimeRate * waitTime + _KMRate * distance;
            return cost;
        }
    }
}