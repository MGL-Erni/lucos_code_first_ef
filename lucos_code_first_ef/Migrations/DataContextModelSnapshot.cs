﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lucos_code_first_ef.Data;

#nullable disable

namespace lucos_code_first_ef.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("lucos_code_first_ef.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("OpeningId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerBId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerWId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OpeningId");

                    b.HasIndex("PlayerBId");

                    b.HasIndex("PlayerWId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("lucos_code_first_ef.Models.Opening", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OpeningName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Openings");
                });

            modelBuilder.Entity("lucos_code_first_ef.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PlayerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerRating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("lucos_code_first_ef.Models.Game", b =>
                {
                    b.HasOne("lucos_code_first_ef.Models.Opening", "Opening")
                        .WithMany()
                        .HasForeignKey("OpeningId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("lucos_code_first_ef.Models.Player", "PlayerB")
                        .WithMany()
                        .HasForeignKey("PlayerBId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("lucos_code_first_ef.Models.Player", "PlayerW")
                        .WithMany()
                        .HasForeignKey("PlayerWId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Opening");

                    b.Navigation("PlayerB");

                    b.Navigation("PlayerW");
                });
#pragma warning restore 612, 618
        }
    }
}
