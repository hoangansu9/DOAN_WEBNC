using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DOAN_WEBNC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
        public DbSet<NamHoc> NamHocs { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<HocSinh> HocSinhs { get; set; }
        public DbSet<LoaiDiem> LoaiDiems { get; set; }
        public DbSet<HocKy> HocKys { get; set; }
        public DbSet<DiemHS> DiemHocSinhs { get; set; }
        public DbSet<ChiTietDiem> ChiTietDiems { get; set; }

    }

}