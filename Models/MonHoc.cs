using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN_WEBNC.Models
{
    public class MonHoc
    {
        [Key]
        public string IDMonHoc { get; set; }
        [Display(Name = "Tên môn học")]
        [Required(ErrorMessage = "Tên môn học không được để trống")]
        public string TenMonHoc { get; set; }

        public ICollection<DiemHS> DiemHS { get; set; }
    }
}