using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class db4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    animalCanDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    animalCanDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    animalCanDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAnimals",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BirdId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimals", x => new { x.UserId, x.AnimalId });
                    table.ForeignKey(
                        name: "FK_UserAnimals_Birds_BirdId",
                        column: x => x.BirdId,
                        principalTable: "Birds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAnimals_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAnimals_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAnimals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "Id", "CanFly", "Color", "Name", "TypeOfAnimal", "animalCanDo" },
                values: new object[,]
                {
                    { new Guid("0fd752e1-7f8f-4e75-a6ae-ab09e2e0ceff"), true, "Green", "Kiwi", "Bird", "This animal can fly" },
                    { new Guid("6b388fdd-c9d5-4bcb-8c31-433d454df077"), true, "Yellow", "Sunshine", "Bird", "This animal can fly" },
                    { new Guid("af3f8cb8-c7c7-4819-9fde-b23a2393d25e"), true, "Red", "Cherry", "Bird", "This animal can fly" },
                    { new Guid("f4b38ecd-b641-4dec-b0e9-064bcd4b3b62"), true, "Blue", "Sky", "Bird", "This animal can fly" },
                    { new Guid("fba6dac8-c543-480a-9744-d18247ab029b"), true, "White", "Snowflake", "Bird", "This animal can fly" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "Id", "Breed", "CanFly", "LikesToPlay", "Name", "TypeOfAnimal", "Weight", "animalCanDo" },
                values: new object[,]
                {
                    { new Guid("106854c9-950b-4f9f-915f-528663a70998"), "Ragdoll", false, true, "Smokey", "Cat", 12, "This animal can meow" },
                    { new Guid("2937c32a-3720-4cc1-afa9-826639df922b"), "Maine Coon", false, true, "Shadow", "Cat", 15, "This animal can meow" },
                    { new Guid("47e16b18-99b3-4b03-9c01-3ceb60e82a88"), "Bengal", false, true, "Tiger", "Cat", 11, "This animal can meow" },
                    { new Guid("7e266adc-fc81-4960-8e44-a983483241ed"), "Persian", false, true, "Mittens", "Cat", 10, "This animal can meow" },
                    { new Guid("d2240adb-1c13-4193-9bb6-e0a417dde3f2"), "Siamese", false, true, "Whiskers", "Cat", 8, "This animal can meow" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Breed", "CanFly", "LikesToPlay", "Name", "TypeOfAnimal", "Weight", "animalCanDo" },
                values: new object[,]
                {
                    { new Guid("254a93fa-525d-4336-a777-61e1a9b74f44"), "Poodle", false, true, "Rocky", "Dog", 15, "This animal can bark" },
                    { new Guid("37e9abd2-f8b4-45aa-b1d4-adcd5158fb4d"), "Golden Retriever", false, true, "Max", "Dog", 28, "This animal can bark" },
                    { new Guid("3b6c7e3e-6268-4089-815c-9ef67887dd9a"), "German Shepherd", false, true, "Bella", "Dog", 30, "This animal can bark" },
                    { new Guid("57b22cdf-74c8-4a99-97bd-90029ca6779e"), "Golden Retriever", false, true, "Riley", "Dog", 30, "This animal can bark" },
                    { new Guid("b1b42520-6942-4c99-b7b8-b3c3974d38b7"), "Beagle", false, true, "Daisy", "Dog", 18, "This animal can bark" },
                    { new Guid("ed93b276-5bfc-4fe5-b935-8e8a6ac74b70"), "Labrador", false, true, "Luna", "Dog", 25, "This animal can bark" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_BirdId",
                table: "UserAnimals",
                column: "BirdId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_CatId",
                table: "UserAnimals",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_DogId",
                table: "UserAnimals",
                column: "DogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnimals");

            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
