using QuanLyDangKyPhongHopNeu.Data.Infrastructure;
using QuanLyDangKyPhongHopNeu.Data.Repository;
using QuanLyDangKyPhongHopNeu.Model.Models;
using QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Models;
using QuanLyDangKyPhongHopNeu.Web.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Controllers
{
    public class QuanLyDangKyController : MasterBaseController
    {
        private IDangKyPhongHopRepository _dangKyPhongHopRepository;
        private IKhuNhaRepository _khuNhaRepository;
        private IPhongRepository _phongRepository;
        private ILoaiPhongRepository _loaiPhongRepository;
        private ILanhDaoRepository _lanhDaoRepository;
        private IMailRepository _mailRepository;

        ILichDangKyRepository _lichDangKyRepository;
        IUnitOfWork _unitOfWork;

        public QuanLyDangKyController(IDangKyPhongHopRepository dangKyPhongHopRepository, IKhuNhaRepository khuNhaRepository, IPhongRepository phongRepository, ILoaiPhongRepository loaiPhongRepository,
            ILichDangKyRepository lichDangKyRepository, IMailRepository mailRepository, ILanhDaoRepository lanhDaoRepository, IUnitOfWork unitOfWork)
        {
            _dangKyPhongHopRepository = dangKyPhongHopRepository;
            _khuNhaRepository = khuNhaRepository;
            _phongRepository = phongRepository;
            _lanhDaoRepository = lanhDaoRepository;
            _loaiPhongRepository = loaiPhongRepository;
            _lichDangKyRepository = lichDangKyRepository;
            _mailRepository = mailRepository;
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index(int IdKhuNha = 0, int IdLoaiPhong = 0, DateTime? date = null)
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

        //// GET: Admin/QuanLyDangKy
        public ActionResult QuanLyDangKyTheoNgay(int? idPhong, DateTime? date = null)
        {
            var phong = _phongRepository.GetAll();
            var lanhDao = _lanhDaoRepository.GetAll();
            var model = _lichDangKyRepository.GetAllLichDangKy(idPhong, date);
            var HienThiLichDangKy = new HienThiLichDangKy();
            HienThiLichDangKy.LichDangKy = model;
            HienThiLichDangKy.Phong = phong;
            HienThiLichDangKy.LanhDaos = lanhDao;
            TempData["NgayDangKy"] = date;
            return View(HienThiLichDangKy);
        }
        [HttpGet]
        public JsonResult GetByID(int id)
        {
            var data = _lichDangKyRepository.GetSingleById(id);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DuyetLichDangKy(int Id)
        {
            var entity = _lichDangKyRepository.GetSingleById(Id);
            var mail = _mailRepository.GetAll();
            try
            {
                entity.TinhTrang = "Đã chấp nhận";
                _lichDangKyRepository.Update(entity);
                _unitOfWork.Commit();

                MailHelper mailHelper = new MailHelper();
                var Phong = _phongRepository.GetAll().Where(x => x.ID == entity.IDPhong);
                //Gửi mail đăng ký thành công
                var fromAdmin = mail.Where(x => x.ValueOfMail == 1);
                string contentfromAdmin = System.IO.File.ReadAllText(Server.MapPath("/Assets/Home/MailStructure/" + fromAdmin.First().TenMail));
                contentfromAdmin = contentfromAdmin.Replace("{{Name}}", entity.TenNguoiDangKy);
                contentfromAdmin = contentfromAdmin.Replace("{{Email}}", entity.Email);
                contentfromAdmin = contentfromAdmin.Replace("{{Room}}", Phong.First().TenPhong);
                contentfromAdmin = contentfromAdmin.Replace("{{ThoiGian}}", entity.ThoiGianBatDau.ToShortTimeString() + "-" + entity.ThoiGianKetThuc.ToShortTimeString());
                contentfromAdmin = contentfromAdmin.Replace("{{NgayDangKy}}", entity.NgayDangKy.ToShortDateString());
                //Extra
                contentfromAdmin = contentfromAdmin.Replace("{{NoiDungCuocHop}}", entity.NoiDungCuocHop);
                contentfromAdmin = contentfromAdmin.Replace("{{SoDienThoai}}", entity.SoDienThoai);
                contentfromAdmin = contentfromAdmin.Replace("{{TieuDe}}", entity.TieuDe);
                contentfromAdmin = contentfromAdmin.Replace("{{ThanhPhan}}", entity.ThanhPhan);
                contentfromAdmin = contentfromAdmin.Replace("{{TinhTrang}}", entity.TinhTrang);

                mailHelper.SendMail(entity.Email, "NEU", contentfromAdmin);

                if (!string.IsNullOrEmpty(entity.ThanhPhan))
                {
                    string[] thanhPhan = entity.ThanhPhan.Split(',');
                    var toMember = mail.Where(x => x.ValueOfMail == 5);
                    List<string> listMail = new List<string>();
                    for (int j = 0; j < thanhPhan.Length; j++)
                    {
                        var item = thanhPhan[j].Split('(');
                        if (item != null && item.Count() > 1)
                        {
                            if (item[1].Contains(")"))
                            {
                                item[1] = item[1].Replace(")", "");
                            }
                            listMail.Add(item[1]);
                        }
                    }
                    foreach (var mailItem in listMail)
                    {
                        string contentToMember = System.IO.File.ReadAllText(Server.MapPath("/Assets/Home/MailStructure/" + toMember.First().TenMail));
                        contentToMember = contentToMember.Replace("{{Name}}", entity.TenNguoiDangKy);
                        contentToMember = contentToMember.Replace("{{EmailMember}}", mailItem);
                        contentToMember = contentToMember.Replace("{{Email}}", entity.Email);
                        contentToMember = contentToMember.Replace("{{Room}}", Phong.First().TenPhong);
                        contentToMember = contentToMember.Replace("{{ThoiGian}}", entity.ThoiGianBatDau.ToShortTimeString() + "-" + entity.ThoiGianKetThuc.ToShortTimeString());
                        contentToMember = contentToMember.Replace("{{NgayDangKy}}", entity.NgayDangKy.ToShortDateString());
                        contentToMember = contentToMember.Replace("{{NoiDungCuocHop}}", entity.NoiDungCuocHop);
                        contentToMember = contentToMember.Replace("{{SoDienThoai}}", entity.SoDienThoai);
                        contentToMember = contentToMember.Replace("{{TieuDe}}", entity.TieuDe);
                        contentToMember = contentToMember.Replace("{{ThanhPhan}}", entity.ThanhPhan);
                        contentToMember = contentToMember.Replace("{{TinhTrang}}", entity.TinhTrang);

                        mailHelper.SendMail(mailItem, "NEU", contentToMember);
                    }
                }
                return View(entity);
            }
            catch (Exception ex)
            {
                return View(entity);
            }
        }
        [HttpGet]
        public ActionResult ChuyenLich(int IdPhong, int Id)
        {
            var model = GetDuLieuChuyenPhong(IdPhong, Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult ChuyenLich(ChuyenPhong chuyenPhong)
        {
            MailHelper mailHelper = new MailHelper();
            var entity = _lichDangKyRepository.GetSingleById(chuyenPhong.ID);
            var phongCu = chuyenPhong.PhongCu;
            if (_lichDangKyRepository.CheckOverlap(entity.ThoiGianBatDau, entity.ThoiGianKetThuc, chuyenPhong.IdPhongMoi))
            {
                return RedirectToAction("ChuyenLichThatBai");
            }
            else
            {
                var mail = _mailRepository.GetAll();
                try
                {
                    entity.IDPhong = int.Parse(chuyenPhong.TenPhong);
                    entity.IdLanhDao = int.Parse(chuyenPhong.IdLanhDao);
                    entity.ThanhPhan = chuyenPhong.ThanhPhan;
                    entity.NgayDangKy = chuyenPhong.NgayDangKy;
                    entity.ThoiGianBatDau = chuyenPhong.NgayDangKy.AddHours(double.Parse(chuyenPhong.ThoiGianBatDau));
                    entity.ThoiGianKetThuc = chuyenPhong.NgayDangKy.AddHours(double.Parse(chuyenPhong.ThoiGianKetThuc));
                    entity.NoiDungCuocHop = chuyenPhong.NoiDungCuocHop;
                    entity.TenNguoiDangKy = chuyenPhong.TenNguoiDangKy;
                    entity.Email = chuyenPhong.Email;
                    entity.TieuDe = chuyenPhong.TieuDe;
                    entity.TinhTrang = "Đã chuyển";
                    _lichDangKyRepository.Update(entity);
                    _unitOfWork.Commit();

                    var changeRoom = mail.Where(x => x.ValueOfMail == 2);
                    //Gửi mail đã chuyển phòng
                    int phongThayThe = int.Parse(chuyenPhong.TenPhong);
                    var PhongDangKy = _phongRepository.GetAll().Where(x => x.ID == phongCu);
                    var PhongChuyen = _phongRepository.GetAll().Where(x => x.ID == phongThayThe);
                    string contentChangeRoom = System.IO.File.ReadAllText(Server.MapPath("/Assets/Home/MailStructure/" + changeRoom.First().TenMail));
                    contentChangeRoom = contentChangeRoom.Replace("{{Name}}", entity.TenNguoiDangKy);
                    contentChangeRoom = contentChangeRoom.Replace("{{PhongDangKy}}", PhongDangKy.First().TenPhong);
                    contentChangeRoom = contentChangeRoom.Replace("{{PhongChuyen}}", PhongChuyen.First().TenPhong);
                    //Extra
                    contentChangeRoom = contentChangeRoom.Replace("{{Email}}", entity.Email);
                    contentChangeRoom = contentChangeRoom.Replace("{{ThoiGian}}", entity.ThoiGianBatDau + "h-" + entity.ThoiGianKetThuc + "h");
                    contentChangeRoom = contentChangeRoom.Replace("{{NgayDangKy}}", entity.NgayDangKy.ToShortDateString());
                    contentChangeRoom = contentChangeRoom.Replace("{{NoiDungCuocHop}}", entity.NoiDungCuocHop);
                    contentChangeRoom = contentChangeRoom.Replace("{{SoDienThoai}}", entity.SoDienThoai);
                    contentChangeRoom = contentChangeRoom.Replace("{{TieuDe}}", entity.TieuDe);
                    contentChangeRoom = contentChangeRoom.Replace("{{ThanhPhan}}", entity.ThanhPhan);
                    contentChangeRoom = contentChangeRoom.Replace("{{TinhTrang}}", entity.TinhTrang);

                    mailHelper.SendMail(entity.Email, "NEU", contentChangeRoom);
                    return RedirectToAction("ChuyenLichThanhCong");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("ChuyenLichThatBai");
                }
            }
        }
        [HttpGet]
        public JsonResult GetPhongTheoDieuKien(int khuNha, int loaiPhong)
        {
            var data = _phongRepository.GetTheoDieuKien(khuNha, loaiPhong).ToList();
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ChuyenLichThanhCong()
        {
            return View();
        }
        public ActionResult ChuyenLichThatBai()
        {
            return View();
        }
        public ChuyenPhong GetDuLieuChuyenPhong(int IdPhong, int Id)
        {

            ChuyenPhong chuyenPhong = new ChuyenPhong();
            var ldk = _lichDangKyRepository.GetSingleById(Id);
            chuyenPhong.ListThoiGianBatDau = GetDanhSachThoiGianDangKyBatDau(ldk.ThoiGianBatDau.TimeOfDay, ldk.NgayDangKy);
            chuyenPhong.ListThoiGianKetThuc = GetDanhSachThoiGianDangKyBatDau(ldk.ThoiGianKetThuc.TimeOfDay, ldk.NgayDangKy);
            chuyenPhong.ListLanhDao = GetDanhSachLanhDao(ldk.IdLanhDao);
            chuyenPhong.ThanhPhan = ldk.ThanhPhan;
            chuyenPhong.NgayDangKy = ldk.NgayDangKy;
            chuyenPhong.ListPhong = GetDanhSachChuyenPhong(IdPhong);
            chuyenPhong.ID = Id;
            chuyenPhong.IdLanhDao = ldk.IdLanhDao.ToString();
            chuyenPhong.PhongCu = IdPhong;
            chuyenPhong.IdPhongMoi = ldk.IDPhong;
            chuyenPhong.TieuDe = ldk.TieuDe;
            chuyenPhong.Email = ldk.Email;
            chuyenPhong.EmailNguoiChuTri = ldk.LanhDao.Email;
            chuyenPhong.TenNguoiChuTriCuocHop = ldk.LanhDao.HoTen;
            chuyenPhong.ChucVu = ldk.LanhDao.ChucVu;
            chuyenPhong.DonViCongTac = ldk.LanhDao.DonViCongTac;
            chuyenPhong.TenNguoiDangKy = ldk.TenNguoiDangKy;
            chuyenPhong.NoiDungCuocHop = ldk.NoiDungCuocHop;
            return chuyenPhong;
        }
        public IEnumerable<SelectListItem> GetDanhSachThoiGianDangKyBatDau(TimeSpan batDau, DateTime date)
        {
            var thoiGianDangKy = date.Date.AddHours(7).TimeOfDay;
            var listTime = new List<SelectListItem>();
            var thoiGianKetThucDangKy = TimeSpan.ParseExact(ConfigurationManager.AppSettings["EndOfDay"], @"hh\:mm", CultureInfo.CurrentCulture);
            var slotMins = TimeSpan.FromMinutes(int.Parse(ConfigurationManager.AppSettings["SlotDurationMins"]));

            for (TimeSpan i = thoiGianDangKy; i <= thoiGianKetThucDangKy; i = i.Add(slotMins))
            {
                var isSelected = (batDau.Hours.Equals(i.Hours) && (batDau.Minutes.Equals(i.Minutes)));

                listTime.Add(new SelectListItem
                {
                    Text = i.ToString(@"hh\:mm"),
                    Value = (((double)(i.Hours) + ((double)(i.Minutes) / 60)).ToString()),
                    Selected = isSelected
                });
            }

            return listTime;
        }
        public IEnumerable<SelectListItem> GetDanhSachChuyenPhong(int IdPhong)
        {
            var listPhong = new List<SelectListItem>();
            IEnumerable<Phong> phongs = _phongRepository.GetAll();
            phongs = phongs.OrderBy(x => x.TenPhong);
            foreach (var phong in phongs)
            {
                var isSelected = phong.ID.Equals(IdPhong);
                listPhong.Add(new SelectListItem
                {
                    Value = phong.ID.ToString(),
                    Text = phong.TenPhong,
                    Selected = isSelected
                });
            }
            return listPhong;
        }
        public IEnumerable<SelectListItem> GetDanhSachLanhDao(int? IdLanhDao)
        {
            var listLanhDao = new List<SelectListItem>();
            IEnumerable<LanhDao> lanhdaos = _lanhDaoRepository.GetAll();
            foreach (var lanhdao in lanhdaos)
            {
                var isSelected = lanhdao.ID.Equals(IdLanhDao);
                listLanhDao.Add(new SelectListItem
                {
                    Value = lanhdao.ID.ToString(),
                    Text = lanhdao.HoTen,
                    Selected = isSelected
                });
            }
            return listLanhDao;
        }
        public ActionResult XoaLich(int Id)
        {
            MailHelper mailHelper = new MailHelper();
            var mail = _mailRepository.GetAll();
            var entity = _lichDangKyRepository.GetSingleById(Id);
            _lichDangKyRepository.Delete(entity);
            _unitOfWork.Commit();

            //Gửi mail hủy đăng ký
            var khongChapNhan = mail.Where(x => x.ValueOfMail == 3);
            string contentNotAccept = System.IO.File.ReadAllText(Server.MapPath("/Assets/Home/MailStructure/" + khongChapNhan.First().TenMail));
            contentNotAccept = contentNotAccept.Replace("{{Name}}", entity.TenNguoiDangKy);

            //Extra
            contentNotAccept = contentNotAccept.Replace("{{Email}}", entity.Email);
            contentNotAccept = contentNotAccept.Replace("{{ThoiGian}}", entity.ThoiGianBatDau + "h-" + entity.ThoiGianKetThuc + "h");
            contentNotAccept = contentNotAccept.Replace("{{NgayDangKy}}", entity.NgayDangKy.ToShortDateString());
            contentNotAccept = contentNotAccept.Replace("{{NoiDungCuocHop}}", entity.NoiDungCuocHop);
            contentNotAccept = contentNotAccept.Replace("{{SoDienThoai}}", entity.SoDienThoai);
            contentNotAccept = contentNotAccept.Replace("{{TieuDe}}", entity.TieuDe);
            contentNotAccept = contentNotAccept.Replace("{{ThanhPhan}}", entity.ThanhPhan);
            contentNotAccept = contentNotAccept.Replace("{{TinhTrang}}", entity.TinhTrang);
            mailHelper.SendMail(entity.Email, "NEU", contentNotAccept);
            return View(entity);
        }

        #region Thêm mới
        public ActionResult ThemMoi(DateTime date, string IdPhong)
        {
            var model = GetDuLieuChoFormThemMoi(date, IdPhong);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi(ThemMoiLichDangKy dangKy)
        {
            if (dangKy.NgayDangKy.Day <= DateTime.Now.Day)
            {
                return RedirectToAction("ThemMoiKhongThanhCong");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    MailHelper mailHelper = new MailHelper();
                    var lichDangKy = new LichDangKy();
                    lichDangKy.TieuDe = dangKy.TieuDe;
                    lichDangKy.IDPhong = int.Parse(dangKy.Phong);
                    lichDangKy.ThoiGianBatDau = dangKy.NgayDangKy.AddHours(double.Parse(dangKy.ThoiGianBatDau));
                    lichDangKy.ThoiGianKetThuc = dangKy.NgayDangKy.AddHours(double.Parse(dangKy.ThoiGianKetThuc));
                    lichDangKy.NgayDangKy = dangKy.NgayDangKy;
                    lichDangKy.SoDienThoai = dangKy.SoDienThoai;
                    lichDangKy.TinhTrang = "Đã chấp nhận";
                    lichDangKy.TenNguoiDangKy = dangKy.TenNguoiDangKy;
                    lichDangKy.Email = dangKy.Email;
                    lichDangKy.ThanhPhan = dangKy.ThanhPhan;
                    lichDangKy.NoiDungCuocHop = dangKy.NoiDungCuocHop;


                    var quanLyDangKy = new QuanLyDangKy(_dangKyPhongHopRepository);
                    lichDangKy.IdLanhDao = dangKy.IdLanhDao;
                    try
                    {
                        _dangKyPhongHopRepository.InsertLichDangKy(lichDangKy);
                        _dangKyPhongHopRepository.Save();

                        var mail = _mailRepository.GetAll();
                        var fromAdmin = mail.Where(x => x.ValueOfMail == 0);
                        string contentToUser = System.IO.File.ReadAllText(Server.MapPath("/Assets/Home/MailStructure/" + fromAdmin.First().TenMail));
                        var Phong = _phongRepository.GetAll().Where(x => x.ID == lichDangKy.IDPhong);
                        //Gửi mail tới người đăng ký
                        if (IsValidEmail(lichDangKy.Email))
                        {


                            contentToUser = contentToUser.Replace("{{Name}}", lichDangKy.TenNguoiDangKy);
                            contentToUser = contentToUser.Replace("{{Email}}", lichDangKy.Email);
                            contentToUser = contentToUser.Replace("{{Room}}", Phong.First().TenPhong);
                            contentToUser = contentToUser.Replace("{{ThoiGian}}", lichDangKy.ThoiGianBatDau.ToShortTimeString() + "-" + lichDangKy.ThoiGianKetThuc.ToShortTimeString());
                            contentToUser = contentToUser.Replace("{{NgayDangKy}}", lichDangKy.NgayDangKy.ToShortDateString());
                            contentToUser = contentToUser.Replace("{{TinhTrang}}", lichDangKy.TinhTrang);
                            //Extra
                            contentToUser = contentToUser.Replace("{{NoiDungCuocHop}}", lichDangKy.NoiDungCuocHop);
                            contentToUser = contentToUser.Replace("{{SoDienThoai}}", lichDangKy.SoDienThoai);
                            contentToUser = contentToUser.Replace("{{TieuDe}}", lichDangKy.TieuDe);
                            contentToUser = contentToUser.Replace("{{ThanhPhan}}", lichDangKy.ThanhPhan);
                            contentToUser = contentToUser.Replace("{{TinhTrang}}", lichDangKy.TinhTrang);
                            contentToUser = contentToUser.Replace("{{DonViCongTac}}", dangKy.DonViCongTac);
                            mailHelper.SendMail(lichDangKy.Email, "NEU", contentToUser);
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }



                        if (!string.IsNullOrEmpty(dangKy.ThanhPhan))
                        {
                            var toMember = mail.Where(x => x.ValueOfMail == 5);
                            string[] thanhPhan = dangKy.ThanhPhan.Split(',');
                            List<string> listMail = new List<string>();
                            for (int j = 0; j < thanhPhan.Length; j++)
                            {
                                var item = thanhPhan[j].Split('(');
                                if (item != null && item.Count() > 1)
                                {
                                    if (item[1].Contains(")"))
                                    {
                                        item[1] = item[1].Replace(")", "");
                                    }
                                    listMail.Add(item[1]);
                                }
                            }

                            foreach (var mailItem in listMail)
                            {
                                if (IsValidEmail(mailItem))
                                {
                                    string contentToMember = System.IO.File.ReadAllText(Server.MapPath("/Assets/Home/MailStructure/" + toMember.First().TenMail));
                                    contentToMember = contentToMember.Replace("{{Name}}", dangKy.TenNguoiDangKy);
                                    contentToMember = contentToMember.Replace("{{EmailMember}}", mailItem);
                                    contentToMember = contentToMember.Replace("{{Email}}", dangKy.Email);
                                    contentToMember = contentToMember.Replace("{{Room}}", Phong.First().TenPhong);
                                    contentToMember = contentToMember.Replace("{{ThoiGian}}", lichDangKy.ThoiGianBatDau.ToShortTimeString() + "-" + lichDangKy.ThoiGianKetThuc.ToShortTimeString());
                                    contentToMember = contentToMember.Replace("{{NgayDangKy}}", lichDangKy.NgayDangKy.ToShortDateString());

                                    //Extra
                                    contentToMember = contentToMember.Replace("{{NoiDungCuocHop}}", lichDangKy.NoiDungCuocHop);
                                    contentToMember = contentToMember.Replace("{{SoDienThoai}}", lichDangKy.SoDienThoai);
                                    contentToMember = contentToMember.Replace("{{TieuDe}}", lichDangKy.TieuDe);
                                    contentToMember = contentToMember.Replace("{{ThanhPhan}}", lichDangKy.ThanhPhan);
                                    contentToMember = contentToMember.Replace("{{TinhTrang}}", lichDangKy.TinhTrang);
                                    mailHelper.SendMail(mailItem, "NEU", contentToMember);
                                }
                                else
                                {
                                    return RedirectToAction("Index");
                                }
                            }





                        }


                        return RedirectToAction("Index");

                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Dữ liệu không hợp lệ");
                }

                return RedirectToAction("Index");
            }

        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";

            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);

            bool valid = false;
            if (string.IsNullOrEmpty(email))
            {
                valid = false;
            }
            else
            {
                valid = check.IsMatch(email);
            }
            return valid;
        }
        public ActionResult ThemMoiKhongThanhCong()
        {
            return View();
        }
        public ThemMoiLichDangKy GetDuLieuChoFormThemMoi(DateTime ngayDangKy, string tenPhong)
        {
            var lichDangKy = new ThemMoiLichDangKy();
            var slotDurationMins = int.Parse(ConfigurationManager.AppSettings["SlotDurationMins"]);
            lichDangKy.ListThoiGianBatDau = GetDanhSachThoiGianDangKy(ngayDangKy.Date.AddHours(7).TimeOfDay);
            lichDangKy.ListThoiGianKetThuc = GetDanhSachThoiGianDangKy(ngayDangKy.Date.AddHours(7).TimeOfDay.Add(new TimeSpan(0, slotDurationMins, 0)));
            lichDangKy.ListPhong = GetDanhSachPhong(tenPhong);
            lichDangKy.NgayDangKy = ngayDangKy.Date;
            return lichDangKy;
        }
        public IEnumerable<SelectListItem> GetDanhSachPhong(string tenPhong)
        {
            var listPhong = new List<SelectListItem>();
            IEnumerable<Phong> phongs = _dangKyPhongHopRepository.GetPhong();
            foreach (var phong in phongs)
            {
                var isSelected = phong.TenPhong.Equals(tenPhong);
                listPhong.Add(new SelectListItem
                {
                    Value = phong.ID.ToString(),
                    Text = phong.TenPhong,
                    Selected = isSelected
                });
            }
            return listPhong;
        }
        public IEnumerable<SelectListItem> GetDanhSachThoiGianDangKy(TimeSpan batDau)
        {
            var listTime = new List<SelectListItem>();
            var thoiGianKetThucDangKy = TimeSpan.ParseExact(ConfigurationManager.AppSettings["EndOfDay"], @"hh\:mm", CultureInfo.CurrentCulture);
            var slotMins = TimeSpan.FromMinutes(int.Parse(ConfigurationManager.AppSettings["SlotDurationMins"]));

            for (TimeSpan i = batDau; i <= thoiGianKetThucDangKy; i = i.Add(slotMins))
            {
                var isSelected = (batDau.Hours.Equals(i.Hours) && (batDau.Minutes.Equals(i.Minutes)));

                listTime.Add(new SelectListItem
                {
                    Text = i.ToString(@"hh\:mm"),
                    Value = (((double)(i.Hours) + ((double)(i.Minutes) / 60)).ToString()),
                    Selected = isSelected
                });
            }

            return listTime;
        }
        #endregion
    }
}
