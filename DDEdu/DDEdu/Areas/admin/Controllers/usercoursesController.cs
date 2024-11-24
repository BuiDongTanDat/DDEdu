using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDEdu.Models;
using Microsoft.Ajax.Utilities;

namespace DDEdu.Areas.admin.Controllers
{
    public class usercoursesController : Controller
    {
        private DDEdu_DB db = new DDEdu_DB();

        // GET: admin/usercourses

        //Trả về danh sách courses y như bên course controller
        //Khác ở chỗ chỉ còn 1 nút button để truy cập vào danh sách lớp của lớp học đó
        public ActionResult Index()
        {
            var v = (from t in db.categories
                     where t.hide == true && t.idMenu == 2 //Id của COURSE
                     select t);
            ViewBag.cert = v.ToList();
            return View(db.courses.ToList());
        }

        // GET: admin/usercourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usercourse usercourse = db.usercourses.Find(id);
            if (usercourse == null)
            {
                return HttpNotFound();
            }
            return View(usercourse);
        }

        // GET: admin/usercourses/Create
        //Create trong usercourse sẽ hiển thị danh sách các sinh viên chưa đăng ký
        //khóa học có idC truyền vào
        public ActionResult Create(int? idC)  //Chú ý: idC là id của course
        {
            //Lấy danh sách sinh viên không phải admin
            var students = db.users
                             .Where(u => u.isAdmin == false)
                             .ToList();


            //Lấy course với id truyền vào
            var course = db.courses.Find(idC);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.currCourse = course; 

            //Lấy danh sách các sinh viên đã đăng ký khóa học
            var registeredUserIds = db.usercourses
                .Where(uc => uc.idCourse == idC)
                .Select(uc => uc.idUser)
                .ToList();

            ///Lấy danh sách các sinh viên chưa đăng ký
            var availableStudents = students
                .Where(s => !registeredUserIds.Contains(s.id))
                .ToList();

            ViewBag.availableStudents = availableStudents;

            return View();
        }


        // POST: admin/usercourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int idC, int[] selectedStudents)
        {
            if (selectedStudents != null)
            {
                foreach (var studentId in selectedStudents)
                {
                    var userCourse = new usercourse
                    {
                        idUser = studentId,
                        idCourse = idC,
                        dateBegin = DateTime.Now,
                        ispaid = false,
                        meta = "my-course"
                    };

                    db.usercourses.Add(userCourse);
                    db.courses.Find(idC).currStudent++;
                }
                db.SaveChanges();
            }

            return RedirectToAction("ListClass", new {id = idC});
        }

        // GET: admin/usercourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usercourse usercourse = db.usercourses.Find(id);
            if (usercourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.course = db.courses.Find(usercourse.idCourse).name.ToString();
            ViewBag.student = db.users.Find(usercourse.idUser).fullname.ToString();
            return View(usercourse);
        }

        // POST: admin/usercourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id, ispaid")] usercourse usercourse)
        {
            if (ModelState.IsValid)
            {
                usercourse temp = db.usercourses.Find(usercourse.id);
                temp.ispaid = usercourse.ispaid;
                temp.dateedit = DateTime.Now;
                temp.meta = "my-course";
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListClass", new {id = temp.idCourse});
            }
            return View(usercourse);
        }

        // GET: admin/usercourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usercourse usercourse = db.usercourses.Find(id);
            if (usercourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.course = db.courses.Find(usercourse.idCourse).name.ToString();
            ViewBag.student = db.users.Find(usercourse.idUser).fullname.ToString();
            return View(usercourse);
        }

        // POST: admin/usercourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usercourse usercourse = db.usercourses.Find(id);
            //Xử lý khi hủy đăng ký
            course course = db.courses.Find(usercourse.idCourse);
            course.currStudent--;

            db.usercourses.Remove(usercourse);
            db.SaveChanges();
            return RedirectToAction("ListClass", new { id = usercourse.idCourse});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        //Trả về danh sách các id sinh viên đã đăng ký với id khóa học truyền vào
        public ActionResult ListClass(int id)
        {
            var userCourses = db.usercourses.Where(uc => uc.idCourse == id).ToList();

            //Lấy thông tin khóa học với id được truyền vào
            var course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            //Gán course vào viewBag
            ViewBag.currCourse = course;

            return View(userCourses);
        }

        //Trả về sinh viên dựa vào id
        public user getStudent(int id)
        {
            return db.users.Find(id);
        }

        public string getStudentName(int id)
        {
            return db.users.Find(id).fullname;
        }

        //Trả về course dựa vào id
        public course getCourse(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.courses.Find(id);
            }
        }



    }
    }
