using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using DDEdu.Models;


namespace DDEdu.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout

        DDEdu_DB _db = new DDEdu_DB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getMenu()
        {
            var v = from t in _db.menus
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}