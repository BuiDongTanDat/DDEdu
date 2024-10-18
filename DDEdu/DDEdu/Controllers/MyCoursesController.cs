using DDEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDEdu.Controllers
{
    public class MyCoursesController : Controller
    {
        DDEdu_DB _db = new DDEdu_DB();
        // GET: MyCourse
        public ActionResult Index()
        {
            //Kiểm tra trạng thái người dùng đăng nhập
            if (Session["User"] != null)
            {
                // Truyền thông tin id người dùng đến view
                var currentUser = (user)Session["User"];
                ViewBag.idUser = currentUser.id;
                return View();
            }
            else
                return RedirectToAction("Login", "User");
        }


        //Vì mỗi View chỉ được sử dụng một model nên
        // Lấy ra danh sách id các khóa học mà user đã đăng ký từ bảng usercourse
        // Từ danh sách các id khóa học hiển thị chi tiết các course đó


        //Lấy danh sách id các course của user đã đăng ký
        public ActionResult getCoursesByUser(int id)
        {
            ViewBag.metaCourses = "my-courses";
            var v = from t in _db.usercourses
                    where t.idUser == id
                    select t;
            return PartialView(v.ToList());
        }

        //Lấy danh sách detail các course
        public ActionResult getDetailCoursesByUser(int id, string day)
        {
            ViewBag.day = day;
            ViewBag.metaGet = "courses";
            var v = from t in _db.courses
                    where t.id == id
                    select t;
            return PartialView(v.FirstOrDefault());
        }


        //Lấy danh sách course hiển thị trong profile
        public ActionResult getIdInProfile(int id)
        {
            ViewBag.metaCourses = "my-courses";
            var v = from t in _db.usercourses
                    where t.idUser == id
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getListId(int id, string day)
        {
            ViewBag.day = day;
            ViewBag.metaGet = "courses";
            var v = from t in _db.courses
                    where t.id == id
                    select t;
            return PartialView(v.FirstOrDefault());
        }


        //Xử lý hủy đăng ký khóa học của người dùng
        [HttpPost]
        public ActionResult unsubscribeCourse(int courseId)
        {
            //Kiểm tra thông tin người dùng có đăng nhập hay chưa
            if (Session["User"] != null)
            {
                // Lấy thông tin người dùng từ Session
                var user = (user)Session["User"];
                var course = _db.courses.Find(courseId);

                
                if (course != null)
                {
                    // Xóa khóa học khỏi bảng usercourse
                    var userCourse = _db.usercourses
                        .FirstOrDefault(uc => uc.idCourse == courseId && uc.idUser == user.id);

                    if (userCourse != null)
                    {
                        _db.usercourses.Remove(userCourse);
                        // Giảm số lượng sinh viên đang học
                        course.currrStudent--;
                        _db.SaveChanges();
                    }

                    TempData["UnsubscribeSuccess"] = "You have successfully unsubscribed from the course.";
                }
                else
                {
                    TempData["UnsubscribeError"] = "You can only unsubscribe within 10 days of the course start date.";
                }

                return RedirectToAction("Index");


            }
            else
            {
                return RedirectToAction("Index");
            }

            
        }
    }
}