﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fit5032_assignment_v4.Models;
using Microsoft.AspNet.Identity;

namespace fit5032_assignment_v4.Controllers
{
    public class RestaurantOwnersController : Controller
    {
        private fit5032_assignment_Model db = new fit5032_assignment_Model();

        // GET: RestaurantOwners
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var restaurantOwners = db.RestaurantOwners.Where(s => s.UserId == userId).ToList();

            return View(restaurantOwners);
        }

        // GET: RestaurantOwners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantOwner restaurantOwner = db.RestaurantOwners.Find(id);
            if (restaurantOwner == null)
            {
                return HttpNotFound();
            }
            return View(restaurantOwner);
        }

        // GET: RestaurantOwners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantOwners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "RestaurantOwner")]
        public ActionResult Create([Bind(Include = "OwnerId,OwnerName")] RestaurantOwner restaurantOwner)
        {
            restaurantOwner.UserId = User.Identity.GetUserId();

            ModelState.Clear();
            TryValidateModel(restaurantOwner);
             
            if (ModelState.IsValid)
            {
                db.RestaurantOwners.Add(restaurantOwner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurantOwner);
        }

        // GET: RestaurantOwners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantOwner restaurantOwner = db.RestaurantOwners.Find(id);
            if (restaurantOwner == null)
            {
                return HttpNotFound();
            }
            return View(restaurantOwner);
        }

        // POST: RestaurantOwners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OwnerId,OwnerName,UserId")] RestaurantOwner restaurantOwner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantOwner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantOwner);
        }

        // GET: RestaurantOwners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantOwner restaurantOwner = db.RestaurantOwners.Find(id);
            if (restaurantOwner == null)
            {
                return HttpNotFound();
            }
            return View(restaurantOwner);
        }

        // POST: RestaurantOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantOwner restaurantOwner = db.RestaurantOwners.Find(id);
            db.RestaurantOwners.Remove(restaurantOwner);
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
