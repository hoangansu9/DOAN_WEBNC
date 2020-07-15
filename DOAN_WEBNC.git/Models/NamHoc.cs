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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDHocKy { get; set; }
        [Display(Name ="Học kỳ")]
        public TenHocKy TenHocKy { get; set; }

        [Display(Name = "Năm học")]
        [ForeignKey("NamHoc")]
        public int IDNamHoc { get; set; }
        public NamHoc NamHoc { get; set; }

        ICollection<DiemHS> DiemHs { get; set; }

    }
    public class NamHoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNamHoc { get; set; }
        [Required(ErrorMessage = "Năm học không được để trống")]
        public string TenNamHoc { get; set; }

        public ICollection<HocKy> HocKys { get; set; }
    }

}