using DDEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDEdu.Controllers
{
    public class ContactController : Controller
    {

        DDEdu_DB _db = new DDEdu_DB();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getContactInfo()
        {
            ViewBag.metaCourses = "contact";
            var v = from t in _db.contacts
                    where t.id == 1 //Do trong bảng này chỉ chứa một hàng nội dung duy nhất
                    select t;
            return PartialView(v.FirstOrDefault());
        }


        public ActionResult getContactInfoForFooter()
        {
            ViewBag.metaCourses = "contact";
            var v = from t in _db.contacts
                    where t.id == 1 //Do trong bảng này chỉ chứa một hàng nội dung duy nhất
                    select t;
            return PartialView(v.FirstOrDefault());
        }
    }
}