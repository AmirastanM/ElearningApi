using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System;
using ElearningApi.Models;
using System.Reflection.Emit;

namespace ElearningApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<InstructorSocial> InstructorSocials { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseImage> CourseImages { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<About>().Property(m => m.Title).IsRequired().HasMaxLength(50);
            builder.Entity<About>().Property(m => m.Description).IsRequired().HasMaxLength(200);
            builder.Entity<About>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Slider>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Information>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Instructor>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Social>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Course>().HasQueryFilter(m => !m.SoftDeleted);
            builder.Entity<Student>().HasQueryFilter(m => !m.SoftDeleted);



            base.OnModelCreating(builder);
        }

    }
}
