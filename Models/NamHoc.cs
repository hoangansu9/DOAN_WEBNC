using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOAN_WEBNC.Models
{

    public enum TenHocKy
    {
        HK1,
        HK2
    }
    public class HocKy
    {
        [Key]
        public string IDHocKy { get; set; }
        [Display(Name ="Học kỳ")]
        public TenHocKy TenHocKy { get; set; }

        [Display(Name = "Năm học")]
        [ForeignKey("NamHoc")]
        public string IDNamHoc { get; set; }
        public NamHoc NamHoc { get; set; }

        ICollection<DiemHS> DiemHs { get; set; }

    }
    public class NamHoc
    {
        [Key]
        public string IDNamHoc { get; set; }
        [Required(ErrorMessage = "Năm học không được để trống")]
        public string TenNamHoc { get; set; }

        public ICollection<HocKy> HocKys { get; set; }
    }

}