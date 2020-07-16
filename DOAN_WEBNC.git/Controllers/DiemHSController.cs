using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DOAN_WEBNC.Models;

namespace DOAN_WEBNC.Controllers
{
    public class DiemHSController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DiemHS
        public ActionResult Index()
        {
            var diemHocSinhs = db.DiemHocSinhs.Include(d => d.HocSinh).Include(d => d.MonHoc).Include(d => d.NamHoc);
            return View(diemHocSinhs.ToList());
        }

        // GET: DiemHS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemHS diemHS = db.DiemHocSinhs.Find(id);
            if (diemHS == null)
            {
                return HttpNotFound();
            }
            return View(diemHS);
        }

        // GET: DiemHS/Create
        public ActionResult Create()
        {

            ViewBag.MaHocSinh = new SelectList(db.HocSinhs, "IDHocSinh", "HoTen");
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "IDMonHoc", "TenMonHoc");
            ViewBag.IDNamHoc = new SelectList(db.NamHocs, "IDNamHoc", "TenNamHoc");

            return View();
        }

        // POST: DiemHS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBangDiem,MaHocSinh,MaMonHoc,IDNamHoc,TenHocKy")] DiemHS diemHS)
        {
            if (ModelState.IsValid)
            {
                db.DiemHocSinhs.Add(diemHS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHocSinh = new SelectList(db.HocSinhs, "IDHocSinh", "HoTen", diemHS.MaHocSinh);
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "IDMonHoc", "TenMonHoc", diemHS.MaMonHoc);
            ViewBag.IDNamHoc = new SelectList(db.NamHocs, "IDNamHoc", "IDNamHoc", diemHS.IDNamHoc);
            return View(diemHS);
        }

        // GET: DiemHS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemHS diemHS = db.DiemHocSinhs.Find(id);
            if (diemHS == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHocSinh = new SelectList(db.HocSinhs, "IDHocSinh", "HoTen", diemHS.MaHocSinh);
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "IDMonHoc", "TenMonHoc", diemHS.MaMonHoc);
            ViewBag.IDNamHoc = new SelectList(db.NamHocs, "IDNamHoc", "IDNamHoc", diemHS.IDNamHoc);
            return View(diemHS);
        }

        // POST: DiemHS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBangDiem,MaHocSinh,MaMonHoc,IDNamHoc,TenHocKy")] DiemHS diemHS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diemHS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHocSinh = new SelectList(db.HocSinhs, "IDHocSinh", "HoTen", diemHS.MaHocSinh);
            ViewBag.MaMonHoc = new SelectList(db.MonHocs, "IDMonHoc", "TenMonHoc", diemHS.MaMonHoc);
            ViewBag.IDNamHoc = new SelectList(db.NamHocs, "IDNamHoc", "IDNamHoc", diemHS.IDNamHoc);
            return View(diemHS);
        }

        // GET: DiemHS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemHS diemHS = db.DiemHocSinhs.Find(id);
            if (diemHS == null)
            {
                return HttpNotFound();
            }
            return View(diemHS);
        }

        // POST: DiemHS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiemHS diemHS = db.DiemHocSinhs.Find(id);
            db.DiemHocSinhs.Remove(diemHS);
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
