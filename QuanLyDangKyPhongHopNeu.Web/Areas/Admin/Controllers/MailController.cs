using QuanLyDangKyPhongHopNeu.Data.Repository;
using QuanLyDangKyPhongHopNeu.Model.Models;
using QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Controllers
{
    public class MailController : MasterBaseController
    {
        IMailRepository _mailRepository;

        public MailController(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }


        // GET: Admin/Mail
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ThemMoiMail(ThemMoiMail model)
        {
            if (ModelState.IsValid)
            {
                string fileLocation = Server.MapPath("/Assets/Home/MailStructure/").ToString();
                var tenFile = model.TenMail;
                FileStream fs = null;
                if (!System.IO.File.Exists(fileLocation + tenFile + ".html"))
                {
                    using (fs = System.IO.File.Create(fileLocation + tenFile + ".html"))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(model.NoiDungMai);
                        fs.Write(info, 0, info.Length);
                    }
                }
                return View("ThemMoiMailThanhCong");
            }
            else
            {
                return View("Index");
            }
        }
        public ActionResult ThemMoiMailThanhCong()
        {

            return View();
        }

        public ActionResult CaiDatMail()
        {
            var model = new CaiDatMail();
            model = GetCaiDat();
            return View(model);
        }
        public CaiDatMail GetCaiDat()
        {
            var model = _mailRepository.GetAll();

            string[] fileEntries = Directory.GetFiles(Server.MapPath("/Assets/Home/MailStructure/"));
            List<string> list = fileEntries.ToList();

            //Xác nhận đã đăng ký
            var ListMailXacNhanDaDangKy = new List<SelectListItem>();
            var xacNhan = model.Where(x => x.ValueOfMail == 0);
            for (int i = 0; i < fileEntries.Length; i++)
            {
                var isSelected = xacNhan.First().TenMail.Equals(fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""));

                ListMailXacNhanDaDangKy.Add(new SelectListItem
                {
                    Text = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""),
                    Value = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""),
                    Selected = isSelected
                });
            }

            //Chấp nhận
            var ListMailChapNhan = new List<SelectListItem>();
            var chapNhan = model.Where(x => x.ValueOfMail == 1);
            for (int i = 0; i < fileEntries.Length; i++)
            {
                var isSelected = chapNhan.First().TenMail.Equals(fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""));

                ListMailChapNhan.Add(new SelectListItem
                {
                    Text = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""),
                    Value = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""),
                    Selected = isSelected
                });
            }
            //Chuyển phòng
            var ListMailChuyenPhong = new List<SelectListItem>();
            var chuyenPhong = model.Where(x => x.ValueOfMail == 2);
            for (int i = 0; i < fileEntries.Length; i++)
            {
                var isSelected = chuyenPhong.First().TenMail.Equals(fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""));

                ListMailChuyenPhong.Add(new SelectListItem
                {
                    Text = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""),
                    Value = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""),
                    Selected = isSelected
                });
            }
            //Không chấp nhận
            var ListMailKhongChapNhan = new List<SelectListItem>();
            var khongChapNhan = model.Where(x => x.ValueOfMail == 3);
            for (int i = 0; i < fileEntries.Length; i++)
            {
                var isSelected = khongChapNhan.First().TenMail.Equals(fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""));

                ListMailKhongChapNhan.Add(new SelectListItem
                {
                    Text = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""),
                    Value = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""),
                    Selected = isSelected
                });
            }
            //Thông báo có người đăng ký
            var ListMailRequestToAdmin = new List<SelectListItem>();
            var thongBao = model.Where(x => x.ValueOfMail == 4);
            for (int i = 0; i < fileEntries.Length; i++)
            {
                var isSelected = thongBao.First().TenMail.Equals(fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""));

                ListMailRequestToAdmin.Add(new SelectListItem
                {
                    Text = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""),
                    Value = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""),
                    Selected = isSelected
                });
            }
            //To Members
            var ListMailToMembers = new List<SelectListItem>();
            var toMembers = model.Where(x => x.ValueOfMail == 5);
            for (int i = 0; i < fileEntries.Length; i++)
            {
                var isSelected = toMembers.First().TenMail.Equals(fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""));

                ListMailToMembers.Add(new SelectListItem
                {
                    Text = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""),
                    Value = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), ""),
                    Selected = isSelected
                });
            }
            var FromEmail = model.Where(x => x.ValueOfMail == 6).First().TenMail;
            var Password = model.Where(x => x.ValueOfMail == 7).First().TenMail;

            var caidatMail = new CaiDatMail();
            caidatMail.ListMailXacNhanDangKy = ListMailXacNhanDaDangKy;
            caidatMail.ListMailChapNhan = ListMailChapNhan;
            caidatMail.ListMailChuyenPhong = ListMailChuyenPhong;
            caidatMail.ListMailKhongChapNhan = ListMailKhongChapNhan;
            caidatMail.ListMailRequestToAdmin = ListMailRequestToAdmin;
            caidatMail.ListMailToMember = ListMailToMembers;
            caidatMail.FromEmail = FromEmail;
            caidatMail.Password = Password;
            return caidatMail;
        }

        [HttpPost]
        public ActionResult PhucHoiMacDinh()
        {
            var oldData = _mailRepository.GetAll();
            foreach (var item in oldData)
            {
                _mailRepository.Delete(item.ID);
            }
            _mailRepository.SaveChange();
            var caiDat = new List<Mail>()
            {
                new Mail{ TenMail="XacNhanDaDangKy.html",ValueOfMail=0},
                new Mail{ TenMail="fromAdmin.html",ValueOfMail=1},
                new Mail{ TenMail="changeRoom.html",ValueOfMail=2},
                new Mail{ TenMail="notAccept.html",ValueOfMail=3},
                new Mail{ TenMail="requestToAdmin.html",ValueOfMail=4},
                new Mail{ TenMail="toMembers.html",ValueOfMail=5},
                new Mail{TenMail ="phaichisophan@gmail.com",ValueOfMail=6},
                new Mail{TenMail ="dung1997",ValueOfMail=7}
            };
            foreach (var cd in caiDat)
            {
                _mailRepository.Add(cd);
            }
            _mailRepository.SaveChange();
            return View("CaiDatThanhCong");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LuuCaiDat(CaiDatMail model)
        {
            if (ModelState.IsValid)
            {
                var oldData = _mailRepository.GetAll();
                foreach (var item in oldData)
                {
                    _mailRepository.Delete(item.ID);
                }
                _mailRepository.SaveChange();
                var caiDat = new List<Mail>()
            {
                new Mail{ TenMail=model.XacNhanDangKy,ValueOfMail=0},
                new Mail{ TenMail=model.ChapNhan,ValueOfMail=1},
                new Mail{ TenMail=model.ChuyenPhong,ValueOfMail=2},
                new Mail{ TenMail=model.KhongChapNhan,ValueOfMail=3},
                new Mail{ TenMail=model.RequestToAdmin,ValueOfMail=4},
                new Mail{ TenMail=model.ToMember,ValueOfMail=5},
                new Mail{TenMail =model.FromEmail,ValueOfMail=6},
                new Mail{TenMail =model.Password,ValueOfMail=7}
            };
                foreach (var cd in caiDat)
                {
                    _mailRepository.Add(cd);
                }
                _mailRepository.SaveChange();
                return View("CaiDatThanhCong");
            }
            else
            {
                return View("CaiDatMail");
            }

        }
        public ActionResult EditMail()
        {
            return View("EditMail");
        }
        [HttpGet]
        [Route("GetAll")]
        public JsonResult GetAll()
        {
            string root = Server.MapPath("/Assets/Home/MailStructure/");
            string[] fileEntries = Directory.GetFiles(root);
            for (int i = 0; i < fileEntries.Length; i++)
            {
                fileEntries[i] = fileEntries[i].Replace(Server.MapPath("/Assets/Home/MailStructure/"), "");
            }
            return Json(new { data = fileEntries }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("OpenFile")]
        public JsonResult OpenFile(string mailName)
        {
            string file = Server.MapPath("/Assets/Home/MailStructure/");
            var data = "";
            if (System.IO.File.Exists(file + mailName))
            {
                StreamReader sr = new StreamReader(file + mailName, true);
                data = sr.ReadToEnd();
                sr.Close();
                return Json(new { status = true, data });
            }
            else
            {
                return Json(new { status = false, error = "Không thể mở file" });
            }

        }

        [HttpPost]
        [Route("SaveFile")]
        [ValidateInput(false)]
        public JsonResult SaveFile(string dataMail)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                EditMail editMail = serializer.Deserialize<EditMail>(dataMail);
                var html = HttpUtility.HtmlDecode(editMail.mailContent);
                string filePre = Server.MapPath("/Assets/Home/MailStructure/");
                var fileName = filePre + editMail.mailName;
                System.IO.File.WriteAllText(fileName, String.Empty);
                System.IO.FileInfo fileInfo = new FileInfo(fileName);
                StreamWriter streamWriter = fileInfo.CreateText();
                streamWriter.WriteLine(editMail.mailContent);
                streamWriter.Close();
                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, error = ex.Message });
            }
        }
        public ActionResult CaiDatThanhCong()
        {
            return View();
        }
    }
}