using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDEdu.Models;

namespace DDEdu.Controllers
{
    public class AboutUsController : Controller
    {
        DDEdu_DB _db = new DDEdu_DB();
        // GET: AboutUs


        //Lấy ảnh hiển thị cho phần background và phần câu hỏi, chỉ cần 2 ảnh
        //nên trong sql chỉ lưu 2 image
        public ActionResult Index()
        {
            ViewBag.meta = "about";
            var v = (from t in _db.aboutus
                     where t.img != null
                     orderby t.id ascending
                     select t).Take(2);
            return View(v.ToList());
        }


        //Lấy các nội dung giới thiệu
        public ActionResult getInto()
        {
            ViewBag.meta = "about";
            var v = (from t in _db.aboutus
                     where t.isquestion == false
                     orderby t.id ascending
                     select t);
            return PartialView(v.ToList());
        }

        //Lấy các nội dung câu hỏi
        public ActionResult getQuestion()
        {
            ViewBag.meta = "about";
            var v = (from t in _db.aboutus
                     where t.isquestion == true
                     orderby t.id ascending
                     select t);
            return PartialView(v.ToList());
        }



    }
}