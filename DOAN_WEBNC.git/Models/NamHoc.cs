using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOAN_WEBNC.Models
{

   
    public class NamHoc
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNamHoc { get; set; }
        [Key]
        [Column(Order = 1)]
        public TenHocKy TenHocKy { get; set; }


        public string TenNamHoc { get; set; }
        public DateTime StartYear { get; set; }
        public DateTime EndYear { get; set; }

        public ICollection<DiemHS> DiemHS { get; set; }
    }

}