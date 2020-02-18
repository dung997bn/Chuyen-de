using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Models
{
    public class ThemMoiMail
    {
        [StringLength(500)]
        [Required(ErrorMessage ="Bạn cần nhập nội dung.")]
        [Display(Name ="Nội dung Email")]
        public string NoiDungMai { set; get; }

        [StringLength(128)]
        [Display(Name = "Tên file")]
        [Required(ErrorMessage = "Bạn cần nhập tên của file.")]
        public string TenMail { set; get; }
    }
}