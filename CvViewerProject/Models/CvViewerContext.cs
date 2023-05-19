using System;
using System.DirectoryServices;
using CvViewerProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cv_Viewer.Models
{
    public partial class CvViewerContext : DbContext
    {
        public CvViewerContext()
        {
        }

        public CvViewerContext(DbContextOptions<CvViewerContext> options)
            : base(options)
        {
        }
        public virtual DbSet<AccountCount> account_count { get; set; }
        public virtual DbSet<Account> accounts { get; set; }
        public virtual DbSet<Communication> communications { get; set; }
        public virtual DbSet<Company> companies { get; set; }
        public virtual DbSet<Position> positions { get; set; }
        public virtual DbSet<CompanyPosition> company_positions { get; set; }
        public virtual DbSet<Person> people { get; set; }
        public virtual DbSet<PersonEdu> person_educations { get; set; }
        public virtual DbSet<Education> educations { get; set; }
        public virtual DbSet<School> schools { get; set; }
        public virtual DbSet<Department> departments { get; set; }
        public virtual DbSet<SchoolDepart> school_departments { get; set; }
        public virtual DbSet<Country> countries { get; set; }
        public virtual DbSet<City> cities { get; set; }
        public virtual DbSet<Experience> experiences { get; set; }
        public virtual DbSet<Ability> abilities { get; set; }
        public virtual DbSet<PersonAbility> person_abilities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=CvViewerDbProject;Username=postgres;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_Turkey.1252");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.e_mail, "Account_eMail_key")
                    .IsUnique();

                entity.Property(e => e.account_id)
                    .ValueGeneratedNever()
                    .HasColumnName("account_id");

                entity.Property(e => e.e_mail)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("e_mail");

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.company_id)
                    .ValueGeneratedNever()
                    .HasColumnName("company_id");

                entity.Property(e => e.company_name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("company_name");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.person_id)
                    .ValueGeneratedNever()
                    .HasColumnName("person_id");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
                 
            });
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.country_id)
                .ValueGeneratedNever()
                .HasColumnName("country_id");

                entity.Property(e => e.country_name).IsRequired()
                .HasMaxLength(20)
                .HasColumnName("country_name");
            });
            modelBuilder.Entity<Account>()
                .HasKey(ky => ky.account_id);

            modelBuilder.Entity<Ability>()
                .HasKey(ky => ky.ability_id);

            modelBuilder.Entity<City>()
                .HasKey(ky=>ky.city_id);

            modelBuilder.Entity<Communication>()
                .HasKey(ky => ky.communication_id);

            modelBuilder.Entity<Company>()
                .HasKey(ky => ky.company_id);

            modelBuilder.Entity<Country>()
                .HasKey(ky=>ky.country_id);

            modelBuilder.Entity<Department>()
                .HasKey(ky => ky.department_id);

            modelBuilder.Entity<Education>()
                .HasKey(ky => ky.edu_id);

            modelBuilder.Entity<Experience>()
                .HasKey(ky => ky.experience_id);

            modelBuilder.Entity<Person>()
                .HasKey(ky => ky.person_id);

            modelBuilder.Entity<PersonAbility>()
                .HasKey(ky => new { ky.ability_id, ky.person_id });
            modelBuilder.Entity<PersonEdu>()
                .HasKey(ky => new { ky.person_id, ky.edu_id });

            modelBuilder.Entity<Position>()
                .HasKey(ky => ky.position_id);

            modelBuilder.Entity<School>()
                .HasKey(ky=>ky.school_id);
            
            modelBuilder.Entity<SchoolDepart>()
                .HasKey(ky => new { ky.school_id, ky.department_id });

            modelBuilder.Entity<CompanyPosition>()
                .HasKey(ky => new { ky.position_id, ky.company_id });


            //modelBuilder.Entity<Communication>()
            //    .HasKey(ky => ky.communication_id);
            //modelBuilder.Entity<Account>()
            //    .HasOne(a => a.communication)
            //    .WithOne(c => c.account)
            //    .HasForeignKey<Communication>(c => c.communication_id);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
