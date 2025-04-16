using MarkMe.Database.Entities;
using MarkMe.Database.Enums;
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
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Activity>()
               .HasOne<ClassRepresentative>()
               .WithMany(cr => cr.Activities)
               .HasForeignKey(a => new { a.ClassRepresentativeStudentId, a.ClassRepresentativeCourseId });

            modelBuilder.Entity<ClassRepresentative>().HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<Student>()
                .HasIndex(e => e.CollegeRollNo)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(e => e.UniversityRollNo)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(e => e.RegistrationNo)
                .IsUnique();

            modelBuilder.Entity<Student>().HasData(new[]
            {
                new Student() {
                    StudentId = 1,
                    FirstName = "Mousa",
                    LastName="Naeem",
                    CollegeRollNo="501",
                    RegistrationNo="2021gsr407",
                    UniversityRollNo="070982",
                    Section="G1",
                    Session="20212025",
                    Email = "mnaeem@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 2,
                    FirstName = "Aftab",
                    LastName="Sattar",
                    CollegeRollNo="539",
                    RegistrationNo="2021gsr442",
                    UniversityRollNo="070943",
                    Section="G1",
                    Session="20212025",
                    Email = "asattar@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 3,
                    FirstName = "Ali",
                    LastName="Senior",
                    CollegeRollNo="540",
                    RegistrationNo="2021gsr443",
                    UniversityRollNo="070944",
                    Section="G1",
                    Session="20212025",
                    Email = "asenior@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 4,
                    FirstName = "Ahmed",
                    LastName="Ali",
                    CollegeRollNo="541",
                    RegistrationNo="2021gsr444",
                    UniversityRollNo="070945",
                    Section="G1",
                    Session="20212025",
                    Email = "aali@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 5,
                    FirstName = "Asad",
                    LastName="Mojenzo",
                    CollegeRollNo="542",
                    RegistrationNo="2021gsr445",
                    UniversityRollNo="070946",
                    Section="G1",
                    Session="20212025",
                    Email = "asad@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 6,
                    FirstName = "Ahsan",
                    LastName="Dildar",
                    CollegeRollNo="543",
                    RegistrationNo="2021gsr446",
                    UniversityRollNo="070947",
                    Section="G1",
                    Session="20212025",
                    Email = "adildar@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 7,
                    FirstName = "Minal",
                    LastName="Asgher",
                    CollegeRollNo="544",
                    RegistrationNo="2021gsr447",
                    UniversityRollNo="070948",
                    Section="G1",
                    Session="20212025",
                    Email = "masgher@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 8,
                    FirstName = "Wajeeha",
                    LastName="Maqsood",
                    CollegeRollNo="545",
                    RegistrationNo="2021gsr448",
                    UniversityRollNo="070949",
                    Section="G1",
                    Session="20212025",
                    Email = "wmaqsood@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 9,
                    FirstName = "Mahnoor",
                    LastName="Aqdas",
                    CollegeRollNo="546",
                    RegistrationNo="2021gsr449",
                    UniversityRollNo="070950",
                    Section="G1",
                    Session="20212025",
                    Email = "maqdas@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 10,
                    FirstName = "Nasir",
                    LastName="Aslam",
                    CollegeRollNo="547",
                    RegistrationNo="2021gsr450",
                    UniversityRollNo="070951",
                    Section="G1",
                    Session="20212025",
                    Email = "naslam@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 11,
                    FirstName = "Mehrooz",
                    LastName="Atif",
                    CollegeRollNo="548",
                    RegistrationNo="2021gsr451",
                    UniversityRollNo="070952",
                    Section="G1",
                    Session="20212025",
                    Email = "matif@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 12,
                    FirstName = "Akther",
                    LastName="Ali",
                    CollegeRollNo="549",
                    RegistrationNo="2021gsr452",
                    UniversityRollNo="070953",
                    Section="G1",
                    Session="20212025",
                    Email = "aali@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 13,
                    FirstName = "Adeel",
                    LastName="Abbas",
                    CollegeRollNo="550",
                    RegistrationNo="2021gsr453",
                    UniversityRollNo="070954",
                    Section="G1",
                    Session="20212025",
                    Email = "aabbas@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 14,
                    FirstName = "Rohan",
                    LastName="Shahmeer",
                    CollegeRollNo="551",
                    RegistrationNo="2021gsr454",
                    UniversityRollNo="070955",
                    Section="G1",
                    Session="20212025",
                    Email = "rshahmeer@gmail.com",
                    IsDeleted = false
                },
                new Student() {
                    StudentId = 15,
                    FirstName = "Amber",
                    LastName="Shamraiz",
                    CollegeRollNo="552",
                    RegistrationNo="2021gsr455",
                    UniversityRollNo="070956",
                    Section="G1",
                    Session="20212025",
                    Email = "ashamraiz@gmail.com",
                    IsDeleted = false
                },
            });


            modelBuilder.Entity<User>().HasData(new[]
            {
                new User() {
                    UserId = 1,
                    FirstName = "Zubair",
                    LastName = "Jamil",
                    Email = "markmetutor@tohru.org",
                    Password = "MarkMe@12",
                    IsDeleted = false
                },
                new User() {
                    UserId = 2,
                    FirstName = "Umair",
                    LastName = "Jamil",
                    Email = "markmeadmin@tohru.org",
                    Password = "MarkMe@12",
                    IsDeleted = false
                },
                new User() {
                    UserId = 3,
                    FirstName = "Mousa",
                    LastName = "Naeem",
                    Email = "markmecr@tohru.org",
                    Password = "MarkMe@12",
                    IsDeleted = false
                }
            });

            modelBuilder.Entity<Course>().HasData(new[]
            {
                new Course
                {
                    CourseId = 1,
                    Code = "CS101",
                    Title = "Introduction to Computing",
                    CreditHours = 120,
                    CreditHoursPerWeek = 4,
                    Semester = 1,
                    Type = CourseType.Major,
                    IsArchived = false,
                    AssignedTo = 1, // Teacher
                },
                new Course
                {
                    CourseId = 2,
                    Code = "CS102",
                    Title = "Programming Fundamentals",
                    CreditHours = 120,
                    CreditHoursPerWeek = 4,
                    Semester = 1,
                    Type = CourseType.Major,
                    IsArchived = false,
                    AssignedTo = 1, // Teacher
                },
                new Course
                {
                    CourseId = 3,
                    Code = "CS103",
                    Title = "Discrete Mathematics",
                    CreditHours = 120,
                    CreditHoursPerWeek = 4,
                    Semester = 1,
                    Type = CourseType.Major,
                    IsArchived = false,
                    AssignedTo = 1, // Teacher
                },
                new Course
                {
                    CourseId = 4,
                    Code = "CS104",
                    Title = "Calculus",
                    CreditHours = 120,
                    CreditHoursPerWeek = 4,
                    Semester = 1,
                    Type = CourseType.Major,
                    IsArchived = false,
                    AssignedTo = 1, // Teacher
                },
                new Course
                {
                    CourseId = 5,
                    Code = "CS105",
                    Title = "English",
                    CreditHours = 120,
                    CreditHoursPerWeek = 4,
                    Semester = 1,
                    Type = CourseType.Major,
                    IsArchived = false,
                    AssignedTo = 1, // Teacher
                }
            });

            //// Class Representatives
            //modelBuilder.Entity<ClassRepresentative>().HasData(new[]
            //{
            //    new ClassRepresentative
            //    {
            //        StudentId = 1,
            //        CourseId = 1,
            //        NominatedBy = 1,
            //        IsDeleted = 0
            //    },
            //    new ClassRepresentative
            //    {
            //        StudentId = 2,
            //        CourseId = 2,
            //        NominatedBy = 1,
            //        IsDeleted = 0
            //    },
            //    new ClassRepresentative
            //    {
            //        StudentId = 2,
            //        CourseId = 1,
            //        NominatedBy = 1,
            //        IsDeleted = 0
            //    },
            //    new ClassRepresentative
            //    {
            //        StudentId = 2,
            //        CourseId = 3,
            //        NominatedBy = 1,
            //        IsDeleted = 0
            //    },
            //    new ClassRepresentative
            //    {
            //        StudentId = 2,
            //        CourseId = 4,
            //        NominatedBy = 1,
            //        IsDeleted = 0
            //    },
            //    new ClassRepresentative
            //    {
            //        StudentId = 2,
            //        CourseId = 5,
            //        NominatedBy = 1,
            //        IsDeleted = 0
            //    },
            //    new ClassRepresentative
            //    {
            //        StudentId = 3,
            //        CourseId = 3,
            //        NominatedBy = 1,
            //        IsDeleted = 0
            //    },
            //    new ClassRepresentative
            //    {
            //        StudentId = 4,
            //        CourseId = 4,
            //        NominatedBy = 1,
            //        IsDeleted = 0
            //    },
            //    new ClassRepresentative
            //    {
            //        StudentId = 5,
            //        CourseId = 5,
            //        NominatedBy = 1,
            //        IsDeleted = 0
            //    },
            //    new ClassRepresentative
            //    {
            //        StudentId = 6,
            //        CourseId = 1,
            //        NominatedBy = 1,
            //        IsDeleted = 0
            //    },
            //    new ClassRepresentative
            //    {
            //        StudentId = 7,
            //        CourseId = 2,
            //        NominatedBy = 1,
            //        IsDeleted = 0,
            //    }
            //});

            // Activities
            modelBuilder.Entity<Activity>().HasData(new[]
            {
                new Activity
                {
                    ActivityId = 1,
                    ClassRepresentativeStudentId = 1,
                    ClassRepresentativeCourseId = 1,
                    Description = "Marked Attendance for Introduction to Computing",
                    Date = new DateTime(2024, 1, 1, 12,3,11),
                },
                new Activity
                {
                    ActivityId = 2,
                    ClassRepresentativeStudentId = 2,
                    ClassRepresentativeCourseId = 2,
                    Description = "Marked Attendance for Programming Fundamentals",
                    Date = new DateTime(2024, 1, 2, 12,3,11),
                },
                new Activity
                {
                    ActivityId = 3,
                    ClassRepresentativeStudentId = 3,
                    ClassRepresentativeCourseId = 3,
                    Description = "Marked Attendance for Discrete Mathematics",
                    Date = new DateTime(2024, 1, 3, 12,3,11),
                },
                new Activity
                {
                    ActivityId = 4,
                    ClassRepresentativeStudentId = 4,
                    ClassRepresentativeCourseId = 4,
                    Description = "Marked Attendance for Calculus",
                    Date = new DateTime(2024, 1, 4, 12,3,11),
                },
                new Activity
                {
                    ActivityId = 5,
                    ClassRepresentativeStudentId = 5,
                    ClassRepresentativeCourseId = 5,
                    Description = "Marked Attendance for English",
                    Date = new DateTime(2024, 1, 6, 12,3,11),
                },
                new Activity
                {
                    ActivityId = 6,
                    ClassRepresentativeStudentId = 1,
                    ClassRepresentativeCourseId = 1,
                    Description = "Marked Attendance for Introduction to Computing",
                    Date = new DateTime(2024, 1, 1, 12,3,11),
                },
                new Activity
                {
                    ActivityId = 7,
                    ClassRepresentativeStudentId = 2,
                    ClassRepresentativeCourseId = 2,
                    Description = "Marked Attendance for Programming Fundamentals",
                    Date = new DateTime(2024, 1, 5, 12,3,11),
                },
                new Activity
                {
                    ActivityId = 8,
                    ClassRepresentativeStudentId = 3,
                    ClassRepresentativeCourseId = 3,
                    Description = "Marked Attendance for Discrete Mathematics",
                    Date = new DateTime(2024, 1, 1, 12,3,11),
                },
                new Activity
                {
                    ActivityId = 9,
                    ClassRepresentativeStudentId = 4,
                    ClassRepresentativeCourseId = 4,
                    Description = "Marked Attendance for Calculus",
                    Date = new DateTime(2024, 1, 6, 12,3,11),
                },
                new Activity
                {
                    ActivityId = 10,
                    ClassRepresentativeStudentId = 5,
                    ClassRepresentativeCourseId = 5,
                    Description = "Marked Attendance for English",
                    Date = new DateTime(2024, 1, 6, 12,3,11),
                },
                new Activity
                {
                    ActivityId = 11,
                    ClassRepresentativeStudentId = 6,
                    ClassRepresentativeCourseId = 1,
                    Description = "Marked Attendance for Introduction to Computing",
                    Date = new DateTime(2024, 1, 1, 12,3,11),
                },
                new Activity
                {
                    ActivityId = 12,
                    ClassRepresentativeStudentId = 7,
                    ClassRepresentativeCourseId = 2,
                    Description = "Marked Attendance for Programming Fundamentals",
                    Date = new DateTime(2024, 1, 5, 12,3,11),
                }
            });

            // Attendence
            modelBuilder.Entity<Attendance>().HasData(new[]
            {
                new Attendance
                {
                    AttendanceId = 1,
                    StudentId = 1,
                    CourseId = 1,
                    DateMarked = new DateTime(2024, 1, 1, 12,3,11),
                    MarkedBy = 1,
                    Status = AttendanceStatus.Present
                },
                new Attendance
                {
                    AttendanceId = 2,
                    StudentId = 2,
                    CourseId = 1,
                    DateMarked = new DateTime(2024, 1, 2, 12,3,11),
                    MarkedBy = 1,
                    Status = AttendanceStatus.Present
                },
                new Attendance
                {
                    AttendanceId = 3,
                    StudentId = 3,
                    CourseId = 1,
                    DateMarked = new DateTime(2024, 1, 3, 12,3,11),
                    MarkedBy = 2,
                    Status = AttendanceStatus.Present
                },
                new Attendance
                {
                    AttendanceId = 4,
                    StudentId = 4,
                    CourseId = 2,
                    DateMarked = new DateTime(2024, 1, 4, 12,3,11),
                    MarkedBy = 2,
                    Status = AttendanceStatus.Late
                },
                new Attendance
                {
                    AttendanceId = 5,
                    StudentId = 5,
                    CourseId = 1,
                    DateMarked = new DateTime(2024, 1, 5, 12,3,11),
                    MarkedBy = 1,
                    Status = AttendanceStatus.Late
                },
                new Attendance
                {
                    AttendanceId = 6,
                    StudentId = 4,
                    CourseId = 1,
                    DateMarked = new DateTime(2024, 1, 4, 12,3,11),
                    MarkedBy = 2,
                    Status = AttendanceStatus.Absent
                },
                new Attendance
                {
                    AttendanceId = 7,
                    StudentId = 5,
                    CourseId = 2,
                    DateMarked = new DateTime(2024, 1, 5, 12,3,11),
                    MarkedBy = 1,
                    Status = AttendanceStatus.Absent
                },
            });

            // Insert Menus
            modelBuilder.Entity<Menu>().HasData(new[]
            {
                new Menu { MenuId = 1, Label = "Mark Attendance", Url = "attendance", Role = Role.Admin },
                new Menu { MenuId = 2, Label = "Export/Share", Url = "export", Role = Role.Admin },
                new Menu { MenuId = 3, Label = "Courses", Url = "courses", Role = Role.Admin },
                new Menu { MenuId = 4, Label = "Students", Url = "students", Role = Role.Admin },
                new Menu { MenuId = 5, Label = "Class Representative", Url = "class-representatives", Role = Role.Admin },
                new Menu { MenuId = 6, Label = "Auto Mark", Url = "automark", Role = Role.Admin },

                new Menu { MenuId = 7, Label = "Mark Attendance", Url = "attendance", Role = Role.Tutor },
                new Menu { MenuId = 8, Label = "Export/Share", Url = "export", Role = Role.Tutor },
                new Menu { MenuId = 9, Label = "Courses", Url = "courses", Role = Role.Tutor },
                new Menu { MenuId = 10, Label = "Students", Url = "students", Role = Role.Tutor },
                new Menu { MenuId = 11, Label = "Class Representative", Url = "class-representatives", Role = Role.Tutor },
                new Menu { MenuId = 12, Label = "Auto Mark", Url = "automark", Role = Role.Tutor },

                new Menu { MenuId = 13, Label = "Mark Attendance", Url = "attendance", Role = Role.CR },
                new Menu { MenuId = 14, Label = "Export/Share", Url = "export", Role = Role.CR },
                new Menu { MenuId = 15, Label = "Auto Mark", Url = "automark", Role = Role.CR },

                // For Readonly Purposes
                new Menu { MenuId = 16, Label = "Export/Share", Url = "export", Role = Role.Member },
                new Menu { MenuId = 17, Label = "Courses", Url = "courses", Role = Role.Member },
                new Menu { MenuId = 18, Label = "Students", Url = "students", Role = Role.Member },
                new Menu { MenuId = 19, Label = "Class Representative", Url = "class-representatives", Role = Role.Member },
            });
        }
    }
}
