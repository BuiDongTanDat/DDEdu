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

        //Tạo trang chi tiết khóa học
        public ActionResult getDetail(int id)
        {
            ViewBag.metaCourses = "courses";
            var v = from t in _db.courses
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
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


    }
}