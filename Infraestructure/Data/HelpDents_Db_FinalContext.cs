using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApiHelpDents.Domain.Entities;

#nullable disable

namespace ApiHelpDents.Infraestructure.Data
{
    public partial class HelpDents_Db_FinalContext : DbContext
    {
        public HelpDents_Db_FinalContext()
        {
        }

        public HelpDents_Db_FinalContext(DbContextOptions<HelpDents_Db_FinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administradors { get; set; }
        public virtual DbSet<Asesor> Asesors { get; set; }
        public virtual DbSet<AsesorHasComentario> AsesorHasComentarios { get; set; }
        public virtual DbSet<AsesorHasEspecialidad> AsesorHasEspecialidads { get; set; }
        public virtual DbSet<AsesorHasTurno> AsesorHasTurnos { get; set; }
        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Especialidad> Especialidads { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=JONA; Initial Catalog=HelpDents_Db_Final; Integrated Security=True;");
            }
        } */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__Administ__EBE80EA1FE402DB1");

                entity.ToTable("Administrador");

                entity.Property(e => e.IdAdministrador).HasColumnName("idAdministrador");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Asesor>(entity =>
            {
                entity.HasKey(e => e.IdAsesor)
                    .HasName("PK__Asesor__A801FCE9F943863A");

                entity.ToTable("Asesor");

                entity.HasIndex(e => e.UsuarioIdUsuario, "Asesor_FKIndex1");

                entity.Property(e => e.IdAsesor).HasColumnName("idAsesor");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Facebook)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Instagram)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Linkendin)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioIdUsuario).HasColumnName("Usuario_idUsuario");

                entity.Property(e => e.YouTube)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioIdUsuarioNavigation)
                    .WithMany(p => p.Asesors)
                    .HasForeignKey(d => d.UsuarioIdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asesor__Usuario___2C3393D0");
            });

            modelBuilder.Entity<AsesorHasComentario>(entity =>
            {
                entity.ToTable("Asesor_has_Comentario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AsesorIdAsesor).HasColumnName("Asesor_idAsesor");

                entity.Property(e => e.ComentarioIdComentario).HasColumnName("Comentario_idComentario");

                entity.HasOne(d => d.AsesorIdAsesorNavigation)
                    .WithMany(p => p.AsesorHasComentarios)
                    .HasForeignKey(d => d.AsesorIdAsesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asesor_ha__Aseso__3A81B327");

                entity.HasOne(d => d.ComentarioIdComentarioNavigation)
                    .WithMany(p => p.AsesorHasComentarios)
                    .HasForeignKey(d => d.ComentarioIdComentario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asesor_ha__Comen__3B75D760");
            });

            modelBuilder.Entity<AsesorHasEspecialidad>(entity =>
            {
                entity.ToTable("Asesor_has_Especialidad");

                entity.HasIndex(e => e.AsesorIdAsesor, "Asesor_has_Especialidad_FKIndex1");

                entity.HasIndex(e => e.EspecialidadIdEspecialidad, "Asesor_has_Especialidad_FKIndex2");

                entity.HasIndex(e => e.AsesorIdAsesor, "IFK_Especializa");

                entity.HasIndex(e => e.EspecialidadIdEspecialidad, "IFK_Pertenece");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AsesorIdAsesor).HasColumnName("Asesor_idAsesor");

                entity.Property(e => e.EspecialidadIdEspecialidad).HasColumnName("Especialidad_idEspecialidad");

                entity.HasOne(d => d.AsesorIdAsesorNavigation)
                    .WithMany(p => p.AsesorHasEspecialidads)
                    .HasForeignKey(d => d.AsesorIdAsesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asesor_ha__Aseso__2F10007B");

                entity.HasOne(d => d.EspecialidadIdEspecialidadNavigation)
                    .WithMany(p => p.AsesorHasEspecialidads)
                    .HasForeignKey(d => d.EspecialidadIdEspecialidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asesor_ha__Espec__300424B4");
            });

            modelBuilder.Entity<AsesorHasTurno>(entity =>
            {
                entity.ToTable("Asesor_has_Turno");

                entity.HasIndex(e => e.AsesorIdAsesor, "Asesor_has_Turno_FKIndex1");

                entity.HasIndex(e => e.TurnoIdTurno, "Asesor_has_Turno_FKIndex2");

                entity.HasIndex(e => e.TurnoIdTurno, "IFK_Pertenece");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AsesorIdAsesor).HasColumnName("Asesor_idAsesor");

                entity.Property(e => e.TurnoIdTurno).HasColumnName("Turno_idTurno");

                entity.HasOne(d => d.AsesorIdAsesorNavigation)
                    .WithMany(p => p.AsesorHasTurnos)
                    .HasForeignKey(d => d.AsesorIdAsesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asesor_ha__Aseso__32E0915F");

                entity.HasOne(d => d.TurnoIdTurnoNavigation)
                    .WithMany(p => p.AsesorHasTurnos)
                    .HasForeignKey(d => d.TurnoIdTurno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asesor_ha__Turno__33D4B598");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PK__Comentar__C74515DAB3A6B13D");

                entity.ToTable("Comentario");

                entity.Property(e => e.IdComentario).HasColumnName("idComentario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioIdUsuario).HasColumnName("Usuario_idUsuario");

                entity.HasOne(d => d.UsuarioIdUsuarioNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.UsuarioIdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comentari__Usuar__36B12243");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidad)
                    .HasName("PK__Especial__E8AB1600338A255F");

                entity.ToTable("Especialidad");

                entity.Property(e => e.IdEspecialidad).HasColumnName("idEspecialidad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.IdTurno)
                    .HasName("PK__Turno__AA068B011834FCEB");

                entity.ToTable("Turno");

                entity.Property(e => e.IdTurno).HasColumnName("idTurno");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6E9FF5A5A");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
