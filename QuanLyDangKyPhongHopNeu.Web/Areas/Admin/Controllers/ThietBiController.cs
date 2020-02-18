using QuanLyDangKyPhongHopNeu.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Controllers
{
    public class ThietBiController : Controller
    {
        IThietBiRepository _thietBiRepository;

        public ThietBiController(IThietBiRepository thietBiRepository)
        {
            _thietBiRepository = thietBiRepository;
        }
        // GET: Admin/ThietBi
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var model = _thietBiRepository.GetAll();
            return Json(new
            {
                status = true,
                data = model
            }, JsonRequestBehavior.AllowGet);
        }
    }
}