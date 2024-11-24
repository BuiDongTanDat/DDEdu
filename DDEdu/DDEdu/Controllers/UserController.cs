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
using System.Xml.Linq;

namespace DDEdu.Controllers
{
    public class UserController : Controller
    {

        DDEdu_DB _db = new DDEdu_DB();

        public object ClientScript { get; private set; }

        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        //Get view form đăng ký
        public ActionResult Register()
        {
            return View();
        }

        //Xử lý đăng ký từ form
        [HttpPost]
        public ActionResult Register(user user, string rePassword)
        {
            

            // Kiểm tra xem tên người dùng hoặc email đã tồn tại chưa
            if (_db.users.Any(u => u.username == user.username))
            {
                ModelState.AddModelError("Username", "* Username already exists.");
            }

            if (_db.users.Any(u => u.email == user.email))
            {
                ModelState.AddModelError("Email", "* Email already exists.");
            }

            // Nếu có lỗi, trả về lại view cùng với thông báo lỗi
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            // Nếu không có lỗi, thêm người dùng vào cơ sở dữ liệu
            //Mã hóa mật khẩu
            string randomPassword = GenerateRandomPassword(8);
            string hashedPassword = MD5Hash(randomPassword);
            user newUser = new user()
            {
                username = user.username,
                email = user.email,
                password = hashedPassword,
                fullname = user.fullname,
                birth = user.birth,
                isAdmin = false,
                dateBegin = DateTime.Now,
                meta = "user"
            };
            _db.users.Add(newUser);
            _db.SaveChanges();

            TempData["Success"] = "Registration successful! Please check your email.";


            // Gửi email cho người dùng với mật khẩu ngẫu nhiên
            string body = "Welcome student! Thank you for registed an account in our center\n";
            body += "Your password is: " + randomPassword + "\n";
            body += "Please keep it in secrect or change your password as soon as posible in User profile";
            body += "\nBy the way, we hope you will find your dream course in here!\n";
            string subject = "[DDEDu English Center] Create account successfully";
            SendEmail(user.email, subject, body);


            // Chuyển hướng đến trang đăng nhập
            return RedirectToAction("Login");
        }


        //Get view Login
        public ActionResult Login()
        {
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
                if (userCheck.isAdmin == true)
                {
                    ViewBag.LoginFail = "* Username or Password is incorrect";
                    return View();
                }
                else
                {
                    Session["User"] = userCheck;
                    return RedirectToAction("Index", "Default"); // Redirect đến trang người dùng thường
                }
            }
            else
            {
                ViewBag.LoginFail = "* Username or Password is incorrect";
                return View(); // Trả về lại view đăng nhập cùng với thông báo lỗi
            }
        }

        //Đăng xuất
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "User");
        }

        //Truy cập trang thông tin cá nhân
        public ActionResult UserInfo()
        {
            // Kiểm tra nếu người dùng đã đăng nhập
            if (Session["User"] != null)
            {
                // Lấy thông tin người dùng từ Session
                var user = (user)Session["User"];

                // Truyền thông tin người dùng đến view UserInfo
                return View(user);
            }
            else
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login");
            }
        }

        public ActionResult changePassword()
        {
            //Kiểm tra người dùng đã đăng nhập
            if (Session["User"] != null)
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
        public ActionResult changePassword(string currpassword, string newpassword, string renewpassword)
        {

            if (ModelState.IsValid)
            {
                var currentUser = (user)Session["User"];
                if (currentUser == null)
                {
                    return RedirectToAction("Login");
                }

                string hashedOldPassword = MD5Hash(currpassword);
                if (currentUser.password != hashedOldPassword)
                {
                    ModelState.AddModelError("currpassword", "* The old password is incorrect.");
                    return View();
                }

                if (newpassword.Length < 6)
                {
                    ModelState.AddModelError("newpassword", "* The new password must be at least 6 characters.");
                    return View();
                }
                if (newpassword != renewpassword)
                {
                    ModelState.AddModelError("renewpassword", "* The new password and re-entered password do not match.");
                    return View();
                }

                currentUser.password = MD5Hash(newpassword);
                try
                {
                    _db.Entry(currentUser).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    TempData["Success"] = "Password changed successfully!";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "* An error occurred while saving changes: " + ex.Message);
                    return View();
                }

                return RedirectToAction("UserInfo");
            }
            return View();
        }



        public ActionResult changeProfile()
        {
            
            if (Session["User"] != null)
            {
                // Truyền thông tin người dùng đến view
                var currentUser = (user)Session["User"];
                return View(currentUser);
            }
            else
                return RedirectToAction("Login");

        }


        //Xử lý thông tin edit profile
        [HttpPost]
        public ActionResult changeProfile(string fullname, string email, DateTime birth)
        {

            if (ModelState.IsValid)
            {
                var currentUser = (user)Session["User"];
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
                    TempData["Success"] = "Profile updated successfully!";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving changes: " + ex.Message);
                    return View();
                }

                return RedirectToAction("UserInfo");
            }
            return View();
        }



        //Lấy view quên mật khẩu
        public ActionResult forgotPassword()
        {
            return View();
        }


        //Đổi mật khẩu và gửi mail
        [HttpPost]
        public ActionResult forgotPassword(string email)
        {

            if (ModelState.IsValid)
            {
                // Kiểm tra xem email có tồn tại trong cơ sở dữ liệu không
                var user = _db.users.FirstOrDefault(u => u.email == email);

                if (user == null)
                {
                    ModelState.AddModelError("", "* Email is not exists.");
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
                TempData["Success"] = "New password have been sent to your email";
                return View();
            }
            return View();
        }





        //Đổi mật khẩu sang md5
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
                return sb.ToString();
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