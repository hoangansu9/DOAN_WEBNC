using DOAN_WEBNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace DOAN_WEBNC.Controllers
{
    public class DiemChiTietController : Controller
    {
        // GET: DiemChiTiet
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var chiTietList = db.DiemHocSinhs.Include(d => d.HocSinh).Include(d => d.MonHoc).Include(d => d.NamHoc).ToList();

            HocSinhViewModel hs = new HocSinhViewModel();

          
            List<HocSinhViewModel> hsViewModelList = chiTietList.Select(x => new HocSinhViewModel
                {
                    MaBangDiem = x.MaBangDiem,
                    MaHocSinh = x.MaHocSinh,
                    TenHocSinh = x.HocSinh.HoTen,
                    MaMonHoc = x.MaMonHoc,
                    IDNamHoc = x.IDNamHoc,
                    TenMonHoc=x.MonHoc.TenMonHoc,
                    NamHoc=x.NamHoc.TenNamHoc,
                   
                }
                ).ToList();

            return View(hsViewModelList);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var chiTietDiem = db.ChiTietDiems.Where(x=> x.MaBangDiem==id).ToList();
            var detail = db.DiemHocSinhs.FirstOrDefault(m => m.MaBangDiem == id);
            ViewBag.TenMH = db.MonHocs.Find(detail.MaMonHoc).TenMonHoc;
            ViewBag.TenHS = db.HocSinhs.Find(detail.MaHocSinh).HoTen;
            if (chiTietDiem == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDiem);
        }
    }
}