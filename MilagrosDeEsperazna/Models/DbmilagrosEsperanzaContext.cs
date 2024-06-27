using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MilagrosDeEsperanza.Models;

public partial class DbmilagrosEsperanzaContext : DbContext
{
    public DbmilagrosEsperanzaContext()
    {
    }

    public DbmilagrosEsperanzaContext(DbContextOptions<DbmilagrosEsperanzaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Noticia> Noticias { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Voluntario> Voluntarios { get; set; }

    public virtual DbSet<VoluntariosProyecto> VoluntariosProyectos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PK__Comentar__1BA6C6F45BF574F2");

            entity.Property(e => e.IdComentario).HasColumnName("id_comentario");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_envio");
            entity.Property(e => e.Mensaje)
                .HasColumnType("text")
                .HasColumnName("mensaje");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Noticia>(entity =>
        {
            entity.HasKey(e => e.IdNoticia).HasName("PK__Noticias__1D4A6BA1A6C3FAC4");

            entity.Property(e => e.IdNoticia).HasColumnName("id_noticia");
            entity.Property(e => e.Contenido)
                .HasColumnType("text")
                .HasColumnName("contenido");
            entity.Property(e => e.FechaPublicacion).HasColumnName("fecha_publicacion");
            entity.Property(e => e.Imagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PK__Proyecto__F38AD81D25AA5C4D");

            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.Imagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Usuarios__AB6E6165C2EEAE02");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(100)
                .HasColumnName("primer_apellido");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .HasColumnName("rol");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(100)
                .HasColumnName("segundo_apellido");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<Voluntario>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Voluntar__AB6E6165572DA4BB");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IdVoluntario)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_voluntario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(100)
                .HasColumnName("primer_apellido");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(100)
                .HasColumnName("segundo_apellido");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<VoluntariosProyecto>(entity =>
        {
            entity.HasKey(e => e.IdAsociacion).HasName("PK__Voluntar__086AFDE70D2F15A3");

            entity.Property(e => e.IdAsociacion).HasColumnName("id_asociacion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.VoluntariosProyectos)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK__Voluntari__email__44FF419A");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.VoluntariosProyectos)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("FK__Voluntari__id_pr__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
