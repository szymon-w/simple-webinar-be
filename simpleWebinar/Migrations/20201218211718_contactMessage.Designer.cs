﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using simpleWebinar.Models;

namespace simpleWebinar.Migrations
{
    [DbContext(typeof(SimpleWebinarDbContext))]
    [Migration("20201218211718_contactMessage")]
    partial class contactMessage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("simpleWebinar.Models.ContactMessage", b =>
                {
                    b.Property<int>("IdMessage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMessage");

                    b.ToTable("ContactMessages");
                });

            modelBuilder.Entity("simpleWebinar.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTeacher")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("simpleWebinar.Models.UserWebinar", b =>
                {
                    b.Property<int>("IdUserWebinar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdWebinar")
                        .HasColumnType("int");

                    b.Property<int?>("Note")
                        .HasColumnType("int");

                    b.HasKey("IdUserWebinar");

                    b.HasIndex("IdWebinar");

                    b.HasIndex("IdUser", "IdWebinar")
                        .IsUnique();

                    b.ToTable("UserWebinars");
                });

            modelBuilder.Entity("simpleWebinar.Models.Webinar", b =>
                {
                    b.Property<int>("IdWebinar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdWebinar");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("IdUser");

                    b.ToTable("Webinars");
                });

            modelBuilder.Entity("simpleWebinar.Models.UserWebinar", b =>
                {
                    b.HasOne("simpleWebinar.Models.User", "User")
                        .WithMany("UserWebinars")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("simpleWebinar.Models.Webinar", "Webinar")
                        .WithMany("UserWebinars")
                        .HasForeignKey("IdWebinar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("simpleWebinar.Models.Webinar", b =>
                {
                    b.HasOne("simpleWebinar.Models.User", "User")
                        .WithMany("Webinars")
                        .HasForeignKey("IdUser");
                });
#pragma warning restore 612, 618
        }
    }
}
