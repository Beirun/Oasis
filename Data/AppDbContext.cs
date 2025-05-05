using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Oasis.Data.Models;

namespace Oasis.Data;

public partial class AppDbContext : DbContext
{


    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Guest> Guest { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Notification> Notification { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<Room> Room { get; set; }
    public DbSet<RoomType> RoomType { get; set; }
    public DbSet<Service> Service { get; set; }
    public DbSet<ServiceType> ServiceType { get; set; }
    public DbSet<AmenityItem> AmenityItem { get; set; }
    public DbSet<Amenity> Amenity { get; set; }
    public DbSet<HouseKeeping> HouseKeeping { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AmenityItem>(entity =>
        {
            entity.HasKey(e => e.item_id);
            entity.ToTable("AmenityItem");

            entity.Property(e => e.item_id)
                .ValueGeneratedOnAdd()
                .HasColumnName("item_id");
            entity.Property(e => e.amenity_name).HasColumnName("amenity_name");
            entity.Property(e => e.amenity_price).HasColumnName("amenity_price");
            List<AmenityItem> amenityItems = new List<AmenityItem>();

            amenityItems.Add(new AmenityItem
            {
                item_id = 1,
                amenity_name = "Air Conditioning (AC)",
                amenity_price = 375
            });

            amenityItems.Add(new AmenityItem
            {
                item_id = 2,
                amenity_name = "Mini Fridge",
                amenity_price = 188
            });

            amenityItems.Add(new AmenityItem
            {
                item_id = 3,
                amenity_name = "Electric Kettle",
                amenity_price = 113
            });

            amenityItems.Add(new AmenityItem
            {
                item_id = 4,
                amenity_name = "Iron & Ironing Board",
                amenity_price = 113
            });

            amenityItems.Add(new AmenityItem
            {
                item_id = 5,
                amenity_name = "Desk Fan",
                amenity_price = 75
            });

            amenityItems.Add(new AmenityItem
            {
                item_id = 6,
                amenity_name = "Universal Adapter",
                amenity_price = 75
            });

            amenityItems.Add(new AmenityItem
            {
                item_id = 7,
                amenity_name = "Smart TV Upgrade",
                amenity_price = 375
            });

            amenityItems.Add(new AmenityItem
            {
                item_id = 8,
                amenity_name = "Hair Dryer",
                amenity_price = 188
            });

            amenityItems.Add(new AmenityItem
            {
                item_id = 9,
                amenity_name = "Portable Heater",
                amenity_price = 450
            });

            amenityItems.Add(new AmenityItem
            {
                item_id = 10,
                amenity_name = "Microwave",
                amenity_price = 525
            });

            amenityItems.Add(new AmenityItem
            {
                item_id = 11,
                amenity_name = "Coffee Maker",
                amenity_price = 450
            });
            entity.HasData(amenityItems);
        });

        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.amenity_id);
            entity.ToTable("Amenity");

            entity.Property(e => e.amenity_id)
                .ValueGeneratedOnAdd()  // Automatically generates the value for amenity_id (typically identity column)
                .HasColumnName("amenity_id");

            entity.Property(e => e.type_id)
                .HasColumnName("type_id");

            entity.Property(e => e.item_id)
                .HasColumnName("item_id");

            entity.HasOne(d => d.amenityItem).WithMany(p => p.amenity).HasForeignKey(d => d.item_id);
            entity.HasOne(d => d.roomType).WithMany(p => p.amenity).HasForeignKey(d => d.type_id);
            List<Amenity> amenities = new List<Amenity>();

            // Standard Room Amenities (type_id = 1)
            amenities.Add(new Amenity { amenity_id = 1, type_id = 1, item_id = 1 }); // Air Conditioning (AC)
            amenities.Add(new Amenity { amenity_id = 2, type_id = 1, item_id = 2 }); // Mini Fridge
            amenities.Add(new Amenity { amenity_id = 3, type_id = 1, item_id = 3 }); // Electric Kettle
            amenities.Add(new Amenity { amenity_id = 4, type_id = 1, item_id = 4 }); // Iron & Ironing Board
            amenities.Add(new Amenity { amenity_id = 5, type_id = 1, item_id = 5 }); // Desk Fan
            amenities.Add(new Amenity { amenity_id = 6, type_id = 1, item_id = 6 }); // Universal Adapter
            amenities.Add(new Amenity { amenity_id = 7, type_id = 1, item_id = 7 }); // Smart TV Upgrade

            // Deluxe Room Amenities (type_id = 2)
            amenities.Add(new Amenity { amenity_id = 8, type_id = 2, item_id = 1 }); // Air Conditioning (AC)
            amenities.Add(new Amenity { amenity_id = 9, type_id = 2, item_id = 2 }); // Mini Fridge
            amenities.Add(new Amenity { amenity_id = 10, type_id = 2, item_id = 3 }); // Electric Kettle
            amenities.Add(new Amenity { amenity_id = 11, type_id = 2, item_id = 8 }); // Hair Dryer
            amenities.Add(new Amenity { amenity_id = 12, type_id = 2, item_id = 4 }); // Iron & Ironing Board
            amenities.Add(new Amenity { amenity_id = 13, type_id = 2, item_id = 5 }); // Desk Fan
            amenities.Add(new Amenity { amenity_id = 14, type_id = 2, item_id = 9 }); // Portable Heater
            amenities.Add(new Amenity { amenity_id = 15, type_id = 2, item_id = 6 }); // Universal Adapter
            amenities.Add(new Amenity { amenity_id = 16, type_id = 2, item_id = 7 }); // Smart TV Upgrade

            // Suite Room Amenities (type_id = 3)
            amenities.Add(new Amenity { amenity_id = 17, type_id = 3, item_id = 1 }); // Air Conditioning (AC)
            amenities.Add(new Amenity { amenity_id = 18, type_id = 3, item_id = 10 }); // Microwave
            amenities.Add(new Amenity { amenity_id = 19, type_id = 3, item_id = 2 }); // Mini Fridge
            amenities.Add(new Amenity { amenity_id = 20, type_id = 3, item_id = 11 }); // Coffee Maker
            amenities.Add(new Amenity { amenity_id = 21, type_id = 3, item_id = 3 }); // Electric Kettle
            amenities.Add(new Amenity { amenity_id = 22, type_id = 3, item_id = 8 }); // Hair Dryer
            amenities.Add(new Amenity { amenity_id = 23, type_id = 3, item_id = 4 }); // Iron & Ironing Board
            amenities.Add(new Amenity { amenity_id = 24, type_id = 3, item_id = 5 }); // Desk Fan
            amenities.Add(new Amenity { amenity_id = 25, type_id = 3, item_id = 9 }); // Portable Heater
            amenities.Add(new Amenity { amenity_id = 26, type_id = 3, item_id = 6 }); // Universal Adapter
            amenities.Add(new Amenity { amenity_id = 27, type_id = 3, item_id = 7 }); // Smart TV Upgrade
            entity.HasData(amenities);
        });


        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.guest_id);
            entity.ToTable("Guest");

            entity.Property(e => e.guest_id)
                .ValueGeneratedNever()
                .HasColumnName("guest_id");
            entity.Property(e => e.registration_date).HasColumnName("registration_date");

            entity.HasOne(d => d.user).WithOne(p => p.guest)
                .HasForeignKey<Guest>(d => d.guest_id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<HouseKeeping>(entity =>
        {
            entity.HasKey(e => e.housekeeping_id);
            entity.ToTable("HouseKeeping");

            entity.Property(e => e.housekeeping_id)
                .ValueGeneratedOnAdd()
                .HasColumnName("house_keeping_id");
            entity.Property(e => e.housekeeping_starttime).HasColumnName("house_keeping_starttime");
            entity.Property(e => e.housekeeping_endtime).HasColumnName("house_keeping_endtime");
            entity.Property(e => e.room_id).HasColumnName("room_id");
            entity.Property(e => e.staff_id).HasColumnName("staff_id");

            entity.HasOne(d => d.room).WithMany(p => p.housekeeping).HasForeignKey(d => d.room_id);

            entity.HasOne(d => d.staff).WithMany(p => p.housekeeping).HasForeignKey(d => d.staff_id);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.notif_id);

            entity.ToTable("Notification");

            entity.Property(e => e.notif_id)
                .ValueGeneratedOnAdd()
                .HasColumnName("notif_id");
            entity.Property(e => e.notif_content).HasColumnName("notif_content");
            entity.Property(e => e.notif_date).HasColumnName("notif_date");
            entity.Property(e => e.notif_status).HasColumnName("notif_status");
            entity.Property(e => e.notif_title).HasColumnName("notif_title");
            entity.Property(e => e.user_id).HasColumnName("user_id");

            entity.HasOne(d => d.user).WithMany(p => p.notification).HasForeignKey(d => d.user_id);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.payment_id);
            entity.ToTable("Payment");

            entity.Property(e => e.payment_id)
                .ValueGeneratedOnAdd()
                .HasColumnName("payment_id");
            entity.Property(e => e.payment_amount).HasColumnName("payment_amount");
            entity.Property(e => e.payment_date).HasColumnName("payment_date");
            entity.Property(e => e.staff_id).HasColumnName("staff_id");

            entity.HasOne(d => d.staff).WithMany(p => p.payment).HasForeignKey(d => d.staff_id);

            entity.HasOne(d => d.reservation).WithOne(p => p.payment)
                .HasForeignKey<Reservation>(d => d.payment_id)
                .OnDelete(DeleteBehavior.ClientSetNull);

        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.rsv_id);

            entity.ToTable("Reservation");

            entity.Property(e => e.rsv_id)
                .ValueGeneratedOnAdd()
                .HasColumnName("rsv_id");
            entity.Property(e => e.guest_id).HasColumnName("guest_id");
            entity.Property(e => e.payment_id).HasColumnName("payment_id");
            entity.Property(e => e.room_id).HasColumnName("room_id");
            entity.Property(e => e.rsv_checkin).HasColumnName("rsv_checkin");
            entity.Property(e => e.rsv_checkout).HasColumnName("rsv_checkout");
            entity.Property(e => e.rsv_status).HasColumnName("rsv_status");

            entity.HasOne(d => d.guest).WithMany(p => p.reservation).HasForeignKey(d => d.guest_id);

            entity.HasOne(d => d.room).WithMany(p => p.reservation).HasForeignKey(d => d.room_id);
            //entity.HasOne(d => d.payment).WithOne(p => p.reservation).HasForeignKey<Payment>(d => d.payment_id);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.review_id);
            entity.ToTable("Review");

            entity.Property(e => e.review_id)
                .ValueGeneratedOnAdd()
                .HasColumnName("review_id");
            entity.Property(e => e.guest_id).HasColumnName("guest_id");
            entity.Property(e => e.review_date).HasColumnName("review_date");
            entity.Property(e => e.review_feedback).HasColumnName("review_feedback");
            entity.Property(e => e.review_rating).HasColumnName("review_rating");
            entity.Property(e => e.rsv_id).HasColumnName("rsv_id");

            entity.HasOne(d => d.guest).WithMany(p => p.review).HasForeignKey(d => d.guest_id);

            entity.HasOne(d => d.reservation).WithOne(p => p.review)
                .HasForeignKey<Review>(d => d.rsv_id);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.room_id);
            entity.ToTable("Room");

            entity.Property(e => e.room_id)
                .ValueGeneratedOnAdd()
                .HasColumnName("room_id");
            entity.Property(e => e.room_no).HasColumnName("room_no");
            entity.Property(e => e.room_status).HasColumnName("room_status");
            entity.Property(e => e.type_id).HasColumnName("type_id");

            entity.HasOne(d => d.roomtype).WithMany(p => p.room).HasForeignKey(d => d.type_id);
            List<Room> rooms = new List<Room>();
            int room_id = 1;
            for (int i = 0; i < 15; i++)
            {
                int roomNumber = (i + 1) * 100;
                for (int j = 0; j < 15; j++)
                {
                    rooms.Add(new Room
                    {
                        room_id = room_id,
                        room_no = roomNumber + (j + 1),
                        type_id = j < 7 ? 1 : j < 12 ? 2 : 3,
                        room_status = "Available",
                    });
                    room_id++;
                }
            }
            entity.HasData(rooms);
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.type_id);

            entity.ToTable("RoomType");

            entity.Property(e => e.type_id)
                .ValueGeneratedOnAdd()
                .HasColumnName("type_id");
            entity.Property(e => e.type_category).HasColumnName("type_category");
            entity.Property(e => e.type_price).HasColumnName("type_price");
            List<RoomType> roomTypes = new List<RoomType>();
            roomTypes.Add(new RoomType{
                type_id = 1,
                type_category = "Standard",
                type_price = 2500
            });
            roomTypes.Add(new RoomType{
                type_id = 2,
                type_category = "Deluxe",
                type_price = 5000
            });
            roomTypes.Add(new RoomType{ 
                type_id = 3,
                type_category = "Suite",
                type_price = 7500
            });
            entity.HasData(roomTypes);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.service_id);
            entity.ToTable("Service");

            entity.Property(e => e.service_id)
                .ValueGeneratedOnAdd()
                .HasColumnName("service_id");
            entity.Property(e => e.rsv_id).HasColumnName("rsv_id");
            entity.Property(e => e.service_date).HasColumnName("service_date");
            entity.Property(e => e.staff_id).HasColumnName("staff_id");
            entity.Property(e => e.type_id).HasColumnName("type_id");

            entity.HasOne(d => d.reservation).WithMany(p => p.service).HasForeignKey(d => d.rsv_id);

            entity.HasOne(d => d.staff).WithMany(p => p.service).HasForeignKey(d => d.staff_id);

            entity.HasOne(d => d.servicetype).WithMany(p => p.service).HasForeignKey(d => d.type_id);
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.HasKey(e => e.type_id);

            entity.ToTable("ServiceType");

            entity.Property(e => e.type_id)
                .ValueGeneratedNever()
                .HasColumnName("type_id");
            entity.Property(e => e.type_name).HasColumnName("type_name");
            entity.Property(e => e.type_price).HasColumnName("type_price");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.staff_id);
            entity.ToTable("Staff");
            entity.Property(e => e.staff_id)
                .ValueGeneratedNever()
                .HasColumnName("staff_id");
            entity.Property(e => e.employment_date).HasColumnName("employment_date");
            entity.Property(e => e.position).HasColumnName("position");

            entity.HasOne(d => d.user).WithOne(p => p.staff)
                .HasForeignKey<Staff>(d => d.staff_id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.user_id);
            entity.ToTable("User");

            entity.Property(e => e.user_id)
                .ValueGeneratedOnAdd()
                .HasColumnName("user_id");
            entity.Property(e => e.user_contactno).HasColumnName("user_contactno");
            entity.Property(e => e.user_dob).HasColumnName("user_dob");
            entity.Property(e => e.user_email).HasColumnName("user_email");
            entity.Property(e => e.user_fname).HasColumnName("user_fname");
            entity.Property(e => e.user_gender).HasColumnName("user_gender");
            entity.Property(e => e.user_lname).HasColumnName("user_lname");
            entity.Property(e => e.user_password).HasColumnName("user_password");
            entity.Property(e => e.user_type).HasColumnName("user_type");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
