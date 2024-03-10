﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RealDatabase))]
    [Migration("20240310142606_db4")]
    partial class db4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Bird", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanFly")
                        .HasColumnType("bit");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfAnimal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("animalCanDo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Birds");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0fd752e1-7f8f-4e75-a6ae-ab09e2e0ceff"),
                            CanFly = true,
                            Color = "Green",
                            Name = "Kiwi",
                            TypeOfAnimal = "Bird",
                            animalCanDo = "This animal can fly"
                        },
                        new
                        {
                            Id = new Guid("6b388fdd-c9d5-4bcb-8c31-433d454df077"),
                            CanFly = true,
                            Color = "Yellow",
                            Name = "Sunshine",
                            TypeOfAnimal = "Bird",
                            animalCanDo = "This animal can fly"
                        },
                        new
                        {
                            Id = new Guid("f4b38ecd-b641-4dec-b0e9-064bcd4b3b62"),
                            CanFly = true,
                            Color = "Blue",
                            Name = "Sky",
                            TypeOfAnimal = "Bird",
                            animalCanDo = "This animal can fly"
                        },
                        new
                        {
                            Id = new Guid("af3f8cb8-c7c7-4819-9fde-b23a2393d25e"),
                            CanFly = true,
                            Color = "Red",
                            Name = "Cherry",
                            TypeOfAnimal = "Bird",
                            animalCanDo = "This animal can fly"
                        },
                        new
                        {
                            Id = new Guid("fba6dac8-c543-480a-9744-d18247ab029b"),
                            CanFly = true,
                            Color = "White",
                            Name = "Snowflake",
                            TypeOfAnimal = "Bird",
                            animalCanDo = "This animal can fly"
                        });
                });

            modelBuilder.Entity("Domain.Models.Cat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CanFly")
                        .HasColumnType("bit");

                    b.Property<bool>("LikesToPlay")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfAnimal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<string>("animalCanDo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d2240adb-1c13-4193-9bb6-e0a417dde3f2"),
                            Breed = "Siamese",
                            CanFly = false,
                            LikesToPlay = true,
                            Name = "Whiskers",
                            TypeOfAnimal = "Cat",
                            Weight = 8,
                            animalCanDo = "This animal can meow"
                        },
                        new
                        {
                            Id = new Guid("7e266adc-fc81-4960-8e44-a983483241ed"),
                            Breed = "Persian",
                            CanFly = false,
                            LikesToPlay = true,
                            Name = "Mittens",
                            TypeOfAnimal = "Cat",
                            Weight = 10,
                            animalCanDo = "This animal can meow"
                        },
                        new
                        {
                            Id = new Guid("2937c32a-3720-4cc1-afa9-826639df922b"),
                            Breed = "Maine Coon",
                            CanFly = false,
                            LikesToPlay = true,
                            Name = "Shadow",
                            TypeOfAnimal = "Cat",
                            Weight = 15,
                            animalCanDo = "This animal can meow"
                        },
                        new
                        {
                            Id = new Guid("106854c9-950b-4f9f-915f-528663a70998"),
                            Breed = "Ragdoll",
                            CanFly = false,
                            LikesToPlay = true,
                            Name = "Smokey",
                            TypeOfAnimal = "Cat",
                            Weight = 12,
                            animalCanDo = "This animal can meow"
                        },
                        new
                        {
                            Id = new Guid("47e16b18-99b3-4b03-9c01-3ceb60e82a88"),
                            Breed = "Bengal",
                            CanFly = false,
                            LikesToPlay = true,
                            Name = "Tiger",
                            TypeOfAnimal = "Cat",
                            Weight = 11,
                            animalCanDo = "This animal can meow"
                        });
                });

            modelBuilder.Entity("Domain.Models.Dog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CanFly")
                        .HasColumnType("bit");

                    b.Property<bool>("LikesToPlay")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfAnimal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<string>("animalCanDo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ed93b276-5bfc-4fe5-b935-8e8a6ac74b70"),
                            Breed = "Labrador",
                            CanFly = false,
                            LikesToPlay = true,
                            Name = "Luna",
                            TypeOfAnimal = "Dog",
                            Weight = 25,
                            animalCanDo = "This animal can bark"
                        },
                        new
                        {
                            Id = new Guid("37e9abd2-f8b4-45aa-b1d4-adcd5158fb4d"),
                            Breed = "Golden Retriever",
                            CanFly = false,
                            LikesToPlay = true,
                            Name = "Max",
                            TypeOfAnimal = "Dog",
                            Weight = 28,
                            animalCanDo = "This animal can bark"
                        },
                        new
                        {
                            Id = new Guid("3b6c7e3e-6268-4089-815c-9ef67887dd9a"),
                            Breed = "German Shepherd",
                            CanFly = false,
                            LikesToPlay = true,
                            Name = "Bella",
                            TypeOfAnimal = "Dog",
                            Weight = 30,
                            animalCanDo = "This animal can bark"
                        },
                        new
                        {
                            Id = new Guid("254a93fa-525d-4336-a777-61e1a9b74f44"),
                            Breed = "Poodle",
                            CanFly = false,
                            LikesToPlay = true,
                            Name = "Rocky",
                            TypeOfAnimal = "Dog",
                            Weight = 15,
                            animalCanDo = "This animal can bark"
                        },
                        new
                        {
                            Id = new Guid("b1b42520-6942-4c99-b7b8-b3c3974d38b7"),
                            Breed = "Beagle",
                            CanFly = false,
                            LikesToPlay = true,
                            Name = "Daisy",
                            TypeOfAnimal = "Dog",
                            Weight = 18,
                            animalCanDo = "This animal can bark"
                        },
                        new
                        {
                            Id = new Guid("57b22cdf-74c8-4a99-97bd-90029ca6779e"),
                            Breed = "Golden Retriever",
                            CanFly = false,
                            LikesToPlay = true,
                            Name = "Riley",
                            TypeOfAnimal = "Dog",
                            Weight = 30,
                            animalCanDo = "This animal can bark"
                        });
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.UserAnimal", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BirdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DogId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "AnimalId");

                    b.HasIndex("BirdId");

                    b.HasIndex("CatId");

                    b.HasIndex("DogId");

                    b.ToTable("UserAnimals");
                });

            modelBuilder.Entity("Domain.Models.UserAnimal", b =>
                {
                    b.HasOne("Domain.Models.Bird", null)
                        .WithMany("UserBird")
                        .HasForeignKey("BirdId");

                    b.HasOne("Domain.Models.Cat", null)
                        .WithMany("UserCat")
                        .HasForeignKey("CatId");

                    b.HasOne("Domain.Models.Dog", null)
                        .WithMany("UserDog")
                        .HasForeignKey("DogId");

                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("UserAnimals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Bird", b =>
                {
                    b.Navigation("UserBird");
                });

            modelBuilder.Entity("Domain.Models.Cat", b =>
                {
                    b.Navigation("UserCat");
                });

            modelBuilder.Entity("Domain.Models.Dog", b =>
                {
                    b.Navigation("UserDog");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("UserAnimals");
                });
#pragma warning restore 612, 618
        }
    }
}