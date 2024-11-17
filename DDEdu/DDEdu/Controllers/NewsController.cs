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


        public ActionResult getTop6News()
        {
            ViewBag.meta = "news";
            var v = (from t in _db.newPosts
                     where t.hide == true
                     orderby t.postDate descending
                     select t).Take(6); //Lấy ra 6 tin bài mới nhất
                return PartialView(v.ToList());        
        }


        public ActionResult getType()
        {
            ViewBag.meta = "news";
            var types = (from t in _db.typePosts
                         where t.hide == true
                         select t);
            return PartialView(types.ToList());
        }


        //Lấy toàn bộ tin theo type
        public ActionResult getAllNewsByType(int type)
        {
            ViewBag.meta = "news";
            ViewBag.type = getTypeString(type).ToString().ToLower();
            var v = (from t in _db.newPosts
                     where t.hide == true && t.type == type
                     orderby t.postDate descending
                     select t); //Lấy ra toàn bộ tin theo danh mục
            return PartialView(v.ToList());
        }

        public ActionResult getNewDetail(string meta)
        {
            ViewBag.meta = "news";
            var v = from t in _db.newPosts
                    where t.meta.Equals(meta) && t.hide == true
                    select t;
            return View(v.FirstOrDefault());
        }

        //Lấy thêm tin để hiển thị ở phần Read More trong NewDetail
        public ActionResult getMoreNew(int id, int type)
        {
            ViewBag.meta = "news";
            ViewBag.type = getTypeString(type).ToString().ToLower();
            var v = (from t in _db.newPosts
                     where t.hide == true && t.id != id && t.type == type
                     orderby t.postDate descending
                     select t).Take(3); //Lấy ra 3 tin bài mới nhất
            return PartialView(v.ToList());
        }


        public string getTypeString(int type)
        {
            var v = (from t in _db.typePosts
                     where t.id == type
                     select t.nameType);
            return v.FirstOrDefault();
        }

    }
}