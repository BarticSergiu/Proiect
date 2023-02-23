﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect.Data;

#nullable disable

namespace Proiect.Migrations
{
    [DbContext(typeof(ProiectContext))]
    [Migration("20230223170107_initdata")]
    partial class initdata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proiect.Models.Persoana", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persoana");
                });

            modelBuilder.Entity("Proiect.Models.Pontaj", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Data")
                        .HasColumnType("int");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<string>("Observatii")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SarcinaId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("SarcinaId");

                    b.ToTable("Pontaj");
                });

            modelBuilder.Entity("Proiect.Models.Sarcina", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OreEstimate")
                        .HasColumnType("int");

                    b.Property<int>("PersoanaId")
                        .HasColumnType("int");

                    b.Property<string>("Prioritate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipSarcina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("PersoanaId");

                    b.ToTable("Sarcina");
                });

            modelBuilder.Entity("Proiect.Models.Pontaj", b =>
                {
                    b.HasOne("Proiect.Models.Sarcina", "sarcinaObj")
                        .WithMany()
                        .HasForeignKey("SarcinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sarcinaObj");
                });

            modelBuilder.Entity("Proiect.Models.Sarcina", b =>
                {
                    b.HasOne("Proiect.Models.Persoana", "persoanaObj")
                        .WithMany()
                        .HasForeignKey("PersoanaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("persoanaObj");
                });
#pragma warning restore 612, 618
        }
    }
}
