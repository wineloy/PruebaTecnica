using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;


#nullable disable

namespace Backend_Productos.Models
{
    public partial class ProductosContext : DbContext
    {
        public ProductosContext()
        {
        }

        public ProductosContext(DbContextOptions<ProductosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC-DESKTOP\\SQLEXPRESS;Database=Productos;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProductos)
                    .HasName("PK__PRODUCTO__718C7D0788CDBF4B");

                entity.ToTable("PRODUCTOS");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProductoLargo).HasColumnType("text");

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__VENTAS__BC1240BDE75923BE");

                entity.ToTable("VENTAS");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.PrecioVenta).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdProductosNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdProductos)
                    .HasConstraintName("FK__VENTAS__cantidad__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
