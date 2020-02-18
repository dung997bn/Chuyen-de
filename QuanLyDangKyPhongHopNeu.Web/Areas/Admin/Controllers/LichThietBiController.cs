using QuanLyDangKyPhongHopNeu.Data.Infrastructure;
using QuanLyDangKyPhongHopNeu.Data.Repository;
using QuanLyDangKyPhongHopNeu.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class LichThietBiController : Controller
    {
        ILichThietBiRepository _lichThietBiRepository;
        IUnitOfWork _unitOfWork;

        public LichThietBiController(ILichThietBiRepository lichThietBiRepository, IUnitOfWork unitOfWork)
        {
            _lichThietBiRepository = lichThietBiRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/LichThietBi
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult TaoMoi(string entity)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            LichThietBi lichThietBi = serializer.Deserialize<LichThietBi>(entity);
            try
            {
                _lichThietBiRepository.Add(lichThietBi);
                _unitOfWork.Commit();
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    status = false
                });
            }
        }

        [HttpGet]
        public JsonResult LoadData(int page, int pageSize)
        {
            var model = _lichThietBiRepository.LoadAllLichThietBi();
            int totalRow = model.Count();
            var query = model.Skip((page - 1) * pageSize).Take(pageSize);
            return Json(new
            {
                status = true,
                data = query,
                total = totalRow
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ThayDoiTrangThai(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            LichThietBi lichThietBi = serializer.Deserialize<LichThietBi>(model);
            var entity = _lichThietBiRepository.GetSingleById(lichThietBi.ID);
            try
            {
                entity.TinhTrang = lichThietBi.TinhTrang;
                _lichThietBiRepository.Update(entity);
                _unitOfWork.Commit();
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    status = false
                });
            }
        }

    }
}