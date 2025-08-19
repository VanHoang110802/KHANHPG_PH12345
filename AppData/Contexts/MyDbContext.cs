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
                optionsBuilder.UseSqlServer("Server=DESKTOP-DG3SFBV\\SQLEXPRESS;Initial Catalog=Hoangtv_Ph31092;User ID=sa;Password=11082002;TrustServerCertificate=True;");
            }
        }
    }
}
