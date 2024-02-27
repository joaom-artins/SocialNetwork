using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<User>().HasKey(u=>u.Id);
            mb.Entity<User>().Property(u=>u.Username).HasMaxLength(256);
            mb.Entity<User>().Property(u=>u.Password).HasMaxLength(256);

            mb.Entity<Post>().HasKey(p=>p.Id);
            mb.Entity<Post>().Property(p=>p.Title).HasMaxLength(256);
            mb.Entity<Post>().Property(p=>p.Content).HasMaxLength(1024);
            mb.Entity<Post>().HasOne(p=>p.User).WithMany(u=>u.Posts).HasForeignKey(p=>p.UserId).OnDelete(DeleteBehavior.NoAction);

            mb.Entity<Comment>().HasKey(c=>c.Id);
            mb.Entity<Comment>().Property(c=>c.Content).HasMaxLength(1024);
            mb.Entity<Comment>().HasOne(c => c.User).WithMany(u => u.Comments).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<Comment>().HasOne(c => c.Post).WithMany(p => p.Comments).HasForeignKey(c => c.PostId).OnDelete(DeleteBehavior.NoAction);
             base.OnModelCreating(mb);
        }
    }
}