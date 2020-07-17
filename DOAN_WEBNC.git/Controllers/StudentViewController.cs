using DOAN_WEBNC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace DOAN_WEBNC.Controllers
{
    public class StudentViewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: StudentView
        public ActionResult Index()
        {
            string userID = "";
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var userIdClaim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                if(userIdClaim != null)
                {
                    userID = userIdClaim.Value;
                }
            }
            var student = db.HocSinhs.Include(m => m.Lop).FirstOrDefault(x => x.IDHocSinh == userID);
            
            if (student != null)
            {
                return View(student);
            }
            else return HttpNotFound();
        }
    }
}