﻿// <auto-generated />
using System;
using EntityFrameworkExample.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MoviesHubAPI.Migrations
{
    [DbContext(typeof(ContextDB))]
    partial class ContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoviesHubAPI.Models.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("E_Num")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("MediaId")
                        .HasColumnType("int");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RelaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("WatchLink")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.EpisodeList", b =>
                {
                    b.Property<int>("Seasonld")
                        .HasColumnType("int");

                    b.Property<int>("Episodeld")
                        .HasColumnType("int");

                    b.HasKey("Seasonld", "Episodeld");

                    b.HasIndex("Episodeld");

                    b.ToTable("EpisodeLists");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.GenderList", b =>
                {
                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.HasKey("MediaId", "GenderId");

                    b.HasIndex("GenderId");

                    b.ToTable("GenderLists");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AgeRate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("OriginalTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterImage")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("RelaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrailerLink")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TypeMedia")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("WatchLink")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Media", (string)null);
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaAvailibleIn", b =>
                {
                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.HasKey("MediaId", "PlatformId");

                    b.HasIndex("PlatformId");

                    b.ToTable("MediaAvailibleIn");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Movie", b =>
                {
                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.HasKey("MediaId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Rating", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<byte>("Rate")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("RateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "MediaId");

                    b.HasIndex("MediaId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Season", b =>
                {
                    b.Property<int>("Seasonld")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Seasonld"));

                    b.Property<DateTime>("DateRelease")
                        .HasColumnType("datetime2");

                    b.Property<byte>("NumSeason")
                        .HasColumnType("tinyint");

                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.HasKey("Seasonld");

                    b.HasIndex("SerieId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.UserAction", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<string>("TypeAction")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "MediaId", "TypeAction");

                    b.HasIndex("MediaId");

                    b.ToTable("UserActions");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Episode", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.Media", null)
                        .WithMany("Episodes")
                        .HasForeignKey("MediaId");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.EpisodeList", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.Episode", "Episode")
                        .WithMany("EpisodesLists")
                        .HasForeignKey("Episodeld")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.Season", "Season")
                        .WithMany("EpisodesLists")
                        .HasForeignKey("Seasonld")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Episode");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.GenderList", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.Gender", "Gender")
                        .WithMany("GendersLists")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.Media", "Media")
                        .WithMany("GendersLists")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaAvailibleIn", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.Media", "Media")
                        .WithMany("MediaAvailibleIns")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.Platform", "Platform")
                        .WithMany("MediaAvailibleIns")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Movie", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.Media", "Media")
                        .WithOne("Movie")
                        .HasForeignKey("MoviesHubAPI.Models.Movie", "MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Rating", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.Media", "Media")
                        .WithMany("Ratings")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Season", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.Media", "Serie")
                        .WithMany("Seasons")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.UserAction", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.Media", "Media")
                        .WithMany("UserActions")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.User", "User")
                        .WithMany("UserActions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Episode", b =>
                {
                    b.Navigation("EpisodesLists");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Gender", b =>
                {
                    b.Navigation("GendersLists");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Media", b =>
                {
                    b.Navigation("Episodes");

                    b.Navigation("GendersLists");

                    b.Navigation("MediaAvailibleIns");

                    b.Navigation("Movie")
                        .IsRequired();

                    b.Navigation("Ratings");

                    b.Navigation("Seasons");

                    b.Navigation("UserActions");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Platform", b =>
                {
                    b.Navigation("MediaAvailibleIns");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Season", b =>
                {
                    b.Navigation("EpisodesLists");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.User", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("UserActions");
                });
#pragma warning restore 612, 618
        }
    }
}
