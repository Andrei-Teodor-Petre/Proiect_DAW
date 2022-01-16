
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuertyKey_DAW.Models;

namespace QuertyKey_DAW.EF
{
    public class DataContext : DbContext
    {
        public DbSet<Keyboard> Keyboards { get; set; }
        public DbSet<Deskmat> Deskmats { get; set; }
        public DbSet<Keycap> Keycaps { get; set; }
        public DbSet<Switch> Switches { get; set; }
        public DbSet<Accessory> Accesories { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Merch> Merch { get; set; }
        public DbSet<User> Users { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Keyboard>()
                .HasOne(s => s.Switch)
                .WithMany(g => g.Keyboards);

            modelBuilder.Entity<Keyboard>()
                .HasOne(s => s.Keycap)
                .WithMany(g => g.Keyboards);

            modelBuilder.Entity<User>()
                .HasMany(a => a.Orders)
                .WithOne(a => a.User);

            modelBuilder.Entity<Order>().HasMany(a => a.Keyboards).WithMany(a => a.Orders);
            modelBuilder.Entity<Order>().HasMany(a => a.Keycaps).WithMany(a => a.Orders);
            modelBuilder.Entity<Order>().HasMany(a => a.Switches).WithMany(a => a.Orders);
            modelBuilder.Entity<Order>().HasMany(a => a.Deskmats).WithMany(a => a.Orders);
            modelBuilder.Entity<Order>().HasMany(a => a.Merch).WithMany(a => a.Orders);
            modelBuilder.Entity<Order>().HasMany(a => a.Accessories).WithMany(a => a.Orders);
            modelBuilder.Entity<Order>().HasMany(a => a.Specialties).WithMany(a => a.Orders);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseNpgsql("User ID=postgres;Password=andrei;Host=localhost;Port=5432;Database=QuertyKey_DAW;");
            }
        }
    }
}