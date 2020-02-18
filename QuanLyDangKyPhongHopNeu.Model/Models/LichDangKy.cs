using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDangKyPhongHopNeu.Model.Models
{
    [Table("LichDangKy")]
    public class LichDangKy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [StringLength(256)]
        public string TieuDe { set; get; }
        public int IDPhong { set; get; }

        public DateTime ThoiGianBatDau { set; get; }
        public DateTime ThoiGianKetThuc { set; get; }
        public DateTime NgayDangKy { set; get; }

        [StringLength(128)]
        public string TenNguoiDangKy { set; get; }

        [StringLength(128)]
        public string Email { set; get; }

        [StringLength(128)]
        [Column(TypeName = "varchar")]
        public string SoDienThoai { set; get; }

        [StringLength(128)]
        public string TinhTrang { set; get; }

        [ForeignKey("IDPhong")]
        public virtual Phong Phong { set; get; }
        public string ThanhPhan { set; get; }
        public string NoiDungCuocHop { set; get; }


        public int IdLanhDao { set; get; }
        [ForeignKey("IdLanhDao")]
        public virtual LanhDao LanhDao { set; get; }

    }
}
