using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuertyKey_DAW.DataModels
{
    public partial class QuertyKey_DAWContext : DbContext
    {
        public QuertyKey_DAWContext()
        {
        }

        public QuertyKey_DAWContext(DbContextOptions<QuertyKey_DAWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accessory> Accessories { get; set; } = null!;
        public virtual DbSet<Deskmat> Deskmats { get; set; } = null!;
        public virtual DbSet<Keyboard> Keyboards { get; set; } = null!;
        public virtual DbSet<Keycap> Keycaps { get; set; } = null!;
        public virtual DbSet<Merch> Merches { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Specialty> Specialties { get; set; } = null!;
        public virtual DbSet<Switch> Switches { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263. security LMAO
                optionsBuilder.UseNpgsql("Server=localhost; Port=5433; Database=QuertyKey_DAW; Username=andrei; Password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessory>(entity =>
            {
                entity.ToTable("Accessory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Deskmat>(entity =>
            {
                entity.ToTable("Deskmat");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Keyboard>(entity =>
            {
                entity.ToTable("Keyboard");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Keycap)
                    .WithMany(p => p.Keyboards)
                    .HasForeignKey(d => d.KeycapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("keycap_fk");

                entity.HasOne(d => d.Switch)
                    .WithMany(p => p.Keyboards)
                    .HasForeignKey(d => d.SwitchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("switch_fk");
            });

            modelBuilder.Entity<Keycap>(entity =>
            {
                entity.ToTable("Keycap");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Merch>(entity =>
            {
                entity.ToTable("Merch");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_fk");

                entity.HasMany(d => d.Deskmats)
                    .WithMany(p => p.Orders)
                    .UsingEntity<Dictionary<string, object>>(
                        "OrderDeskmatRecord",
                        l => l.HasOne<Deskmat>().WithMany().HasForeignKey("DeskmatId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("deskmat_fk"),
                        r => r.HasOne<Order>().WithMany().HasForeignKey("OrderId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("order_fk"),
                        j =>
                        {
                            j.HasKey("OrderId", "DeskmatId").HasName("order_deskmat_pk");

                            j.ToTable("OrderDeskmatRecords");
                        });

                entity.HasMany(d => d.Keyboards)
                    .WithMany(p => p.Orders)
                    .UsingEntity<Dictionary<string, object>>(
                        "OrderKeyboardRecord",
                        l => l.HasOne<Keyboard>().WithMany().HasForeignKey("KeyboardId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("RecordKeyboard_fk"),
                        r => r.HasOne<Order>().WithMany().HasForeignKey("OrderId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("RecordOrder_fk"),
                        j =>
                        {
                            j.HasKey("OrderId", "KeyboardId").HasName("order_keyboard_pk");

                            j.ToTable("OrderKeyboardRecords");
                        });

                entity.HasMany(d => d.Keycaps)
                    .WithMany(p => p.Orders)
                    .UsingEntity<Dictionary<string, object>>(
                        "OrderKeycapRecord",
                        l => l.HasOne<Keycap>().WithMany().HasForeignKey("KeycapId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("keycap_fk"),
                        r => r.HasOne<Order>().WithMany().HasForeignKey("OrderId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("order_fk"),
                        j =>
                        {
                            j.HasKey("OrderId", "KeycapId").HasName("order_keycap_fk");

                            j.ToTable("OrderKeycapRecords");
                        });

                entity.HasMany(d => d.Merches)
                    .WithMany(p => p.Orders)
                    .UsingEntity<Dictionary<string, object>>(
                        "OrderMerchRecord",
                        l => l.HasOne<Merch>().WithMany().HasForeignKey("MerchId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("merch_fk"),
                        r => r.HasOne<Order>().WithMany().HasForeignKey("OrderId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("order_fk"),
                        j =>
                        {
                            j.HasKey("OrderId", "MerchId").HasName("order_merch _pk");

                            j.ToTable("OrderMerchRecords");
                        });

                entity.HasMany(d => d.Specialties)
                    .WithMany(p => p.Orders)
                    .UsingEntity<Dictionary<string, object>>(
                        "OrderSpecialtyRecord",
                        l => l.HasOne<Specialty>().WithMany().HasForeignKey("SpecialtyId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("specialty_fk"),
                        r => r.HasOne<Order>().WithMany().HasForeignKey("OrderId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("order_fk"),
                        j =>
                        {
                            j.HasKey("OrderId", "SpecialtyId").HasName("order_specialty_pk");

                            j.ToTable("OrderSpecialtyRecords");
                        });

                entity.HasMany(d => d.Switches)
                    .WithMany(p => p.Orders)
                    .UsingEntity<Dictionary<string, object>>(
                        "OrderSwitchRecord",
                        l => l.HasOne<Switch>().WithMany().HasForeignKey("SwitchId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("switch_fk"),
                        r => r.HasOne<Order>().WithMany().HasForeignKey("OrderId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("order_fk"),
                        j =>
                        {
                            j.HasKey("OrderId", "SwitchId").HasName("order_switch_fk");

                            j.ToTable("OrderSwitchRecords");
                        });
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.ToTable("Specialty");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Switch>(entity =>
            {
                entity.ToTable("Switch");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).UseCollation("C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
