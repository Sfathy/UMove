using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.Controllers
{
    public class ReservedTripHistoryController : ApiController
    {
        public HttpResponseMessage Get(int userId, int page = 0)
        {
            int pageSize = clsSettings.Setting.PageSize;
            string jsonString = "";
            DataTable dt = new clsTripRequest().getSharedTrips(userId);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                List<TripRequest> lst = dt.DataTableToList<TripRequest>();
                if (page != 0)
                {
                    if ((page - 1) * pageSize < lst.Count)
                    {
                        jsonString = JsonConvert.SerializeObject(lst.Skip((page - 1) * pageSize).Take(pageSize));
                    }
                    else
                    {
                        jsonString = "{ \"error\": { \"code\": 2, \"message\": \"no trips in this page \"  } }"; ;
                    }
                }
                else
                {
                    jsonString = JsonConvert.SerializeObject(dt);
                }

            }
            else
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't find trips for this user \"  } }"; ;
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}
