using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Anima
{
    public partial class AnimaDBContext : DbContext
    {
        public AnimaDBContext()
        {
        }

        public AnimaDBContext(DbContextOptions<AnimaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAluno> TbAluno { get; set; }
        public virtual DbSet<TbGrade> TbGrade { get; set; }
        public virtual DbSet<TbMatricula> TbMatricula { get; set; }
        public virtual DbSet<TbProfessor> TbProfessor { get; set; }
        public virtual DbSet<TbUsuario> TbUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("AnimaContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAluno>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK_tbAluno_CPF");

                entity.ToTable("tbAluno");

                entity.HasIndex(e => e.Ra)
                    .HasName("UK_tbAluno_RA")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11);

                entity.Property(e => e.Ra).HasColumnName("RA");

                entity.HasOne(d => d.CpfNavigation)
                    .WithOne(p => p.TbAluno)
                    .HasForeignKey<TbAluno>(d => d.Cpf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbAluno_tbUsuario");
            });

            modelBuilder.Entity<TbGrade>(entity =>
            {
                entity.HasKey(e => e.CodGrade)
                    .HasName("PK_tbGrade_CodGrade");

                entity.ToTable("tbGrade");

                entity.Property(e => e.CodGrade).ValueGeneratedNever();

                entity.Property(e => e.NomeCurso)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NomeDisciplina)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NomeTurma)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.CodFuncionarioNavigation)
                    .WithMany(p => p.TbGrade)
                    .HasPrincipalKey(p => p.CodFuncionario)
                    .HasForeignKey(d => d.CodFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbGrade_tbProfessor");

                entity.HasOne(d => d.CodParentGradeNavigation)
                    .WithMany(p => p.InverseCodParentGradeNavigation)
                    .HasForeignKey(d => d.CodParentGrade)
                    .HasConstraintName("FK_tbGrade_tbGrade");
            });


            modelBuilder.Entity<TbMatricula>(entity =>
            {
                entity.HasKey(e => new { e.CodGrade, e.Ra });

                entity.ToTable("tbMatricula");

                entity.HasIndex(e => new { e.Ra, e.CodGrade })
                    .HasName("UK_tbMatricula_RA_CodGrade")
                    .IsUnique();

                entity.Property(e => e.Ra).HasColumnName("RA");

                entity.HasOne(d => d.CodGradeNavigation)
                    .WithMany(p => p.TbMatricula)
                    .HasForeignKey(d => d.CodGrade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMatricula_tbGrade");

                entity.HasOne(d => d.RaNavigation)
                    .WithMany(p => p.TbMatricula)
                    .HasPrincipalKey(p => p.Ra)
                    .HasForeignKey(d => d.Ra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMatricula_tbAluno");
            });

            modelBuilder.Entity<TbProfessor>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK_tbProfessor_CPF");

                entity.ToTable("tbProfessor");

                entity.HasIndex(e => e.CodFuncionario)
                    .HasName("UK_tbProfessor_CodFuncionario")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11);

                entity.Property(e => e.CodFuncionario).HasColumnName("codFuncionario");

                entity.HasOne(d => d.CpfNavigation)
                    .WithOne(p => p.TbProfessor)
                    .HasForeignKey<TbProfessor>(d => d.Cpf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProfessor_tbUsuario");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK_tbUsuario_CPF");

                entity.ToTable("tbUsuario");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
