using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDangKyPhongHopNeu.Model.Models
{
   public class Mail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [StringLength(128)]
        public string TenMail { set; get; }
        public int ValueOfMail { set; get; }
    }
}
