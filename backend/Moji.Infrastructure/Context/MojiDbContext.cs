using Microsoft.EntityFrameworkCore;
using Moji.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Infrastructure.Context
{
    public class MojiDbContext:DbContext
    {
        public MojiDbContext(DbContextOptions<MojiDbContext> options):base(options) 
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Category> Category { get; set; }
        // Để ngăn chặn việc xóa university cascade post, user-> ta đặt config ondelete ở phía dependent là post,user
        // Chỉ config relationship ở bên chứa FK, Ex: User(1)->(n)University thì cấu hình relationship ở phía user vì user chưa FK
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b=> 
            {
                b.HasKey(b => b.Id);
                b.HasOne(b => b.University).WithMany(u => u.Users).HasForeignKey(b => b.UniversityId).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Post>(b => 
            {
                b.HasKey(b=>b.Id);
                b.Property(b => b.Price).HasColumnType("decimal(18,2)");
                b.HasOne(b => b.Creator).WithMany(c => c.Post).HasForeignKey(b=>b.CreatorId);
                b.HasOne(b => b.University).WithMany(u => u.Posts).HasForeignKey(b => b.UniversityId).OnDelete(DeleteBehavior.Restrict);
                b.HasOne(b=>b.Category).WithMany(c=>c.Posts).HasForeignKey(b=>b.CategoryId);
            });
            modelBuilder.Entity<Category>(b =>
            {
                b.HasKey(b => b.Id);
            });
            modelBuilder.Entity<University>(b =>
            {
                b.HasKey(b=>b.Id);
            });
            modelBuilder.Entity<Image>(b =>
            {
                b.HasKey(b=>b.Id);
                b.HasOne(b => b.Post).WithMany(p => p.Images).HasForeignKey(b=>b.PostId);
            });
            modelBuilder.Entity<RefreshToken>(b =>
            {
                b.HasKey(b => b.Id);
                b.HasOne(b=>b.User).WithMany(u=>u.RefreshTokens).HasForeignKey(b=>b.UserId);
            });
        }
    }
}
