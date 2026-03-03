using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using техносервис.Models;

namespace техносервис.Context;

public partial class DbUser13Context : DbContext
{
    public DbUser13Context()
    {
    }

    public DbUser13Context(DbContextOptions<DbUser13Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserApplication> UserApplications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.3.4;Database=db_user13;Username=user13;password=MKJPb+gbzMfAD2hP");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("applications_pkey");

            entity.ToTable("applications");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("add_date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.ExecutorId).HasColumnName("executor_id");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.Result)
                .HasMaxLength(255)
                .HasColumnName("result");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Applications)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("equipment_id");

            entity.HasOne(d => d.Executor).WithMany(p => p.ApplicationExecutors)
                .HasForeignKey(d => d.ExecutorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("applications_executor_id_fkey");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Application)
                .HasForeignKey<Application>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("applications_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Applications)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("applications_status_id_fkey");

            entity.HasOne(d => d.Type).WithMany(p => p.Applications)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("type_id");

            entity.HasOne(d => d.User).WithMany(p => p.ApplicationUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("applications_user_id_fkey");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comment_pkey");

            entity.ToTable("comment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApplicId).HasColumnName("applic_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Applic).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ApplicId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comment_applic_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comment_user_id_fkey");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("equipment_pkey");

            entity.ToTable("equipment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("priority_pkey");

            entity.ToTable("priority");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("status_pkey");

            entity.ToTable("status");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("status_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("type_pkey");

            entity.ToTable("type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("users_role_id_fkey");
        });

        modelBuilder.Entity<UserApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_application_pk");

            entity.ToTable("user_application");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicId).HasColumnName("applic_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Applic).WithMany(p => p.UserApplications)
                .HasForeignKey(d => d.ApplicId)
                .HasConstraintName("user_application_applications_fk");

            entity.HasOne(d => d.User).WithMany(p => p.UserApplications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_application_users_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
