using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRManager.data;
using HRManager.domain.Entities;
using HRManager.service;

namespace HRManagerWeb.Controllers
{
    public class DayOffController : Controller
    {

        IDayOffService dos;
        public DayOffController() { dos = new DayOffService(); }
        private HRManagerContext db = new HRManagerContext();


        // GET: DayOff
        public ActionResult Index()
        {
            return View(dos.GetAll().Where(dayoff => dayoff.State == State.Pending));
        }

        public ActionResult Grant(int DayOffId)
        {
            dos.GrantDayOff(DayOffId);
            return RedirectToAction("Index", "DayOff");
        }
        public ActionResult Decline(int DayOffId)
        {
            dos.DeclineDayOff(DayOffId);
            return RedirectToAction("Index", "DayOff");
        }

        // GET: DayOff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayOff dayOff = db.DayOff.Find(id);
            if (dayOff == null)
            {
                return HttpNotFound();
            }
            return View(dayOff);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult AskForDayOff(long id)
        {
            DayOff dayOff = new DayOff();
            dayOff.UserId = int.Parse(id.ToString());
            return PartialView(dayOff);
        }
        public ActionResult Add(DayOff dayOff)
        {
            if (dayOff.Duration == 0)
            {
                ModelState.AddModelError("Duration", "Duration cannot be 0");
               return RedirectToAction("Profile", "User");
            }
            else if (dayOff.StartDate <= DateTime.Now)
            {
                ModelState.AddModelError("StartDate", "Please choose another date");
              return  RedirectToAction("Profile", "User");
            }
            else
            {

                dos.Add(dayOff);
                dos.Commit();
                return RedirectToAction("Profile", "User");
            }
        }

        // POST: DayOff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DayOffId,StartDate,EndDate,Duration,Description,Balance,UserId")] DayOff dayOff)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dos.Add(dayOff);
                    dos.Commit();
                }
                catch
                {

                    return View();
                }
            }

            return View(dayOff);
        }

        // GET: DayOff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayOff dayOff = db.DayOff.Find(id);
            if (dayOff == null)
            {
                return HttpNotFound();
            }
            return View(dayOff);
        }

        // POST: DayOff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DayOffId,StartDate,EndDate,Duration,Description,Balance,UserId")] DayOff dayOff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dayOff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dayOff);
        }

        // GET: DayOff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayOff dayOff = db.DayOff.Find(id);
            if (dayOff == null)
            {
                return HttpNotFound();
            }
            return View(dayOff);
        }

        // POST: DayOff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DayOff dayOff = db.DayOff.Find(id);
            db.DayOff.Remove(dayOff);
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
