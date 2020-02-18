using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QuanLyDangKyPhongHopNeu.Model;
using QuanLyDangKyPhongHopNeu.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Controllers
{
    public class QuanLyUserController : MasterBaseController
    {
        QuanLyDangKyPhongHopNeuDbContext _context = new QuanLyDangKyPhongHopNeuDbContext();
        // GET: Admin/QuanLyUser
        public ActionResult Index()
        {
            IEnumerable<ApplicationUser> model = _context.Users.AsEnumerable();
            return View(model);
        }
        public ActionResult Edit(string Id)
        {
            ApplicationUser model = _context.Users.Find(Id);
            return View(model);
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser( ApplicationUser user)
        {
            var model = new ApplicationUser();
            model.Email = user.Email;
            model.UserName = user.UserName;
            model.HoTen = user.HoTen;
            model.SDT = user.SDT;
            model.DiaChi = user.DiaChi;
            model.EmailConfirmed = true;
            if (ModelState.IsValid)
            {
                
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new QuanLyDangKyPhongHopNeuDbContext()));
                manager.Create(model, user.PasswordHash);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Có lỗi xảy ra trong quá trình tạo User, vui lòng thử lại!");
            }
           
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser model)
        {
            try
            {
                _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
        public ActionResult EditRole(string Id)
        {
            ApplicationUser model = _context.Users.Find(Id);
            ViewBag.RoleId = new SelectList(_context.Roles.ToList().Where(item => model.Roles.FirstOrDefault(r => r.RoleId == item.Id) == null).ToList(), "Id", "Name");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToRole(string UserId, string[] RoleId)
        {
            ApplicationUser model = _context.Users.Find(UserId);
            if (RoleId != null && RoleId.Count() > 0)
            {
                foreach (string item in RoleId)
                {
                    IdentityRole role = _context.Roles.Find(RoleId);
                    model.Roles.Add(new IdentityUserRole() { UserId = UserId, RoleId = item });
                }
                _context.SaveChanges();
            }

            ViewBag.RoleId = new SelectList(_context.Roles.ToList().Where(item => model.Roles.FirstOrDefault(r => r.RoleId == item.Id) == null).ToList(), "Id", "Name");
            return RedirectToAction("EditRole", new { Id = UserId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleFromUser(string UserId, string RoleId)
        {
            ApplicationUser model = _context.Users.Find(UserId);
            model.Roles.Remove(model.Roles.Single(m => m.RoleId == RoleId));
            _context.SaveChanges();
            ViewBag.RoleId = new SelectList(_context.Roles.ToList().Where(item => model.Roles.FirstOrDefault(r => r.RoleId == item.Id) == null).ToList(), "Id", "Name");
            return RedirectToAction("EditRole", new { Id = UserId });
        }
        public ActionResult Delete(string Id)
        {
            var model = _context.Users.Find(Id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string Id)
        {
            ApplicationUser model = null;
            try
            {
                model = _context.Users.Find(Id);
                _context.Users.Remove(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Delete", model);
            }
        }
    }
}