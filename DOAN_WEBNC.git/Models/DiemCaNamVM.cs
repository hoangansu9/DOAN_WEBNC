using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_WEBNC.Models
{
    public class DiemCaNamVM
    {
        public int MaBangDiem { get; set; }
        public string MaHocSinh { get; set; }
        public string TenHocSinh { get; set; }
        public double TBM { get; set; }
        public double TBCN { get; set; }
    }
}