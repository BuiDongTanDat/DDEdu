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
using DDEdu.Models;
using Microsoft.Ajax.Utilities;
using DDEdu.Helper;

namespace DDEdu.Areas.admin.Controllers
{
    public class coursesController : Controller
    {
        private DDEdu_DB db = new DDEdu_DB();

        // GET: admin/courses
        public ActionResult Index()
        {
            var v = (from t in db.categories
                     where t.hide == true && t.idMenu == 2 //Id của COURSE
                     select t);
            ViewBag.cert = v.ToList();
            return View(db.courses.ToList());
        }

        // GET: admin/courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            var v = (from t in db.categories
                     where t.hide == true && t.idMenu == 2 //Id của COURSE
                     select t);
            ViewBag.cert = v.ToList();
            ViewBag.typeCert = db.categories.Find(course.idCategory).name;
            return View(course);
        }

        // GET: admin/courses/Create
        public ActionResult Create()
        {
            var v = (from t in db.categories
                     where t.hide == true && t.idMenu == 2 //Id của COURSE
                     select t);
            ViewBag.certList = v.ToList(); // Populate certList
            return View();
        }

        // POST: admin/courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "name,desc,detail,startOn,endDate,maxStudent,currStudent,tuition,idCategory,meta,hide,image")] course course, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";

                // Validate Start Date
                if (course.startOn.HasValue && course.startOn.Value < DateTime.Now)
                {
                    ModelState.AddModelError("startOn", "Start date must be in the future.");
                }

                // Validate End Date
                if (course.endDate.HasValue && course.startOn.HasValue && course.endDate.Value < course.startOn.Value)
                {
                    ModelState.AddModelError("endDate", "End date must be after the start date.");
                }

                // Ensure the model state is valid
                if (ModelState.IsValid)
                {
                    // Handle file upload if an image is provided
                    if (img != null && img.ContentLength > 0)
                    {
                        // Validate the file (check extension and size)
                        string[] validExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
                        string fileExtension = Path.GetExtension(img.FileName).ToLower();

                        if (!validExtensions.Contains(fileExtension))
                        {
                            ModelState.AddModelError("image", "Invalid image format. Allowed formats: .jpg, .jpeg, .png, .gif.");
                        }

                        // Validate file size (example: limit to 5MB)
                        if (img.ContentLength > 5 * 1024 * 1024)
                        {
                            ModelState.AddModelError("image", "Image size must not exceed 5MB.");
                        }

                        if (ModelState.IsValid)
                        {
                            // Ensure unique filenames
                            filename = Guid.NewGuid().ToString() + fileExtension;
                            path = Path.Combine(Server.MapPath("~/Content/upload/img/course"), filename);
                            img.SaveAs(path);
                            course.image = filename;
                        }
                    }
                    else
                    {
                        // Default image if no file is uploaded
                        course.image = "logo.png";
                    }

                    // Set additional fields
                    course.meta = Functions.ConvertToUnSign(getNameCert(course.idCategory)); //meta is the certificate name in lowercase
                    course.currStudent = 0;
                    course.datebegin = DateTime.Now;

                    // Save the new course to the database
                    db.courses.Add(course);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                // Log detailed validation errors for debugging
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                // Add a general error message to the model state
                ModelState.AddModelError("", "An error occurred while saving the course. Please try again.");
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine(ex.Message);
                // Add a general error message to the model state
                ModelState.AddModelError("", "An unexpected error occurred. Please try again.");
            }

            // If validation failed or an exception occurred, return the view with the course model to display errors
            return View(course);
        }


        // GET: admin/courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            var v = (from t in db.categories
                     where t.hide == true && t.idMenu == 2 //Id của COURSE
                     select t);
            ViewBag.cert = v.ToList();
            return View(course);
        }

        // POST: admin/courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,desc,detail,startOn,endDate,maxStudent,currStudent,tuition,idCategory,meta,hide,image,datebegin")] course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: admin/courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: admin/courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            course course = db.courses.Find(id);
            db.courses.Remove(course);
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

        public course getById(int id)
        {
            return db.courses.Find(id);
        }

        public string getNameCert(int? idCategory)
        {


            return db.categories.Find(idCategory).name;
        }


        //Lấy toàn bộ tin theo chứng chỉ
        public ActionResult getAllCoursesForTable(int? type)
        {
            if (type == null)
            {
                var v = (from t in db.courses
                         where t.hide == true
                         orderby t.startOn descending
                         select t);
                return PartialView(v.ToList());
            }
            var m = (from t in db.courses
                     where t.hide == true && t.idCategory == type
                     orderby t.startOn descending
                     select t); //Lấy ra toàn bộ khóa học theo danh mục
            ViewBag.meta = "courses";
            return PartialView(m.ToList());
        }
    }
}
