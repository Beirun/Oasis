using Microsoft.EntityFrameworkCore;
using Oasis.Data.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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
    public DbSet<Amenity> Amenity { get; set; }
    public DbSet<AmenityItem> AmenityItem { get; set; }
    public DbSet<Discount> Discount { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }
}
