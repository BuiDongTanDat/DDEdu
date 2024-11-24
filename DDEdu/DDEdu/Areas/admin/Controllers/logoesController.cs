using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDEdu.Models;

namespace DDEdu.Areas.admin.Controllers
{
    public class logoesController : Controller
    {
        private DDEdu_DB db = new DDEdu_DB();

        // GET: admin/logoes
        public ActionResult Index()
        {
            //Vì trong db, các thông tin trong HOME có thể thay đổi
            //đều được lưu trong cùng 1 hàng dữ liệu
            return RedirectToAction("Details", "logoes");
        }

        // GET: admin/logoes/Details/5
        public ActionResult Details()
        {
            
            logo logo = db.logoes.Find(1);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // GET: admin/logoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/logoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,logoImage,logoName,meta,link,hide,text,desc,datebegin")] logo logo)
        {
            if (ModelState.IsValid)
            {
                db.logoes.Add(logo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logo);
        }

        // GET: admin/logoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            logo logo = db.logoes.Find(id);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // POST: admin/logoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,logoName,link,text,desc")] logo logo, HttpPostedFileBase img)
        {
            try
            {
                logo temp = db.logoes.Find(logo.id);

                if (ModelState.IsValid)
                {
                    // If an image is uploaded, save it and update the image field
                    if (img != null && img.ContentLength > 0)
                    {
                        // Generate a unique file name to avoid overwriting
                        var filename = DateTime.Now.ToString("dd-MM-yy-HH-mm-ss-") + Path.GetFileName(img.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/upload/img/logo"), filename);
                        img.SaveAs(path); // Save the image file

                        // Update the logoImage path in the database
                        temp.logoImage = filename;
                    }

                    // Update other fields
                    temp.logoName = logo.logoName;
                    temp.text = logo.text;
                    temp.desc = logo.desc;
                    temp.link = logo.link;
                    temp.hide = true;
                    temp.meta = logo.meta ?? "default";
                    temp.dateBegin = DateTime.Now;

                    // Mark the entity as modified and save changes
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                ModelState.AddModelError("", $"Có lỗi xảy ra: {ex.Message}");
            }

            // If an error occurs or validation fails, return the view with the model
            return View(logo);
        }

        // GET: admin/logoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            logo logo = db.logoes.Find(id);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // POST: admin/logoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            logo logo = db.logoes.Find(id);
            db.logoes.Remove(logo);
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
