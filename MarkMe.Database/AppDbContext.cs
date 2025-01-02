using MarkMe.Database.Entities;

using Microsoft.EntityFrameworkCore;

namespace MarkMe.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<ClassRepresentative> ClassRepresentatives { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Enrolment> Enrolments { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClassRepresentative>().HasKey(e => new { e.StudentId, e.CourseId });
            modelBuilder.Entity<Student>().HasData(new[]
            {
                new Student() {
                    StudentId = 1,
                    FirstName = "Zubair",
                    LastName="Jamil",
                    CollegeRollNo="537",
                    RegistrationNo="2021-gsr-439",
                    UniversityRollNo="070941",
                    Section="G1",
                    Session="2021-2025",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 2,
                    FirstName = "Umair",
                    LastName="Jamil",
                    CollegeRollNo="539",
                    RegistrationNo="2021-gsr-442",
                    UniversityRollNo="070943",
                    Section="G1",
                    Session="2021-2025",
                    IsDeleted = false
                },
            });


            modelBuilder.Entity<User>().HasData(new[]
            {
                new User() {
                    UserId = 1,
                    FirstName = "Zubair",
                    LastName = "Jamil",
                    Email = "xubairjamil@gmail.com",
                    Password = "123456",
                    IsDeleted = false
                },
            });
        }
    }
}
