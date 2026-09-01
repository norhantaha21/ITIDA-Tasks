using CinemaTicketBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }


        public ApplicationDbContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c=>c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(150);
                entity.Property(c => c.Email).IsRequired().HasMaxLength(150);

                entity.HasMany(c => c.Bookings)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<ShowTime>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasMany(c => c.Bookings)
                .WithOne(c => c.ShowTime)
                .HasForeignKey(c => c.ShowTimeId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Name).IsRequired().HasMaxLength(200);
                entity.Property(m => m.Genre).IsRequired().HasMaxLength(100);

                entity.HasMany(x => x.Shows)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(b => b.Status)
                      .HasConversion<string>()
                      .HasMaxLength(20);
            });

            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasMany(a => a.Shows)
                      .WithOne(s => s.Auditorium)
                      .HasForeignKey(s => s.AuditoriumId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

    }
}
