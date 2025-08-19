using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppData.Contexts
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }

        public DbSet<NhanVien> NhanViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MAY-21\\SQLEXPRESS;Database=KHANHPG_PH12345;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
            }
        }
    }
}
