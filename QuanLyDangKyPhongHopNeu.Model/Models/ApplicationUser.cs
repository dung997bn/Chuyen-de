using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuanLyDangKyPhongHopNeu.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(128)]
        public string HoTen { set; get; }
        [StringLength(128)]
        public string DiaChi { set; get; }
        [StringLength(128)]
        [Column(TypeName = "varchar")]
        public string SDT { set; get; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
