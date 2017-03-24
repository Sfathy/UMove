using Newtonsoft.Json;
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
using System.Web.Http;
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
            Canceled = 5,
            Expired = 6
        }
        public List<TripRequest> SearchTrip(DateTime? searchDate,int carCategory,string startAddress,string endAddress)
        {
            List<TripRequest> trips = null;
            DateTime date;
            if (searchDate == DateTime.MinValue || searchDate == null)
                date = DateTime.Today;
            else
                date = searchDate.Value;
            string sql = "Select TripRequest.ID,   TripRequest.NoOfSeats, CarDescription , CarNo,  TripRequest.UserID, " +
                "TripRequest.EstimatedDistance,TripRequest.EstimatedDuration,TripRequest.EstimatedCost," +
                "TripRequest.SourceLat, TripRequest.SourceLong, dbo.TripRequest.DestLat, dbo.TripRequest.DestLong, " +
                "dbo.TripRequest.DriverID,  dbo.TripRequest.PicUpDate, dbo.TripRequest.Status, dbo.TripRequest.PaymentMethod," +
                " dbo.TripRequest.CarCategory, dbo.TripRequest.Distance, dbo.TripRequest.WaitingTime, dbo.TripRequest.Cost," +
                " dbo.TripRequest.StartTime, dbo.TripRequest.EndTime, dbo.TripRequest.StartAddress, " +
                "dbo.TripRequest.EndAddress, TripCreator,EstimatedStartTime,EstimatedEndTime,FeesPerChair,FeesforCar, "+
                " StartDate,EndDate, " +
                "dbo.Users.Name AS DriverName, dbo.Users.Phone AS DriverPhone, " +
                "dbo.CarCategory.Name AS CarCategoryName, dbo.CarCategory.icon " +
                "FROM dbo.TripRequest LEFT OUTER JOIN dbo.CarCategory ON dbo.TripRequest.CarCategory = dbo.CarCategory.ID " +
                "LEFT OUTER JOIN dbo.Users ON dbo.Users.ID = dbo.TripRequest.DriverID " +
                "left outer join DriverCarDetails on dbo.TripRequest.DriverID = DriverCarDetails.UserID" +
                " where TripCreator = 2 and CarCategory = " + carCategory.ToString() + " and '" + date + "' between StartDate and EndDate";
            if (!string.IsNullOrEmpty(startAddress))
                sql += " and StartAddress like '%" + startAddress + "%'";
            if (!string.IsNullOrEmpty(endAddress))
                sql += " and EndAddress like '%" + endAddress + "%'";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if(dt != null && dt.Rows != null && dt.Rows.Count >0)
                trips = dt.DataTableToList<TripRequest>();
            return trips;
        }
        public int insert(TripRequest trip)
        {
            JObject googleApi = (JObject)JsonConvert.DeserializeObject(trip.Route, typeof(JObject));
            //check if the user name exist before
            SqlParameter[] param = new SqlParameter[29];
            param[0] = DataAccess.AddParamter("@UserID", trip.UserID, SqlDbType.Int, 50);
            param[1] = DataAccess.AddParamter("@DestLat", trip.DestLat, SqlDbType.Decimal, 500);
            param[2] = DataAccess.AddParamter("@DestLong", trip.DestLong, SqlDbType.Decimal, 500);
            param[3] = DataAccess.AddParamter("@SourceLat", trip.SourceLat, SqlDbType.Decimal, 500);
            param[4] = DataAccess.AddParamter("@SourceLong", trip.Sourcelong, SqlDbType.Decimal, 500);
            param[5] = DataAccess.AddParamter("@DriverID", trip.DriverID, SqlDbType.Int, 50);
            param[6] = DataAccess.AddParamter("@PicUpDate", trip.PicUpDate, SqlDbType.DateTime, 50);
            param[7] = DataAccess.AddParamter("@PaymentMethod", trip.PaymentMethod, SqlDbType.Int, 50);
            param[8] = DataAccess.AddParamter("@CarCategory", trip.CarCategory, SqlDbType.Int, 50);
            param[9] = DataAccess.AddParamter("@Route", googleApi==null? "": googleApi.ToString(), SqlDbType.NVarChar, int.MaxValue);
            param[10] = DataAccess.AddParamter("@StartAddress",string.IsNullOrEmpty(trip.StartAddress)?"": trip.StartAddress, SqlDbType.NVarChar, int.MaxValue);
            param[11] = DataAccess.AddParamter("@EndAddress", string.IsNullOrEmpty(trip.EndAddress) ? "" : trip.EndAddress, SqlDbType.NVarChar, int.MaxValue);

            param[12] = DataAccess.AddParamter("@Cost", trip.Cost, SqlDbType.Decimal, 50);
            param[13] = DataAccess.AddParamter("@WaitingTime", trip.WaitingTime, SqlDbType.Decimal, 50);
            param[14] = DataAccess.AddParamter("@Distance", trip.Distance, SqlDbType.Decimal, 50);

            param[15] = DataAccess.AddParamter("@EstimatedCost", string.IsNullOrEmpty(trip.EstimatedCost) ? "" : trip.EstimatedCost, SqlDbType.NVarChar, 50);
            param[16] = DataAccess.AddParamter("@EstimatedDuration", string.IsNullOrEmpty(trip.EstimatedDuration) ? "" : trip.EstimatedDuration, SqlDbType.NVarChar, 50);
            param[17] = DataAccess.AddParamter("@EstimatedDistance", string.IsNullOrEmpty(trip.EstimatedDistance) ? "" : trip.EstimatedDistance, SqlDbType.NVarChar, 50);
            param[18] = DataAccess.AddParamter("@NoOfSeats", trip.NoOfSeats, SqlDbType.Int, 50);


            param[19] = DataAccess.AddParamter("@TripCreator", trip.TripCreator, SqlDbType.Int, 50);
            param[20] = DataAccess.AddParamter("@EstimatedStartTime", trip.EstimatedStartTime, SqlDbType.Time, 50);
            param[21] = DataAccess.AddParamter("@EstimatedEndTime", trip.EstimatedEndTime, SqlDbType.Time, 50);
            param[22] = DataAccess.AddParamter("@IsSchedule", trip.IsSchedule, SqlDbType.Bit, 50);
            param[23] = DataAccess.AddParamter("@FeesPerChair", trip.FeesPerChair, SqlDbType.Decimal, 50);
            param[24] = DataAccess.AddParamter("@FeesforCar", trip.FeesforCar, SqlDbType.Decimal, 50);
            param[25] = DataAccess.AddParamter("@Every", trip.Every, SqlDbType.Int, 50);
            param[26] = DataAccess.AddParamter("@Frequency", trip.Frequency, SqlDbType.Int, 50);
            param[27] = DataAccess.AddParamter("@StartDate", trip.StartDate, SqlDbType.Date, 50);
            param[28] = DataAccess.AddParamter("@EndDate", trip.EndDate, SqlDbType.Date, 50);

            
            //param[10] = DataAccess.AddParamter("@Cost", trip.Cost, SqlDbType.Decimal, 50);


            string sql = "insert into TripRequest([UserID],[DestLat],[DestLong],[SourceLat],[SourceLong],[DriverID],"+
                "[PicUpDate],PaymentMethod,CarCategory,Route,StartAddress,EndAddress,Status,Cost,WaitingTime,Distance,"+
                "EstimatedCost,EstimatedDuration,EstimatedDistance,NoOfSeats,TripCreator,EstimatedStartTime,EstimatedEndTime," +
                "IsSchedule,FeesPerChair,FeesforCar,Every,Frequency,StartDate,EndDate) values" +
                "(@UserID,@DestLat,@DestLong,@SourceLat,@SourceLong,@DriverID,@PicUpDate,@PaymentMethod,@CarCategory,"+
                "@Route,@StartAddress,@EndAddress," + ((int)TripStatus.Request).ToString() + ",@Cost,@WaitingTime,@Distance,"+
                "@EstimatedCost,@EstimatedDuration,@EstimatedDistance,@NoOfSeats,@TripCreator,@EstimatedStartTime,@EstimatedEndTime," +
                "@IsSchedule,@FeesPerChair,@FeesforCar,@Every,@Frequency,@StartDate,@EndDate)";
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
            string sql = "select TripRequest.*,driver.Name as DriverName,driver.Phone as DriverPhone, cust.Name as UserName,cust.Phone as UserPhone,CarNo,CarDescription,DriverPhoto from TripRequest left outer join users as driver on driver.ID = TripRequest.DriverID left outer join users as cust on cust.ID = TripRequest.UserID left outer join DriverCarDetails on TripRequest.DriverID = DriverCarDetails.UserID  where TripRequest.ID = " + id.ToString() ;
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                TripRequest tr = new TripRequest();
                tr.UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
                tr.DestLat = decimal.Parse(dt.Rows[0]["DestLat"].ToString());
                tr.DestLong = decimal.Parse(dt.Rows[0]["DestLong"].ToString());
                tr.DriverID = (dt.Rows[0]["DriverID"] == DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["DriverID"].ToString());
                if (tr.DriverID != 0)
                {
                    tr.DriverRate = new clsUserRate().get(tr.DriverID).Rate;
                    tr.IsFav = new clsFavDriver().isFav(tr.UserID, tr.DriverID);
                }
                tr.PicUpDate = (dt.Rows[0]["PicUpDate"] == DBNull.Value) ? DateTime.UtcNow : DateTime.Parse(dt.Rows[0]["PicUpDate"].ToString());
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
                tr.DriverPhoto = (dt.Rows[0]["DriverPhoto"] == DBNull.Value) ? "" : dt.Rows[0]["DriverPhoto"].ToString();
                tr.UserName = (dt.Rows[0]["UserName"] == DBNull.Value) ? "" : dt.Rows[0]["UserName"].ToString();
                tr.UserPhone = (dt.Rows[0]["UserPhone"] == DBNull.Value) ? "" : dt.Rows[0]["UserPhone"].ToString();
                tr.DriverCarNo = (dt.Rows[0]["CarNo"] == DBNull.Value) ? "" : dt.Rows[0]["CarNo"].ToString();
                tr.DriverCarDescription = (dt.Rows[0]["CarDescription"] == DBNull.Value) ? "" : dt.Rows[0]["CarDescription"].ToString(); 
                tr.StartTime = (dt.Rows[0]["StartTime"] == DBNull.Value) ? DateTime.MinValue  : DateTime.Parse(dt.Rows[0]["StartTime"].ToString());
                tr.EndTime = (dt.Rows[0]["EndTime"] == DBNull.Value) ? DateTime.MinValue: DateTime.Parse(dt.Rows[0]["EndTime"].ToString());
                tr.Duration = (tr.EndTime - tr.StartTime).TotalHours;
                tr.StartAddress = (dt.Rows[0]["StartAddress"] == DBNull.Value) ? "" : dt.Rows[0]["StartAddress"].ToString();
                tr.EndAddress = (dt.Rows[0]["EndAddress"] == DBNull.Value) ? "" : dt.Rows[0]["EndAddress"].ToString();
                tr.Steps= (dt.Rows[0]["Steps"] == DBNull.Value) ? "" : dt.Rows[0]["Steps"].ToString();
                tr.NoOfSeats = (dt.Rows[0]["NoOfSeats"] == DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["NoOfSeats"].ToString());
                tr.EstimatedDistance = (dt.Rows[0]["EstimatedDistance"] == DBNull.Value) ? "" : dt.Rows[0]["EstimatedDistance"].ToString();
                tr.EstimatedCost = (dt.Rows[0]["EstimatedCost"] == DBNull.Value) ? "" : dt.Rows[0]["EstimatedCost"].ToString();
                tr.EstimatedDuration = (dt.Rows[0]["EstimatedDuration"] == DBNull.Value) ? "" : dt.Rows[0]["EstimatedDuration"].ToString();

                tr.TripCreator = (dt.Rows[0]["TripCreator"] == DBNull.Value) ? 1 : int.Parse(dt.Rows[0]["TripCreator"].ToString());
                tr.EstimatedStartTime = (dt.Rows[0]["EstimatedStartTime"] == DBNull.Value) ? TimeSpan.MinValue : TimeSpan.Parse(dt.Rows[0]["EstimatedStartTime"].ToString());
                tr.EstimatedEndTime = (dt.Rows[0]["EstimatedEndTime"] == DBNull.Value) ? TimeSpan.MinValue : TimeSpan.Parse(dt.Rows[0]["EstimatedEndTime"].ToString());

                tr.IsSchedule = (dt.Rows[0]["IsSchedule"] == DBNull.Value) ? false : Boolean.Parse( dt.Rows[0]["IsSchedule"].ToString());
                tr.FeesPerChair = (dt.Rows[0]["FeesPerChair"] == DBNull.Value) ? 0 : Decimal.Parse( dt.Rows[0]["FeesPerChair"].ToString());
                tr.FeesforCar = (dt.Rows[0]["FeesforCar"] == DBNull.Value) ? 0 :Decimal.Parse( dt.Rows[0]["FeesforCar"].ToString());
                tr.Every = (dt.Rows[0]["Every"] == DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["Every"].ToString());
                tr.Frequency = (dt.Rows[0]["Frequency"] == DBNull.Value) ? 0 : int.Parse( dt.Rows[0]["Frequency"].ToString());
                tr.StartDate = (dt.Rows[0]["StartDate"] == DBNull.Value) ? DateTime.MinValue :DateTime.Parse( dt.Rows[0]["StartDate"].ToString());
                tr.EndDate = (dt.Rows[0]["EndDate"] == DBNull.Value) ? DateTime.MinValue :DateTime.Parse( dt.Rows[0]["EndDate"].ToString());

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

        public DataTable get(int userId,int userType,int isFuture,int isActive)
        {

            string sql = "SELECT TripRequest.ID, TripCreator,EstimatedStartTime,EstimatedEndTime," +
                "IsSchedule,FeesPerChair,FeesforCar,Every,Frequency,StartDate,EndDate,  TripRequest.NoOfSeats, CarDescription , CarNo,  TripRequest.UserID, TripRequest.EstimatedDistance,TripRequest.EstimatedDuration,TripRequest.EstimatedCost,TripRequest.SourceLat, TripRequest.SourceLong, dbo.TripRequest.DestLat, dbo.TripRequest.DestLong, dbo.TripRequest.DriverID,  dbo.TripRequest.PicUpDate, dbo.TripRequest.Status, dbo.TripRequest.PaymentMethod, dbo.TripRequest.CarCategory, dbo.TripRequest.Distance, dbo.TripRequest.WaitingTime, dbo.TripRequest.Cost, dbo.TripRequest.StartTime, dbo.TripRequest.EndTime, dbo.TripRequest.StartAddress, dbo.TripRequest.EndAddress, dbo.Users.Name AS DriverName, dbo.Users.Phone AS DriverPhone, dbo.CarCategory.Name AS CarCategoryName, dbo.CarCategory.icon FROM dbo.TripRequest LEFT OUTER JOIN dbo.CarCategory ON dbo.TripRequest.CarCategory = dbo.CarCategory.ID LEFT OUTER JOIN dbo.Users ON dbo.Users.ID = dbo.TripRequest.DriverID left outer join DriverCarDetails on dbo.TripRequest.DriverID = DriverCarDetails.UserID";
            if(userType == 0)
                sql += " where dbo.TripRequest.UserID = " + userId.ToString();
            else
                sql += " where DriverID = " + userId.ToString();
            if (isFuture == 1)
                sql += " and PicUpDate > '" + DateTime.UtcNow + "'";
            if (isActive ==1)
            {
                sql += " and (TripRequest.status= " + ((int)TripStatus.Request).ToString() + " OR TripRequest.status= " + ((int)TripStatus.Accepted).ToString() + " OR TripRequest.status= " + ((int)TripStatus.InProgress).ToString() + " )";
            }
            sql += " order by TripRequest.ID desc";
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

        public int Expire(int UserID)
        {
            string sql = "update TripRequest set Status = " + ((int)TripStatus.Expired).ToString() + " Where userID = " + UserID.ToString() + " and PicUpDate<'" + DateTime.UtcNow.AddHours(-5) + "' and Status = " + ((int) TripStatus.Request).ToString();
            DataAccess.ExecuteSQLNonQuery(sql);
            return 1;
        }

        public int Start(int tripID)
        {
            string sql = "update TripRequest set Status = " + ((int)TripStatus.InProgress).ToString() + ", StartTime ='"+DateTime.UtcNow+"' Where ID = " + tripID.ToString();
            DataAccess.ExecuteSQLNonQuery(sql);
            return tripID;
        }

        public int End(int tripID,EndedTripInfo endedTripInfo)
        {
            clsTripRequest trip = new clsTripRequest();
            clsUser u = new clsUser();

            TripRequest userTrip = trip.get(tripID);
            if (userTrip.TripCreator == 1)
            {
                EndNormalTrip(tripID, endedTripInfo,userTrip);
            }
            else
            {
                EndSharedTrip(tripID, endedTripInfo,userTrip);
            }
            
            
            return tripID;
        }

        private void EndSharedTrip(int tripID, EndedTripInfo endedTripInfo, TripRequest userTrip)
        {
            decimal distance;
            decimal waitTime;
            JObject steps;
            steps = endedTripInfo.Steps;
            CalcWaitingTime(endedTripInfo, out distance, out waitTime, steps);
            string sql = "";
            decimal finalCost = 0;

            foreach (ReservedTrip user in endedTripInfo.PickedUpUsers)
            {
                //update reserved table    
                sql = "update TripReservation set status = 1 where userID = " + user.UserID.ToString();
                //update the KM and money balance for each user 
                //update user balance (KM only)
                sql = " if exists ( select * from UserBalance where userid = " + user.UserID.ToString() + ") begin Update UserBalance set KMBalance = KMBalance + " + distance.ToString() + ",PointsBalance= PointsBalance +" + (distance / clsSettings.Setting.UserPointRate).ToString() + " where userid = " + user.UserID.ToString()
                    + " end else begin insert into UserBalance(UserID, KMBalance,MoneyBalance,PointsBalance) values (" + user.UserID.ToString() + "," + distance.ToString() + ",0," + (distance / clsSettings.Setting.UserPointRate).ToString() + ") end ";
                DataAccess.ExecuteSQLNonQuery(sql);
                finalCost += userTrip.FeesPerChair * user.NoOfSeats;
            }

            TripRequest t = get(tripID);
            //update the KM and money balance for the driver
            sql = "if exists ( select * from UserBalance where userid = " + t.DriverID.ToString() + ") begin Update UserBalance set KMBalance = KMBalance + " + distance.ToString() + ",PointsBalance= PointsBalance +" + (distance / clsSettings.Setting.DriverPointRate).ToString() + ",MoneyBalance = MoneyBalance - " + (finalCost * clsSettings.Setting.CompanyRate / 100).ToString() + " where userid = " + t.DriverID.ToString()
                + " end else begin insert into UserBalance(UserID, KMBalance,MoneyBalance,PointsBalance) values (" + t.DriverID.ToString() + "," + distance.ToString() + "," + (-1 * finalCost * clsSettings.Setting.CompanyRate / 100).ToString() + "," + (distance / clsSettings.Setting.DriverPointRate).ToString() + ") end";
            DataAccess.ExecuteSQLNonQuery(sql);

            UpdateTripStatus(tripID, distance, waitTime, steps, finalCost);
            
        }
        public List<ReservedTrip> GetTripReservations(int tripId,DateTime date)
        {
            string sql = "Select * from TripReservation where TripID = " + tripId.ToString() + " and ReservationDate ='" + date.ToShortDateString() + "'";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            return dt.DataTableToList<ReservedTrip>();
        }
        private void EndNormalTrip(int tripID, EndedTripInfo endedTripInfo,TripRequest userTrip)
        {
            decimal distance;
            decimal waitTime;
            JObject steps;
            steps = endedTripInfo.Steps;
            CalcWaitingTime(endedTripInfo, out distance, out waitTime,steps);
            decimal finalCost = Math.Round(calcCost(distance, waitTime, userTrip.CarCategory), 3);

            string sql = "";
            UpdateTripStatus(tripID, distance, waitTime, steps, finalCost);
            TripRequest t = new clsTripRequest().get(tripID);
            //update user balance (KM only)
            sql = " if exists ( select * from UserBalance where userid = " + t.UserID.ToString() + ") begin Update UserBalance set KMBalance = KMBalance + " + distance.ToString() + ",PointsBalance= PointsBalance +" + (distance / clsSettings.Setting.UserPointRate).ToString() + " where userid = " + t.UserID.ToString()
                + " end else begin insert into UserBalance(UserID, KMBalance,MoneyBalance,PointsBalance) values (" + t.UserID.ToString() + "," + distance.ToString() + ",0," + (distance / clsSettings.Setting.UserPointRate).ToString() + ") end ";
            DataAccess.ExecuteSQLNonQuery(sql);
            //update driver balance
            sql = "if exists ( select * from UserBalance where userid = " + t.DriverID.ToString() + ") begin Update UserBalance set KMBalance = KMBalance + " + distance.ToString() + ",PointsBalance= PointsBalance +" + (distance / clsSettings.Setting.DriverPointRate).ToString() + ",MoneyBalance = MoneyBalance - " + (finalCost * clsSettings.Setting.CompanyRate / 100).ToString() + " where userid = " + t.DriverID.ToString()
                + " end else begin insert into UserBalance(UserID, KMBalance,MoneyBalance,PointsBalance) values (" + t.DriverID.ToString() + "," + distance.ToString() + "," + (-1 * finalCost * clsSettings.Setting.CompanyRate / 100).ToString() + "," + (distance / clsSettings.Setting.DriverPointRate).ToString() + ") end";
            DataAccess.ExecuteSQLNonQuery(sql);
            //notify the user with the end trip
            //get customer Device Token
            clsUser u = new clsUser();
            string customerDeviceToken = u.getUserDeviceToken(userTrip.UserID);

            //DataTable dtDriver = u.get(acceptTrip.UserID);

            //send notification to the user with the driver information
            AndroidGcmPushNotification not = new AndroidGcmPushNotification();
            //string jsonString = string.Empty;
            //jsonString = "{ \"TripEnded\": {\"Status\":\"Ended\", \"id\": " + tripID.ToString() + ",\"Cost\":\""+finalCost.ToString()+" LE\"  } }";
            var message = new
            {
                to = customerDeviceToken,
                notification = new
                {
                    title = "Your Trip Ended",
                    body = " Your trip ended with cost " + finalCost.ToString(),
                    status = "Ended",
                    id = tripID.ToString()
                }
            };
            //not.SendGcmNotification("", new string[] { customerDeviceToken }, jsonString);
            not.SendNotification("AAAA0-XrarI:APA91bEReLIPg2bjfuuPshOiO3GbDeFg7irdrAMF3h2ErPhsf2LOOEGLP4C0Hz2CKjzWspoK0V7JwLRTXs1Kz-fQikKZG2hZNikWrAxJK1gLueNJ9SuB5JU_3aF_b-dAtiTHrEzXA7fB-Z59suJsTBvI3DODJwpusA", "910095510194", customerDeviceToken, message, "Trip Ended");
            // not.SendNotification("AIzaSyAUzTKuzVyD4ERLmaQb49bt4HnwioeVgT8", "UMove", customerDeviceToken, jsonString);
            ////////////////////////////////////////////////
            //    string s="[{\"distance\":{\"text\":\"10Km\",\"value\":1000.0},\"duration\":{\"text\":\"10 min\",\"value\":600000.0},\"end_location\":{\"lat\":25.22145,\"lng\":630.254},\"html_instructions\":\"Continue onto <b>Al Betrool</b>\",\"start_location\":{\"lat\":68.215,\"lng\":36.25412},\"travel_mode\":\"DRIVING\"}],\"Duration\":50.0}]"   ;
        }

        private static void CalcWaitingTime(EndedTripInfo endedTripInfo, out decimal distance, out decimal waitTime,  JObject steps)
        {
            decimal duration = 0M;
            distance = 0M;
            waitTime = 0M;
            
            decimal.TryParse(steps.GetValue("duration").ToString(), out duration);
            decimal.TryParse(steps.GetValue("distance").ToString(), out distance);
            if (distance != 0)
            {
                waitTime = new clsTripRequest().calcWaitTime(distance, duration);
            }
        }

        private static void UpdateTripStatus(int tripID, decimal distance, decimal waitTime, JObject steps, decimal finalCost)
        {
            string sql = "update TripRequest set Status = " + ((int)TripStatus.Ended).ToString() + ",EndTime = '" + DateTime.UtcNow + "',   WaitingTime = " + waitTime.ToString() + ", Distance = " + distance.ToString() + ", Cost = " + finalCost.ToString() + ", Steps = '" + steps + "' Where ID = " + tripID.ToString();
            DataAccess.ExecuteSQLNonQuery(sql);
            
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
            decimal cost = 0;
            string sql = "select * from carCategory where ID = " + carCategory.ToString();
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                decimal _WaitTimeRate = decimal.Parse(dt.Rows[0]["MinFees"].ToString());
                decimal _KMRate = decimal.Parse(dt.Rows[0]["KmFees"].ToString());
                decimal _StartFees = decimal.Parse(dt.Rows[0]["StartFees"].ToString());
                decimal _minFees = decimal.Parse(dt.Rows[0]["MinimumFees"].ToString());

                cost = _StartFees + _WaitTimeRate * waitTime + _KMRate * distance;
                if (cost < _minFees)
                    cost = _minFees;
            }
            return Math.Round(cost,3);
        }

        public int cancelTrip(int tripID,int userType)
        {
            string sql = "update TripRequest set Status = " + ((int)TripStatus.Canceled).ToString() +   " Where ID = " + tripID.ToString();
            DataAccess.ExecuteSQLNonQuery(sql);
            int userID = 0; 
            decimal fees = 0.0M;
            TripRequest t = new clsTripRequest().get(tripID);
            if (userType == 0)
            {
                userID = t.UserID;
                fees = clsSettings.Setting.UserCancelFee;
            }
            else
            {
                userID =  t.DriverID;
                fees = clsSettings.Setting.DriverCancelFee;
            }
            //update the balance for the user
            sql = "if exists ( select * from UserBalance where userid = "+userID.ToString()+") begin update UserBalance set MoneyBalance = MoneyBalance + " + fees.ToString() +" where userID = "+userID.ToString() 
                + " end else begin insert into UserBalance(UserID, KMBalance,MoneyBalance,PointsBalance) values ("+userID.ToString()+",0,"+fees.ToString()+",0) end ";
                
            DataAccess.ExecuteSQLNonQuery(sql);

            return tripID;
        }

        public DataTable get(decimal lat,decimal lng)
        {
            //string sql = "SELECT TOP 5 Min(acos(sin(" + lat.ToString() + ") * sin(latitude) + cos(" + lat.ToString() + ") * cos(latitude) * cos(Longitude - (" + lon.ToString() + "))))  as dis,UserID,Users.Name,latitude,Longitude,[datetime],[type],deviceToken,CarType,Angle,5 as Time FROM UserLocation inner join Users on Users.ID =UserLocation.UserID inner join DeviceInstallation on Users.installationKey = DeviceInstallation.InstallationKey group by UserID,Users.Name,latitude,Longitude,[datetime],[type],deviceToken,CarType,Angle  having datetime > convert(VARCHAR(24),'" + DateTime.Now.AddMinutes(-30).ToString("yyyy-MM-dd hh:mm:ss") + "',120) and Users.Type = 1 order By dis";
            string sql = "SELECT TOP 5 Min(dbo.CalcDist(" + lat.ToString() + ", " + lng.ToString() + ",SourceLat, SourceLong) ) as dis , "+
                "TripRequest.ID,TripRequest.NoOfSeats, TripRequest.UserID, TripRequest.SourceLat  , TripRequest.SourceLong, "+
                "TripRequest.DestLat, TripRequest.DestLong ,  TripRequest.PicUpDate, TripRequest.Status, "+
                "TripRequest.PaymentMethod, TripRequest.CarCategory, TripRequest.Distance, TripRequest.WaitingTime, "+
                "TripRequest.Cost, TripRequest.Route,  TripRequest.StartAddress, TripRequest.EndAddress, "+
                "Users.Name AS UserName, Users.Phone AS UserPhone, CarCategory.Name AS CarCategoryName  "+
                "FROM TripRequest  LEFT OUTER JOIN CarCategory ON TripRequest.CarCategory = CarCategory.ID  "+
                "LEFT OUTER JOIN Users ON Users.ID = TripRequest.UserID  where TripRequest.Status = 1 "+
                "group by  TripRequest.ID, TripRequest.UserID, TripRequest.SourceLat  , TripRequest.SourceLong, "+
                "TripRequest.DestLat, TripRequest.DestLong  ,  TripRequest.PicUpDate, TripRequest.Status  , "+
                "TripRequest.PaymentMethod, TripRequest.CarCategory  , TripRequest.Distance, TripRequest.WaitingTime, "+
                "TripRequest.Cost  , TripRequest.Route,  TripRequest.StartAddress, TripRequest.EndAddress  , "+
                "Users.Name,Users.Phone  , CarCategory.Name,TripRequest.NoOfSeats   Order by dis asc ,ID desc";
            
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        public int ReserveTrip(ReservedTrip reservedTrip)
        {
            TripRequest t = get(reservedTrip.TripID);
            //get the reserved seats for this day
            string sql = "select *from TripReservation where tripID = " +reservedTrip.TripID.ToString() +" and reservationDate='"+reservedTrip.ReserveDate.ToShortDateString()+"'";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            List<ReservedTrip> ReservedSeats = dt.DataTableToList<ReservedTrip>();
            int researvedSeats = ReservedSeats.Sum(m => m.NoOfSeats);
            //validate availability
            ///get the total no of seats
            sql = "select * from CarCategory";
            DataTable dtCarCat = DataAccess.ExecuteSQLQuery(sql);
            int totalNoOfSeats = dtCarCat.Rows[0]["maxsize"] == DBNull.Value ? 0 : int.Parse(dtCarCat.Rows[0]["maxsize"].ToString());
            if (totalNoOfSeats < researvedSeats + reservedTrip.NoOfSeats)
                return -1;
            //add the reservation to the DB
            sql = "insert into TripReservation(TripID,ReservationDate,NoOfSeats,userID) values("+reservedTrip.TripID.ToString()
                +",'"+reservedTrip.ReserveDate.ToShortDateString()+"',"+reservedTrip.NoOfSeats.ToString()+","+reservedTrip.UserID.ToString()+")";
            return DataAccess.ExecuteSQLNonQuery(sql);
            
        }
    }
}