using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMoveNew.Models;
namespace UMoveNew.Controllers
{
    public class TripsController : Controller
    {
        public ActionResult Index()
        {
            return View("Categories");
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Categories()
        {
            if (Request.Cookies["user"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("login", "user");
        }

        public ActionResult Vehicles()
        {
            if (Request.Cookies["user"] != null)
            {
                return View();
            }

            else
                return RedirectToAction("login", "user");
        }
        public ActionResult Household()
        {
            if (Request.Cookies["user"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult Moves()
        {
            if (Request.Cookies["user"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult Freight()
        {
            if (Request.Cookies["user"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult Animals()
        {
            if (Request.Cookies["user"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("login", "user");
        }

        public ActionResult createVeh(int id)
        {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/Shipments/CreateVeh.aspx?id=" + id);
            }
            else
                return RedirectToAction("login", "user");
        }

        public ActionResult createHouseHolde(int id)
        {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/Shipments/CreateHouse.aspx?id=" + id);
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult CreateHeavyEquipment()
        {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/Shipments/CreateHeavyEquipment.aspx");
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult CreateFreight(int id)
        {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/Shipments/CreateFreight.aspx?id=" + id);
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult CreateOthers()
        {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/Shipments/CreateOthers.aspx");
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult AllShipments()
        {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/Shipments/AllTrips.aspx");
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult MyShipments()
        {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/Shipments/MyShipments.aspx");
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult MyInbox()
        {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/Shipments/Inbox.aspx");
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult MyBids()
        {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/Shipments/MyBids.aspx");
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult MyCars()
        {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/Shipments/MyCars.aspx");
            }
            else
                return RedirectToAction("login", "user");
        }
        public ActionResult TripBids(int TripID) {
            if (Request.Cookies["user"] != null)
            {
                return Redirect("/Shipments/TripBids.aspx?id="+TripID);
            }
            else
                return RedirectToAction("login", "user");
        }
        //
        // GET: /Trips/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Trips/Edit/5
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
        // GET: /Trips/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Trips/Delete/5
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
