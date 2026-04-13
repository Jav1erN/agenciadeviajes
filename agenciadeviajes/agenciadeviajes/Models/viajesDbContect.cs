using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace agenciadeviajes.Models;

public partial class viajesDbContect : DbContext
{
    public viajesDbContect()
    {
    }

    public viajesDbContect(DbContextOptions<viajesDbContect> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Itinerario> Itinerarios { get; set; }

    public virtual DbSet<Paqueteturistico> Paqueteturisticos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ViajesDB;Username=postgres;Password=aL866TEC2558;Port=5432");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.Documentoidentidad, "cliente_documentoidentidad_key").IsUnique();

            entity.HasIndex(e => e.Email, "cliente_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Documentoidentidad)
                .HasMaxLength(20)
                .HasColumnName("documentoidentidad");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Itinerario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("itinerario_pkey");

            entity.ToTable("itinerario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Actividad)
                .HasMaxLength(150)
                .HasColumnName("actividad");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Dia).HasColumnName("dia");
            entity.Property(e => e.Paqueteid).HasColumnName("paqueteid");

            entity.HasOne(d => d.Paquete).WithMany(p => p.Itinerarios)
                .HasForeignKey(d => d.Paqueteid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("itinerario_paqueteid_fkey");
        });

        modelBuilder.Entity<Paqueteturistico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("paqueteturistico_pkey");

            entity.ToTable("paqueteturistico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacidadmaxima).HasColumnName("capacidadmaxima");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .HasDefaultValueSql("'Activo'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Preciobase)
                .HasPrecision(10, 2)
                .HasColumnName("preciobase");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proveedor_pkey");

            entity.ToTable("proveedor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calificacionpromedio)
                .HasPrecision(3, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("calificacionpromedio");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .HasColumnName("contacto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reserva_pkey");

            entity.ToTable("reserva");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Estadopago)
                .HasMaxLength(15)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estadopago");
            entity.Property(e => e.Fechareserva)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechareserva");
            entity.Property(e => e.Montototal)
                .HasPrecision(10, 2)
                .HasColumnName("montototal");
            entity.Property(e => e.Paqueteid).HasColumnName("paqueteid");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.Clienteid)
                .HasConstraintName("reserva_clienteid_fkey");

            entity.HasOne(d => d.Paquete).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.Paqueteid)
                .HasConstraintName("reserva_paqueteid_fkey");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("servicio_pkey");

            entity.ToTable("servicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Costo)
                .HasPrecision(10, 2)
                .HasColumnName("costo");
            entity.Property(e => e.Disponibilidad)
                .HasDefaultValue(true)
                .HasColumnName("disponibilidad");
            entity.Property(e => e.Nombreservicio)
                .HasMaxLength(100)
                .HasColumnName("nombreservicio");
            entity.Property(e => e.Proveedorid).HasColumnName("proveedorid");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.Proveedorid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("servicio_proveedorid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
