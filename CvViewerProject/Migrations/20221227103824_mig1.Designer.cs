﻿// <auto-generated />
using System;
using Cv_Viewer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CvViewerProject.Migrations
{
    [DbContext(typeof(CvViewerContext))]
    [Migration("20221227103824_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Turkish_Turkey.1252")
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cv_Viewer.Models.Ability", b =>
                {
                    b.Property<int>("ability_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ability_id"));

                    b.Property<string>("ability_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ability_id");

                    b.ToTable("abilities");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Account", b =>
                {
                    b.Property<int>("account_id")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<string>("account_type")
                        .HasColumnType("text");

                    b.Property<int>("city_id")
                        .HasColumnType("integer");

                    b.Property<int>("country_id")
                        .HasColumnType("integer");

                    b.Property<string>("e_mail")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)")
                        .HasColumnName("e_mail");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("password");

                    b.Property<string>("picture_path")
                        .HasColumnType("text");

                    b.HasKey("account_id");

                    b.HasIndex("city_id");

                    b.HasIndex("country_id");

                    b.HasIndex(new[] { "e_mail" }, "Account_eMail_key")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Cv_Viewer.Models.City", b =>
                {
                    b.Property<int>("city_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("city_id"));

                    b.Property<string>("city_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("country_id")
                        .HasColumnType("integer");

                    b.HasKey("city_id");

                    b.HasIndex("country_id");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Communication", b =>
                {
                    b.Property<int>("communication_id")
                        .HasColumnType("integer");

                    b.Property<string>("facebook")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("linked_in")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("twitter")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("communication_id");

                    b.ToTable("communications");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Company", b =>
                {
                    b.Property<int>("company_id")
                        .HasColumnType("integer")
                        .HasColumnName("company_id");

                    b.Property<string>("company_name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("company_name");

                    b.HasKey("company_id");

                    b.ToTable("company", (string)null);
                });

            modelBuilder.Entity("Cv_Viewer.Models.CompanyPosition", b =>
                {
                    b.Property<int>("position_id")
                        .HasColumnType("integer");

                    b.Property<int>("company_id")
                        .HasColumnType("integer");

                    b.HasKey("position_id", "company_id");

                    b.HasIndex("company_id");

                    b.ToTable("company_positions");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Country", b =>
                {
                    b.Property<int>("country_id")
                        .HasColumnType("integer")
                        .HasColumnName("country_id");

                    b.Property<string>("country_name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("country_name");

                    b.HasKey("country_id");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Department", b =>
                {
                    b.Property<int>("department_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("department_id"));

                    b.Property<string>("department_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("department_id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Education", b =>
                {
                    b.Property<int>("edu_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("edu_id"));

                    b.Property<int>("department_id")
                        .HasColumnType("integer");

                    b.Property<int>("university_id")
                        .HasColumnType("integer");

                    b.HasKey("edu_id");

                    b.HasIndex("department_id");

                    b.HasIndex("university_id");

                    b.ToTable("educations");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Experience", b =>
                {
                    b.Property<int>("experience_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("experience_id"));

                    b.Property<int>("company_id")
                        .HasColumnType("integer");

                    b.Property<string>("end_date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("person_id")
                        .HasColumnType("integer");

                    b.Property<int>("position_id")
                        .HasColumnType("integer");

                    b.Property<string>("start_date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("experience_id");

                    b.HasIndex("company_id");

                    b.HasIndex("person_id");

                    b.HasIndex("position_id");

                    b.ToTable("experiences");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Person", b =>
                {
                    b.Property<int>("person_id")
                        .HasColumnType("integer")
                        .HasColumnName("person_id");

                    b.Property<string>("level")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<string>("school")
                        .HasColumnType("text");

                    b.HasKey("person_id");

                    b.ToTable("person", (string)null);
                });

            modelBuilder.Entity("Cv_Viewer.Models.PersonAbility", b =>
                {
                    b.Property<int>("ability_id")
                        .HasColumnType("integer");

                    b.Property<int>("person_id")
                        .HasColumnType("integer");

                    b.HasKey("ability_id", "person_id");

                    b.HasIndex("person_id");

                    b.ToTable("person_abilities");
                });

            modelBuilder.Entity("Cv_Viewer.Models.PersonEdu", b =>
                {
                    b.Property<int>("person_id")
                        .HasColumnType("integer");

                    b.Property<int>("edu_id")
                        .HasColumnType("integer");

                    b.Property<int?>("PersonEduedu_id")
                        .HasColumnType("integer");

                    b.Property<int?>("PersonEduperson_id")
                        .HasColumnType("integer");

                    b.Property<string>("end_date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("start_date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("person_id", "edu_id");

                    b.HasIndex("edu_id");

                    b.HasIndex("PersonEduperson_id", "PersonEduedu_id");

                    b.ToTable("person_educations");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Position", b =>
                {
                    b.Property<int>("position_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("position_id"));

                    b.Property<string>("position_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("position_id");

                    b.ToTable("positions");
                });

            modelBuilder.Entity("Cv_Viewer.Models.School", b =>
                {
                    b.Property<int>("school_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("school_id"));

                    b.Property<string>("school_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("school_id");

                    b.ToTable("schools");
                });

            modelBuilder.Entity("Cv_Viewer.Models.SchoolDepart", b =>
                {
                    b.Property<int>("school_id")
                        .HasColumnType("integer");

                    b.Property<int>("department_id")
                        .HasColumnType("integer");

                    b.HasKey("school_id", "department_id");

                    b.HasIndex("department_id");

                    b.ToTable("school_departments");
                });

            modelBuilder.Entity("CvViewerProject.Models.AccountCount", b =>
                {
                    b.Property<int>("AccountCountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AccountCountId"));

                    b.Property<int>("account_count")
                        .HasColumnType("integer");

                    b.HasKey("AccountCountId");

                    b.ToTable("account_count");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Account", b =>
                {
                    b.HasOne("Cv_Viewer.Models.City", "city")
                        .WithMany("accounts")
                        .HasForeignKey("city_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cv_Viewer.Models.Country", "country")
                        .WithMany("accounts")
                        .HasForeignKey("country_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");

                    b.Navigation("country");
                });

            modelBuilder.Entity("Cv_Viewer.Models.City", b =>
                {
                    b.HasOne("Cv_Viewer.Models.Country", "country")
                        .WithMany("cities")
                        .HasForeignKey("country_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Communication", b =>
                {
                    b.HasOne("Cv_Viewer.Models.Account", "account")
                        .WithOne("communication")
                        .HasForeignKey("Cv_Viewer.Models.Communication", "communication_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("Cv_Viewer.Models.CompanyPosition", b =>
                {
                    b.HasOne("Cv_Viewer.Models.Company", "company")
                        .WithMany("company_positions")
                        .HasForeignKey("company_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cv_Viewer.Models.Position", "position")
                        .WithMany("companies")
                        .HasForeignKey("position_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");

                    b.Navigation("position");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Education", b =>
                {
                    b.HasOne("Cv_Viewer.Models.Department", "department")
                        .WithMany("educations")
                        .HasForeignKey("department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cv_Viewer.Models.School", "school")
                        .WithMany("educations")
                        .HasForeignKey("university_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");

                    b.Navigation("school");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Experience", b =>
                {
                    b.HasOne("Cv_Viewer.Models.Company", "company")
                        .WithMany("experiences")
                        .HasForeignKey("company_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cv_Viewer.Models.Person", "person")
                        .WithMany("experiences")
                        .HasForeignKey("person_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cv_Viewer.Models.Position", "position")
                        .WithMany("experiences")
                        .HasForeignKey("position_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");

                    b.Navigation("person");

                    b.Navigation("position");
                });

            modelBuilder.Entity("Cv_Viewer.Models.PersonAbility", b =>
                {
                    b.HasOne("Cv_Viewer.Models.Ability", "ability")
                        .WithMany("person_abilities")
                        .HasForeignKey("ability_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cv_Viewer.Models.Person", "person")
                        .WithMany("person_ability")
                        .HasForeignKey("person_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ability");

                    b.Navigation("person");
                });

            modelBuilder.Entity("Cv_Viewer.Models.PersonEdu", b =>
                {
                    b.HasOne("Cv_Viewer.Models.Education", "education")
                        .WithMany("person_educations")
                        .HasForeignKey("edu_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cv_Viewer.Models.Person", "person")
                        .WithMany("person_educations")
                        .HasForeignKey("person_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cv_Viewer.Models.PersonEdu", null)
                        .WithMany("person_educations")
                        .HasForeignKey("PersonEduperson_id", "PersonEduedu_id");

                    b.Navigation("education");

                    b.Navigation("person");
                });

            modelBuilder.Entity("Cv_Viewer.Models.SchoolDepart", b =>
                {
                    b.HasOne("Cv_Viewer.Models.Department", "department")
                        .WithMany("school_departs")
                        .HasForeignKey("department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cv_Viewer.Models.School", "school")
                        .WithMany("school_departs")
                        .HasForeignKey("school_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");

                    b.Navigation("school");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Ability", b =>
                {
                    b.Navigation("person_abilities");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Account", b =>
                {
                    b.Navigation("communication");
                });

            modelBuilder.Entity("Cv_Viewer.Models.City", b =>
                {
                    b.Navigation("accounts");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Company", b =>
                {
                    b.Navigation("company_positions");

                    b.Navigation("experiences");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Country", b =>
                {
                    b.Navigation("accounts");

                    b.Navigation("cities");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Department", b =>
                {
                    b.Navigation("educations");

                    b.Navigation("school_departs");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Education", b =>
                {
                    b.Navigation("person_educations");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Person", b =>
                {
                    b.Navigation("experiences");

                    b.Navigation("person_ability");

                    b.Navigation("person_educations");
                });

            modelBuilder.Entity("Cv_Viewer.Models.PersonEdu", b =>
                {
                    b.Navigation("person_educations");
                });

            modelBuilder.Entity("Cv_Viewer.Models.Position", b =>
                {
                    b.Navigation("companies");

                    b.Navigation("experiences");
                });

            modelBuilder.Entity("Cv_Viewer.Models.School", b =>
                {
                    b.Navigation("educations");

                    b.Navigation("school_departs");
                });
#pragma warning restore 612, 618
        }
    }
}
