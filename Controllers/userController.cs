using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using UMoveNew.Controllers.AppCode;
using UMoveNew.Models;

namespace UMoveNew.Controllers
{
    public class userController : Controller
    {
        //
        // GET: /user/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login([Bind(Include = "Email,Password")] LoginModel login)
        {
            if (ModelState.IsValid)
            {
                clsUser user = new clsUser();
                int UserID = user.login(login.Email, login.Password);
                if (UserID > 0)
                {
                    DataTable dt = user.get(UserID);
                    HttpCookie usercookie = new HttpCookie("user");

                    usercookie.Values.Add("userid", UserID.ToString());
                    usercookie.Values.Add("username", dt.Rows[0]["username"].ToString());
                    usercookie.Values.Add("type", dt.Rows[0]["Type"].ToString());
                    usercookie.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Add(usercookie);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(login);
                }

            }
            else
            {
                return View(login);
            }
        }
        public ActionResult Logout()
        {
            if (Request.Cookies["user"] != null)
            {
                HttpCookie cookie = new HttpCookie("user");
                cookie.Value = "user";
                cookie.Expires = DateTime.Now.AddDays(-2);
                Response.SetCookie(cookie);
            }
            return RedirectToAction("Index", "Home");
        }
        //


        //
        // GET: /user/Create
        public ActionResult Create()
        {
            var url = Url.RequestContext.RouteData.Values["id"];
            TempData["Type"] = url;
            return View();
        }

        //
        // POST: /user/Create
        [HttpPost]

        public ActionResult Create([Bind(Include = "Name,UserName,Password,Email,Address,Phone,ConfirmPassword,Type")] Users user)
        {

            if (ModelState.IsValid)
            {
                clsUser User = new clsUser();
                //user.Type =Convert.ToInt32(TempData["Type"].ToString());
                int id = User.insert(user);
                if (id > 0)
                {
                    TempData["error"] = "";
                    return RedirectToAction("login", "user");

                }
                else
                {
                    TempData["error"] = "User Name or Mail Exist";
                }
                return RedirectToAction("login", "user");
            }
            else
            return View(user);

        }

        public ActionResult Details(int id)
        {

            if (Request.Cookies["user"] != null)
            {
                clsUser user = new clsUser();
                DataTable dt = user.get(id);
                Users us = new Users();
                us.Name = dt.Rows[0]["Name"].ToString();
                us.UserName = dt.Rows[0]["UserName"].ToString();
                us.Email = dt.Rows[0]["Email"].ToString();
                us.Address = dt.Rows[0]["Address"].ToString();
                us.Phone = dt.Rows[0]["Phone"].ToString();
                return View(us);
            }
            else
                return RedirectToAction("login", "user");
        }


        //
        // GET: /user/Edit/5

        public ActionResult Edit(int id)
        {
            if (Request.Cookies["user"] != null)
            {
                clsUser user = new clsUser();
                DataTable dt = user.get(id);
                Users us = new Users();
                us.UserID = id;
                us.Name = dt.Rows[0]["name"].ToString();
                us.UserName = dt.Rows[0]["username"].ToString();
                us.Email = dt.Rows[0]["email"].ToString();
                us.Address = dt.Rows[0]["address"].ToString();
                us.Phone = dt.Rows[0]["phone"].ToString();
                us.Password = dt.Rows[0]["password"].ToString();
                us.ConfirmPassword = dt.Rows[0]["password"].ToString();
                us.Type = Convert.ToInt32(dt.Rows[0]["type"].ToString());
                TempData["Type"] = us.Type;
                TempData["UserID"] = id;
                return View(us);
            }
            else
                return RedirectToAction("login", "user");
        }

        //
        // POST: /user/Edit/5
        [HttpPost]

        public ActionResult Edit(Users user)
        {
            try
            {

                clsUser User = new clsUser();
                int id = User.update(user.UserID, user);
                return RedirectToAction("Details", new { id = id });

            }
            catch
            {
                return View(user);
            }
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string Email)
        {
            try
            {
                clsUser User = new clsUser();
                DataTable dt = User.restPassword(Email.ToString());
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    //var fromAddress = new MailAddress("semsem9000@gmail.com", "UMove");
                    //var toAddress = new MailAddress(Email);
                    //const string fromPassword = "fromPassword";
                    //const string subject = "Subject";
                    //const string body = "Body";

                    //var smtp = new SmtpClient
                    //{
                    //    Host = "smtp.gmail.com",
                    //    Port = 587,
                    //    EnableSsl = true,
                    //    DeliveryMethod = SmtpDeliveryMethod.Network,
                    //    UseDefaultCredentials = false,
                    //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    //};
                    //using (var message = new MailMessage(fromAddress, toAddress)
                    //{
                    //    Subject = dt.Rows[0]["password"].ToString(),
                    //    Body = body
                    //})
                    //{
                    //    smtp.Send(message);
                    //}
                    return RedirectToAction("Password", new { Password = dt.Rows[0]["password"].ToString() });
                }
                return View("ForgetPassword");
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ActionResult Password(string password)
        {
            ViewData["Password"] = password;
            return View();
        }
        //
        // GET: /user/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /user/Delete/5
        [HttpPost]

        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
