using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDangKyPhongHopNeu.Model.Models
{
    [Table("LoaiPhong")]
    public class LoaiPhong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [StringLength(128)]
        public string TenLoaiPhong { set; get; }
        public virtual IEnumerable<Phong> Phongs { set; get; }
    }
}
