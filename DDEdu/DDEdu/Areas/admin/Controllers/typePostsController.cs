using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDEdu.Models;

namespace DDEdu.Areas.admin.Controllers
{
    public class typePostsController : Controller
    {
        private DDEdu_DB db = new DDEdu_DB();

        // GET: admin/typePosts
        public ActionResult Index()
        {
            return View(db.typePosts.ToList());
        }

        // GET: admin/typePosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typePost typePost = db.typePosts.Find(id);
            if (typePost == null)
            {
                return HttpNotFound();
            }

            return View(typePost);
        }

        // GET: admin/typePosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/typePosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nameType,link,meta,hide,order,datebegin")] typePost typePost)
        {
            if (ModelState.IsValid)
            {
                db.typePosts.Add(typePost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typePost);
        }

        // GET: admin/typePosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typePost typePost = db.typePosts.Find(id);
            if (typePost == null)
            {
                return HttpNotFound();
            }
            return View(typePost);
        }

        // POST: admin/typePosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nameType,link,meta,hide,order,datebegin")] typePost typePost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typePost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typePost);
        }

        // GET: admin/typePosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typePost typePost = db.typePosts.Find(id);
            if (typePost == null)
            {
                return HttpNotFound();
            }
            return View(typePost);
        }

        // POST: admin/typePosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            typePost typePost = db.typePosts.Find(id);
            db.typePosts.Remove(typePost);
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
