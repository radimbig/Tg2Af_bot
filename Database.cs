using Microsoft.EntityFrameworkCore;


namespace Telegram2A
{
    public class Database:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AuthKeyValue> AuthDict { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydatabase.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<AuthKeyValue>().HasKey(x => x.Id);
            modelBuilder.Entity<AuthKeyValue>().ToTable("AuthDict");
            modelBuilder.Entity<AuthKeyValue>().HasOne(x => x.Owner).WithMany(u => u.AuthKeyValues).HasForeignKey(x=>x.ForeignId);
        }
    }
}
