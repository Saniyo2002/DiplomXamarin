using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace diplomApiV4
{
    public partial class DATABASE_1Context : DbContext
    {
        public DATABASE_1Context()
        {
        }

        public DATABASE_1Context(DbContextOptions<DATABASE_1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Case> Cases { get; set; } = null!;
        public virtual DbSet<ChipsetTypeMatheboard> ChipsetTypeMatheboards { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientComponent> ClientComponents { get; set; } = null!;
        public virtual DbSet<ComponentsType> ComponentsTypes { get; set; } = null!;
        public virtual DbSet<FormFactorTypeMatheboard> FormFactorTypeMatheboards { get; set; } = null!;
        public virtual DbSet<HardDisk> HardDisks { get; set; } = null!;
        public virtual DbSet<M2> M2s { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Matheboard> Matheboards { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderStatusType> OrderStatusTypes { get; set; } = null!;
        public virtual DbSet<PowerCase> PowerCases { get; set; } = null!;
        public virtual DbSet<Processor> Processors { get; set; } = null!;
        public virtual DbSet<Ram> Rams { get; set; } = null!;
        public virtual DbSet<RamType> RamTypes { get; set; } = null!;
        public virtual DbSet<SocketType> SocketTypes { get; set; } = null!;
        public virtual DbSet<SolidStateDrife> SolidStateDrives { get; set; } = null!;
        public virtual DbSet<Videocard> Videocards { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = SQL8001.site4now.net; Initial Catalog = db_a875cc_diplom; User Id = db_a875cc_diplom_admin; Password = sasha222; Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Case>(entity =>
            {
                entity.Property(e => e.CaseImage).HasMaxLength(200);

                entity.Property(e => e.CaseName).HasMaxLength(100);

                entity.Property(e => e.CasePrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.CaseFactory)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.CaseFactoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cases_Manufacturers");

                entity.HasOne(d => d.CaseFormFactor)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.CaseFormFactorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cases_FormFactorTypeMatheboard");

                entity.HasOne(d => d.ComponentType)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.ComponentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cases_ComponentsType");
            });

            modelBuilder.Entity<ChipsetTypeMatheboard>(entity =>
            {
                entity.HasKey(e => e.ChipsetTypeId);

                entity.ToTable("ChipsetTypeMatheboard");

                entity.Property(e => e.ChipsetName).HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientBirthday).HasColumnType("date");

                entity.Property(e => e.ClientImage).HasMaxLength(100);

                entity.Property(e => e.ClientMail).HasMaxLength(50);

                entity.Property(e => e.ClientNick).HasMaxLength(20);

                entity.Property(e => e.ClientPassword)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ClientComponent>(entity =>
            {
                entity.ToTable("ClientComponent");

                entity.Property(e => e.M2id).HasColumnName("M2Id");

                entity.HasOne(d => d.Case1)
                    .WithMany(p => p.ClientComponents)
                    .HasForeignKey(d => d.CaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientComponent_Cases");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientComponents)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientComponent_Clients");

                entity.HasOne(d => d.Hdd)
                    .WithMany(p => p.ClientComponents)
                    .HasForeignKey(d => d.HddId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientComponent_HardDisks");

                entity.HasOne(d => d.M2)
                    .WithMany(p => p.ClientComponents)
                    .HasForeignKey(d => d.M2id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientComponent_M2");

                entity.HasOne(d => d.Matheboard)
                    .WithMany(p => p.ClientComponents)
                    .HasForeignKey(d => d.MatheboardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientComponent_Matheboard");

                entity.HasOne(d => d.PowerCase)
                    .WithMany(p => p.ClientComponents)
                    .HasForeignKey(d => d.PowerCaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientComponent_PowerCases");

                entity.HasOne(d => d.Processor)
                    .WithMany(p => p.ClientComponents)
                    .HasForeignKey(d => d.ProcessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientComponent_Processors");

                entity.HasOne(d => d.Ram)
                    .WithMany(p => p.ClientComponents)
                    .HasForeignKey(d => d.RamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientComponent_Rams");

                entity.HasOne(d => d.Ssd)
                    .WithMany(p => p.ClientComponents)
                    .HasForeignKey(d => d.SsdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientComponent_SolidStateDrives");

                entity.HasOne(d => d.Videocard)
                    .WithMany(p => p.ClientComponents)
                    .HasForeignKey(d => d.VideocardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientComponent_Videocards");
            });

            modelBuilder.Entity<ComponentsType>(entity =>
            {
                entity.HasKey(e => e.ComponentId);

                entity.ToTable("ComponentsType");

                entity.Property(e => e.ComponentName).HasMaxLength(50);
            });

            modelBuilder.Entity<FormFactorTypeMatheboard>(entity =>
            {
                entity.HasKey(e => e.FormFactorTypeId);

                entity.ToTable("FormFactorTypeMatheboard");

                entity.Property(e => e.FormFactorName).HasMaxLength(100);
            });

            modelBuilder.Entity<HardDisk>(entity =>
            {
                entity.HasKey(e => e.HddId);

                entity.Property(e => e.HddImage).HasMaxLength(200);

                entity.Property(e => e.HddName).HasMaxLength(100);

                entity.Property(e => e.HddPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.ComponentType)
                    .WithMany(p => p.HardDisks)
                    .HasForeignKey(d => d.ComponentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardDisks_ComponentsType");

                entity.HasOne(d => d.HddFactory)
                    .WithMany(p => p.HardDisks)
                    .HasForeignKey(d => d.HddFactoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardDisks_Manufacturers");
            });

            modelBuilder.Entity<M2>(entity =>
            {
                entity.ToTable("M2");

                entity.Property(e => e.M2id).HasColumnName("M2Id");

                entity.Property(e => e.M2factoryId).HasColumnName("M2FactoryId");

                entity.Property(e => e.M2image)
                    .HasMaxLength(200)
                    .HasColumnName("M2Image");

                entity.Property(e => e.M2name)
                    .HasMaxLength(100)
                    .HasColumnName("M2Name");

                entity.Property(e => e.M2price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M2Price");

                entity.HasOne(d => d.ComponentType)
                    .WithMany(p => p.M2s)
                    .HasForeignKey(d => d.ComponentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_M2_ComponentsType");

                entity.HasOne(d => d.M2factory)
                    .WithMany(p => p.M2s)
                    .HasForeignKey(d => d.M2factoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_M2_Manufacturers");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(e => e.ManagerFullName).HasMaxLength(100);

                entity.Property(e => e.ManagerImage).HasMaxLength(200);

                entity.Property(e => e.ManagerPhone).HasMaxLength(15);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.FactoryId);

                entity.Property(e => e.FactoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Matheboard>(entity =>
            {
                entity.ToTable("Matheboard");

                entity.Property(e => e.MatheboardImage).HasMaxLength(200);

                entity.Property(e => e.MatheboardM2count).HasColumnName("MatheboardM2Count");

                entity.Property(e => e.MatheboardName).HasMaxLength(500);

                entity.Property(e => e.MatheboardPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.ComponentType)
                    .WithMany(p => p.Matheboards)
                    .HasForeignKey(d => d.ComponentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matheboard_ComponentsType");

                entity.HasOne(d => d.MatheboardChipset)
                    .WithMany(p => p.Matheboards)
                    .HasForeignKey(d => d.MatheboardChipsetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matheboard_ChipsetTypeMatheboard");

                entity.HasOne(d => d.MatheboardManufacturer)
                    .WithMany(p => p.Matheboards)
                    .HasForeignKey(d => d.MatheboardManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matheboard_Manufacturers");

                entity.HasOne(d => d.MatheboardSocket)
                    .WithMany(p => p.Matheboards)
                    .HasForeignKey(d => d.MatheboardSocketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matheboard_SocketType");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.ClientComponents)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientComponentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_ClientComponent");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Clients");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Managers");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK_Orders_OrderStatusType");
            });

            modelBuilder.Entity<OrderStatusType>(entity =>
            {
                entity.HasKey(e => e.OrderStatusId);

                entity.ToTable("OrderStatusType");

                entity.Property(e => e.OrderTitle).HasMaxLength(50);
            });

            modelBuilder.Entity<PowerCase>(entity =>
            {
                entity.Property(e => e.PowerCaseImage).HasMaxLength(200);

                entity.Property(e => e.PowerCaseName).HasMaxLength(100);

                entity.Property(e => e.PowerCasePrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.ComponentType)
                    .WithMany(p => p.PowerCases)
                    .HasForeignKey(d => d.ComponentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PowerCases_ComponentsType");

                entity.HasOne(d => d.PowerCaseFactory)
                    .WithMany(p => p.PowerCases)
                    .HasForeignKey(d => d.PowerCaseFactoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PowerCases_Manufacturers");
            });

            modelBuilder.Entity<Processor>(entity =>
            {
                entity.Property(e => e.ProcessorImage).HasMaxLength(200);

                entity.Property(e => e.ProcessorName).HasMaxLength(100);

                entity.Property(e => e.ProcessorPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.ComponentType)
                    .WithMany(p => p.Processors)
                    .HasForeignKey(d => d.ComponentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processors_ComponentsType");

                entity.HasOne(d => d.ProcessorFactory)
                    .WithMany(p => p.Processors)
                    .HasForeignKey(d => d.ProcessorFactoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processors_Manufacturers");

                entity.HasOne(d => d.ProcessorSocket)
                    .WithMany(p => p.Processors)
                    .HasForeignKey(d => d.ProcessorSocketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Processors_SocketType");
            });

            modelBuilder.Entity<Ram>(entity =>
            {
                entity.Property(e => e.RamImage).HasMaxLength(250);

                entity.Property(e => e.RamName).HasMaxLength(100);

                entity.Property(e => e.RamPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.ComponentType)
                    .WithMany(p => p.Rams)
                    .HasForeignKey(d => d.ComponentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rams_ComponentsType");

                entity.HasOne(d => d.RamFactory)
                    .WithMany(p => p.Rams)
                    .HasForeignKey(d => d.RamFactoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rams_Manufacturers");

                entity.HasOne(d => d.RamType)
                    .WithMany(p => p.Rams)
                    .HasForeignKey(d => d.RamTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rams_RamType");
            });

            modelBuilder.Entity<RamType>(entity =>
            {
                entity.ToTable("RamType");

                entity.Property(e => e.RamName).HasMaxLength(100);
            });

            modelBuilder.Entity<SocketType>(entity =>
            {
                entity.HasKey(e => e.IdSocketType);

                entity.ToTable("SocketType");

                entity.Property(e => e.SocketName).HasMaxLength(50);
            });

            modelBuilder.Entity<SolidStateDrife>(entity =>
            {
                entity.HasKey(e => e.SsdId);

                entity.Property(e => e.SsdImage).HasMaxLength(200);

                entity.Property(e => e.SsdName).HasMaxLength(100);

                entity.Property(e => e.SsdPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.ComponentType)
                    .WithMany(p => p.SolidStateDrives)
                    .HasForeignKey(d => d.ComponentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolidStateDrives_ComponentsType");

                entity.HasOne(d => d.SsdFactory)
                    .WithMany(p => p.SolidStateDrives)
                    .HasForeignKey(d => d.SsdFactoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SolidStateDrives_Manufacturers");
            });

            modelBuilder.Entity<Videocard>(entity =>
            {
                entity.Property(e => e.VideocardImage).HasMaxLength(200);

                entity.Property(e => e.VideocardName).HasMaxLength(100);

                entity.Property(e => e.VideocardPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.ComponentType)
                    .WithMany(p => p.Videocards)
                    .HasForeignKey(d => d.ComponentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Videocards_ComponentsType");

                entity.HasOne(d => d.VideocardFactory)
                    .WithMany(p => p.Videocards)
                    .HasForeignKey(d => d.VideocardFactoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Videocards_Manufacturers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
