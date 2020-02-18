using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Controllers
{
    public class HomeController : MasterBaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}