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
    public class categoriesController : Controller
    {
        private DDEdu_DB db = new DDEdu_DB();

        // GET: admin/categories
        public ActionResult Index()
        {
            return View(db.categories.ToList());
        }

        // GET: admin/categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category menu = db.categories.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }

            ViewBag.ParentMenu = getParent(menu.id);
            return View(menu);
        }

        // GET: admin/categories/Create
        public ActionResult Create()
        {
            /// Lấy danh sách menu cha
            var parentMenus = db.menus.ToList(); // Lấy toàn bộ menu cha
            ViewBag.MenuList = parentMenus; // Truyền danh sách menu cha vào ViewBag
            return View();
        }

        // POST: admin/categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,link,meta,hide,order,idMenu")] category category)
        {

            if (ModelState.IsValid)
            {
                db.categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index","menus");
            }

            return View(category);
        }

        // GET: admin/categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category category = db.categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            /// Lấy danh sách menu cha
            var parentMenus = db.menus.ToList(); // Lấy toàn bộ menu cha
            ViewBag.MenuList = parentMenus; // Truyền danh sách menu cha vào ViewBag
            return  View(category);
        }

        // POST: admin/categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,link,meta,hide,order,idMenu,datebegin")] category category)
        {
            if (ModelState.IsValid)
            {
                category.datebegin = DateTime.Now; // Update the date
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index", "menus");
        }

        // GET: admin/categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category category = db.categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentMenu = getParent(category.id);
            return View(category);
        }

        // POST: admin/categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            category category = db.categories.Find(id);
            db.categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index", "menus");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string getParent(int id)
        {
            // Tìm category dựa trên ID được truyền vào
            var category = db.categories.Find(id);

            // Kiểm tra xem category có tồn tại và idMenu có hợp lệ không
            if (category == null || category.idMenu == null)
            {
                return "Parent menu not found";
            }

            // Tìm menu cha dựa trên idMenu của category
            var parentMenu = db.menus.Find(category.idMenu);
            if (parentMenu != null)
            {
                return parentMenu.name;
            }
            return "None";
        }
    }
}
