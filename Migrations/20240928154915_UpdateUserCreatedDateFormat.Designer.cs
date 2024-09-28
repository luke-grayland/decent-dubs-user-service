﻿// <auto-generated />
using System;
using DecentDubs.UserService.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DecentDubs.UserService.Migrations
{
    [DbContext(typeof(DecentDubsDbContext))]
    [Migration("20240928154915_UpdateUserCreatedDateFormat")]
    partial class UpdateUserCreatedDateFormat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DecentDubs.UserService.Models.SocialMediaLink", b =>
                {
                    b.Property<string>("WalletId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SocialMediaTypeId")
                        .HasColumnType("int");

                    b.HasKey("WalletId", "SocialMediaTypeId");

                    b.HasIndex("SocialMediaTypeId");

                    b.ToTable("SocialMediaLinks");
                });

            modelBuilder.Entity("DecentDubs.UserService.Models.SocialMediaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SocialMediaTypes");
                });

            modelBuilder.Entity("DecentDubs.UserService.Models.User", b =>
                {
                    b.Property<string>("WalletId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("Relational:JsonPropertyName", "walletId");

                    b.Property<string>("Bio")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasAnnotation("Relational:JsonPropertyName", "bio");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("Relational:JsonPropertyName", "country");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "created");

                    b.Property<string>("Email")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasAnnotation("Relational:JsonPropertyName", "email");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasAnnotation("Relational:JsonPropertyName", "isAdmin");

                    b.Property<string>("ProfilePicUrl")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasAnnotation("Relational:JsonPropertyName", "profilePicUrl");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("Relational:JsonPropertyName", "username");

                    b.Property<bool>("Verified")
                        .HasColumnType("bit")
                        .HasAnnotation("Relational:JsonPropertyName", "verified");

                    b.HasKey("WalletId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DecentDubs.UserService.Models.UserSession", b =>
                {
                    b.Property<string>("SessionId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WalletId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SessionId");

                    b.HasIndex("WalletId");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("DecentDubs.UserService.Models.SocialMediaLink", b =>
                {
                    b.HasOne("DecentDubs.UserService.Models.SocialMediaType", "SocialMediaType")
                        .WithMany()
                        .HasForeignKey("SocialMediaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DecentDubs.UserService.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SocialMediaType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DecentDubs.UserService.Models.UserSession", b =>
                {
                    b.HasOne("DecentDubs.UserService.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
