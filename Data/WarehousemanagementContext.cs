using System.Configuration;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.Model;

namespace Warehouse_Management.Data
{
    public partial class WarehousemanagementContext : DbContext
    {
        public WarehousemanagementContext()
        {
        }

        public WarehousemanagementContext(DbContextOptions<WarehousemanagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Semitrailer> Semitrailers { get; set; }
        public virtual DbSet<Truck> Trucks { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString
, x => x.ServerVersion("8.0.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("cities");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("char(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.CityName)
                    .HasName("city_name");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnName("city_name")
                    .HasColumnType("char(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("char(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.CityNameNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CityName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customers_ibfk_1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("customer_id");

                entity.HasIndex(e => e.SemitrailerId)
                    .HasName("semitrailer_id");

                entity.HasIndex(e => e.TruckId)
                    .HasName("truck_id");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("warehouse_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SemitrailerId)
                    .HasColumnName("semitrailer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TruckId)
                    .HasColumnName("truck_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_ibfk_1");

                entity.HasOne(d => d.Semitrailer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SemitrailerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_ibfk_4");

                entity.HasOne(d => d.Truck)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TruckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_ibfk_3");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_ibfk_2");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.OrderId)
                    .HasName("order_id");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("warehouse_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("char(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Volume)
                    .HasColumnName("volume")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("products_ibfk_2");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("products_ibfk_1");
            });

            modelBuilder.Entity<Semitrailer>(entity =>
            {
                entity.ToTable("semitrailers");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("warehouse_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MaxAxleLoad)
                    .HasColumnName("max_axle_load")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MaxVolume)
                    .HasColumnName("max_volume")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Semitrailers)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("semitrailers_ibfk_1");
            });

            modelBuilder.Entity<Truck>(entity =>
            {
                entity.ToTable("trucks");

                entity.HasIndex(e => e.WarehouseId)
                    .HasName("warehouse_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasColumnName("manufacturer")
                    .HasColumnType("char(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Mileage)
                    .HasColumnName("mileage")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasColumnType("char(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ModelYear)
                    .HasColumnName("model_year")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WarehouseId)
                    .HasColumnName("warehouse_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Trucks)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("trucks_ibfk_1");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("warehouses");

                entity.HasIndex(e => e.City)
                    .HasName("city");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("char(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("char(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.City)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("warehouses_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}