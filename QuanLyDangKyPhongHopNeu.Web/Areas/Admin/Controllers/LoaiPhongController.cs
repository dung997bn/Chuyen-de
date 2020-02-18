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
    public class LoaiPhongController : Controller
    {
        ILoaiPhongRepository _loaiPhongRepository;
        IUnitOfWork _unitOfWork;

        public LoaiPhongController(ILoaiPhongRepository loaiPhongRepository, IUnitOfWork unitOfWork)
        {
            _loaiPhongRepository = loaiPhongRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/LoaiPhong
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var model = _loaiPhongRepository.GetAll();
            return Json(new
            {
                status = true,
                data = model,
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadData(int page, int pageSize, int loaiphong = 0, int khunha = 0)
        {
            var model = _loaiPhongRepository.GetAll();
            int totalRow = model.Count();
            var responseData = model.OrderBy(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize);
            return Json(new
            {
                status = true,
                data = responseData,
                total = totalRow
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetById(int id)
        {
            var model = _loaiPhongRepository.GetSingleById(id);

            return Json(new
            {
                status = true,
                data = model
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveData(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            LoaiPhong loaiPhong = serializer.Deserialize<LoaiPhong>(model);
            bool status = false;
            string message = string.Empty;
            if (loaiPhong.ID == 0)
            {
                try
                {
                    _loaiPhongRepository.Add(loaiPhong);
                    _unitOfWork.Commit();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                    message = ex.Message;
                }
            }
            else
            {
                var entity = _loaiPhongRepository.GetSingleById(loaiPhong.ID);
                try
                {
                    entity.TenLoaiPhong = loaiPhong.TenLoaiPhong;
                    _loaiPhongRepository.Update(entity);
                    _unitOfWork.Commit();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                    message = ex.Message;
                }
            }
            return Json(new
            {
                status = status,
                message = message
            });
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                _loaiPhongRepository.Delete(id);
                _unitOfWork.Commit();
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}