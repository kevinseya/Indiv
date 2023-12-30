using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Indiv.Models;

public partial class Indiv2Context : DbContext
{
    public Indiv2Context()
    {
    }

    public Indiv2Context(DbContextOptions<Indiv2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Carro> Carros { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Colore> Colores { get; set; }

    public virtual DbSet<Domicilio> Domicilios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MATEOPC;Initial Catalog=INDIV_2;User ID=MateoMarcos;Password=MateoMarcos;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carro>(entity =>
        {
            entity.HasKey(e => e.Idcarro).HasName("PK__Carros__1B46E29708919468");

            entity.Property(e => e.Idcarro).HasColumnName("IDCARRO");
            entity.Property(e => e.Aniofabricacion).HasColumnName("ANIOFABRICACION");
            entity.Property(e => e.Colorid).HasColumnName("COLORID");
            entity.Property(e => e.Modelo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MODELO");

            entity.HasOne(d => d.Color).WithMany(p => p.Carros)
                .HasForeignKey(d => d.Colorid)
                .HasConstraintName("FK__Carros__COLORID__2C3393D0");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__Clientes__1EA344C2115733B7");

            entity.Property(e => e.Idcliente).HasColumnName("IDCLIENTE");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IDENTIFICACION");
            entity.Property(e => e.Nombres)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
        });

        modelBuilder.Entity<Colore>(entity =>
        {
            entity.HasKey(e => e.Idcolor).HasName("PK__Colores__C6042179118F61FE");

            entity.Property(e => e.Idcolor).HasColumnName("IDCOLOR");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("COLOR");
        });

        modelBuilder.Entity<Domicilio>(entity =>
        {
            entity.HasKey(e => e.Iddomicilio).HasName("PK__Domicili__84335A8FB7F36E2A");

            entity.ToTable("Domicilio");

            entity.HasIndex(e => e.Clientesid, "UQ__Domicili__5FE975FD258F7FD4").IsUnique();

            entity.Property(e => e.Iddomicilio).HasColumnName("IDDOMICILIO");
            entity.Property(e => e.Calle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CALLE");
            entity.Property(e => e.Clientesid).HasColumnName("CLIENTESID");
            entity.Property(e => e.Numerocasa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NUMEROCASA");

            entity.HasOne(d => d.Clientes).WithOne(p => p.Domicilio)
                .HasForeignKey<Domicilio>(d => d.Clientesid)
                .HasConstraintName("FK__Domicilio__CLIEN__276EDEB3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
