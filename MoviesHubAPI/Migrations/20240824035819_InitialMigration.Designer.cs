﻿// <auto-generated />
using System;
using EntityFrameworkExample.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MoviesHubAPI.Migrations
{
    [DbContext(typeof(ContextDB))]
    [Migration("20240824035819_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoviesHubAPI.Models.Genders.Gender", b =>
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

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_Genders_Name");

                    b.ToTable("Genders", (string)null);
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Genders.GenderListF.GenderList", b =>
                {
                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int?>("SerieId")
                        .HasColumnType("int");

                    b.HasKey("MediaId", "GenderId");

                    b.HasIndex("GenderId");

                    b.HasIndex("SerieId");

                    b.ToTable("GenderList");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaF.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("smalldatetime");

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
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("PosterImage")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("RelaseDate")
                        .HasColumnType("smalldatetime");

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

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaF.SerieF.EpisodeListF.EpisodeList", b =>
                {
                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.Property<int?>("MediaId")
                        .HasColumnType("int");

                    b.Property<int?>("SerieId")
                        .HasColumnType("int");

                    b.HasKey("SeasonId", "EpisodeId");

                    b.HasIndex("EpisodeId");

                    b.HasIndex("MediaId");

                    b.HasIndex("SerieId");

                    b.ToTable("EpisodeList", (string)null);
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaF.SerieF.Episodes.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("smalldatetime");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<byte>("E_Num")
                        .HasColumnType("tinyint");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RelaseDate")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("WatchLink")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("Episode", (string)null);
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaF.SerieF.SeasonF.Season", b =>
                {
                    b.Property<int>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeasonId"));

                    b.Property<DateTime>("DateRelease")
                        .HasColumnType("datetime2");

                    b.Property<byte>("NumSeason")
                        .HasColumnType("tinyint");

                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.Property<int>("SerieId1")
                        .HasColumnType("int");

                    b.HasKey("SeasonId");

                    b.HasIndex("SerieId");

                    b.HasIndex("SerieId1");

                    b.ToTable("Season");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaF.SerieF.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AgeRate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("OriginalTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RelaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrailerLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeMedia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WatchLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Platforms.EnablePlatform.MediaAvailibleIn", b =>
                {
                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<int?>("MediaId1")
                        .HasColumnType("int");

                    b.Property<int?>("SerieId")
                        .HasColumnType("int");

                    b.HasKey("MediaId", "PlatformId");

                    b.HasIndex("MediaId1");

                    b.HasIndex("PlatformId");

                    b.HasIndex("SerieId");

                    b.ToTable("MediaAvailibleIn", (string)null);
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Platforms.Platform", b =>
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

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_Platforms_Name");

                    b.ToTable("Platforms", (string)null);
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Ratings.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RatingId"));

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RatingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("SerieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("MediaId");

                    b.HasIndex("SerieId");

                    b.HasIndex("UserId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.UserActions.UserAction", b =>
                {
                    b.Property<int>("UserActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserActionId"));

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserActionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAction");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.UserF.User", b =>
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
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasDefaultValue("user");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("IX_Users_Email");

                    b.ToTable("Users", null, t =>
                        {
                            t.HasCheckConstraint("CK_User_Role", "[Role] IN ('admin', 'user')");
                        });
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaF.MovieF.Movie", b =>
                {
                    b.HasBaseType("MoviesHubAPI.Models.MediaF.Media");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time(7)");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.HasIndex("MediaId");

                    b.ToTable("Movie", (string)null);
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Genders.GenderListF.GenderList", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.Genders.Gender", "Gender")
                        .WithMany("GenderLists")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.MediaF.Media", "Media")
                        .WithMany("GenderLists")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.MediaF.SerieF.Serie", null)
                        .WithMany("GenderLists")
                        .HasForeignKey("SerieId");

                    b.Navigation("Gender");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaF.SerieF.EpisodeListF.EpisodeList", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.MediaF.SerieF.Episodes.Episode", "Episode")
                        .WithMany()
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.MediaF.Media", null)
                        .WithMany("EpisodesLists")
                        .HasForeignKey("MediaId");

                    b.HasOne("MoviesHubAPI.Models.MediaF.SerieF.SeasonF.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.MediaF.SerieF.Serie", null)
                        .WithMany("EpisodesLists")
                        .HasForeignKey("SerieId");

                    b.Navigation("Episode");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaF.SerieF.Episodes.Episode", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.MediaF.SerieF.SeasonF.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaF.SerieF.SeasonF.Season", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.MediaF.Media", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.MediaF.SerieF.Serie", null)
                        .WithMany("Seasons")
                        .HasForeignKey("SerieId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Platforms.EnablePlatform.MediaAvailibleIn", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.MediaF.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.MediaF.Media", null)
                        .WithMany("MediaAvailableIns")
                        .HasForeignKey("MediaId1");

                    b.HasOne("MoviesHubAPI.Models.Platforms.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.MediaF.SerieF.Serie", null)
                        .WithMany("MediaAvailableIns")
                        .HasForeignKey("SerieId");

                    b.Navigation("Media");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Ratings.Rating", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.MediaF.Media", "Media")
                        .WithMany("Ratings")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.MediaF.SerieF.Serie", null)
                        .WithMany("Ratings")
                        .HasForeignKey("SerieId");

                    b.HasOne("MoviesHubAPI.Models.UserF.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.UserActions.UserAction", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.UserF.User", "User")
                        .WithMany("UserActions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaF.MovieF.Movie", b =>
                {
                    b.HasOne("MoviesHubAPI.Models.MediaF.Media", null)
                        .WithOne()
                        .HasForeignKey("MoviesHubAPI.Models.MediaF.MovieF.Movie", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesHubAPI.Models.MediaF.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.Genders.Gender", b =>
                {
                    b.Navigation("GenderLists");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaF.Media", b =>
                {
                    b.Navigation("EpisodesLists");

                    b.Navigation("GenderLists");

                    b.Navigation("MediaAvailableIns");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.MediaF.SerieF.Serie", b =>
                {
                    b.Navigation("EpisodesLists");

                    b.Navigation("GenderLists");

                    b.Navigation("MediaAvailableIns");

                    b.Navigation("Ratings");

                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("MoviesHubAPI.Models.UserF.User", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("UserActions");
                });
#pragma warning restore 612, 618
        }
    }
}
