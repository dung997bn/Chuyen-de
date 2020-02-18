using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDangKyPhongHopNeu.Model.Models
{
    [Table("ThietBi")]
    public class ThietBi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [StringLength(128)]
        public string TenThietBi { set; get; }
        public int SoLuong { set; get; }
    }
}
