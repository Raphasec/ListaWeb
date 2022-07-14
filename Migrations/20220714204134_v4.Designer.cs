﻿// <auto-generated />
using Aula14.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aula14.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220714204134_v4")]
    partial class v4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("Aula14.Models.Genre", b =>
                {
                    b.Property<int>("IdGenre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("IdGenre");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Aula14.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Classification")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdGenre")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Rating")
                        .HasColumnType("REAL");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("TEXT");

                    b.HasKey("MovieId");

                    b.HasIndex("IdGenre");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Aula14.Models.Movie", b =>
                {
                    b.HasOne("Aula14.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("IdGenre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
