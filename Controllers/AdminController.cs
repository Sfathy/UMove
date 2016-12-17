using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UMoveNew.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllShipments()
        {
            if (Request.Cookies["user"] != null )
            {
                HttpCookie myCookie = Request.Cookies["user"];
                int Type = Convert.ToInt32(myCookie.Values["type"].ToString());
                if (Type ==3)
                {
                    return Redirect("/Administrator/AllTrips.aspx");
                }
                else
                {
                    return RedirectToAction("NotAuthonticated", "Admin");
                }
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult AllBids()
        {
            if (Request.Cookies["user"] != null)
            {
                HttpCookie myCookie = Request.Cookies["user"];
                int Type = Convert.ToInt32(myCookie.Values["type"].ToString());
                if (Type == 3)
                {
                    return Redirect("/Administrator/AllBids.aspx");
                }
                else
                {
                    return RedirectToAction("NotAuthonticated", "Admin");
                }
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult Questions()
        {
            if (Request.Cookies["user"] != null)
            {
                HttpCookie myCookie = Request.Cookies["user"];
                int Type = Convert.ToInt32(myCookie.Values["type"].ToString());
                if (Type == 3)
                {
                    return Redirect("/Administrator/Questions.aspx");
                }
                else
                {
                    return RedirectToAction("NotAuthonticated", "Admin");
                }
            }
            else
                return RedirectToAction("login", "user");
        }
        //
        // GET: /Admin/Details/5
        public ActionResult NotAuthonticated() { 
        
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Delete/5
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
