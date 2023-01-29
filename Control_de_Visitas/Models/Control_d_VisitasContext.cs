using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Control_de_Visitas.Models
{
    public partial class Control_d_VisitasContext : DbContext
    {
        public Control_d_VisitasContext()
        {
        }

        public Control_d_VisitasContext(DbContextOptions<Control_d_VisitasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Estatus> Estatuses { get; set; }
        public virtual DbSet<Portero> Porteros { get; set; }
        public virtual DbSet<TipoVisitante> TipoVisitantes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Visitante> Visitantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=Control_d_Visitas; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10842AB09B");

                entity.Property(e => e.IdCategoria).ValueGeneratedNever();

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.NombreCa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstatusNavigation)
                    .WithMany(p => p.Categoria)
                    .HasForeignKey(d => d.Estatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Categoria__estat__35BCFE0A");
            });

            modelBuilder.Entity<Estatus>(entity =>
            {
                entity.HasKey(e => e.Estatus1)
                    .HasName("PK__Estatus__7C6BAF5E1C47ED6E");

                entity.ToTable("Estatus");

                entity.Property(e => e.Estatus1)
                    .ValueGeneratedNever()
                    .HasColumnName("estatus");

                entity.Property(e => e.DetalleEstatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Detalle_Estatus");
            });

            modelBuilder.Entity<Portero>(entity =>
            {
                entity.HasKey(e => e.IdPortero)
                    .HasName("PK__Portero__1D8F736F97A59B5A");

                entity.ToTable("Portero");

                entity.Property(e => e.IdPortero).ValueGeneratedNever();

                entity.Property(e => e.ApellidoO)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.NombreP)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstatusNavigation)
                    .WithMany(p => p.Porteros)
                    .HasForeignKey(d => d.Estatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Portero__estatus__31EC6D26");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Porteros)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Portero__IdUsuar__2E1BDC42");

                entity.HasOne(d => d.IdVisitanteNavigation)
                    .WithMany(p => p.Porteros)
                    .HasForeignKey(d => d.IdVisitante)
                    .HasConstraintName("FK__Portero__IdVisit__2D27B809");
            });

            modelBuilder.Entity<TipoVisitante>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__Tipo_Vis__06416392CED135A8");

                entity.ToTable("Tipo_Visitantes");

                entity.Property(e => e.IdTipo)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Tipo");

                entity.Property(e => e.DetalleTipo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Detalle_Tipo");

                entity.Property(e => e.StatusTipo).HasColumnName("Status_Tipo");

                entity.HasOne(d => d.StatusTipoNavigation)
                    .WithMany(p => p.TipoVisitantes)
                    .HasForeignKey(d => d.StatusTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tipo_Visi__Statu__33D4B598");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF9724E6C8E6");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstatusNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Estatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__estatus__34C8D9D1");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__IdCateg__30F848ED");

                entity.HasOne(d => d.IdVisitanteNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdVisitante)
                    .HasConstraintName("FK__Usuario__IdVisit__300424B4");
            });

            modelBuilder.Entity<Visitante>(entity =>
            {
                entity.HasKey(e => e.IdVisitante)
                    .HasName("PK__Visitant__696F3E9F78AFABB2");

                entity.Property(e => e.IdVisitante).ValueGeneratedNever();

                entity.Property(e => e.ApellidoV)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Hora");

                entity.Property(e => e.IdTipo).HasColumnName("Id_Tipo");

                entity.Property(e => e.NombreV)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StatusVisita).HasColumnName("Status_Visita");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Visitantes)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visitante__Id_Ti__2F10007B");

                entity.HasOne(d => d.StatusVisitaNavigation)
                    .WithMany(p => p.Visitantes)
                    .HasForeignKey(d => d.StatusVisita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visitante__Statu__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
