using QuanLyDangKyPhongHopNeu.Data.Repository;
using QuanLyDangKyPhongHopNeu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuanLyDangKyPhongHopNeuDbContext _dbContext = new QuanLyDangKyPhongHopNeuDbContext();
        public ActionResult Index(DateTime? date = null)
        {
            if (date == null)
            {
                date = DateTime.Today.AddDays(-(((int)DateTime.Today.DayOfWeek) + 6) % 7);
            }
            var dangKyPhongHopRepository = new DangKyPhongHopRepository();
            var quanLyDangKy = new QuanLyDangKy(dangKyPhongHopRepository);
            return View(quanLyDangKy.GetDangKyTheoTuan(date.Value));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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
                if(item !=null && item.Count() > 1)
                {
                    if (item[1].Contains(")"))
                    {
                        item[1] = item[1].Replace(")", "");
                    }
                    listMail.Add(item[1]);
                }
               
            }

            List<string> data = new List<string>();
            foreach (var item in listMail)
            {
                var lanhDao = _dbContext.LanhDaos.SingleOrDefault(x => x.Email == item);
                if(lanhDao != null)
                {
                    var name =lanhDao.HoTen;
                    data.Add(name);
                }               
            }
           
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}