using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using DOAN_WEBNC.Models;
using Microsoft.Ajax.Utilities;

namespace DOAN_WEBNC.Controllers
{
    public class LopController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lop
        public ActionResult Index()
        {
            return View(db.Lops.ToList());
        }

        // GET: Lop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lops.Find(id);
            var listHocSinh = db.HocSinhs.Include(x => x.Lop).Where(x => x.Lop.IDLop == id).ToList();
//            var chiTietList = db.DiemHocSinhs.Include(d => d.HocSinh).Include(d => d.MonHoc).Include(d => d.NamHoc).ToList();
//            var list = (from r1 in listHocSinh
//                        join
//r2                      in db.DiemHocSinhs on r1.IDHocSinh equals r2.MaHocSinh
//                        join r3 in db.ChiTietDiems on r2.MaBangDiem equals r3.MaBangDiem
//                        join r4 in db.MonHocs on r2.MaMonHoc equals r4.IDMonHoc
//                        join r5 in db.NamHocs on r2.IDNamHoc equals r5.IDNamHoc
//                        select new LopViewModel
//                        {
//                            IDHocSinh = r1.IDHocSinh,
//                            TenHocSinh = r1.HoTen,
//                            IDLop = r1.Lop.IDLop,
//                            TenLop = r1.Lop.TenLop,
//                            MaBangDiem = r2.MaBangDiem,
//                            TenMonHoc = r4.TenMonHoc,
//                            IDnamHoc = r2.IDNamHoc,
//                            LoaiDiem = r3.LoaiDiem,
//                            LanThi = r3.LanThi,
//                            Diem = r3.Diem,
//                            TenNamHoc = r5.TenNamHoc
//                        }).ToList();
//            ViewBag.listDiem = list;
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(listHocSinh);
        }

        //detal hoc sinh
        public ActionResult DetailStudent(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bangDiem = db.DiemHocSinhs.Include(d => d.HocSinh)
                .Include(d => d.MonHoc).Include(d => d.NamHoc)
                .Where(m => m.MaHocSinh == id).ToList();
            CTDiemTungHSVM cTDiemTungHS = new CTDiemTungHSVM();
            ViewBag.NamHoc = bangDiem.First().NamHoc.TenNamHoc;
            ViewBag.TenHS = bangDiem.First().HocSinh.HoTen;
            var listDiem = bangDiem.Select(m => new CTDiemTungHSVM
            {
                MaBangDiem = m.MaBangDiem,
                TenMon = m.MonHoc.TenMonHoc,
                DiemTong = 0
            });
            return View(listDiem);
        }


        // GET: Lop/Create
        public ActionResult Create()
        {
            return View();
        }

       
        // POST: Lop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLop,TenLop")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Lops.Add(lop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lop);
        }

        // GET: Lop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lops.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // POST: Lop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLop,TenLop")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lop);
        }

        // GET: Lop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lops.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // POST: Lop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lop lop = db.Lops.Find(id);
            db.Lops.Remove(lop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
