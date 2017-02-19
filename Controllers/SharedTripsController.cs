using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UMoveNew.Controllers
{
    public class SharedTripsController : Controller
    {
        //
        // GET: /SharedTrips/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /SharedTrips/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //
        // GET: /SharedTrips/Create
        public ActionResult CreateSharedTrip(int id)
        {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/SharedShipment/CreateSharedTrip.aspx?id=" + id);
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult AllSharedShipments()
        {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/SharedShipment/SharedTrips.aspx");
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult MySharedShipments()
        {
             if (Request.Cookies["user"] != null)
            {
                return Redirect("/SharedShipment/MySharedTrips.aspx");
            }
            else
                return RedirectToAction("login", "user");
        }
        ////
        //// POST: /SharedTrips/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /SharedTrips/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /SharedTrips/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /SharedTrips/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /SharedTrips/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
