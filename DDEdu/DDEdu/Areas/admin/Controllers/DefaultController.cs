using DDEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DDEdu.Areas.admin.Controllers
{
    public class DefaultController : Controller
    {

       

        // GET: admin/Default
        public ActionResult Index()
        {
            //Kiểm tra trạng thái người dùng đăng nhập
            if (Session["Admin"] != null)
            {
                // Truyền thông tin id người dùng đến view
                var currentUser = (user)Session["Admin"];
                ViewBag.idUser = currentUser.id;
                return View();
            }
            else
                return RedirectToAction("Login", "account");
        }


        
    }
}