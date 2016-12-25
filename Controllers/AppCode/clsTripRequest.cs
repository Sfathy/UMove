﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
            Ended = 4,
            Canceled
        }
        public int insert(TripRequest trip)
        {
            JObject googleApi = (JObject)JsonConvert.DeserializeObject(trip.Route, typeof(JObject));
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[12];
            param[0] = DataAccess.AddParamter("@UserID", trip.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@DestLat", trip.DestLat, SqlDbType.Decimal, 500);
            param[2] = DataAccess.AddParamter("@DestLong", trip.DestLong, SqlDbType.Decimal, 500);
            param[3] = DataAccess.AddParamter("@SourceLat", trip.SourceLat, SqlDbType.Decimal, 500);
            param[4] = DataAccess.AddParamter("@SourceLong", trip.Sourcelong, SqlDbType.Decimal, 500);
            param[5] = DataAccess.AddParamter("@DriverID", trip.DriverID, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@PicUpDate", trip.PicUpDate, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@PaymentMethod", trip.PaymentMethod, SqlDbType.Int, 50);
            param[8] = DataAccess.AddParamter("@CarCategory", trip.CarCategory, SqlDbType.Int, 50);
            param[9] = DataAccess.AddParamter("@Route", googleApi.ToString(), SqlDbType.NVarChar, int.MaxValue);
            param[10] = DataAccess.AddParamter("@StartAddress", trip.StartAddress, SqlDbType.NVarChar, int.MaxValue);
            param[11] = DataAccess.AddParamter("@EndAddress", trip.EndAddress, SqlDbType.NVarChar, int.MaxValue);
            
            //param[10] = DataAccess.AddParamter("@Cost", trip.Cost, SqlDbType.Decimal, 50);


            string sql = "insert into TripRequest([UserID],[DestLat],[DestLong],[SourceLat],[SourceLong],[DriverID],[PicUpDate],PaymentMethod,CarCategory,Route,StartAddress,EndAddress,Status) values" +
                "(@UserID,@DestLat,@DestLong,@SourceLat,@SourceLong,@DriverID,@PicUpDate,@PaymentMethod,@CarCategory,@Route,@StartAddress,@EndAddress,"+((int) TripStatus.Request).ToString()+")";
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
            string sql = "select TripRequest.*,Users.Name as DriverName,Users.Phone as DriverPhone from TripRequest inner join users on users.ID = TripRequest.DriverID where TripRequest.ID = " + id.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                TripRequest tr = new TripRequest();
                tr.UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
                tr.DestLat = decimal.Parse(dt.Rows[0]["DestLat"].ToString());
                tr.DestLong = decimal.Parse(dt.Rows[0]["DestLong"].ToString());
                tr.DriverID = int.Parse(dt.Rows[0]["DriverID"].ToString());
                tr.PicUpDate = DateTime.Parse(dt.Rows[0]["PicUpDate"].ToString());
                tr.SourceLat = decimal.Parse(dt.Rows[0]["SourceLat"].ToString());
                tr.Sourcelong = decimal.Parse(dt.Rows[0]["SourceLong"].ToString());
                tr.Status = (dt.Rows[0]["Status"] == DBNull.Value)?0:int.Parse(dt.Rows[0]["Status"].ToString());
                tr.PaymentMethod = (dt.Rows[0]["PaymentMethod"]==DBNull.Value)?0: int.Parse(dt.Rows[0]["PaymentMethod"].ToString());
                tr.CarCategory = int.Parse(dt.Rows[0]["CarCategory"].ToString()) ;
                tr.Cost = (dt.Rows[0]["Cost"] == DBNull.Value) ? 0 : decimal.Parse(dt.Rows[0]["Cost"].ToString());
                tr.WaitingTime = (dt.Rows[0]["WaitingTime"] == DBNull.Value) ? 0 : decimal.Parse(dt.Rows[0]["WaitingTime"].ToString());
                tr.Distance = (dt.Rows[0]["Distance"] == DBNull.Value) ? 0 : decimal.Parse(dt.Rows[0]["Distance"].ToString());
                
                tr.DriverName = (dt.Rows[0]["DriverName"] == DBNull.Value) ? "" : dt.Rows[0]["DriverName"].ToString();
                tr.DriverPhone = (dt.Rows[0]["DriverPhone"] == DBNull.Value) ? "" : dt.Rows[0]["DriverPhone"].ToString();
                tr.DriverCarNo = "ت ع 256";
                tr.StartTime = (dt.Rows[0]["StartTime"] == DBNull.Value) ? DateTime.MinValue  : DateTime.Parse(dt.Rows[0]["StartTime"].ToString());
                tr.EndTime = (dt.Rows[0]["EndTime"] == DBNull.Value) ? DateTime.MinValue: DateTime.Parse(dt.Rows[0]["EndTime"].ToString());
                tr.Duration = (tr.EndTime - tr.StartTime).TotalHours;
                tr.StartAddress = (dt.Rows[0]["StartAddress"] == DBNull.Value) ? "" : dt.Rows[0]["StartAddress"].ToString();
                tr.EndAddress = (dt.Rows[0]["EndAddress"] == DBNull.Value) ? "" : dt.Rows[0]["EndAddress"].ToString();
                tr.Steps= (dt.Rows[0]["Steps"] == DBNull.Value) ? "" : dt.Rows[0]["Steps"].ToString();
                //tr.EndTime = DateTime.Now;
                //string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + tr.SourceLat.ToString() + "%2C" + tr.Sourcelong.ToString() + "&destination=" + tr.DestLat.ToString() + "%2C" + tr.DestLong.ToString();
                //string jsonString = string.Empty;
                //HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(string.Format(url));
                //webReq.Method = "GET";
                //HttpWebResponse webResponse = (HttpWebResponse)webReq.GetResponse();
                //using (Stream responseStream = webResponse.GetResponseStream())
                //{
                //    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                //    jsonString = reader.ReadToEnd();
                //}
                tr.Route = (dt.Rows[0]["Route"] == DBNull.Value) ? "" : JsonConvert.DeserializeObject(dt.Rows[0]["Route"].ToString(), typeof(JObject)).ToString();
                //   tr.steps = new List<TripRouteSteps>();
              //  tr.steps.Add(new TripRouteSteps(){distance = new propt("10Km",1000),duration = new propt("10 min",600000),end_location = new Point(25.22145M,630.254M),start_location = new Point(68.215M,36.25412M),travel_mode ="DRIVING",html_instructions="Continue onto \u003cb\u003eAl Betrool\u003c/b\u003e"});
                return tr;
            }
            return null;
        }

        public DataTable get(int userId,int userType)
        {

            string sql = "SELECT dbo.TripRequest.ID, 'Hundai Elintra Black' as  CarDescription ,'ت ع 256' as CarNo,  dbo.TripRequest.UserID, dbo.TripRequest.SourceLat, dbo.TripRequest.SourceLong, dbo.TripRequest.DestLat, dbo.TripRequest.DestLong, dbo.TripRequest.DriverID,  dbo.TripRequest.PicUpDate, dbo.TripRequest.Status, dbo.TripRequest.PaymentMethod, dbo.TripRequest.CarCategory, dbo.TripRequest.Distance, dbo.TripRequest.WaitingTime, dbo.TripRequest.Cost, dbo.TripRequest.Route, dbo.TripRequest.StartTime, dbo.TripRequest.EndTime, dbo.TripRequest.StartAddress, dbo.TripRequest.EndAddress, dbo.Users.Name AS DriverName, dbo.Users.Phone AS DriverPhone, dbo.CarCategory.Name AS CarCategoryName, dbo.CarCategory.icon FROM dbo.TripRequest LEFT OUTER JOIN dbo.CarCategory ON dbo.TripRequest.CarCategory = dbo.CarCategory.ID LEFT OUTER JOIN dbo.Users ON dbo.Users.ID = dbo.TripRequest.DriverID ";
            if(userType == 1)
                sql +=" where userID = " + userId.ToString();
            else
                sql += " where DriverID = " + userId.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return dt;
            }
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
            string sql = "update TripRequest set Status = " + ((int)TripStatus.InProgress).ToString() + ", StartTime ='"+DateTime.Now+"' Where ID = " + tripID.ToString();
            DataAccess.ExecuteSQLNonQuery(sql);
            return tripID;
        }

        public int End(int tripID,decimal waitingTime,decimal distance,decimal cost,string steps)
        {
            string sql = "update TripRequest set Status = " + ((int)TripStatus.Ended).ToString() + ",EndTime = '"+DateTime.Now+"',   WaitingTime = "+ waitingTime.ToString()+", Distance = " + distance.ToString() +", Cost = " + cost.ToString() + ", Steps = '" + steps +"' Where ID = " + tripID.ToString();
            DataAccess.ExecuteSQLNonQuery(sql);
            return tripID;
        }

        public  decimal calcWaitTime(decimal distance, decimal duration)
        {
            duration = duration / 60;
            duration = duration - (40 / distance * 60);
            if (duration < 0)
                duration = 0;
            return duration;
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

        public int cancelTrip(int tripID)
        {
            string sql = "update TripRequest set Status = " + ((int)TripStatus.Canceled).ToString() +   " Where ID = " + tripID.ToString();
            DataAccess.ExecuteSQLNonQuery(sql);
            return tripID;
        }

        public DataTable get(decimal lat,decimal lng)
        {
            //string sql = "SELECT TOP 5 Min(acos(sin(" + lat.ToString() + ") * sin(latitude) + cos(" + lat.ToString() + ") * cos(latitude) * cos(Longitude - (" + lon.ToString() + "))))  as dis,UserID,Users.Name,latitude,Longitude,[datetime],[type],deviceToken,CarType,Angle,5 as Time FROM UserLocation inner join Users on Users.ID =UserLocation.UserID inner join DeviceInstallation on Users.installationKey = DeviceInstallation.InstallationKey group by UserID,Users.Name,latitude,Longitude,[datetime],[type],deviceToken,CarType,Angle  having datetime > convert(VARCHAR(24),'" + DateTime.Now.AddMinutes(-30).ToString("yyyy-MM-dd hh:mm:ss") + "',120) and Users.Type = 1 order By dis";
            string sql = "SELECT TOP 5 Min(acos(sin(" + lat.ToString() + ") * sin(sourcelat) + cos(" + lat.ToString() + ") * cos(sourcelat) * cos(SourceLong - (" + lng.ToString() + "))))  as dis , TripRequest.ID, TripRequest.UserID, TripRequest.SourceLat "
+ " , TripRequest.SourceLong, TripRequest.DestLat, TripRequest.DestLong "
+ ",  TripRequest.PicUpDate, TripRequest.Status"
+ ", TripRequest.PaymentMethod, TripRequest.CarCategory"
+ ", TripRequest.Distance, TripRequest.WaitingTime, TripRequest.Cost"
+ ", TripRequest.Route,  TripRequest.StartAddress, TripRequest.EndAddress"
+ ", Users.Name AS UserName, Users.Phone AS UserPhone"
+ ", CarCategory.Name AS CarCategoryName "

+ " FROM TripRequest "
+ " LEFT OUTER JOIN CarCategory ON TripRequest.CarCategory = CarCategory.ID "
+ " LEFT OUTER JOIN Users ON Users.ID = TripRequest.UserID "

+ " where TripRequest.Status = 1"
+ " group by "
+ " TripRequest.ID, TripRequest.UserID, TripRequest.SourceLat "
+ " , TripRequest.SourceLong, TripRequest.DestLat, TripRequest.DestLong "
+ " ,  TripRequest.PicUpDate, TripRequest.Status "
+ " , TripRequest.PaymentMethod, TripRequest.CarCategory "
+ " , TripRequest.Distance, TripRequest.WaitingTime, TripRequest.Cost "
+ " , TripRequest.Route,  TripRequest.StartAddress, TripRequest.EndAddress "
+ " , Users.Name,Users.Phone "
+ " , CarCategory.Name  ";
            
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
    }
}