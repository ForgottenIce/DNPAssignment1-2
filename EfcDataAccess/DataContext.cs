using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;
public class DataContext :DbContext {
    
    public DbSet<User> Users { get; set; }
    public DbSet<SubPage> SubPages { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/data.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<User>().HasMany(u => u.LikedPosts).WithMany()
            .UsingEntity(join => join.ToTable("UserLikesPost"));
        modelBuilder.Entity<User>().HasMany(u => u.DislikedPosts).WithMany()
            .UsingEntity(join => join.ToTable("UserDislikesPost"));
        modelBuilder.Entity<User>().HasMany(u => u.SubscribedSubs).WithMany()
            .UsingEntity(join => join.ToTable("UserSubscribedToSub"));

        modelBuilder.Entity<SubPage>().HasKey(x => x.Id);
        modelBuilder.Entity<SubPage>().HasOne<User>("Owner");

        modelBuilder.Entity<Post>().HasKey(x => x.Id);
        modelBuilder.Entity<Post>().HasOne<User>("Author");
        modelBuilder.Entity<Post>().Property(p => p.Title).IsRequired(false);
        
    }
}
