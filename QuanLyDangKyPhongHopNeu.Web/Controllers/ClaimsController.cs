using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using QuanLyDangKyPhongHopNeu.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web.Controllers
{
    [Authorize]
    public class ClaimsController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ClaimsController(ApplicationSignInManager signInManager, ApplicationUserManager userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            var userClaims = User.Identity as System.Security.Claims.ClaimsIdentity;
            var listUser = _userManager.Users.Where(x => x.Roles.Any(r => r.RoleId == "Ad")).AsEnumerable();
            foreach (var item in listUser)
            {
                if (userClaims?.FindFirst("preferred_username")?.Value == item.Email || (userClaims?.FindFirst("preferred_username")?.Value == item.UserName))
                {
                    var claims = new Claim(ClaimTypes.Role, "Admin");
                    userClaims.AddClaim(claims);

                }
            }
            


            ViewBag.Name = userClaims?.FindFirst("name")?.Value;
            ViewBag.Email = userClaims?.FindFirst("preferred_username")?.Value;
            ViewBag.Subject = userClaims?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.TenantId = userClaims?.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid")?.Value;
            return View();
        }
    }
}