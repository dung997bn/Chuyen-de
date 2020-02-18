using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Models
{
    public class CaiDatMail
    {
        public IEnumerable<SelectListItem> ListMailXacNhanDangKy { set; get; }
        public IEnumerable<SelectListItem> ListMailChapNhan { set; get; }
        public IEnumerable<SelectListItem> ListMailChuyenPhong { set; get; }
        public IEnumerable<SelectListItem> ListMailKhongChapNhan { set; get; }
        public IEnumerable<SelectListItem> ListMailToMember { set; get; }
        public IEnumerable<SelectListItem> ListMailRequestToAdmin { set; get; }

        [Display(Name="Xác nhận đã đăng ký")]
        public string XacNhanDangKy { get; set; }

        [Display(Name = "Chấp nhận đăng ký")]
        public string ChapNhan { get; set; }

        [Display(Name = "Thông báo chuyển phòng")]
        public string ChuyenPhong { get; set; }

        [Display(Name = "Không chấp nhận")]
        public string KhongChapNhan { get; set; }

        [Display(Name = "Gửi mail tới thành viên khi chấp nhận")]
        public string ToMember { get; set; }

        [Display(Name = "Thông báo đã có người đăng ký")]
        public string RequestToAdmin { get; set; }

        [Display(Name = "Gửi từ Email")]
        public string FromEmail { get; set; }

        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

    }
}