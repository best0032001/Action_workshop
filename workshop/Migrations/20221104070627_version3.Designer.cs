﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using workshop.Model;

#nullable disable

namespace workshop.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221104070627_version3")]
    partial class version3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ContosoUniversity.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ContosoUniversity.Models.CourseAssignment", b =>
                {
                    b.Property<int>("CourseAssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseAssignmentID"), 1L, 1);

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("InstructorID")
                        .HasColumnType("int");

                    b.HasKey("CourseAssignmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("InstructorID");

                    b.ToTable("CourseAssignments");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"), 1L, 1);

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<int?>("InstructorID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DepartmentID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentID"), 1L, 1);

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("ContosoUniversity.Models.OfficeAssignment", b =>
                {
                    b.Property<int>("InstructorID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InstructorID");

                    b.ToTable("OfficeAssignments");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("workshop.Model.Entitys.UserEntity", b =>
                {
                    b.Property<int>("UserEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserEntityId"), 1L, 1);

                    b.Property<string>("Access_token")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AdminApproved")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AdminApprovedIP")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AdminDeactivate")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AdminDeactivateIP")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AdminNotApproved")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AdminNotApprovedIP")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AdminReactivate")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AdminReactivateIP")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("ApprovedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommetNotApproved")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("ConfirmEmailTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ConfirmKYCTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ConfirmPersonalIDTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ConfirmTelTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeactivateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EmailOTP")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("EmailOTPRef")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Expires_in")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("IsConfirmEmail")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmKYC")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmPersonalID")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmTel")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeactivate")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReactivate")
                        .HasColumnType("bit");

                    b.Property<string>("LineId")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("NotApprovedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Organization_Code")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Organization_Name_TH")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("PersonalID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReactivateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Refresh_token")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("SMSExpire")
                        .HasColumnType("datetime2");

                    b.Property<string>("SMSOTP")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("SMSOTPRef")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestCol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCode")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserStage")
                        .HasColumnType("int");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("dbPathFace")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("dbPathKYC")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("dbPathPersonalID")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("faceData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fileNameFace")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fileNameKYC")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fileNamePersonalID")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fullPathFace")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fullPathKYC")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("fullPathPersonalID")
                        .HasColumnType("varchar(100)");

                    b.HasKey("UserEntityId");

                    b.ToTable("UserEntitys");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Instructor", b =>
                {
                    b.HasBaseType("ContosoUniversity.Models.Person");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Instructor");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Student", b =>
                {
                    b.HasBaseType("ContosoUniversity.Models.Person");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Course", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ContosoUniversity.Models.CourseAssignment", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Course", "Course")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContosoUniversity.Models.Instructor", "Instructor")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Department", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Instructor", "Administrator")
                        .WithMany()
                        .HasForeignKey("InstructorID");

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Enrollment", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContosoUniversity.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ContosoUniversity.Models.OfficeAssignment", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Instructor", "Instructor")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("ContosoUniversity.Models.OfficeAssignment", "InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Course", b =>
                {
                    b.Navigation("CourseAssignments");

                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Instructor", b =>
                {
                    b.Navigation("CourseAssignments");

                    b.Navigation("OfficeAssignment");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
