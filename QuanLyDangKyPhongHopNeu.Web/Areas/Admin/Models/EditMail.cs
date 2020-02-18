using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Models
{
    public class EditMail
    {
        public string mailName { get; set; }
        public string mailContent { get; set; }
    }
}