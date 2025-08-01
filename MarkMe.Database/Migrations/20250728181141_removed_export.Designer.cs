﻿// <auto-generated />
using System;
using MarkMe.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarkMe.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250728181141_removed_export")]
    partial class removed_export
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MarkMe.Database.Entities.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityId"));

                    b.Property<int>("ClassRepresentativeCourseId")
                        .HasColumnType("int");

                    b.Property<int>("ClassRepresentativeStudentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActivityId");

                    b.HasIndex("ClassRepresentativeStudentId", "ClassRepresentativeCourseId");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            ActivityId = 1,
                            ClassRepresentativeCourseId = 1,
                            ClassRepresentativeStudentId = 1,
                            Date = new DateTime(2024, 1, 1, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            Description = "Marked Attendance for Introduction to Computing"
                        },
                        new
                        {
                            ActivityId = 2,
                            ClassRepresentativeCourseId = 2,
                            ClassRepresentativeStudentId = 2,
                            Date = new DateTime(2024, 1, 2, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            Description = "Marked Attendance for Programming Fundamentals"
                        },
                        new
                        {
                            ActivityId = 3,
                            ClassRepresentativeCourseId = 3,
                            ClassRepresentativeStudentId = 3,
                            Date = new DateTime(2024, 1, 3, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            Description = "Marked Attendance for Discrete Mathematics"
                        },
                        new
                        {
                            ActivityId = 4,
                            ClassRepresentativeCourseId = 4,
                            ClassRepresentativeStudentId = 4,
                            Date = new DateTime(2024, 1, 4, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            Description = "Marked Attendance for Calculus"
                        },
                        new
                        {
                            ActivityId = 5,
                            ClassRepresentativeCourseId = 5,
                            ClassRepresentativeStudentId = 5,
                            Date = new DateTime(2024, 1, 6, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            Description = "Marked Attendance for English"
                        },
                        new
                        {
                            ActivityId = 6,
                            ClassRepresentativeCourseId = 1,
                            ClassRepresentativeStudentId = 1,
                            Date = new DateTime(2024, 1, 1, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            Description = "Marked Attendance for Introduction to Computing"
                        },
                        new
                        {
                            ActivityId = 7,
                            ClassRepresentativeCourseId = 2,
                            ClassRepresentativeStudentId = 2,
                            Date = new DateTime(2024, 1, 5, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            Description = "Marked Attendance for Programming Fundamentals"
                        },
                        new
                        {
                            ActivityId = 8,
                            ClassRepresentativeCourseId = 3,
                            ClassRepresentativeStudentId = 3,
                            Date = new DateTime(2024, 1, 1, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            Description = "Marked Attendance for Discrete Mathematics"
                        },
                        new
                        {
                            ActivityId = 9,
                            ClassRepresentativeCourseId = 4,
                            ClassRepresentativeStudentId = 4,
                            Date = new DateTime(2024, 1, 6, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            Description = "Marked Attendance for Calculus"
                        },
                        new
                        {
                            ActivityId = 10,
                            ClassRepresentativeCourseId = 5,
                            ClassRepresentativeStudentId = 5,
                            Date = new DateTime(2024, 1, 6, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            Description = "Marked Attendance for English"
                        },
                        new
                        {
                            ActivityId = 11,
                            ClassRepresentativeCourseId = 1,
                            ClassRepresentativeStudentId = 6,
                            Date = new DateTime(2024, 1, 1, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            Description = "Marked Attendance for Introduction to Computing"
                        },
                        new
                        {
                            ActivityId = 12,
                            ClassRepresentativeCourseId = 2,
                            ClassRepresentativeStudentId = 7,
                            Date = new DateTime(2024, 1, 5, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            Description = "Marked Attendance for Programming Fundamentals"
                        });
                });

            modelBuilder.Entity("MarkMe.Database.Entities.Attendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendanceId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateMarked")
                        .HasColumnType("datetime2");

                    b.Property<int>("MarkedBy")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("AttendanceId");

                    b.ToTable("Attendances");

                    b.HasData(
                        new
                        {
                            AttendanceId = 1,
                            CourseId = 1,
                            DateMarked = new DateTime(2024, 1, 1, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            MarkedBy = 1,
                            Status = 2,
                            StudentId = 1
                        },
                        new
                        {
                            AttendanceId = 2,
                            CourseId = 1,
                            DateMarked = new DateTime(2024, 1, 2, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            MarkedBy = 1,
                            Status = 2,
                            StudentId = 2
                        },
                        new
                        {
                            AttendanceId = 3,
                            CourseId = 1,
                            DateMarked = new DateTime(2024, 1, 3, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            MarkedBy = 2,
                            Status = 2,
                            StudentId = 3
                        },
                        new
                        {
                            AttendanceId = 4,
                            CourseId = 2,
                            DateMarked = new DateTime(2024, 1, 4, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            MarkedBy = 2,
                            Status = 4,
                            StudentId = 4
                        },
                        new
                        {
                            AttendanceId = 5,
                            CourseId = 1,
                            DateMarked = new DateTime(2024, 1, 5, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            MarkedBy = 1,
                            Status = 4,
                            StudentId = 5
                        },
                        new
                        {
                            AttendanceId = 6,
                            CourseId = 1,
                            DateMarked = new DateTime(2024, 1, 4, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            MarkedBy = 2,
                            Status = 1,
                            StudentId = 4
                        },
                        new
                        {
                            AttendanceId = 7,
                            CourseId = 2,
                            DateMarked = new DateTime(2024, 1, 5, 12, 3, 11, 0, DateTimeKind.Unspecified),
                            MarkedBy = 1,
                            Status = 1,
                            StudentId = 5
                        });
                });

            modelBuilder.Entity("MarkMe.Database.Entities.ClassRepresentative", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<int>("NominatedBy")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId");

                    b.ToTable("ClassRepresentatives");
                });

            modelBuilder.Entity("MarkMe.Database.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<int>("AssignedTo")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("CreditHours")
                        .HasColumnType("int");

                    b.Property<int>("CreditHoursPerWeek")
                        .HasColumnType("int");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            AssignedTo = 1,
                            Code = "CS101",
                            CreditHours = 120,
                            CreditHoursPerWeek = 4,
                            IsArchived = false,
                            Semester = 1,
                            Title = "Introduction to Computing",
                            Type = 1
                        },
                        new
                        {
                            CourseId = 2,
                            AssignedTo = 1,
                            Code = "CS102",
                            CreditHours = 120,
                            CreditHoursPerWeek = 4,
                            IsArchived = false,
                            Semester = 1,
                            Title = "Programming Fundamentals",
                            Type = 1
                        },
                        new
                        {
                            CourseId = 3,
                            AssignedTo = 1,
                            Code = "CS103",
                            CreditHours = 120,
                            CreditHoursPerWeek = 4,
                            IsArchived = false,
                            Semester = 1,
                            Title = "Discrete Mathematics",
                            Type = 1
                        },
                        new
                        {
                            CourseId = 4,
                            AssignedTo = 1,
                            Code = "CS104",
                            CreditHours = 120,
                            CreditHoursPerWeek = 4,
                            IsArchived = false,
                            Semester = 1,
                            Title = "Calculus",
                            Type = 1
                        },
                        new
                        {
                            CourseId = 5,
                            AssignedTo = 1,
                            Code = "CS105",
                            CreditHours = 120,
                            CreditHoursPerWeek = 4,
                            IsArchived = false,
                            Semester = 1,
                            Title = "English",
                            Type = 1
                        });
                });

            modelBuilder.Entity("MarkMe.Database.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MarkMe.Database.Entities.Enrolment", b =>
                {
                    b.Property<int>("EnrolmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrolmentId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("EnrolmentId");

                    b.ToTable("Enrolments");
                });

            modelBuilder.Entity("MarkMe.Database.Entities.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            MenuId = 1,
                            Label = "Mark Attendance",
                            Role = 0,
                            Url = "attendance"
                        },
                        new
                        {
                            MenuId = 2,
                            Label = "Courses",
                            Role = 0,
                            Url = "courses"
                        },
                        new
                        {
                            MenuId = 3,
                            Label = "Students",
                            Role = 0,
                            Url = "students"
                        },
                        new
                        {
                            MenuId = 4,
                            Label = "Class Representative",
                            Role = 0,
                            Url = "class-representatives"
                        },
                        new
                        {
                            MenuId = 5,
                            Label = "Auto Mark",
                            Role = 0,
                            Url = "automark"
                        },
                        new
                        {
                            MenuId = 6,
                            Label = "Chatbot",
                            Role = 0,
                            Url = "chatbot"
                        },
                        new
                        {
                            MenuId = 7,
                            Label = "Mark Attendance",
                            Role = 1,
                            Url = "attendance"
                        },
                        new
                        {
                            MenuId = 8,
                            Label = "Courses",
                            Role = 1,
                            Url = "courses"
                        },
                        new
                        {
                            MenuId = 9,
                            Label = "Students",
                            Role = 1,
                            Url = "students"
                        },
                        new
                        {
                            MenuId = 10,
                            Label = "Class Representative",
                            Role = 1,
                            Url = "class-representatives"
                        },
                        new
                        {
                            MenuId = 11,
                            Label = "Auto Mark",
                            Role = 1,
                            Url = "automark"
                        },
                        new
                        {
                            MenuId = 12,
                            Label = "Chatbot",
                            Role = 1,
                            Url = "chatbot"
                        },
                        new
                        {
                            MenuId = 13,
                            Label = "Mark Attendance",
                            Role = 2,
                            Url = "attendance"
                        },
                        new
                        {
                            MenuId = 14,
                            Label = "Auto Mark",
                            Role = 2,
                            Url = "automark"
                        },
                        new
                        {
                            MenuId = 15,
                            Label = "Chatbot",
                            Role = 2,
                            Url = "chatbot"
                        },
                        new
                        {
                            MenuId = 16,
                            Label = "Courses",
                            Role = 3,
                            Url = "courses"
                        },
                        new
                        {
                            MenuId = 17,
                            Label = "Students",
                            Role = 3,
                            Url = "students"
                        },
                        new
                        {
                            MenuId = 18,
                            Label = "Class Representative",
                            Role = 3,
                            Url = "class-representatives"
                        });
                });

            modelBuilder.Entity("MarkMe.Database.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("CollegeRollNo")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegistrationNo")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Session")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("UniversityRollNo")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("StudentId");

                    b.HasIndex("CollegeRollNo")
                        .IsUnique();

                    b.HasIndex("RegistrationNo")
                        .IsUnique();

                    b.HasIndex("UniversityRollNo")
                        .IsUnique();

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            CollegeRollNo = "501",
                            Email = "mnaeem@gmail.com",
                            FirstName = "Mousa",
                            IsDeleted = false,
                            LastName = "Naeem",
                            RegistrationNo = "2021gsr407",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070982"
                        },
                        new
                        {
                            StudentId = 2,
                            CollegeRollNo = "539",
                            Email = "asattar@gmail.com",
                            FirstName = "Aftab",
                            IsDeleted = false,
                            LastName = "Sattar",
                            RegistrationNo = "2021gsr442",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070943"
                        },
                        new
                        {
                            StudentId = 3,
                            CollegeRollNo = "540",
                            Email = "asenior@gmail.com",
                            FirstName = "Ali",
                            IsDeleted = false,
                            LastName = "Senior",
                            RegistrationNo = "2021gsr443",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070944"
                        },
                        new
                        {
                            StudentId = 4,
                            CollegeRollNo = "541",
                            Email = "aali@gmail.com",
                            FirstName = "Ahmed",
                            IsDeleted = false,
                            LastName = "Ali",
                            RegistrationNo = "2021gsr444",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070945"
                        },
                        new
                        {
                            StudentId = 5,
                            CollegeRollNo = "542",
                            Email = "asad@gmail.com",
                            FirstName = "Asad",
                            IsDeleted = false,
                            LastName = "Mojenzo",
                            RegistrationNo = "2021gsr445",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070946"
                        },
                        new
                        {
                            StudentId = 6,
                            CollegeRollNo = "543",
                            Email = "adildar@gmail.com",
                            FirstName = "Ahsan",
                            IsDeleted = false,
                            LastName = "Dildar",
                            RegistrationNo = "2021gsr446",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070947"
                        },
                        new
                        {
                            StudentId = 7,
                            CollegeRollNo = "544",
                            Email = "masgher@gmail.com",
                            FirstName = "Minal",
                            IsDeleted = false,
                            LastName = "Asgher",
                            RegistrationNo = "2021gsr447",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070948"
                        },
                        new
                        {
                            StudentId = 8,
                            CollegeRollNo = "545",
                            Email = "wmaqsood@gmail.com",
                            FirstName = "Wajeeha",
                            IsDeleted = false,
                            LastName = "Maqsood",
                            RegistrationNo = "2021gsr448",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070949"
                        },
                        new
                        {
                            StudentId = 9,
                            CollegeRollNo = "546",
                            Email = "maqdas@gmail.com",
                            FirstName = "Mahnoor",
                            IsDeleted = false,
                            LastName = "Aqdas",
                            RegistrationNo = "2021gsr449",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070950"
                        },
                        new
                        {
                            StudentId = 10,
                            CollegeRollNo = "547",
                            Email = "naslam@gmail.com",
                            FirstName = "Nasir",
                            IsDeleted = false,
                            LastName = "Aslam",
                            RegistrationNo = "2021gsr450",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070951"
                        },
                        new
                        {
                            StudentId = 11,
                            CollegeRollNo = "548",
                            Email = "matif@gmail.com",
                            FirstName = "Mehrooz",
                            IsDeleted = false,
                            LastName = "Atif",
                            RegistrationNo = "2021gsr451",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070952"
                        },
                        new
                        {
                            StudentId = 12,
                            CollegeRollNo = "549",
                            Email = "aali@gmail.com",
                            FirstName = "Akther",
                            IsDeleted = false,
                            LastName = "Ali",
                            RegistrationNo = "2021gsr452",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070953"
                        },
                        new
                        {
                            StudentId = 13,
                            CollegeRollNo = "550",
                            Email = "aabbas@gmail.com",
                            FirstName = "Adeel",
                            IsDeleted = false,
                            LastName = "Abbas",
                            RegistrationNo = "2021gsr453",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070954"
                        },
                        new
                        {
                            StudentId = 14,
                            CollegeRollNo = "551",
                            Email = "rshahmeer@gmail.com",
                            FirstName = "Rohan",
                            IsDeleted = false,
                            LastName = "Shahmeer",
                            RegistrationNo = "2021gsr454",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070955"
                        },
                        new
                        {
                            StudentId = 15,
                            CollegeRollNo = "552",
                            Email = "ashamraiz@gmail.com",
                            FirstName = "Amber",
                            IsDeleted = false,
                            LastName = "Shamraiz",
                            RegistrationNo = "2021gsr455",
                            Section = "G1",
                            Session = "20212025",
                            UniversityRollNo = "070956"
                        });
                });

            modelBuilder.Entity("MarkMe.Database.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "markmetutor@tohru.org",
                            FirstName = "Zubair",
                            IsDeleted = false,
                            LastName = "Jamil",
                            Password = "MarkMe@12"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "markmeadmin@tohru.org",
                            FirstName = "Umair",
                            IsDeleted = false,
                            LastName = "Jamil",
                            Password = "MarkMe@12"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "markmecr@tohru.org",
                            FirstName = "Mousa",
                            IsDeleted = false,
                            LastName = "Naeem",
                            Password = "MarkMe@12"
                        });
                });

            modelBuilder.Entity("MarkMe.Database.Entities.Activity", b =>
                {
                    b.HasOne("MarkMe.Database.Entities.ClassRepresentative", null)
                        .WithMany("Activities")
                        .HasForeignKey("ClassRepresentativeStudentId", "ClassRepresentativeCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarkMe.Database.Entities.ClassRepresentative", b =>
                {
                    b.Navigation("Activities");
                });
#pragma warning restore 612, 618
        }
    }
}
