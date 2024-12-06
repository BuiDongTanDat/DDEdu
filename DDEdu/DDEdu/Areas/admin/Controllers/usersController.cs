using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using DDEdu.Models;

namespace DDEdu.Areas.admin.Controllers
{
    public class usersController : Controller
    {
        private DDEdu_DB db = new DDEdu_DB();

        // GET: admin/users
        public ActionResult Index()
        {
            //Ẩn đi account admin mặc định duy nhất trong hệ thống
            var userList = db.users.Where(u => u.hide == true).ToList();
            return View(userList);
        }

        // GET: admin/users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: admin/users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "username,password,fullname,email,birth,isAdmin,isActive, dateBegin")] user user)
        {

            if (ModelState.IsValid)
            {
                if (db.users.Any(u => u.username.ToLower() == user.username.ToLower()))
                {
                    ModelState.AddModelError("username", "Username already exists.");
                    return View(user);
                }
                if (user.password.Length < 6)
                {
                    ModelState.AddModelError("password", "Password must be at least 6 character.");
                    return View(user);
                }
                if (db.users.Any(u => u.email.ToLower() == user.email.ToLower()))
                {
                    ModelState.AddModelError("email", "Email address already exists.");
                    return View(user);
                }
                user.password = MD5Hash(user.password);
                user.dateBegin = DateTime.Now;
                user.meta = "user";
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: admin/users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: admin/users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id, username,password,fullname,email,birth,isAdmin,isActive,dateBegin")] user user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.users.Find(user.id);
                if (existingUser == null)
                {
                    return HttpNotFound();
                }
                if (db.users.Any(u => u.username.ToLower() == user.username.ToLower() && u.id != user.id))
                {
                    ModelState.AddModelError("username", "Username already exists.");
                    return View(user);
                }

                if (user.password!=null && user.password.Length<6)
                {
                    ModelState.AddModelError("password", "Password must be at least 6 character.");
                    return View(user);
                }
                if (db.users.Any(u => u.email.ToLower() == user.email.ToLower() && u.id != user.id))
                {
                    ModelState.AddModelError("email", "Email address already exists.");
                    return View(user);
                }
                if (user.password == null)
                {
                    user.password = existingUser.password;
                }
                else
                {
                    user.password = MD5Hash(user.password);
                }
                existingUser.username = user.username;
                existingUser.fullname = user.fullname;
                existingUser.password = user.password;
                existingUser.email = user.email;
                existingUser.birth = user.birth;
                existingUser.isAdmin = user.isAdmin;
                existingUser.isActive = user.isActive;
                existingUser.dateBegin = DateTime.Now;

                // Kiểm tra nếu mật khẩu mới được cung cấp, mã hóa nó
                if (!string.IsNullOrEmpty(user.password) && user.password != existingUser.password)
                {
                    existingUser.password = MD5Hash(user.password);
                }

                db.Entry(existingUser).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
           }

        // GET: admin/users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: admin/users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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

        public ActionResult getUserByType(int? id)
        {
            IEnumerable<user> result;

            if (id == 1)
            {
                result = db.users.Where(t => t.hide == true && t.isAdmin == false);
            }
            else if (id == 2)
            {
                result = db.users.Where(t => t.hide == true && t.isAdmin == true);
            }
            else
            {
                result = db.users.Where(t => t.hide == true);
            }

            ViewBag.meta = "users";
            return PartialView(result.ToList());
        }

    }
}
