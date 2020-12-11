using AplicacionComercial.Common.Entities;

using Microsoft.EntityFrameworkCore;

namespace AplicacionComercial.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }
        public virtual DbSet<Bodega> Bodegas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Concepto> Conceptos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<ImagenProducto> ImagenesProducto { get; set; }
        public virtual DbSet<Iva> Ivas { get; set; }
        public virtual DbSet<Medida> Medidas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<TipoDocumento> TiposDocumentos { get; set; }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("DefaultConnection");

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Descripcion).IsRequired();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdtipoDocumento });

                //entity.HasIndex(e => new { e.IdtipoDocumento, e.Documento })
                //    .HasName("IX_TipoDocumento_Documento")
                //    .IsUnique();
                entity.HasIndex(e => new { e.IdtipoDocumento, e.Documento })
                        .HasDatabaseName("IX_TipoDocumento_Documento")
                        .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdtipoDocumento).HasColumnName("IDTipoDocumento");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Aniversario).HasColumnType("date");

                entity.Property(e => e.ApellidosContacto)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CodPostal).HasMaxLength(5);

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NombreComercial)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.NombresContacto)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Notas).HasColumnType("text");

                entity.Property(e => e.Poblacion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Movil)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.Telefono).HasMaxLength(9);

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_TipoDocumento");
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion).IsRequired();
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion).IsRequired();
            });

            modelBuilder.Entity<ImagenProducto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.ImageId).IsRequired();
                entity.HasIndex(e => e.ImageId)
                .IsUnique();                
                
                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.ImagenesProducto)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ImagenProducto_Producto");

            });
            modelBuilder.Entity<Iva>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("IVA");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Descripcion).IsRequired();
            });

            modelBuilder.Entity<Medida>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasMaxLength(2);

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.Activo)
                      .IsRequired()
                      .HasDefaultValueSql("((1))");
            });
            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => new { e.IdtipoDocumento, e.Documento })
                    .HasDatabaseName("IX_IDTipoDocumento_Documento")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ApellidosContacto).IsRequired();

                entity.Property(e => e.CodPostal)
                    .IsRequired();

                entity.Property(e => e.Correo)
                    .IsRequired();

                entity.Property(e => e.Direccion)
                    .IsRequired();

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IdtipoDocumento).HasColumnName("IdTipoDocumento");               

                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.NombresContacto).IsRequired();

                entity.Property(e => e.Movil).IsRequired();               

                entity.Property(e => e.Notas).HasColumnType("text");

                entity.Property(e => e.Poblacion).IsRequired();

                entity.Property(e => e.Provincia).IsRequired();
                    

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedor_TipoDocumento");
            });
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.Iddepartamento).HasColumnName("IdDepartamento");

                entity.Property(e => e.Idiva).HasColumnName("IdIva");

                entity.Property(e => e.Idmedida)
                    .IsRequired()
                    .HasColumnName("IdMedida")
                    .HasMaxLength(2);

                entity.Property(e => e.Medida).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notas).HasColumnType("text");

                entity.Property(e => e.Precio).HasColumnType("money");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IddepartamentoNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.Iddepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Departamento");

                entity.HasOne(d => d.IdivaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.Idiva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_IVA");

                entity.HasOne(d => d.IdmedidaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.Idmedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Medida");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            });
        }
    }
}
