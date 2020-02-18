using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using QuanLyDangKyPhongHopNeu.Model.Models;
using QuanLyDangKyPhongHopNeu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QuanLyDangKyPhongHopNeu.Web.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public LoginController()
        {
        }
        public LoginController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ApplicationUser user = _userManager.Find(model.UserName, model.Password);
            if (user != null)
            {
                IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                ClaimsIdentity identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationProperties props = new AuthenticationProperties();
                authenticationManager.SignIn(props, identity);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
            }
            else
            {
                ModelState.AddModelError("", "Thông tin đăng nhập không đúng.");
            }
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> LoginAjax(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            LoginViewModel login = serializer.Deserialize<LoginViewModel>(model);
            bool status = false;
            ApplicationUser user =await _userManager.FindAsync(login.UserName, login.Password);
            if (user != null)
            {
                IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                ClaimsIdentity identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationProperties props = new AuthenticationProperties();
                authenticationManager.SignIn(props, identity);
                status = true;
                return Json(new
                {
                    user,
                    status
                });
            }
            else
            {
                return Json(new
                {
                    status,
                    message = "Sai tên đăng nhập hoặc mật khẩu."
                });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOutAjax()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Login", "Login");
        }

        public void SignIn365()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
            else
            {
                var userClaims = User.Identity as System.Security.Claims.ClaimsIdentity;
                var listUser = _userManager.Users.Where(x=>x.Roles.First().RoleId=="Ad").AsEnumerable();
                foreach (var item in listUser)
                {
                    if (userClaims?.FindFirst("preferred_username")?.Value == item.Email || (userClaims?.FindFirst("preferred_username")?.Value == item.UserName))
                    {
                        var user = new ApplicationUser { UserName = userClaims?.FindFirst("preferred_username")?.Value, Email = (userClaims?.FindFirst("preferred_username")?.Value)};
                        _userManager.CreateAsync(user, "dung1997");
                        _userManager.AddToRole(user.Id, "Admin");
                    }
                }

                RedirectToAction("DangKyTheoTuan", "DangKy");
            }
        }

        /// <summary>
        /// Send an OpenID Connect sign-out request.
        /// </summary>
        public void SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType,
                CookieAuthenticationDefaults.AuthenticationType);
        }
    }
}