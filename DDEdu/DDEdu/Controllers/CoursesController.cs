using DDEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDEdu.Controllers
{
    public class CoursesController : Controller
    {

        DDEdu_DB _db = new DDEdu_DB();
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }


        //Hiển thị View theo Category
        public ActionResult getViewByCategory(string metatitle)
        {
            ViewBag.metaCourses = "courses";
            var v = from t in _db.categories
                    where t.meta == metatitle
                    select t;
            return View(v.FirstOrDefault());
        }



        //Hiển thị các khóa học đang và sắp diễn ra, 
        //Các khóa học đang diễn ra sẽ chỉ được hiển thị nếu đã
        //diễn ra kể từ ngày bắt đầu không quá 10 ngày
        public ActionResult getAllCourseByCategory(int id, string metaTitle)
        {
            ViewBag.metaGet = metaTitle;
            var currentDate = DateTime.Now; // Lấy ngày và giờ hiện tại
            var tenDaysAgo = currentDate.AddDays(-10); // Lấy ngày cách 10 ngày trước

            var v = from t in _db.courses
                    where t.hide == true
                          && t.idCategory == id
                          && (t.startOn > currentDate // Khóa học sắp diễn ra
                               || (t.startOn <= currentDate && t.startOn >= tenDaysAgo)) // Khóa học đang diễn ra không quá 10 ngày kể từ ngày bắt đầu
                    orderby t.id descending
                    select t; // Lấy tất cả các khóa học cho danh mục tương ứng

            return PartialView(v.ToList());
        }

        //Tạo trang chi tiết khóa học -- Notice: thêm phần user để check trạng thái hiển thị đăng ký của khóa học
        public ActionResult getDetail(int id)
        {
            ViewBag.metaCourses = "courses";

            var course = _db.courses.FirstOrDefault(t => t.id == id);

            if (course == null)
            {
                return HttpNotFound(); // Return a 404 if the course is not found
            }

            // Check if the user is logged in and registered for the course
            bool isRegistered = false;
            string currUser = null;
            if (Session["User"] != null)
            {
                var user = (user)Session["User"];
                currUser = user.id.ToString();
                isRegistered = _db.usercourses.Any(uc => uc.idUser == user.id && uc.idCourse == id);
            }

            // Trả về trạng thái đăng ký
            ViewBag.IsRegistered = isRegistered;
            ViewBag.currUser = currUser;
            return View(course);
        }

        //Lấy 3 courses liên quan category mới nhất và 
        public ActionResult getRelativeCourses(int idCourse, string metaRelative, string metaCourse)
        {
            ViewBag.metaCourse = metaCourse;

            var currentDate = DateTime.Now; // Lấy ngày và giờ hiện tại
            var tenDaysAgo = currentDate.AddDays(-10); // Lấy ngày cách 10 ngày trước


            var v = (from t in _db.courses
                    where t.hide == true && t.meta == metaRelative && t.id != idCourse //không hiển thị course đang mở ở trang hiện tại
                                && (t.startOn > currentDate // Khóa học sắp diễn ra
                                        || (t.startOn <= currentDate && t.startOn >= tenDaysAgo))
                     orderby t.id descending
                    select t).Take(3);  //Lấy 3 course mới nhất
            return PartialView(v.ToList());
        }


        //Xử lý đăng ký khóa học của người dùng
        [HttpPost]
        public ActionResult RegisterCourse(int courseId)
        {   
            //Kiểm tra thông tin người dùng có đăng nhập hay chưa
            if (Session["User"] != null)
            {
                // Lấy thông tin người dùng từ Session
                var user = (user)Session["User"];
                var course = _db.courses.Find(courseId);
                if (course == null)
                {
                    TempData["Error"] = "Course not found.";
                    return RedirectToAction("Index"); // Redirect to an appropriate view
                }

                if (course.currrStudent >= course.maxStudent)
                {
                    TempData["Success"] = "Registration failed: Course is full.";
                    return RedirectToAction("getDetail", new { id = courseId }); // Redirect to course detail
                }

                // Xử lý đăng ký
                var registration = new usercourse
                {
                    idCourse = courseId,
                    idUser = user.id,
                    dateBegin = DateTime.Now,
                    meta = "my-course",
                };

                _db.usercourses.Add(registration);
                course.currrStudent++;
                _db.SaveChanges();

                TempData["SignInComplete"] = "You are now registered for this course!";
                return RedirectToAction("getDetail", new { id = courseId }); //Trở về trang chi tiết
            }
            else
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login");
            }

            
        }

    }



}