using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class ParqueaderoContext : DbContext
{
    public ParqueaderoContext()
    {
    }

    public ParqueaderoContext(DbContextOptions<ParqueaderoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Distribucion> Distribucions { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<MovPaqueadero> MovPaqueaderos { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<TipoIdentificacion> TipoIdentificacions { get; set; }

    public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=parqueadero;User ID=super_lenguaje; PWD= R0l4nd.ct;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.CiuId).HasName("PK__ciudad__66B91EF31E877303");

            entity.ToTable("ciudad");

            entity.HasIndex(e => e.CiuCodigo, "Unique_ciu_codigo").IsUnique();

            entity.Property(e => e.CiuId).HasColumnName("ciu_id");
            entity.Property(e => e.CiuCodigo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ciu_codigo");
            entity.Property(e => e.CiuNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ciu_nombre");
        });

        modelBuilder.Entity<Distribucion>(entity =>
        {
            entity.HasKey(e => e.DisId).HasName("PK__distribu__79CED96FA1AFEF69");

            entity.ToTable("distribucion");

            entity.HasIndex(e => new { e.SucId, e.DisSigla, e.DisSerie }, "Unique_suc_id_dis_sigla_dis_serie").IsUnique();

            entity.Property(e => e.DisId).HasColumnName("dis_id");
            entity.Property(e => e.DisHabilitado).HasColumnName("dis_habilitado");
            entity.Property(e => e.DisSerie).HasColumnName("dis_serie");
            entity.Property(e => e.DisSigla)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("dis_sigla");
            entity.Property(e => e.SucId).HasColumnName("suc_id");

            entity.HasOne(d => d.Suc).WithMany(p => p.Distribucions)
                .HasForeignKey(d => d.SucId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_sucursal_dis");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarId).HasName("PK__marca__8312A7DFAC73B16B");

            entity.ToTable("marca");

            entity.HasIndex(e => e.MarCodigo, "Unique_mar_codigo").IsUnique();

            entity.Property(e => e.MarId).HasColumnName("mar_id");
            entity.Property(e => e.MarCodigo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("mar_codigo");
            entity.Property(e => e.MarDescrip)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("mar_descrip");
        });

        modelBuilder.Entity<MovPaqueadero>(entity =>
        {
            entity.HasKey(e => e.ParqueId).HasName("PK__mov_paqu__4740F3245984171E");

            entity.ToTable("mov_paqueadero");

            entity.HasIndex(e => e.ParFacDcto, "Unique_par_fac_dcto").IsUnique();

            entity.Property(e => e.ParqueId).HasColumnName("parque_id");
            entity.Property(e => e.DisId).HasColumnName("dis_id");
            entity.Property(e => e.ParFacDcto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("par_fac_dcto");
            entity.Property(e => e.ParqueCosto)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("parque_costo");
            entity.Property(e => e.ParqueHoraIn)
                .HasColumnType("datetime")
                .HasColumnName("parque_hora_in");
            entity.Property(e => e.ParqueHoraOut)
                .HasColumnType("datetime")
                .HasColumnName("parque_hora_out");
            entity.Property(e => e.ParqueTiempoMin)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("parque_tiempo_min");
            entity.Property(e => e.VehId).HasColumnName("veh_id");

            entity.HasOne(d => d.Dis).WithMany(p => p.MovPaqueaderos)
                .HasForeignKey(d => d.DisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_distribucion_parque");

            entity.HasOne(d => d.Veh).WithMany(p => p.MovPaqueaderos)
                .HasForeignKey(d => d.VehId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_vehiculo_parque");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.SucId).HasName("PK__sucursal__C6E02F5FB66730F8");

            entity.ToTable("sucursal");

            entity.HasIndex(e => new { e.TipideId, e.SucDocumento }, "Unique_tipide_id_suc_documento").IsUnique();

            entity.Property(e => e.SucId).HasColumnName("suc_id");
            entity.Property(e => e.CiuId).HasColumnName("ciu_id");
            entity.Property(e => e.SucDcto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("suc_dcto");
            entity.Property(e => e.SucDir)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("('N/A')")
                .HasColumnName("suc_dir");
            entity.Property(e => e.SucDocumento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("suc_documento");
            entity.Property(e => e.SucManejaDcto).HasColumnName("suc_maneja_dcto");
            entity.Property(e => e.SucRazon)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("suc_razon");
            entity.Property(e => e.TipideId).HasColumnName("tipide_id");

            entity.HasOne(d => d.Ciu).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.CiuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ciudad_suc");

            entity.HasOne(d => d.Tipide).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.TipideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tipo_identificacion_suc");
        });

        modelBuilder.Entity<TipoIdentificacion>(entity =>
        {
            entity.HasKey(e => e.TipideId).HasName("PK__tipo_ide__40EFF42FF1645A73");

            entity.ToTable("tipo_identificacion");

            entity.HasIndex(e => e.TipideCodigo, "Unique_tipide_codigo").IsUnique();

            entity.Property(e => e.TipideId).HasColumnName("tipide_id");
            entity.Property(e => e.TipideCodigo)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("tipide_codigo");
            entity.Property(e => e.TipideDescrip)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipide_descrip");
        });

        modelBuilder.Entity<TipoVehiculo>(entity =>
        {
            entity.HasKey(e => e.TipvehId).HasName("PK__tipo_veh__097102772F452D3F");

            entity.ToTable("tipo_vehiculo");

            entity.HasIndex(e => e.TipvehCodigo, "Unique_tipveh_codigo").IsUnique();

            entity.Property(e => e.TipvehId).HasColumnName("tipveh_id");
            entity.Property(e => e.TipvehCodigo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("tipveh_codigo");
            entity.Property(e => e.TipvehDescrip)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("tipveh_descrip");
            entity.Property(e => e.TipvehTarifa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tipveh_tarifa");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VehId).HasName("PK__vehiculo__9D15D3F9B411209F");

            entity.ToTable("vehiculo");

            entity.HasIndex(e => e.VehPlaca, "Unique_veh_placa").IsUnique();

            entity.Property(e => e.VehId).HasColumnName("veh_id");
            entity.Property(e => e.MarId).HasColumnName("mar_id");
            entity.Property(e => e.TipvehId).HasColumnName("tipveh_id");
            entity.Property(e => e.VehFecRegistro)
                .HasColumnType("datetime")
                .HasColumnName("veh_fec_registro");
            entity.Property(e => e.VehPlaca)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("veh_placa");

            entity.HasOne(d => d.Tipveh).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.TipvehId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_tipo_vehiculo_veh");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
