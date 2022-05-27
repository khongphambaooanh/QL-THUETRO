using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTHUETRO_BAOOANH.Models;
using PagedList;
using PagedList.Mvc;

namespace QLTHUETRO_BAOOANH.Controllers
{
    public class SUCO_60131724Controller : Controller
    {
        private QL_THUETRO_BOEntities11 db = new QL_THUETRO_BOEntities11();

        // GET: SUCO_60131724
        public ActionResult Index(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 4;
            return View(db.SUCOes.ToList().OrderBy(n => n.MaSC).ToPagedList(pageNumber, pageSize));

            //return View(db.SUCOes.ToList());
        }

        // GET: SUCO_60131724/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCO sUCO = db.SUCOes.Find(id);
            if (sUCO == null)
            {
                return HttpNotFound();
            }
            return View(sUCO);
        }

        // GET: SUCO_60131724/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SUCO_60131724/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSC,TenSC")] SUCO sUCO)
        {
            if (ModelState.IsValid)
            {
                db.SUCOes.Add(sUCO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sUCO);
        }

        // GET: SUCO_60131724/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCO sUCO = db.SUCOes.Find(id);
            if (sUCO == null)
            {
                return HttpNotFound();
            }
            return View(sUCO);
        }

        // POST: SUCO_60131724/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSC,TenSC")] SUCO sUCO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUCO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sUCO);
        }

        // GET: SUCO_60131724/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCO sUCO = db.SUCOes.Find(id);
            if (sUCO == null)
            {
                return HttpNotFound();
            }
            return View(sUCO);
        }

        // POST: SUCO_60131724/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SUCO sUCO = db.SUCOes.Find(id);
            db.SUCOes.Remove(sUCO);
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
