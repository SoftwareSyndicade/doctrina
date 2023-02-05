﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using doctrine_api.Services.SQLServer;

#nullable disable

namespace doctrineapi.Migrations
{
    [DbContext(typeof(DoctrinaStore))]
    partial class DoctrinaStoreModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("doctrine_api.DataModels.Account", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ACCOUNT_TYPE")
                        .HasColumnType("int");

                    b.Property<DateTime>("CREATED_ON")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FIRST_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("IMAGE")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LAST_NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MIDDEL_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PASSWORD_HASH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PHONE_NUMBER")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("SALT")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("USERNAME")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ID");

                    b.ToTable("ACCOUNT");
                });

            modelBuilder.Entity("doctrine_api.DataModels.AssistanceProposals", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ACTIVE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AVAILABILITY")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("COST")
                        .HasColumnType("float");

                    b.Property<string>("CREATED_BY")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CREATED_ON")
                        .HasColumnType("datetime2");

                    b.Property<double>("DISCOUNT")
                        .HasColumnType("float");

                    b.Property<int>("HOURS")
                        .HasColumnType("int");

                    b.Property<double>("PERHOUR_RATE")
                        .HasColumnType("float");

                    b.Property<string>("REQUEST_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TUTOR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("REQUEST_ID");

                    b.ToTable("ASSISTANCE_PROPOSALS");
                });

            modelBuilder.Entity("doctrine_api.DataModels.AssistanceReuest", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CATEGORY")
                        .HasColumnType("int");

                    b.Property<bool>("COMPLETED")
                        .HasColumnType("bit");

                    b.Property<string>("CREATED_BY")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CREATED_ON")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DEADLINE")
                        .HasColumnType("datetime2");

                    b.Property<string>("DETAILS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EDUCATION_LEVEL")
                        .HasColumnType("int");

                    b.Property<bool>("IS_RECURRING")
                        .HasColumnType("bit");

                    b.Property<string>("MEETING_LINK")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PAID")
                        .HasColumnType("bit");

                    b.Property<string>("TUTOR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ASSISTANCE_REQUEST");
                });

            modelBuilder.Entity("doctrine_api.DataModels.Attachments", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("CONTENT")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("CREATED_ON")
                        .HasColumnType("datetime2");

                    b.Property<string>("MIME_TYPE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("REQUEST_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("REQUEST_ID");

                    b.ToTable("ATTACHMENTS");
                });

            modelBuilder.Entity("doctrine_api.DataModels.Degree", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CREATED_ON")
                        .HasColumnType("datetime2");

                    b.Property<int>("EDUCATION_LEVEL")
                        .HasColumnType("int");

                    b.Property<int>("GRADES")
                        .HasColumnType("int");

                    b.Property<string>("QUALIFICATION_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("QUALIFICATION_ID");

                    b.ToTable("DEGREE");
                });

            modelBuilder.Entity("doctrine_api.DataModels.Qualification", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CREATED_ON")
                        .HasColumnType("datetime2");

                    b.Property<string>("FIELD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("INSTITUTION")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NUMBER_OF_YEARS")
                        .HasColumnType("int");

                    b.Property<int>("QUALIFICATION_TYPE")
                        .HasColumnType("int");

                    b.Property<string>("TITLE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TUTOR_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("TUTOR_ID");

                    b.ToTable("QUALIFICATIONS");
                });

            modelBuilder.Entity("doctrine_api.DataModels.Student", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ACCOUNT_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CREATED_ON")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ACCOUNT_ID");

                    b.ToTable("STUDENT");
                });

            modelBuilder.Entity("doctrine_api.DataModels.Tutor", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ACCOUNT_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CREATED_ON")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ACCOUNT_ID");

                    b.ToTable("TUTOR");
                });

            modelBuilder.Entity("doctrine_api.DataModels.AssistanceProposals", b =>
                {
                    b.HasOne("doctrine_api.DataModels.AssistanceReuest", "ASSISTANCE_REQUEST")
                        .WithMany()
                        .HasForeignKey("REQUEST_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ASSISTANCE_REQUEST");
                });

            modelBuilder.Entity("doctrine_api.DataModels.Attachments", b =>
                {
                    b.HasOne("doctrine_api.DataModels.AssistanceReuest", "ASSISTANCE_REQUEST")
                        .WithMany()
                        .HasForeignKey("REQUEST_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ASSISTANCE_REQUEST");
                });

            modelBuilder.Entity("doctrine_api.DataModels.Degree", b =>
                {
                    b.HasOne("doctrine_api.DataModels.Qualification", "QUALIFICATION")
                        .WithMany()
                        .HasForeignKey("QUALIFICATION_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QUALIFICATION");
                });

            modelBuilder.Entity("doctrine_api.DataModels.Qualification", b =>
                {
                    b.HasOne("doctrine_api.DataModels.Tutor", "TUTOR")
                        .WithMany()
                        .HasForeignKey("TUTOR_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TUTOR");
                });

            modelBuilder.Entity("doctrine_api.DataModels.Student", b =>
                {
                    b.HasOne("doctrine_api.DataModels.Account", "ACCOUNT")
                        .WithMany()
                        .HasForeignKey("ACCOUNT_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ACCOUNT");
                });

            modelBuilder.Entity("doctrine_api.DataModels.Tutor", b =>
                {
                    b.HasOne("doctrine_api.DataModels.Account", "ACCOUNT")
                        .WithMany()
                        .HasForeignKey("ACCOUNT_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ACCOUNT");
                });
#pragma warning restore 612, 618
        }
    }
}
