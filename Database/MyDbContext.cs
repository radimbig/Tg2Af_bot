using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Telegram2A.Core;

namespace Telegram2A.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AuthKeyValue> AuthDict { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string PathToDb = Environment.CurrentDirectory + "\\mydatabase.db";
            optionsBuilder.UseSqlite($"Data Source={PathToDb}");
        }
        public MyDbContext()
        {
        }   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<AuthKeyValue>().HasKey(x => x.Id);
            modelBuilder.Entity<AuthKeyValue>().Property(x => x.NameOfAuth).HasColumnName("NameOfAuth");
            modelBuilder.Entity<AuthKeyValue>().Property(x => x.Secret).HasColumnName("Secret");
            modelBuilder.Entity<AuthKeyValue>().HasOne(x=>x.Owner).WithMany(x=>x.AuthKeyValues).HasForeignKey(x=>x.ForeignId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
