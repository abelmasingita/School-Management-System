using DataAccessLayer.Configurations;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DataLayer : IdentityDbContext<User>
    {
        public DataLayer(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<Student>()
                        .HasOne(s => s.User)
                        .WithMany()
                        .HasForeignKey(s => s.UserId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                        .HasOne(s => s.Class)
                        .WithMany(c => c.Students)
                        .HasForeignKey(s => s.ClassId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                        .HasOne(s => s.Parent)
                        .WithMany()
                        .HasForeignKey(s => s.ParentId)
                        .OnDelete(DeleteBehavior.Restrict);

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
