﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oasis.Data;

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

            modelBuilder.Entity("Oasis.Data.Models.Amenity", b =>
                {
                    b.Property<int>("amenity_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("amenity_id");

                    b.Property<string>("amenity_name")
                        .HasColumnType("TEXT")
                        .HasColumnName("amenity_name");

                    b.Property<float?>("amenity_price")
                        .HasColumnType("REAL")
                        .HasColumnName("amenity_price");

                    b.HasKey("amenity_id");

                    b.ToTable("Amenity", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.Discount", b =>
                {
                    b.Property<int>("discount_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("discount_id");

                    b.Property<string>("discount_name")
                        .HasColumnType("TEXT")
                        .HasColumnName("discount_name");

                    b.Property<double?>("discount_rate")
                        .HasColumnType("REAL")
                        .HasColumnName("discount_rate");

                    b.HasKey("discount_id");

                    b.ToTable("Discount", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.Guest", b =>
                {
                    b.Property<int>("guest_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("guest_id");

                    b.Property<DateTime?>("registration_date")
                        .HasColumnType("TEXT")
                        .HasColumnName("registration_date");

                    b.HasKey("guest_id");

                    b.ToTable("Guest", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.HouseKeeping", b =>
                {
                    b.Property<int>("housekeeping_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("house_keeping_id");

                    b.Property<DateTime?>("housekeeping_date")
                        .HasColumnType("TEXT")
                        .HasColumnName("house_keeping_date");

                    b.Property<int?>("room_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("room_id");

                    b.Property<int?>("staff_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("staff_id");

                    b.HasKey("housekeeping_id");

                    b.HasIndex("room_id");

                    b.HasIndex("staff_id");

                    b.ToTable("HouseKeeping", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.Notification", b =>
                {
                    b.Property<int>("notif_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("notif_id");

                    b.Property<string>("notif_content")
                        .HasColumnType("TEXT")
                        .HasColumnName("notif_content");

                    b.Property<DateTime?>("notif_date")
                        .HasColumnType("TEXT")
                        .HasColumnName("notif_date");

                    b.Property<string>("notif_status")
                        .HasColumnType("TEXT")
                        .HasColumnName("notif_status");

                    b.Property<string>("notif_title")
                        .HasColumnType("TEXT")
                        .HasColumnName("notif_title");

                    b.Property<int?>("user_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.HasKey("notif_id");

                    b.HasIndex("user_id");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.Payment", b =>
                {
                    b.Property<int>("payment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("payment_id");

                    b.Property<int?>("discount_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("discount_id");

                    b.Property<double?>("payment_amount")
                        .HasColumnType("REAL")
                        .HasColumnName("payment_amount");

                    b.Property<DateTime?>("payment_date")
                        .HasColumnType("TEXT")
                        .HasColumnName("payment_date");

                    b.Property<string>("payment_method")
                        .HasColumnType("TEXT")
                        .HasColumnName("payment_method");

                    b.Property<int?>("staff_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("staff_id");

                    b.HasKey("payment_id");

                    b.HasIndex("discount_id");

                    b.HasIndex("staff_id");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.Reservation", b =>
                {
                    b.Property<int>("rsv_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("rsv_id");

                    b.Property<int?>("guest_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("guest_id");

                    b.Property<int?>("payment_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("payment_id");

                    b.Property<int?>("room_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("room_id");

                    b.Property<DateTime?>("rsv_checkin")
                        .HasColumnType("TEXT")
                        .HasColumnName("rsv_checkin");

                    b.Property<DateTime?>("rsv_checkout")
                        .HasColumnType("TEXT")
                        .HasColumnName("rsv_checkout");

                    b.Property<string>("rsv_status")
                        .HasColumnType("TEXT")
                        .HasColumnName("rsv_status");

                    b.HasKey("rsv_id");

                    b.HasIndex("guest_id");

                    b.HasIndex("room_id");

                    b.ToTable("Reservation", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.Review", b =>
                {
                    b.Property<int>("review_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("review_id");

                    b.Property<int?>("guest_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("guest_id");

                    b.Property<DateTime?>("review_date")
                        .HasColumnType("TEXT")
                        .HasColumnName("review_date");

                    b.Property<string>("review_feedback")
                        .HasColumnType("TEXT")
                        .HasColumnName("review_feedback");

                    b.Property<int?>("review_rating")
                        .HasColumnType("INTEGER")
                        .HasColumnName("review_rating");

                    b.Property<int?>("room_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("room_id");

                    b.HasKey("review_id");

                    b.HasIndex("guest_id");

                    b.HasIndex("room_id");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.Room", b =>
                {
                    b.Property<int>("room_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("room_id");

                    b.Property<int?>("guest_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("guest_id");

                    b.Property<int?>("room_no")
                        .HasColumnType("INTEGER")
                        .HasColumnName("room_no");

                    b.Property<int?>("room_status")
                        .HasColumnType("INTEGER")
                        .HasColumnName("room_status");

                    b.Property<int?>("type_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("type_id");

                    b.HasKey("room_id");

                    b.HasIndex("guest_id");

                    b.HasIndex("type_id");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.RoomType", b =>
                {
                    b.Property<int>("type_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("type_id");

                    b.Property<string>("type_category")
                        .HasColumnType("TEXT")
                        .HasColumnName("type_category");

                    b.Property<double?>("type_price")
                        .HasColumnType("REAL")
                        .HasColumnName("type_price");

                    b.HasKey("type_id");

                    b.ToTable("RoomType", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.Service", b =>
                {
                    b.Property<int>("service_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("service_id");

                    b.Property<int?>("rsv_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("rsv_id");

                    b.Property<DateTime?>("service_date")
                        .HasColumnType("TEXT")
                        .HasColumnName("service_date");

                    b.Property<int?>("staff_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("staff_id");

                    b.Property<int?>("type_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("type_id");

                    b.HasKey("service_id");

                    b.HasIndex("rsv_id");

                    b.HasIndex("staff_id");

                    b.HasIndex("type_id");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.ServiceType", b =>
                {
                    b.Property<int>("type_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("type_id");

                    b.Property<string>("type_name")
                        .HasColumnType("TEXT")
                        .HasColumnName("type_name");

                    b.Property<double?>("type_price")
                        .HasColumnType("REAL")
                        .HasColumnName("type_price");

                    b.HasKey("type_id");

                    b.ToTable("ServiceType", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.Staff", b =>
                {
                    b.Property<int>("staff_id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("staff_id");

                    b.Property<DateTime?>("employment_date")
                        .HasColumnType("TEXT")
                        .HasColumnName("employment_date");

                    b.Property<string>("position")
                        .HasColumnType("TEXT")
                        .HasColumnName("position");

                    b.HasKey("staff_id");

                    b.ToTable("Staff", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.Property<string>("user_contactno")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_contactno");

                    b.Property<DateOnly?>("user_dob")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_dob");

                    b.Property<string>("user_email")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_email");

                    b.Property<string>("user_fname")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_fname");

                    b.Property<string>("user_gender")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_gender");

                    b.Property<string>("user_lname")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_lname");

                    b.Property<string>("user_password")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_password");

                    b.Property<string>("user_type")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_type");

                    b.HasKey("user_id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Oasis.Data.Models.Guest", b =>
                {
                    b.HasOne("Oasis.Data.Models.User", "user")
                        .WithOne("guest")
                        .HasForeignKey("Oasis.Data.Models.Guest", "guest_id")
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Oasis.Data.Models.HouseKeeping", b =>
                {
                    b.HasOne("Oasis.Data.Models.Room", "room")
                        .WithMany("housekeeping")
                        .HasForeignKey("room_id");

                    b.HasOne("Oasis.Data.Models.Staff", "staff")
                        .WithMany("housekeeping")
                        .HasForeignKey("staff_id");

                    b.Navigation("room");

                    b.Navigation("staff");
                });

            modelBuilder.Entity("Oasis.Data.Models.Notification", b =>
                {
                    b.HasOne("Oasis.Data.Models.User", "user")
                        .WithMany("notification")
                        .HasForeignKey("user_id");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Oasis.Data.Models.Payment", b =>
                {
                    b.HasOne("Oasis.Data.Models.Discount", "discount")
                        .WithMany("payment")
                        .HasForeignKey("discount_id");

                    b.HasOne("Oasis.Data.Models.Staff", "staff")
                        .WithMany("payment")
                        .HasForeignKey("staff_id");

                    b.Navigation("discount");

                    b.Navigation("staff");
                });

            modelBuilder.Entity("Oasis.Data.Models.Reservation", b =>
                {
                    b.HasOne("Oasis.Data.Models.Guest", "guest")
                        .WithMany("reservation")
                        .HasForeignKey("guest_id");

                    b.HasOne("Oasis.Data.Models.Room", "room")
                        .WithMany("reservation")
                        .HasForeignKey("room_id");

                    b.Navigation("guest");

                    b.Navigation("room");
                });

            modelBuilder.Entity("Oasis.Data.Models.Review", b =>
                {
                    b.HasOne("Oasis.Data.Models.Guest", "guest")
                        .WithMany("review")
                        .HasForeignKey("guest_id");

                    b.HasOne("Oasis.Data.Models.Room", "room")
                        .WithMany("review")
                        .HasForeignKey("room_id");

                    b.Navigation("guest");

                    b.Navigation("room");
                });

            modelBuilder.Entity("Oasis.Data.Models.Room", b =>
                {
                    b.HasOne("Oasis.Data.Models.Guest", "guest")
                        .WithMany("room")
                        .HasForeignKey("guest_id");

                    b.HasOne("Oasis.Data.Models.RoomType", "roomtype")
                        .WithMany("room")
                        .HasForeignKey("type_id");

                    b.Navigation("guest");

                    b.Navigation("roomtype");
                });

            modelBuilder.Entity("Oasis.Data.Models.Service", b =>
                {
                    b.HasOne("Oasis.Data.Models.Reservation", "reservation")
                        .WithMany("service")
                        .HasForeignKey("rsv_id");

                    b.HasOne("Oasis.Data.Models.Staff", "staff")
                        .WithMany("service")
                        .HasForeignKey("staff_id");

                    b.HasOne("Oasis.Data.Models.ServiceType", "servicetype")
                        .WithMany("service")
                        .HasForeignKey("type_id");

                    b.Navigation("reservation");

                    b.Navigation("servicetype");

                    b.Navigation("staff");
                });

            modelBuilder.Entity("Oasis.Data.Models.Staff", b =>
                {
                    b.HasOne("Oasis.Data.Models.User", "user")
                        .WithOne("staff")
                        .HasForeignKey("Oasis.Data.Models.Staff", "staff_id")
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Oasis.Data.Models.Discount", b =>
                {
                    b.Navigation("payment");
                });

            modelBuilder.Entity("Oasis.Data.Models.Guest", b =>
                {
                    b.Navigation("reservation");

                    b.Navigation("review");

                    b.Navigation("room");
                });

            modelBuilder.Entity("Oasis.Data.Models.Reservation", b =>
                {
                    b.Navigation("service");
                });

            modelBuilder.Entity("Oasis.Data.Models.Room", b =>
                {
                    b.Navigation("housekeeping");

                    b.Navigation("reservation");

                    b.Navigation("review");
                });

            modelBuilder.Entity("Oasis.Data.Models.RoomType", b =>
                {
                    b.Navigation("room");
                });

            modelBuilder.Entity("Oasis.Data.Models.ServiceType", b =>
                {
                    b.Navigation("service");
                });

            modelBuilder.Entity("Oasis.Data.Models.Staff", b =>
                {
                    b.Navigation("housekeeping");

                    b.Navigation("payment");

                    b.Navigation("service");
                });

            modelBuilder.Entity("Oasis.Data.Models.User", b =>
                {
                    b.Navigation("guest");

                    b.Navigation("notification");

                    b.Navigation("staff");
                });
#pragma warning restore 612, 618
        }
    }
}
