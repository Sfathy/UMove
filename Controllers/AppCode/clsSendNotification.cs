using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;


public class AndroidGcmPushNotification
{
    //private  string _apiAccessKey;
    //private  string[] _registrationIds;
    //private  string _message;
    //private  string _title;
    //private  string _subtitle;
    //private  string _tickerText;
    //private  bool _vibrate;
    //private  bool _sound;

    public AndroidGcmPushNotification()
    {

    }

    //public AndroidFCMPushNotificationStatus SendNotification(string serverApiKey, string senderId, string deviceId, string message)
    //{
    //    AndroidFCMPushNotificationStatus result = new AndroidFCMPushNotificationStatus();

    //    try
    //    {
    //        result.Successful = false;
    //        result.Error = null;

    //        var value = message;
    //        WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
    //        tRequest.Method = "post";
    //        tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
    //        tRequest.Headers.Add(string.Format("Authorization: key={0}", serverApiKey));
    //       // tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

    //        string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.UtcNow.ToString() + "&registration_id=" + deviceId + "";

    //        Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    //        tRequest.ContentLength = byteArray.Length;

    //        using (Stream dataStream = tRequest.GetRequestStream())
    //        {
    //            dataStream.Write(byteArray, 0, byteArray.Length);

    //            using (WebResponse tResponse = tRequest.GetResponse())
    //            {
    //                using (Stream dataStreamResponse = tResponse.GetResponseStream())
    //                {
    //                    using (StreamReader tReader = new StreamReader(dataStreamResponse))
    //                    {
    //                        String sResponseFromServer = tReader.ReadToEnd();
    //                        result.Response = sResponseFromServer;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        result.Successful = false;
    //        result.Response = null;
    //        result.Error = ex;
    //    }

    //    return result;
    //}

    public class FCMResponse
    {
        public long multicast_id { get; set; }
        public int success { get; set; }
        public int failure { get; set; }
        public int canonical_ids { get; set; }
        // public List<FCMResult> results { get; set; }
    }

    public FCMResponse SendNotification(string serverApiKey, string senderId, string deviceId, string message, string title)
    {
        WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        tRequest.Method = "post";
        tRequest.ContentType = "application/json";
        var objNotification = new
        {
            to = deviceId,
            notification = new
            {
                title = title,
                body = message,
                type = title
            }
        };
        string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(objNotification);

        Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
        tRequest.Headers.Add(string.Format("Authorization: key={0}", serverApiKey));
        tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
        tRequest.ContentLength = byteArray.Length;
        tRequest.ContentType = "application/json";
        FCMResponse response = null;
        using (Stream dataStream = tRequest.GetRequestStream())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);

            using (WebResponse tResponse = tRequest.GetResponse())
            {
                using (Stream dataStreamResponse = tResponse.GetResponseStream())
                {
                    using (StreamReader tReader = new StreamReader(dataStreamResponse))
                    {
                        String responseFromFirebaseServer = tReader.ReadToEnd();

                        response = Newtonsoft.Json.JsonConvert.DeserializeObject<FCMResponse>(responseFromFirebaseServer);
                        /*if (response.success == 1)
                        {
                            new NotificationBLL().InsertNotificationLog(dayNumber, notification, true);
                        }
                        else if (response.failure == 1)
                        {
                            new NotificationBLL().InsertNotificationLog(dayNumber, notification, false);
                            sbLogger.AppendLine(string.Format("Error sent from FCM server, after sending request : {0} , for following device info: {1}", responseFromFirebaseServer, jsonNotificationFormat));

                        }*/

                    }
                }

            }
        }
        return response;
    }

    public class AndroidFCMPushNotificationStatus
    {
        public bool Successful
        {
            get;
            set;
        }

        public string Response
        {
            get;
            set;
        }
        public Exception Error
        {
            get;
            set;
        }
    }

    #region Commented
    //public string SendGcmNotification(string apiAccessKey, string[] registrationIds, string message, string title = "",
    //    string subtitle = "", string tickerText = "", bool vibrate = true, bool sound = true)
    //{
    //    _apiAccessKey = "AIzaSyBjyvyZH0EiPFf83txTcUnpbwoBuH3E1EA";//apiAccessKey;
    //    _registrationIds = registrationIds;
    //    _message = message;
    //    _title = title;
    //    _subtitle = subtitle;
    //    _tickerText = tickerText;
    //    _vibrate = vibrate;
    //    _sound = sound;

    //    //MESSAGE DATA
    //    GcmPostData data = new GcmPostData()
    //    {
    //        message = _message,
    //        title = _title,
    //        subtitle = _subtitle,
    //        tickerText = _tickerText,
    //        vibrate = _vibrate,
    //        sound = _sound
    //    };

    //    //MESSAGE FIELDS 
    //    GcmPostFields fields = new GcmPostFields();
    //    fields.registration_ids = _registrationIds;
    //    fields.data = data;

    //    //SERIALIZE TO JSON 
    //    JavaScriptSerializer jsonEncode = new JavaScriptSerializer();

    //    //CONTENTS
    //    byte[] byteArray = Encoding.UTF8.GetBytes(jsonEncode.Serialize(fields));

    //    //REQUEST
    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
    //    request.Method = "POST";
    //    request.KeepAlive = false;
    //    request.ContentType = "application/json";
    //    request.Headers.Add("Authorization: key={_apiAccessKey}");
    //    request.ContentLength = byteArray.Length;

    //    Stream dataStream = request.GetRequestStream();
    //    dataStream.Write(byteArray, 0, byteArray.Length);
    //    dataStream.Close();


    //    //SEND REQUEST
    //    try
    //    {
    //        WebResponse response = request.GetResponse();
    //        {
    //            StreamReader reader = new StreamReader(response.GetResponseStream());
    //            string responseLine = reader.ReadToEnd();
    //            reader.Close();

    //            return responseLine;
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        return e.Message;
    //    }

    //}
    //private class GcmPostFields
    //{
    //    public string[] registration_ids { get; set; }
    //    public GcmPostData data { get; set; }

    //}
    //private class GcmPostData
    //{
    //    public string message { get; set; }
    //    public string title { get; set; }
    //    public string subtitle { get; set; }
    //    public string tickerText { get; set; }
    //    public bool vibrate { get; set; }
    //    public bool sound { get; set; }
    //}
    #endregion
}