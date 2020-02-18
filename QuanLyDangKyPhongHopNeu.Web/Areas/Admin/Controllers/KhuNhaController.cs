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
    public class KhuNhaController : Controller
    {
        // GET: Admin/KhuNha
        IKhuNhaRepository _khuNhaRepository;
        IUnitOfWork _unitOfWork;

        public KhuNhaController(IKhuNhaRepository khuNhaRepository, IUnitOfWork unitOfWork)
        {
            _khuNhaRepository = khuNhaRepository;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var model = _khuNhaRepository.GetAll();
            return Json(new
            {
                status = true,
                data = model,
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
            var model = _khuNhaRepository.GetAll();
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
            var model = _khuNhaRepository.GetSingleById(id);

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
            KhuNha khuNha = serializer.Deserialize<KhuNha>(model);
            bool status = false;
            string message = string.Empty;
            if (khuNha.ID == 0)
            {
                try
                {
                    _khuNhaRepository.Add(khuNha);
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
                var entity = _khuNhaRepository.GetSingleById(khuNha.ID);
                try
                {
                    entity.TenKhuNha = khuNha.TenKhuNha;
                    _khuNhaRepository.Update(entity);
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
                _khuNhaRepository.Delete(id);
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