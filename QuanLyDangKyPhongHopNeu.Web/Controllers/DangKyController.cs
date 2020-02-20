using QuanLyDangKyPhongHopNeu.Data.Repository;
using QuanLyDangKyPhongHopNeu.Model;
using QuanLyDangKyPhongHopNeu.Model.Models;
using QuanLyDangKyPhongHopNeu.Web.Common;
using QuanLyDangKyPhongHopNeu.Web.Models.DangKyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web.Controllers
{
    [Authorize]
    public class DangKyController : Controller
    {
        private readonly QuanLyDangKyPhongHopNeuDbContext _dbContext = new QuanLyDangKyPhongHopNeuDbContext();
        private IDangKyPhongHopRepository _dangKyPhongHopRepository;
        private IKhuNhaRepository _khuNhaRepository;
        private IPhongRepository _phongRepository;
        private ILoaiPhongRepository _loaiPhongRepository;
        private ILanhDaoRepository _lanhDaoRepository;
        private List<DateTime> ListDateDangKyRepeat = new List<DateTime>();
        private IMailRepository _mailRepository;
        public DangKyController(IDangKyPhongHopRepository dangKyPhongHopRepository)
        {
            _dangKyPhongHopRepository = dangKyPhongHopRepository;
        }
        public DangKyController()
        {
            _dangKyPhongHopRepository = new DangKyPhongHopRepository();
        }

        public DangKyController(IDangKyPhongHopRepository dangKyPhongHopRepository, ILanhDaoRepository lanhDaoRepository, IPhongRepository phongRepository,
            IKhuNhaRepository khuNhaRepository, IMailRepository mailRepository, ILoaiPhongRepository loaiPhongRepository) : this(dangKyPhongHopRepository)
        {
            _khuNhaRepository = khuNhaRepository;
            _loaiPhongRepository = loaiPhongRepository;
            _phongRepository = phongRepository;
            _mailRepository = mailRepository;
            _lanhDaoRepository = lanhDaoRepository;
        }
        // GET: DangKy
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKyTheoNgay(int IdKhuNha = 0, int IdLoaiPhong = 0, DateTime? date = null)
        {
            if (date == null)
            {
                date = DateTime.Today;
            }
            var dangKyPhongHopRepository = new DangKyPhongHopRepository();
            var quanLyDangKy = new QuanLyDangKy(dangKyPhongHopRepository);
            return View(quanLyDangKy.GetDangKyTheoNgay(IdKhuNha, IdLoaiPhong, date.Value));
        }
        public ActionResult DangKyTheoTuan(int IdKhuNha = 0, int IdLoaiPhong = 0, DateTime? date = null)
        {
            if (date == null)
            {
                date = DateTime.Today.AddDays(-(((int)DateTime.Today.DayOfWeek) + 6) % 7);
            }
            var dangKyPhongHopRepository = new DangKyPhongHopRepository();
            var quanLyDangKy = new QuanLyDangKy(dangKyPhongHopRepository);
            return View(quanLyDangKy.GetDangKyTheoTuan(IdKhuNha, IdLoaiPhong, date.Value));
        }

        [HttpGet]
        public ActionResult DangKy(DateTime ngayDangKy, DateTime batDau, string tenPhong)
        {
            var dangKyPhongHopRepository = new DangKyPhongHopRepository();
            var quanLyDangKy = new QuanLyDangKy(dangKyPhongHopRepository);
            return View(quanLyDangKy.GetDuLieuChoFormDangKy(ngayDangKy, batDau, tenPhong));
        }

        public ActionResult DangKyThatBai()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(LichDangKyModels model)
        {
            if (model.NgayDangKy.Date < DateTime.Now.Date.AddDays(1))
            {
                return RedirectToAction("DangKyThatBai");
            }
            if (Request.IsAuthenticated)
            {
                var Ten = ((User.Identity as System.Security.Claims.ClaimsIdentity)?.FindFirst("name")?.Value);
                var Email = ((User.Identity as System.Security.Claims.ClaimsIdentity)?.FindFirst("preferred_username")?.Value);
                if (ModelState.IsValid)
                {
                    MailHelper mailHelper = new MailHelper();
                    var lichDangKy = new LichDangKy();
                    lichDangKy.TieuDe = model.TieuDe;
                    lichDangKy.IDPhong = int.Parse(model.Phong);
                    lichDangKy.ThoiGianBatDau = model.NgayDangKy.AddHours(double.Parse(model.ThoiGianBatDau));
                    lichDangKy.ThoiGianKetThuc = model.NgayDangKy.AddHours(double.Parse(model.ThoiGianKetThuc));
                    lichDangKy.NgayDangKy = model.NgayDangKy;
                    lichDangKy.SoDienThoai = model.SoDienThoai;
                    lichDangKy.TinhTrang = "Đang chờ xử lý";
                    lichDangKy.TenNguoiDangKy = Ten;
                    lichDangKy.Email = Email;
                    lichDangKy.ThanhPhan = model.ThanhPhan;
                    lichDangKy.NoiDungCuocHop = model.NoiDungCuocHop;

                    var quanLyDangKy = new QuanLyDangKy(_dangKyPhongHopRepository);
                    lichDangKy.IdLanhDao = int.Parse(model.IdLanhDao);

                    try
                    {
                        _dangKyPhongHopRepository.InsertLichDangKy(lichDangKy);
                        _dangKyPhongHopRepository.Save();

                        var mail = _mailRepository.GetAll();
                        var fromAdmin = mail.Where(x => x.ValueOfMail == 0);

                        //Gửi mail tới người đăng ký
                        var Phong = _phongRepository.GetAll().Where(x => x.ID == lichDangKy.IDPhong);
                        string contentToUser = System.IO.File.ReadAllText(Server.MapPath("/Assets/Home/MailStructure/" + fromAdmin.First().TenMail));
                        contentToUser = contentToUser.Replace("{{Name}}", lichDangKy.TenNguoiDangKy);
                        contentToUser = contentToUser.Replace("{{Email}}", lichDangKy.Email);
                        contentToUser = contentToUser.Replace("{{Room}}", Phong.First().TenPhong);
                        contentToUser = contentToUser.Replace("{{ThoiGian}}", lichDangKy.ThoiGianBatDau.ToShortTimeString() + "-" + lichDangKy.ThoiGianKetThuc.ToShortTimeString());
                        contentToUser = contentToUser.Replace("{{NgayDangKy}}", lichDangKy.NgayDangKy.ToShortDateString());
                        contentToUser = contentToUser.Replace("{{TinhTrang}}", lichDangKy.TinhTrang);
                        //Extra
                        contentToUser = contentToUser.Replace("{{NoiDungCuocHop}}", lichDangKy.NoiDungCuocHop);
                        contentToUser = contentToUser.Replace("{{GhiChu}}", lichDangKy.TieuDe);
                        contentToUser = contentToUser.Replace("{{ThanhPhan}}", lichDangKy.ThanhPhan);
                        contentToUser = contentToUser.Replace("{{TinhTrang}}", lichDangKy.TinhTrang);
                        contentToUser = contentToUser.Replace("{{DonViCongTac}}", model.DonViCongTac);
                        mailHelper.SendMail(lichDangKy.Email, "NEU", contentToUser);

                        //Gửi mail tới quản trị
                        var toAdmin = mail.Where(x => x.ValueOfMail == 4);
                        string contentToAdmin = System.IO.File.ReadAllText(Server.MapPath("/Assets/Home/MailStructure/" + toAdmin.First().TenMail));
                        string CurrentLink = GetConfig.GetByKey("CurrentLink");
                        string AdminEmail = GetConfig.GetByKey("AdminEmail");
                        contentToAdmin = contentToAdmin.Replace("{{CurrentLink}}", CurrentLink.ToString());
                        mailHelper.SendMail(AdminEmail, "NEU", contentToAdmin);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                    TempData["LichDangKy"] = lichDangKy;
                }
                else
                {
                    ModelState.AddModelError("", "Bạn cần nhập đầy đủ thông tin");
                    return View(model);
                }
            }
            return RedirectToAction("DangKyThemThietBi", "DangKy");
        }
        [HttpGet]
        public ActionResult DangKyThemThietBi()
        {
            var lich = TempData["LichDangKy"] as LichDangKy;
            return View(lich);
        }
        [HttpGet]
        public JsonResult GetDropDownListData()
        {
            var khuNha = _khuNhaRepository.GetAll();
            var loaiPhong = _loaiPhongRepository.GetAll();
            return Json(new
            {
                status = true,
                KhuNha = khuNha,
                LoaiPhong = loaiPhong
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLanhDao()
        {
            var lanhDaoList = _lanhDaoRepository.GetAll();
            return Json(new
            {
                lanhDaoList,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetLanhDaoByEmail(string Email)
        {
            var lanhDaoByEmail = _lanhDaoRepository.GetByEmail(Email);
            return Json(new
            {
                lanhDaoByEmail,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetInfoLichDangKyByID(int id)
        {
            var data = _dbContext.LichDangKies.Include("Phong").Include("LanhDao").SingleOrDefault(x => x.ID == id);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetNameByEmail(string email)
        {
            string[] parts = email.Split(',');
            List<string> listMail = new List<string>();
            for (int j = 0; j < parts.Length; j++)
            {
                var item = parts[j].Split('(');
                if (item[1].Contains(")"))
                {
                    item[1] = item[1].Replace(")", "");
                }
                listMail.Add(item[1]);
            }

            List<string> data = new List<string>();
            foreach (var item in listMail)
            {
                var lanhDao = _dbContext.LanhDaos.SingleOrDefault(x => x.Email == item);
                if (lanhDao != null)
                {
                    var name = lanhDao.HoTen;
                    data.Add(name);
                }
            }

            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetKhuNhaByIdPhong(int id)
        {
            var data = _dbContext.Phongs.Include("KhuNha").FirstOrDefault(x => x.ID == id);

            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}