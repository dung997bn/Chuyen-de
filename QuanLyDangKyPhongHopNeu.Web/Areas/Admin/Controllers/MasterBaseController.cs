using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize(Roles = "Admin")]
    public class MasterBaseController : Controller
    {
        // GET: Admin/MasterBase
    }
}