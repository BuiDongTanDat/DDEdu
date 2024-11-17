using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDEdu.Helper;
using DDEdu.Models;

namespace DDEdu.Areas.admin.Controllers
{
    public class newPostsController : Controller
    {
        private DDEdu_DB db = new DDEdu_DB();

        // GET: admin/newPosts
        public ActionResult Index()
        {
            //Truyền list vào để lựa chọn giữa các mục
            var typeList = db.typePosts.ToList();
            ViewBag.typeList = typeList;
            return View(db.newPosts.ToList());
        }

        // GET: admin/newPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newPost newPost = db.newPosts.Find(id);
            if (newPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.typePost = getType(newPost.id);
            return View(newPost);
        }

        // GET: admin/newPosts/Create
        public ActionResult Create()
        {
            /// Lấy danh sách cacs danh mucj
            var typeList = db.typePosts.ToList(); // Lấy toàn bộ danh mục
            ViewBag.typeList = typeList; // Truyền danh sách danh mục vào ViewBag
            return View();
        }

        // POST: admin/newPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "title,desc,detail,hide,meta,author,type")] newPost newPost, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                if (ModelState.IsValid)
                {
 
                    if (img != null)
                    {
                        // Ensure unique filenames
                        filename = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/news"), filename);
                        img.SaveAs(path);
                        newPost.image = filename;
                    }
                    else
                    {
                        newPost.image = "logo.png";
                    }

                    newPost.datebegin = DateTime.Now;
                    newPost.postDate = DateTime.Now; // Convert Vietnamese accents to non-accented text
                    db.newPosts.Add(newPost);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                // Log validation errors for debugging
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} Error: {1}",
                                          validationError.PropertyName,
                                          validationError.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                // Log generic exceptions
                Console.WriteLine(ex.Message);
                throw;
            }

            return View(newPost);
        }

        // GET: admin/newPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newPost newPost = db.newPosts.Find(id);
            if (newPost == null)
            {
                return HttpNotFound();
            }

            /// Lấy danh sách cacs danh mucj
            var typeList = db.typePosts.ToList(); // Lấy toàn bộ danh mục
            ViewBag.typeList = typeList; // Truyền danh sách danh mục vào ViewBag
            ViewBag.typePost = getType(newPost.id);
            return View(newPost);
        }

        // POST: admin/newPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,title,desc,detail,image,hide,meta,author,type")] newPost newPost, HttpPostedFileBase img)
        {
            try
            {
                // Get the existing post from the database
                newPost temp = getById(newPost.id); // Lấy đối tượng post từ cơ sở dữ liệu bằng ID

                if (ModelState.IsValid)
                {
                    // If an image is uploaded, save it and update the image field
                    if (img != null && img.ContentLength > 0)
                    {
                        var filename = DateTime.Now.ToString("dd-MM-yy-HH-mm-ss-") + Path.GetFileName(img.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/upload/img/news"), filename);
                        img.SaveAs(path);

                        temp.image = Path.GetFileName(path);
                    }

                    // Update the other fields from the model
                    temp.title = newPost.title;
                    temp.desc = newPost.desc;
                    temp.detail = newPost.detail;
                    temp.hide = newPost.hide;
                    temp.meta = newPost.meta;
                    temp.author = newPost.author;
                    temp.type = newPost.type;
                    temp.datebegin = DateTime.Now;

                    // Mark the post as modified and save changes
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra. Vui lòng thử lại.");
            }

            // If we reached here, there was an error, so return the view again with the model
            return View(newPost);
        }


        // GET: admin/newPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newPost newPost = db.newPosts.Find(id);
            if (newPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.typePost = getType(newPost.id);
            return View(newPost);
        }

        // POST: admin/newPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            newPost newPost = db.newPosts.Find(id);
            db.newPosts.Remove(newPost);
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


        public string getType(int id)
        {
            // Tìm post dựa trên ID được truyền vào
            var post = db.newPosts.Find(id);

            if (post == null || post.id == null)
            {
                return "Post news not found";
            }

            var typePost = db.typePosts.Find(post.type);
            if (typePost != null)
            {
                return typePost.nameType;
            }
            return "None";
        }

        public newPost getById(int id)
        {
            return db.newPosts.Find(id);
        }

        //Lấy toàn bộ tin theo type
        public ActionResult getAllNewsForTable(int? type)
        {
            if (type == null)
            {
                 var v = (from t in db.newPosts
                         where t.hide == true
                         orderby t.postDate descending
                         select t);
                return PartialView(v.ToList());
            }
            var m = (from t in db.newPosts
                         where t.hide == true && t.type == type
                         orderby t.postDate descending
                         select t); //Lấy ra toàn bộ tin theo danh mục
            ViewBag.meta = "news";     
            return PartialView(m.ToList());
        }
    }
}
