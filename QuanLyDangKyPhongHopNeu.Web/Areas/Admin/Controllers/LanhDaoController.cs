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
    public class LanhDaoController : Controller
    {
        // GET: Admin/LanhDao
        ILanhDaoRepository _lanhDaoRepository;
        IUnitOfWork _unitOfWork;

        public LanhDaoController(ILanhDaoRepository lanhdaoRepository, IUnitOfWork unitOfWork)
        {
            _lanhDaoRepository = lanhdaoRepository;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var model = _lanhDaoRepository.GetAll();
            return Json(new
            {
                status = true,
                data = model,
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult LoadAllKhuNha()
        {
            var model = _lanhDaoRepository.GetAll();
            return Json(new
            {
                status = true,
                data = model
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult LoadData(int page, int pageSize, int loaiphong = 0, int khunha = 0)
        {
            var model = _lanhDaoRepository.GetAll();
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
            var model = _lanhDaoRepository.GetSingleById(id);

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
            LanhDao lanhDao = serializer.Deserialize<LanhDao>(model);
            bool status = false;
            string message = string.Empty;
            if (lanhDao.ID == 0)
            {
                try
                {
                    _lanhDaoRepository.Add(lanhDao);
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
                var entity = _lanhDaoRepository.GetSingleById(lanhDao.ID);
                try
                {
                    entity.HoTen = lanhDao.HoTen;
                    entity.Email = lanhDao.Email;
                    entity.ChucVu = lanhDao.ChucVu;
                    entity.DonViCongTac = lanhDao.DonViCongTac;
                    _lanhDaoRepository.Update(entity);
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
                _lanhDaoRepository.Delete(id);
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