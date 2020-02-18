using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDangKyPhongHopNeu.Model.Models
{
    [Table("LichThietBi")]
    public class LichThietBi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        public int? IDLichDangKy { set; get; }
        public int? IDThietBi { set; get; }
        public string NguoiThue { set; get; }
        public int? SoLuongThue { set; get; }
        [StringLength(128)]
        public string TinhTrang { set; get; }
    }
}
