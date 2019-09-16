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
    public class AppointmentsController : Controller
    {
        private fit5032_assignment_Model db = new fit5032_assignment_Model();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Customer).Include(a => a.Restaurant).Include(a => a.Review);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        [Authorize(Roles = "Customer")]
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "RestaurantName");
            ViewBag.CustomerId = new SelectList(db.Reviews, "CustomerId", "ReviewDesc");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public ActionResult Create([Bind(Include = "CustomerId,RestaurantId,AppointmentDate")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", appointment.CustomerId);
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "RestaurantName", appointment.RestaurantId);
            ViewBag.CustomerId = new SelectList(db.Reviews, "CustomerId", "ReviewDesc", appointment.CustomerId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        [Authorize(Roles = "Customer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", appointment.CustomerId);
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "RestaurantName", appointment.RestaurantId);
            ViewBag.CustomerId = new SelectList(db.Reviews, "CustomerId", "ReviewDesc", appointment.CustomerId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public ActionResult Edit([Bind(Include = "CustomerId,RestaurantId,AppointmentDate")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", appointment.CustomerId);
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "RestaurantName", appointment.RestaurantId);
            ViewBag.CustomerId = new SelectList(db.Reviews, "CustomerId", "ReviewDesc", appointment.CustomerId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        [Authorize(Roles = "Customer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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
