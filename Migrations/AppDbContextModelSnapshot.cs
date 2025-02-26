﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Oasis.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("Oasis.Data.Models.Guest", b =>
                {
                    b.Property<int>("guest_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("guest_contactno")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("guest_dob")
                        .HasColumnType("TEXT");

                    b.Property<string>("guest_email")
                        .HasColumnType("TEXT");

                    b.Property<string>("guest_fname")
                        .HasColumnType("TEXT");

                    b.Property<string>("guest_gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("guest_lname")
                        .HasColumnType("TEXT");

                    b.Property<string>("guest_password")
                        .HasColumnType("TEXT");

                    b.HasKey("guest_id");

                    b.ToTable("Guest");
                });
#pragma warning restore 612, 618
        }
    }
}
