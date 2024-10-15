using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDEdu.Models;

namespace DDEdu.Controllers
{
    public class DefaultController : Controller
    {
        DDEdu_DB _db = new DDEdu_DB();

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }


        //Lấy ảnh slide
        public ActionResult getSlide()
        {
            var v = from t in _db.slides
                    where t.hide == true
                    orderby t.id ascending
                    select t;
            return PartialView(v.ToList());
        }
        
        
        
        //Lấy Category
        public ActionResult getCategoryDF()
        {  
            ViewBag.meta = "courses";
            var v = from t in _db.categories
                    where t.hide == true
                    orderby t.id ascending
                    select t;
            return PartialView(v.ToList());
        }

        //Lấy Course theo category tương ứng
        //Lấy 3 course mới nhất, course đang diễn ra thì
        //không quá 10 ngày kể từ ngày bắt đầu --> Xem mô tả bên CourseController
        public ActionResult getCourse(int id, string meta)
        {
            ViewBag.meta = meta;

            var currentDate = DateTime.Now; // Lấy ngày và giờ hiện tại
            var tenDaysAgo = currentDate.AddDays(-10); // Lấy ngày cách 10 ngày trước


            var v = (from t in _db.courses
                    where t.hide == true && t.idCategory == id
                    && (t.startOn > currentDate // Khóa học sắp diễn ra
                               || (t.startOn <= currentDate && t.startOn >= tenDaysAgo))
                     orderby t.startOn descending
                    select t).Take(3);  //Lấy ra 3 courses cho mỗi danh mục hiển thị lên HOME
            return PartialView(v.ToList());

           
        }


        //Lấy thông tin NEWS
        public ActionResult getNew()
        {
            ViewBag.meta = "news";
            var v = (from t in _db.newPosts
                    where t.hide == true
                    orderby t.postDate descending //Nhằm lấy ra 6 tin bài mới nhất
                    select t).Take(6);
            return PartialView(v.ToList());
        }
    }


}