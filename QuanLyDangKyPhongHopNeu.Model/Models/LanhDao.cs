using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDangKyPhongHopNeu.Model.Models
{
    [Table("LanhDao")]
    public class LanhDao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [StringLength(128)]
        public string HoTen { set; get; }
        [StringLength(128)]
        public string ChucVu { set; get; }
        [StringLength(128)]
        public string Email { set; get; }

        public string DonViCongTac { set; get; }
        public virtual IEnumerable<LichDangKy> LichDangKies { set; get; }
    }
}
