﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Puma.Prey.Rabbit.Context;

namespace Puma.Prey.Rabbit.Migrations
{
    [DbContext(typeof(RabbitDBContext))]
    [Migration("20190711144734_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnimalName");

                    b.Property<string>("Color");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<int>("SafariId");

                    b.Property<string>("Species");

                    b.Property<string>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("SafariId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.PumaRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("PumaRoles");
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.PumaRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("PumaRoleClaims");
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.PumaUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("BillingAddress1");

                    b.Property<string>("BillingAddress2");

                    b.Property<string>("BillingCity");

                    b.Property<string>("BillingState");

                    b.Property<string>("BillingZip");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CreditCardExpiration");

                    b.Property<string>("CreditCardNumber");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<int>("MemberId");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("PumaUsers");
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.PumaUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PumaUserClaims");
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.PumaUserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("PumaUserLogins");
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.PumaUserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("PumaUserRoles");
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.PumaUserToken", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("PumaUserTokens");
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.Safari", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Safaris");
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.SafariUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PumaUserId");

                    b.Property<int>("SafariId");

                    b.HasKey("Id");

                    b.HasIndex("PumaUserId");

                    b.HasIndex("SafariId", "PumaUserId");

                    b.ToTable("SafariUsers");
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.Animal", b =>
                {
                    b.HasOne("Puma.Prey.Rabbit.Models.Safari", "Safari")
                        .WithMany("Animals")
                        .HasForeignKey("SafariId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.PumaRoleClaim", b =>
                {
                    b.HasOne("Puma.Prey.Rabbit.Models.PumaRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.PumaUserClaim", b =>
                {
                    b.HasOne("Puma.Prey.Rabbit.Models.PumaUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.PumaUserLogin", b =>
                {
                    b.HasOne("Puma.Prey.Rabbit.Models.PumaUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.PumaUserRole", b =>
                {
                    b.HasOne("Puma.Prey.Rabbit.Models.PumaRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Puma.Prey.Rabbit.Models.PumaUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.PumaUserToken", b =>
                {
                    b.HasOne("Puma.Prey.Rabbit.Models.PumaUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Puma.Prey.Rabbit.Models.SafariUser", b =>
                {
                    b.HasOne("Puma.Prey.Rabbit.Models.PumaUser", "PumaUser")
                        .WithMany("SafariUsers")
                        .HasForeignKey("PumaUserId");

                    b.HasOne("Puma.Prey.Rabbit.Models.Safari", "Safaris")
                        .WithMany("SafariUsers")
                        .HasForeignKey("SafariId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
