using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Models
{
    public class ThemMoiLichDangKy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [StringLength(256)]
        [Required(ErrorMessage = "Bạn cần nhập ghi chú")]
        [Display(Name = "Ghi chú")]
        public string TieuDe { set; get; }
        [Display(Name = "Phòng")]
        public string Phong { set; get; }
        [Display(Name = "Bắt đầu vào")]
        public string ThoiGianBatDau { set; get; }
        [Display(Name = "Kết thúc")]
        public string ThoiGianKetThuc { set; get; }
        [Display(Name = "Ngày đăng ký")]
        public DateTime NgayDangKy { set; get; }
        public IEnumerable<SelectListItem> ListThoiGianBatDau { set; get; }
        public IEnumerable<SelectListItem> ListThoiGianKetThuc { set; get; }
        public IEnumerable<SelectListItem> ListPhong { set; get; }

        [StringLength(128)]
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Bạn cần nhập tên người đăng ký")]
        public string TenNguoiDangKy { set; get; }

        [StringLength(128)]
        [Required(ErrorMessage = "Bạn cần nhập Email")]
        [Display(Name = "Email")]
        public string Email { set; get; }

        //[StringLength(128)]
        //[Column(TypeName = "varchar")]
        //[Display(Name = "Số điện thoại")]
        public string SoDienThoai { set; get; }

        [Display(Name = "Thành phần (Email)")]
        public string ThanhPhan { set; get; }
        [StringLength(128)]
        [Display(Name = "Tên người chủ trì cuộc họp")]
        [Required(ErrorMessage = "Bạn cần nhập thông tin của người chủ trì cuộc họp")]
        public string TenNguoiChuTriCuocHop { set; get; }
        [StringLength(128)]
        [Display(Name = "Chức vụ")]
        [Required(ErrorMessage = "Bạn cần nhập chức vụ của người chủ trì cuộc họp")]
        public string ChucVu { set; get; }
        [StringLength(128)]
        [Display(Name = "Email của người chủ trì")]
        [Required(ErrorMessage = "Bạn cần nhập Email của người chủ trì cuộc họp")]
        public string EmailNguoiChuTri { set; get; }
        [Display(Name = "Nội dung cuộc họp")]
        [Required(ErrorMessage = "Bạn cần nhập nội dung cuộc họp")]
        public string NoiDungCuocHop { set; get; }
        [Display(Name = "Đơn vị công tác (*)")]
        [Required(ErrorMessage = "Bạn cần nhập đơn vị công tác")]
        public string DonViCongTac { set; get; }

        public int IdLanhDao { get; set; }

    }
}