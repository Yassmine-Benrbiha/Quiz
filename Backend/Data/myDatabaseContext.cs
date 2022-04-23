using System;
using System.Collections.Generic;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data
{
    public partial class myDatabaseContext : DbContext
    {
        public myDatabaseContext()
        {
        }

        public myDatabaseContext(DbContextOptions<myDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Option> Options { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<QuestionOption> QuestionOptions { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=myDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.OptId)
                    .HasName("PK__Option__140CDAA9B6D06C09");

                entity.ToTable("Option");

                entity.Property(e => e.OptId)
                    .HasColumnName("OPT_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.OptCreatedBy)
                    .HasMaxLength(250)
                    .HasColumnName("OPT_CreatedBy");

                entity.Property(e => e.OptCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("OPT_CreatedDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OptLastModifiedBy)
                    .HasMaxLength(250)
                    .HasColumnName("OPT_LastModifiedBy");

                entity.Property(e => e.OptLastModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("OPT_LastModifiedDate");

                entity.Property(e => e.OptText)
                    .HasMaxLength(500)
                    .HasColumnName("OPT_Text");

                entity.Property(e => e.OptValue).HasColumnName("OPT_Value");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QueId)
                    .HasName("PK__Question__30E0186D1AA80585");

                entity.ToTable("Question");

                entity.Property(e => e.QueId)
                    .HasColumnName("QUE_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.QueCreatedBy)
                    .HasMaxLength(250)
                    .HasColumnName("QUE_CreatedBy");

                entity.Property(e => e.QueCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("QUE_CreatedDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QueLastModifiedBy)
                    .HasMaxLength(250)
                    .HasColumnName("QUE_LastModifiedBy");

                entity.Property(e => e.QueLastModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("QUE_LastModifiedDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QueText)
                    .HasMaxLength(500)
                    .HasColumnName("QUE_Text");

                entity.Property(e => e.QueType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("QUE_TYPE");
            });

            modelBuilder.Entity<QuestionOption>(entity =>
            {
                entity.HasKey(e => new { e.QueId, e.OptId })
                    .HasName("PK__Question__B1A0D5C715F537C5");

                entity.Property(e => e.QueId).HasColumnName("QUE_Id");

                entity.Property(e => e.OptId).HasColumnName("OPT_Id");

                entity.HasOne(d => d.Opt)
                    .WithMany(p => p.QuestionOptions)
                    .HasForeignKey(d => d.OptId)
                    .HasConstraintName("Constr_Option_fk");

                entity.HasOne(d => d.Que)
                    .WithMany(p => p.QuestionOptions)
                    .HasForeignKey(d => d.QueId)
                    .HasConstraintName("Constr_Question_fk");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.HasKey(e => e.QuiId)
                    .HasName("PK__Quiz__D0A04FDEBC8FFE66");

                entity.ToTable("Quiz");

                entity.Property(e => e.QuiId)
                    .HasColumnName("QUI_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.QuiCreatedBy)
                    .HasMaxLength(250)
                    .HasColumnName("QUI_CreatedBy");

                entity.Property(e => e.QuiCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("QUI_CreatedDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QuiLastModifiedBy)
                    .HasMaxLength(250)
                    .HasColumnName("QUI_LastModifiedBy");

                entity.Property(e => e.QuiLastModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("QUI_LastModifiedDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QuiTitle)
                    .HasMaxLength(250)
                    .HasColumnName("QUI_Title");
            });

            modelBuilder.Entity<QuizQuestion>(entity =>
            {
                entity.HasKey(e => new { e.QuiId, e.QueId })
                    .HasName("PK__QuizQues__13AE4E582EFDA41C");

                entity.Property(e => e.QuiId).HasColumnName("QUI_Id");

                entity.Property(e => e.QueId).HasColumnName("QUE_Id");

                entity.HasOne(d => d.Que)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.QueId)
                    .HasConstraintName("Constr_QuestionId_fk");

                entity.HasOne(d => d.Qui)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.QuiId)
                    .HasConstraintName("Constr_QuizId_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
