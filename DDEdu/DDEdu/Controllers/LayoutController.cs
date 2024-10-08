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


        //Lấy danh mục con cho danh mục cha
        public ActionResult getCategory(int idForMenu)
        {
            var v = from t in _db.categories
                    where t.hide == true && t.idMenu == idForMenu
                    orderby t.order ascending
                    select t;

            // Nếu không có danh mục con, thì không trả về gì
            if (!v.Any())
            {
                return null;
            }

            return PartialView(v.ToList());
        }


        //Lấy các menu nằm bên góc phải
        public ActionResult getMenuRight()
        {
            var v = from t in _db.menuRights
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }

        //Lấy menu cho footer - vì footer định dạng danh sách menu khác với menu chính
        public ActionResult getMenuFooter()
        {
            var menus = from t in _db.menus
                        where t.hide == true
                        orderby t.order ascending
                        select t;
            return PartialView(menus.ToList());
        }


        //Lấy logo
        public ActionResult getLogo()
        {
            var logo = _db.logoes.FirstOrDefault(t => t.hide == true);
            return PartialView(logo);
        }

        public ActionResult getFooter() {

            var logo = _db.logoes.FirstOrDefault(t => t.hide == true);
            return PartialView(logo);

        }

        public ActionResult getLogo_Welcome()
        {

            var logo = _db.logoes.FirstOrDefault(t => t.hide == true);
            return PartialView(logo);

        }




    }
}