using DDEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDEdu.Controllers
{
    public class NewsController : Controller
    {
        // GET: New
        DDEdu_DB _db = new DDEdu_DB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getAllNews()
        {
            ViewBag.meta = "news";
            var v = (from t in _db.newPosts
                     where t.hide == true
                     orderby t.postDate descending
                     select t); //Lấy ra toàn bộ tin
                return PartialView(v.ToList());        
        }


        public ActionResult getType()
        {
            ViewBag.meta = "news";
            var types = (from t in _db.newPosts
                         where t.hide == true
                         select t.type).Distinct().ToList();
            return PartialView(types);
        }


        //Lấy toàn bộ tin theo type
        public ActionResult getAllNewsByType(string type)
        {
            ViewBag.meta = "news";
            var v = (from t in _db.newPosts
                     where t.hide == true && t.type == type
                     orderby t.postDate descending
                     select t); //Lấy ra toàn bộ tin theo danh mục
            return PartialView(v.ToList());
        }

        public ActionResult getNewDetail(int id)
        {
            ViewBag.metaCourses = "news";
            var v = from t in _db.newPosts
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }

        //Lấy thêm tin để hiển thị ở phần Read More trong NewDetail
        public ActionResult getMoreNew(int id)
        {
            var v = (from t in _db.newPosts
                     where t.hide == true && t.id != id
                     orderby t.postDate descending
                     select t).Take(3); //Lấy ra 3 tin bài mới nhất
            return PartialView(v.ToList());
        }

    }
}