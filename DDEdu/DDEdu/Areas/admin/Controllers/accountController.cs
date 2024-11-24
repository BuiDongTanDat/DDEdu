using DDEdu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace DDEdu.Areas.admin.Controllers
{
    public class accountController : Controller
    {

        DDEdu_DB _db = new DDEdu_DB();
        // GET: admin/account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Session["Admin"] != null)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }

        //Xử lý đăng nhập từ form
        [HttpPost]
        public ActionResult Login(user user)
        {
            var username = user.username;
            var password = MD5Hash(user.password); // Mã hóa mật khẩu người dùng nhập vào

            var userCheck = _db.users.SingleOrDefault(x => x.username.Equals(username) && x.password.Equals(password));

            if (userCheck != null)
            {
                if (userCheck.isActive == false)
                {
                    ViewBag.LoginFail = "* Your account is locked.";
                    return View(); // Trả về view đăng nhập cùng với thông báo tài khoản bị khóa
                }

                if (userCheck.isAdmin == false)
                {
                    ViewBag.LoginFail = "* Your account don't have this permission";
                    return View();
                }
                else
                {
                    Session["Admin"] = userCheck;
                    return RedirectToAction("Index", "Default"); // Redirect đến trang người dùng thường
                }
            }
            else
            {
                ViewBag.LoginFail = "* Username or Password is incorrect";
                return View(); // Trả về lại view đăng nhập cùng với thông báo lỗi
            }
        }

        public ActionResult ProfileChange()
        {

            if (Session["Admin"] != null)
            {
                // Truyền thông tin người dùng đến view
                var currentUser = (user)Session["Admin"];
                return View(currentUser);
            }
            else
                return RedirectToAction("Login");

        }


        //Xử lý thông tin edit profile
        [HttpPost]
        public ActionResult ProfileChange(string fullname, string email, DateTime birth)
        {

            if (ModelState.IsValid)
            {
                var currentUser = (user)Session["Admin"];
                if (currentUser == null)
                {
                    return RedirectToAction("Login");
                }

                currentUser.fullname = fullname;
                currentUser.email = email;
                currentUser.birth = birth;

                try
                {
                    _db.Entry(currentUser).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving changes: " + ex.Message);
                    return View();
                }

                return RedirectToAction("ProfileInfo");
            }
            return View();
        }

        public ActionResult ProfileInfo()
        {
            // Kiểm tra nếu người dùng đã đăng nhập
            if (Session["Admin"] != null)
            {
                // Lấy thông tin người dùng từ Session
                var user = (user)Session["Admin"];

                // Truyền thông tin người dùng đến view UserInfo
                return View(user);
            }
            else
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login");
            }
        }

        public ActionResult PassChange()
        {
            //Kiểm tra người dùng đã đăng nhập
            if (Session["Admin"] != null)
            {
                // Truyền thông tin người dùng đến view
                return View();
            }
            else
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login");
            }

        }

        [HttpPost]
        public ActionResult PassChange(string oldPassword, string newPassword, string reEnterPassword)
        {
            var currentUser = (user)Session["Admin"];
            if (currentUser == null)
            {
                return RedirectToAction("Login");
            }

         
            string hashedOldPassword = MD5Hash(oldPassword);
            if (currentUser.password.ToLower() != hashedOldPassword.ToLower())
            {
                ModelState.AddModelError("oldPassword", "* The old password is incorrect.");
                return View(); 
            }

            // Validate new password length
            if (newPassword.Length < 6)
            {
                ModelState.AddModelError("newPassword", "* The new password must be at least 6 characters.");
                return View(); 
            }

            // Check if new password and re-entered password match
            if (newPassword != reEnterPassword)
            {
                ModelState.AddModelError("reEnterPassword", "* The new password and re-entered password do not match.");
                return View(); 
            }

            // Update password
            currentUser.password = MD5Hash(newPassword);

            try
            {
                _db.Entry(currentUser).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "* An error occurred while saving changes: " + ex.Message);
                return View(); 
            }

            return RedirectToAction("ProfileInfo");
        }
        public ActionResult PassForgot()
        {
            return View();
        }
        [HttpPost]        
        public ActionResult PassForgot(string email)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem email có tồn tại trong cơ sở dữ liệu không
                var user = _db.users.FirstOrDefault(u => u.email == email);
               
                if (user == null )
                {
                    ModelState.AddModelError("", "* Email is not exists.");
                    return View();
                }
                if (user.isAdmin == false) //Chú ý: Tránh trường hợp nhập email của sinh viên
                {    ModelState.AddModelError("", "* Email is not exists.");
                    return View();
                }

                // Tạo mật khẩu mới
                string newPassword = GenerateRandomPassword(8); // Tạo một hàm để tạo mật khẩu ngẫu nhiên
                user.password = MD5Hash(newPassword); // Mã hóa mật khẩu trước khi lưu
                _db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu


                string body = "Hi " + user.username + "! Your password have been reset.";
                body += "\nNew password is: " + newPassword + "\n";
                body += "Please keep it in secrect or change your password as soon as posible in User profile";
                body += "\nBy the way, we hope you will find your dream course in here!\n";
                string subject = "[DDEDu English Center] Reset password successfully";
                // Gửi email với mật khẩu mới
                SendEmail(email, subject, body); // Gọi phương thức gửi email mà bạn đã tạo trước đó
                
                return View();
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["Admin"] = null;
            return RedirectToAction("Login"); ;
        }


        //Mã hóa mật khẩu sang md5
        public string MD5Hash(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển đổi byte array sang chuỗi hexadecimal
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower(); //Mã hóa thì ToLower để tránh 2 mk khác nhau
            }
        }


        //Tạo mật khẩu ngẫu nhiên
        private string GenerateRandomPassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }


        //Hàm gửi mail
        private void SendEmail(string toEmail, string subject, string body)
        {
            string from = "bdtd1ad@gmail.com";
            string pass = "ojwe bppb lato ksse";


            MailMessage mail = new MailMessage();
            mail.To.Add(toEmail);
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            mail.Body = body;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            smtp.Send(mail);
        }
    }
}