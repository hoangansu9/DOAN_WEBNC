using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOAN_WEBNC.Models
{
    public class DiemHS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaBangDiem { get; set; }
        
        [ForeignKey("HocSinh")]
        [Required(ErrorMessage = "Học sinh không được để trống")]
        public string MaHocSinh { get; set; }

        public HocSinh HocSinh { get; set; }

        [Display(Name = "Mã môn học")]
        [ForeignKey("MonHoc")]
        [Required(ErrorMessage = "Môn học không được để trống")]
        public int MaMonHoc { get; set; }

        public MonHoc MonHoc { get; set; }
        [ForeignKey("HocKy")]
        [Required(ErrorMessage = "Học kỳ không được để trống")]
        public int IDHocKy { get; set; }
        public HocKy HocKy { get; set; }
        public ICollection<ChiTietDiem> ChiTietDiems { get; set; }
    }
}