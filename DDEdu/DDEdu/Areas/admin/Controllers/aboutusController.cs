using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDEdu.Models;
using static CKFinder.Connector.CKFinderEvent;

namespace DDEdu.Areas.admin.Controllers
{
    public class aboutusController : Controller
    {
        private DDEdu_DB db = new DDEdu_DB();

        // GET: admin/aboutus
        public ActionResult Index()
        {
            return View(db.aboutus.ToList());
        }


        // GET: admin/aboutus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aboutu aboutu = db.aboutus.Find(id);
            if (aboutu == null)
            {
                return HttpNotFound();
            }
            return View(aboutu);
        }

        // GET: admin/aboutus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/aboutus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "title,desc,icon,isquestion,hide,order")] aboutu aboutu)
        {
            if (ModelState.IsValid)
            {
                aboutu.meta = "aboutus";
                aboutu.datebegin = DateTime.Now;
                db.aboutus.Add(aboutu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutu);
        }

        // GET: admin/aboutus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aboutu aboutu = db.aboutus.Find(id);
            if (aboutu == null)
            {
                return HttpNotFound();
            }
            return View(aboutu);
        }

        // POST: admin/aboutus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,desc,icon,isquestion,meta,hide,order,datebegin")] aboutu aboutu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutu);
        }

        // GET: admin/aboutus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aboutu aboutu = db.aboutus.Find(id);
            if (aboutu == null)
            {
                return HttpNotFound();
            }
            return View(aboutu);
        }

        // POST: admin/aboutus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aboutu aboutu = db.aboutus.Find(id);
            db.aboutus.Remove(aboutu);
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

        public ActionResult getAllTagByType(int? tag)
        {
            IEnumerable<aboutu> result;

            if (tag == 1)
            {
                result = db.aboutus.Where(t => t.isquestion == false);
            }
            else if (tag == 2)
            {
                result = db.aboutus.Where(t => t.isquestion == true);
            }
            else
            {
                result = db.aboutus;
            }

            ViewBag.meta = "aboutus";
            return PartialView(result.ToList());
        }
    }
}
