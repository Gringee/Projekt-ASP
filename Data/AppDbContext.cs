using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PhotoEntity> Photos { get; set; }
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "photo.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhotoEntity>().HasData(
                new PhotoEntity() { Id = 1, Data = new DateTime(2000, 10, 10), Opis = "zdjecie z tatr", Aparat = "Nikon", Autor = "Adam", Resolution = "1920x1080", Format= "16x9"}
            );
        }
    }
}
