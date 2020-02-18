using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDangKyPhongHopNeu.Model.Models
{
    [Table("Phong")]
    public class Phong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [StringLength(128)]
        public string TenPhong { set; get; }
        public int IDKhuNha { set; get; }
        public int IDLoaiPhong { set; get; }

        public virtual IEnumerable<LichDangKy> LichDangKies { set; get; }

        [ForeignKey("IDKhuNha")]
        public virtual KhuNha KhuNha { set; get; }
        [ForeignKey("IDLoaiPhong")]
        public virtual LoaiPhong LoaiPhong { set; get; }
    }
}
