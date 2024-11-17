using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDEdu.Helper;
using DDEdu.Models;

namespace DDEdu.Areas.admin.Controllers
{
    public class slidesController : Controller
    {
        private DDEdu_DB db = new DDEdu_DB();

        // GET: admin/slides
        public ActionResult Index()
        {
            return View(db.slides.ToList());
        }

        // GET: admin/slides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slide slide = db.slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // GET: admin/slides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/slides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hide,order,datebegin")] slide slide, HttpPostedFileBase img)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Kiểm tra nếu có file ảnh được upload
                    if (img != null && img.ContentLength > 0)
                    {
                        // Tạo tên file mới với timestamp để lưu trên server
                        var timestamp = DateTime.Now.ToString("dd-MM-yy-HH-mm-ss-");
                        var filename = timestamp + Path.GetFileName(img.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/upload/img/slide"), filename);

                        // Lưu file ảnh vào server
                        img.SaveAs(path);
                        slide.name = Path.GetFileName(path);
                        slide.nameI = Path.GetFileName(img.FileName);
                    }
                    else
                    {
                        slide.name = "logo.png"; // Nếu không có ảnh, sử dụng ảnh mặc định
                    }

                    slide.datebegin = DateTime.Now;
                    db.slides.Add(slide);
                    db.SaveChanges();

                    return RedirectToAction("Index"); // Chuyển hướng về trang chỉ mục
                }
            }
            catch (DbEntityValidationException e)
            {
                // Xử lý ngoại lệ nếu có lỗi xác thực
                ModelState.AddModelError("", "Lỗi xác thực. Vui lòng kiểm tra thông tin.");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ chung
                ModelState.AddModelError("", "Có lỗi xảy ra. Vui lòng thử lại.");
            }

            // Trả về view nếu có lỗi
            return View(slide);
        }

        // GET: admin/slides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slide slide = db.slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: admin/slides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,hide,order,datebegin")] slide slide, HttpPostedFileBase img)
        {
            try
            {
                slide temp = getById(slide.id); // Lấy đối tượng slide từ cơ sở dữ liệu bằng ID
                if (ModelState.IsValid)
                {
                    if (img != null && img.ContentLength > 0) // Kiểm tra nếu có file ảnh được upload
                    {
                        // Tạo tên file duy nhất với timestamp
                        var filename = DateTime.Now.ToString("dd-MM-yy-HH-mm-ss-") + Path.GetFileName(img.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/upload/img/slide"), filename);

                        // Lưu file ảnh vào server
                        img.SaveAs(path);

                        // Cập nhật thuộc tính name và nameI
                        temp.name = Path.GetFileName(path);
                        temp.nameI = Path.GetFileName(img.FileName); // Tên gốc của file ảnh
                    }

                    // Cập nhật các thuộc tính khác của slide
                    temp.hide = slide.hide;
                    temp.order = slide.order;
                    temp.datebegin = DateTime.Now;

                    // Đánh dấu đối tượng là đã chỉnh sửa
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index"); // Chuyển hướng về trang chỉ mục sau khi lưu thay đổi
                }
            }
            catch (DbEntityValidationException e)
            {
                ModelState.AddModelError("", "Lỗi xác thực dữ liệu. Vui lòng kiểm tra lại thông tin.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra. Vui lòng thử lại.");
            }

            // Trả về view nếu có lỗi
            return View(slide);
        }


        public slide getById(int id)
        {
            return db.slides.Find(id);
        }

        // GET: admin/slides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slide slide = db.slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: admin/slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            slide slide = db.slides.Find(id);
            db.slides.Remove(slide);
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
    }
}
