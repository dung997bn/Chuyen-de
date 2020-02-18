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
    public class PhongController : Controller
    {
        IPhongRepository _phongRepository;
        IKhuNhaRepository _khuNhaRepository;
        ILoaiPhongRepository _loaiPhongRepository;
        IUnitOfWork _unitOfWork;

        public PhongController(IPhongRepository phongRepository, IKhuNhaRepository khuNhaRepository,
            ILoaiPhongRepository loaiPhongRepository, IUnitOfWork unitOfWork)
        {
            _phongRepository = phongRepository;
            _khuNhaRepository = khuNhaRepository;
            _loaiPhongRepository = loaiPhongRepository;
            _unitOfWork = unitOfWork;
        }


        // GET: Admin/Phong
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var model = _phongRepository.GetAll();
            return Json(new
            {
                status = true,
                data = model,
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadAllLoaiPhong()
        {
            var model = _loaiPhongRepository.GetAll();
            return Json(new
            {
                status = true,
                data = model
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetLoaiPhongByID(int id)
        {
            var model = _loaiPhongRepository.GetSingleById(id);

            return Json(new
            {
                status = true,
                data = model
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetKhuNhaByID(int id)
        {
            var model = _khuNhaRepository.GetSingleById(id);

            return Json(new
            {
                status = true,
                data = model
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult LoadAllKhuNha()
        {
            var model = _khuNhaRepository.GetAll();
            return Json(new
            {
                status = true,
                data = model
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult LoadData(int page, int pageSize, int loaiphong = 0, int khunha = 0)
        {
            string[] week = new string[2];
            week[0] = "KhuNha";
            week[1] = "LoaiPhong";
            var model = _phongRepository.GetAll(week);
            if (loaiphong != 0)
            {
                model = model.Where(x => x.IDLoaiPhong == loaiphong);
            }
            if (khunha != 0)
            {
                model = model.Where(x => x.IDKhuNha == khunha);
            }
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
            var model = _phongRepository.GetSingleById(id);

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
            Phong phong = serializer.Deserialize<Phong>(model);
            bool status = false;
            string message = string.Empty;
            if (phong.ID == 0)
            {
                try
                {
                    _phongRepository.Add(phong);
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
                var entity = _phongRepository.GetSingleById(phong.ID);
                try
                {
                    entity.TenPhong = phong.TenPhong;
                    entity.IDKhuNha = phong.IDKhuNha;
                    entity.IDLoaiPhong = phong.IDLoaiPhong;
                    _phongRepository.Update(entity);
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
                _phongRepository.Delete(id);
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