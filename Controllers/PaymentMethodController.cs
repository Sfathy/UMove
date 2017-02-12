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
    public class PaymentMethodController : ApiController
    {
        // GET api/paymentmethod
        public HttpResponseMessage Get()
        {
            string sql = "select * from PaymentMethod";
            DataTable dt = DataAccess.ExecuteSQLQuery(sql);
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(dt);
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
            
        }

        // GET api/paymentmethod/5
        public HttpResponseMessage Get(int userID)
        {
            string jsonString = string.Empty;
            try
            {
                clsPaymentMethod c = new clsPaymentMethod();
                DataTable card = c.get(userID);
                if (card != null)
                {
                    jsonString = JsonConvert.SerializeObject(card);
                }
                else
                {
                    jsonString = "{ \"error\": { \"code\": 3, \"message\": \"no payment method exist\"  } }";
                }
            }
            catch (Exception e)
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't retrieve payment methods\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // POST api/paymentmethod
        public HttpResponseMessage Post([FromBody]paymentMethodDetails card)
        {
             string jsonString = string.Empty;
             try
             {
                 clsPaymentMethod c = new clsPaymentMethod();
                 int cardID = c.insert(card);
                 if (cardID > 0)
                 {
                     jsonString = "{ \"success\": { \"id\": " + cardID.ToString() + "  } }";
                 }
                 else
                 {
                     jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't save trip\"  } }";
                 }
             }
            catch(Exception e)
             {
                 jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't save trip\"  } }";
             }
             return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // PUT api/paymentmethod/5
        public HttpResponseMessage Put(int id, [FromBody]paymentMethodDetails card)
        {
            string jsonString = string.Empty;
            try
            {
                clsPaymentMethod c = new clsPaymentMethod();
                int cardID = c.updtate(id,card);
                if (cardID > 0)
                {
                    jsonString = "{ \"success\": { \"id\": " + cardID.ToString() + "  } }";
                }
                else
                {
                    jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't save trip\"  } }";
                }
            }
            catch (Exception e)
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't save trip\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }

        // DELETE api/paymentmethod/5
        public HttpResponseMessage Delete(int id)
        {
            string jsonString = string.Empty;
            try
            {
                clsPaymentMethod c = new clsPaymentMethod();
                int res = c.delete(id);
                if (res > 0)
                {
                    jsonString = "{ \"success\": { \"id\": " + id.ToString() + "  } }";
                }
                else
                {
                    jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't delete the card\"  } }";
                }
            }
            catch (Exception e)
            {
                jsonString = "{ \"error\": { \"code\": 3, \"message\": \"can't delete the card\"  } }";
            }
            return new HttpResponseMessage() { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/jason") };
        }
    }
}
