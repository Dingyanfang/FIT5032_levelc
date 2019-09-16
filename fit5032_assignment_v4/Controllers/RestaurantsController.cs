using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fit5032_assignment_v4.Models;

namespace fit5032_assignment_v4.Controllers
{
    public class RestaurantsController : Controller
    {
        private fit5032_assignment_Model db = new fit5032_assignment_Model();

        // GET: Restaurants
        public ActionResult Index()
        {
            var restaurants = db.Restaurants.Include(r => r.RestaurantOwner);
            return View(restaurants.ToList());
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        [Authorize(Roles = "RestaurantOwner")]
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.RestaurantOwners, "OwnerId", "OwnerName");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "RestaurantOwner")]
        public ActionResult Create([Bind(Include = "RestaurantId,OwnerId,RestaurantName,RestaurantDesc,RestaurantCountry,RestaurantState,RestaurantCity,RestaurantSuburb,RestaurantStreet,RestaurantPostcode")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.RestaurantOwners, "OwnerId", "OwnerName", restaurant.OwnerId);
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        [Authorize(Roles = "RestaurantOwner")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.RestaurantOwners, "OwnerId", "OwnerName", restaurant.OwnerId);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "RestaurantOwner")]
        public ActionResult Edit([Bind(Include = "RestaurantId,OwnerId,RestaurantName,RestaurantDesc,RestaurantCountry,RestaurantState,RestaurantCity,RestaurantSuburb,RestaurantStreet,RestaurantPostcode")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.RestaurantOwners, "OwnerId", "OwnerName", restaurant.OwnerId);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        [Authorize(Roles = "RestaurantOwner")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "RestaurantOwner")]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
