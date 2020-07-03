using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN_WEBNC.Models
{
    public class Lop
    {
        [Key]
        public string IDLop { get; set; }
        [Display(Name = "Tên lớp")]
        [Required(ErrorMessage = "Tên lớp không được để trống")]
        public string TenLop { get; set; }

        public ICollection<HocSinh> HocSinhs { get; set; }
    }
}