using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RevFIT.Context.Models;

namespace RevFIT.Context.Context;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Excercise> Excercises { get; set; }

    public virtual DbSet<ExcerciseDifficulty> ExcerciseDifficulties { get; set; }

    public virtual DbSet<ExcerciseProgram> ExcercisePrograms { get; set; }

    public virtual DbSet<ExcerciseType> ExcerciseTypes { get; set; }

    public virtual DbSet<ExcersiceMuscleGroup> ExcersiceMuscleGroups { get; set; }

    public virtual DbSet<ProgramType> ProgramTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }

    public virtual DbSet<WorkoutCircuitChild> WorkoutCircuitChildren { get; set; }

    public virtual DbSet<WorkoutCircuitParent> WorkoutCircuitParents { get; set; }

    public virtual DbSet<WorkoutRegular> WorkoutRegulars { get; set; }

    public virtual DbSet<WorkoutRegularChild> WorkoutRegularChildren { get; set; }

    public virtual DbSet<WorkoutScoringType> WorkoutScoringTypes { get; set; }

    public virtual DbSet<WorkoutType> WorkoutTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Excercise>(entity =>
        {
            entity.Property(e => e.ExcerciseId).HasColumnName("ExcerciseID");
            entity.Property(e => e.Difficulty).IsUnicode(false);
            entity.Property(e => e.Equipment).IsUnicode(false);
            entity.Property(e => e.Instructions).IsUnicode(false);
            entity.Property(e => e.Muscle).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.ProgramId).HasColumnName("ProgramID");
            entity.Property(e => e.Type).IsUnicode(false);
        });

        modelBuilder.Entity<ExcerciseDifficulty>(entity =>
        {
            entity.ToTable("ExcerciseDifficulty");

            entity.Property(e => e.ExcerciseDifficultyId).HasColumnName("ExcerciseDifficultyID");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Value).IsUnicode(false);
        });

        modelBuilder.Entity<ExcerciseProgram>(entity =>
        {
            entity.HasKey(e => e.ProgramId);

            entity.ToTable("ExcerciseProgram");

            entity.Property(e => e.ProgramId).HasColumnName("ProgramID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ProgramName).IsUnicode(false);
            entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.ProgramType).WithMany(p => p.ExcercisePrograms)
                .HasForeignKey(d => d.ProgramTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExcerciseProgram_ProgramType");
        });

        modelBuilder.Entity<ExcerciseType>(entity =>
        {
            entity.HasKey(e => e.ExcerciseTypId);

            entity.ToTable("ExcerciseType");

            entity.Property(e => e.ExcerciseTypId).HasColumnName("ExcerciseTypID");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Value).IsUnicode(false);
        });

        modelBuilder.Entity<ExcersiceMuscleGroup>(entity =>
        {
            entity.HasKey(e => e.MuscleGroupId);

            entity.ToTable("ExcersiceMuscleGroup");

            entity.Property(e => e.MuscleGroupId).HasColumnName("MuscleGroupID");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Value).IsUnicode(false);
        });

        modelBuilder.Entity<ProgramType>(entity =>
        {
            entity.ToTable("ProgramType");

            entity.Property(e => e.ProgramTypeId).HasColumnName("ProgramTypeID");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Value).IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Email).IsUnicode(false);
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.Property(e => e.WorkoutId).HasColumnName("WorkoutID");
            entity.Property(e => e.CoolDown).IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ProgramId).HasColumnName("ProgramID");
            entity.Property(e => e.WarmUp)
                .IsUnicode(false)
                .HasColumnName("WarmUP");
            entity.Property(e => e.WokoutDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.WorkoutName).IsUnicode(false);
            entity.Property(e => e.WorkoutTypeId).HasColumnName("WorkoutTypeID");

            entity.HasOne(d => d.Program).WithMany(p => p.Workouts)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Workouts_ExcerciseProgram");
        });

        modelBuilder.Entity<WorkoutCircuitChild>(entity =>
        {
            entity.HasKey(e => e.WorkoutCircuitChild1);

            entity.ToTable("WorkoutCircuitChild");

            entity.Property(e => e.WorkoutCircuitChild1).HasColumnName("WorkoutCircuitChild");
            entity.Property(e => e.Excercise).IsUnicode(false);
            entity.Property(e => e.Time).IsUnicode(false);
            entity.Property(e => e.WorkoutCircuitParentId).HasColumnName("WorkoutCircuitParentID");
            entity.Property(e => e.WorkoutDate).HasColumnType("datetime");

            entity.HasOne(d => d.WorkoutCircuitParent).WithMany(p => p.WorkoutCircuitChildren)
                .HasForeignKey(d => d.WorkoutCircuitParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkoutCircuitChild_WorkoutCircuitParent");
        });

        modelBuilder.Entity<WorkoutCircuitParent>(entity =>
        {
            entity.HasKey(e => e.WorkoutCircutParent).HasName("PK_WorkoutCircutParent");

            entity.ToTable("WorkoutCircuitParent");

            entity.Property(e => e.Time).IsUnicode(false);
            entity.Property(e => e.WokoutDate).HasColumnType("datetime");
            entity.Property(e => e.WorkoutId).HasColumnName("WorkoutID");

            entity.HasOne(d => d.Workout).WithMany(p => p.WorkoutCircuitParents)
                .HasForeignKey(d => d.WorkoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkoutCircuitParent_Workouts");
        });

        modelBuilder.Entity<WorkoutRegular>(entity =>
        {
            entity.ToTable("WorkoutRegular");

            entity.Property(e => e.WorkoutRegularId).HasColumnName("WorkoutRegularID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ExcerciseName).IsUnicode(false);
            entity.Property(e => e.MuscleGroupFocus).IsUnicode(false);
            entity.Property(e => e.Notes).IsUnicode(false);
            entity.Property(e => e.WorkoutId).HasColumnName("WorkoutID");

            entity.HasOne(d => d.Workout).WithMany(p => p.WorkoutRegulars)
                .HasForeignKey(d => d.WorkoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkoutRegular_Workouts");
        });

        modelBuilder.Entity<WorkoutRegularChild>(entity =>
        {
            entity.HasKey(e => e.WorkoutRegularChildrenId);

            entity.ToTable("WorkoutRegularChild");

            entity.Property(e => e.WorkoutRegularChildrenId).HasColumnName("WorkoutRegularChildrenID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Notes).IsUnicode(false);
            entity.Property(e => e.WorkoutRegularParentId).HasColumnName("WorkoutRegularParentID");

            entity.HasOne(d => d.WorkoutRegularParent).WithMany(p => p.WorkoutRegularChildren)
                .HasForeignKey(d => d.WorkoutRegularParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkoutRegularChild_WorkoutRegular");
        });

        modelBuilder.Entity<WorkoutScoringType>(entity =>
        {
            entity.HasKey(e => e.ScoringTypeId);

            entity.ToTable("WorkoutScoringType");

            entity.Property(e => e.ScoringTypeId)
                .ValueGeneratedNever()
                .HasColumnName("ScoringTypeID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ScoringType).IsUnicode(false);
        });

        modelBuilder.Entity<WorkoutType>(entity =>
        {
            entity.ToTable("WorkoutType");

            entity.Property(e => e.WorkoutTypeId).HasColumnName("WorkoutTypeID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.WorkoutType1)
                .IsUnicode(false)
                .HasColumnName("WorkoutType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
