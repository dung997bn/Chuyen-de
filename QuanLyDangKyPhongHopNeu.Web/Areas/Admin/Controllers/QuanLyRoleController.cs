using Microsoft.AspNet.Identity.EntityFramework;
using QuanLyDangKyPhongHopNeu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Controllers
{
    public class QuanLyRoleController : MasterBaseController
    {
        QuanLyDangKyPhongHopNeuDbContext _context = new QuanLyDangKyPhongHopNeuDbContext();
        // GET: Admin/QuanLyRole
        public ActionResult Index()
        {
            var model = _context.Roles.AsEnumerable();
            return View(model);
        }
        public ViewResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Roles.Add(role);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(role);
        }
        public ActionResult Delete(string Id)
        {
            var model = _context.Roles.Find(Id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string Id)
        {
            IdentityRole model = null;
            try
            {
                model = _context.Roles.Find(Id);

                _context.Roles.Remove(model);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }
    }
}
