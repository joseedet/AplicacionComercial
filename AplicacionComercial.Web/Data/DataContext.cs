using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AplicacionComercial.Web.Models;

namespace AplicacionComercial.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }
        public virtual DbSet<Bodega> Bodegas { get; set; }
        public virtual DbSet<TipoDocumento> TiposDocumentos { get; set; }
        public virtual DbSet<Concepto> Conceptos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Medida> Medidas { get; set; }
        public virtual DbSet<Iva> Ivas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<BodegaProducto> BodegaProductos { get; set; }
        public virtual DbSet<ImagenProducto> ImagenesProducto { get; set; }
        public virtual DbSet<Barra> Barras { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<CompraDetalle> CompraDetalles { get; set; }
        public virtual DbSet<Kardex> Kardex { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<MainComment> MainComments { get; set; }
        public virtual DbSet<SubComment> SubComments { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("DefaultConnection");

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.HasDefaultSchema("dbo");
                modelBuilder.Entity("AplicacionComercial.Web.Data.Entities.User", b =>
                {
                    
                    b.ToTable(name: "User");
                   

                });

                modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {

                    b.ToTable(name: "Role");

                });
                modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {

                    b.ToTable("UserRoles");
                });

                modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {

                    b.ToTable(name: "UserClaims");
                });

                modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.ToTable(name: "UserLogins");
                });

                modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {

                    b.ToTable("RoleClaims");
                });

                modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {

                    b.ToTable("UserTokens");
                });

            }

            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Descripcion).IsRequired();
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
                    .HasColumnName("Id");
                //.HasMaxLength(2);

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.Activo)
                      .IsRequired()
                      .HasDefaultValueSql("((1))");
            });

            //modelBuilder.Entity<Proveedor>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    //    entity.HasIndex(e => new { e.IdtipoDocumento, e.Documento })
            //    //        .HasDatabaseName("IX_IDTipoDocumento_Documento")
            //    //        .IsUnique();

            //    //    entity.Property(e => e.Id).HasColumnName("Id");

            //    //    entity.Property(e => e.Activo)
            //    //        .IsRequired()
            //    //        .HasDefaultValueSql("((1))");

            //    //    entity.Property(e => e.ApellidosContacto).IsRequired();

            //    //    entity.Property(e => e.CodPostal)
            //    //        .IsRequired();

            //    //    entity.Property(e => e.Correo)
            //    //        .IsRequired();

            //    //    entity.Property(e => e.Direccion)
            //    //        .IsRequired();

            //    //    entity.Property(e => e.Documento)
            //    //        .IsRequired()
            //    //        .HasMaxLength(20);

            //    //    entity.Property(e => e.IdtipoDocumento).HasColumnName("IdTipoDocumento");               

            //    //    entity.Property(e => e.Nombre).IsRequired();

            //    //    entity.Property(e => e.NombresContacto).IsRequired();

            //    //    entity.Property(e => e.Movil).IsRequired();               

            //    //    entity.Property(e => e.Notas).HasColumnType("text");

            //    //    entity.Property(e => e.Poblacion).IsRequired();

            //    //    entity.Property(e => e.Provincia).IsRequired();


            //    entity.HasOne(d => d.IdtipoDocumentoNavigation)
            //        .WithMany(p => p.Proveedores)
            //        .HasForeignKey(d => d.IdtipoDocumento)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Proveedor_TipoDocumento");
            //});
            modelBuilder.Entity<Producto>(entity =>
                {
                    entity.HasKey(e => e.Id);

                    entity.Property(e => e.Id).HasColumnName("Id");

                    entity.Property(e => e.Nombre)/*.IsRequired()*/;

                    entity.Property(e => e.Descripcion)/*.IsRequired()*/;

                    entity.Property(e => e.Activo);
                    //.IsRequired()
                    //.HasDefaultValueSql("((1))")

                    entity.Property(e => e.IsStarred);

                    entity.Property(e => e.Iddepartamento).HasColumnName("IdDepartamento");

                    entity.Property(e => e.Idiva).HasColumnName("IdIva");

                    entity.Property(e => e.Idmedida)
                        //.IsRequired()
                        .HasColumnName("IdMedida");
                    //.HasMaxLength(2);             


                    entity.Property(e => e.Notas).HasColumnType("text");

                    entity.Property(e => e.Precio).HasColumnType("money");


                    entity.HasOne(d => d.Departamento)
                         .WithMany(p => p.Producto)
                         .HasForeignKey(d => d.Iddepartamento)
                         .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                         .HasConstraintName("FK_Producto_Departamento");

                    entity.HasOne(d => d.Iva)
                        .WithMany(p => p.Producto)
                        .HasForeignKey(d => d.Idiva)
                        .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Producto_IVA");

                    entity.HasOne(d => d.Medida)
                        .WithMany(p => p.Producto)
                        .HasForeignKey(d => d.Idmedida)
                        .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Producto_Medida");
                });

            modelBuilder.Entity<BodegaProducto>(entity =>
            {
                //entity.Property(e => e.Id).HasColumnName("Id")
                //.HasColumnType("Integer")
                //.UseIdentityColumn(seed: 1);
                entity.HasKey(e => new { e.Idbodega, e.Idproducto });

                entity.Property(e => e.Idbodega).HasColumnName("IdBodega");

                entity.Property(e => e.Idproducto).HasColumnName("IdProducto");

                entity.Property(e => e.CantidadMinima).HasDefaultValueSql("((1))");

                entity.Property(e => e.DiasReposicion).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Bodega)
                   .WithMany(p => p.Almacenes)
                   .HasForeignKey(d => d.Idbodega)
                   .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_BodegaProducto_Bodega");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.BodegaProductos)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BodegaProducto_Producto");
            });
            modelBuilder.Entity<ImagenProducto>(entity =>
            {
                entity.HasKey(e => e.Id)

                /*entity.HasKey(e => new { e.ProductoId, e.ImageId })*/;
                entity.Property(e => e.ImageId);/*.IsRequired();*/
                //entity.HasIndex(e => e.ImageId)
                //.IsUnique();
                entity.Property(e => e.ProductoId);/*.IsRequired();*/
                //TODO:Descomentar.

                entity.HasOne(d => d.IdproductoNavigation)
                .WithMany(p => p.ImagenesProducto)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImagenProducto_Producto");

            });

            modelBuilder.Entity<Barra>(entity =>
            {

                entity.HasKey(e => new { e.Idproducto, e.Barra1 });

                entity.HasIndex(e => e.Barra1)
                    .HasDatabaseName("IX_Barra")
                    .IsUnique();

                entity.Property(e => e.Idproducto).HasColumnName("IdProducto");

                entity.Property(e => e.Barra1).HasColumnName("Cod.Barras");

                entity.Property(e => e.Activo)
                       .IsRequired()
                       .HasDefaultValueSql("((1))");


                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Barras)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Barra_Producto");
            });



        }
        public DbSet<AplicacionComercial.Web.Models.AddUserViewModel> AddUserViewModel { get; set; }
    }
}

