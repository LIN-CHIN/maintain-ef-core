using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace maintainProject.Models
{
    public partial class MaintainContext : DbContext
    {
        public MaintainContext()
        {
        }

        public MaintainContext(DbContextOptions<MaintainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EquipmentInfo> EquipmentInfos { get; set; }
        public virtual DbSet<MaintainInfo> MaintainInfos { get; set; }
        public virtual DbSet<MaintainPlan> MaintainPlans { get; set; }
        public virtual DbSet<MaintainRecord> MaintainRecords { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=maintain;user=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<EquipmentInfo>(entity =>
            {
                entity.HasKey(e => e.EquipmentId)
                    .HasName("PRIMARY");

                entity.ToTable("equipment_info");

                entity.HasComment("設備基本資訊")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.EquipmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("equipment_id");

                entity.Property(e => e.CrtDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("crt_datetime");

                entity.Property(e => e.CrtUserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("crt_user_id")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.EquipmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("equipment_name")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.EquipmentStatus)
                    .HasMaxLength(1)
                    .HasColumnName("equipment_status")
                    .HasDefaultValueSql("'0'")
                    .IsFixedLength(true)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IsStop)
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_stop")
                    .HasDefaultValueSql("b'0'");
            });

            modelBuilder.Entity<MaintainInfo>(entity =>
            {
                entity.HasKey(e => e.MaintainItemId)
                    .HasName("PRIMARY");

                entity.ToTable("maintain_info");

                entity.HasComment("保養基本資料")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.MaintainItemId).HasColumnName("maintain_item_id");

                entity.Property(e => e.CrtDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("crt_datetime");

                entity.Property(e => e.CrtUserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("crt_user_id")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MaintainItemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("maintain_item_name")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MaintainType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("maintain_type")
                    .IsFixedLength(true)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<MaintainPlan>(entity =>
            {
                entity.HasKey(e => new { e.EquipmentId, e.MaintainId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("maintain_plan");

                entity.HasComment("保養計畫")
                    .HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

                entity.Property(e => e.MaintainId).HasColumnName("maintain_id");

                entity.Property(e => e.CrtDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("crt_datetime");

                entity.Property(e => e.CrtUserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("crt_user_id");

                entity.Property(e => e.IsStop)
                    .HasMaxLength(1)
                    .HasColumnName("is_stop")
                    .HasDefaultValueSql("'0'")
                    .IsFixedLength(true)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MaintainStatus)
                    .HasMaxLength(1)
                    .HasColumnName("maintain_status")
                    .HasDefaultValueSql("'0'")
                    .IsFixedLength(true)
                    .HasComment("未達保養時間、需保養、正在保養")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NextMaintainDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("next_maintain_datetime");

                entity.Property(e => e.PlanStartDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("plan_start_datetime");

                entity.Property(e => e.RegularDatetime)
                    .HasMaxLength(50)
                    .HasColumnName("regular_datetime")
                    .HasComment("定期保養時間(每月五號) ex: 1205 (每個12月的五號) , 9905(每個月五號))")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SpecialDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("special_datetime")
                    .HasComment("特定時間 ex: 2022/03/20");

                entity.Property(e => e.Times).HasColumnName("times");
            });

            modelBuilder.Entity<MaintainRecord>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("PRIMARY");

                entity.ToTable("maintain_record");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.RecordId)
                    .ValueGeneratedNever()
                    .HasColumnName("record_id");

                entity.Property(e => e.EndDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_datetime");

                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

                entity.Property(e => e.MaintainDesc)
                    .HasMaxLength(50)
                    .HasColumnName("maintain_desc")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MaintainId).HasColumnName("maintain_id");

                entity.Property(e => e.MaintainUserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("maintain_user_id")
                    .HasComment("保養人員")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PassDesc)
                    .HasMaxLength(50)
                    .HasColumnName("pass_desc")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PassUserId)
                    .HasMaxLength(50)
                    .HasColumnName("pass_user_id")
                    .HasComment("驗收人員")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StartDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'")
                    .IsFixedLength(true)
                    .HasComment("正在保養、待驗收、驗收不通過、保養完成")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("user_info");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("user_id")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("department")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("role")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("user_name")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
