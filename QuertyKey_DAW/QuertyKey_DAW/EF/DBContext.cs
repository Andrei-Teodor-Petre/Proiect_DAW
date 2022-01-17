
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

    }
        
}