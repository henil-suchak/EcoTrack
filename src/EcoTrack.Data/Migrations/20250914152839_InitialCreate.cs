using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmissionFactors",
                columns: table => new
                {
                    EmissionFactorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActivityType = table.Column<string>(type: "TEXT", nullable: false),
                    SubType = table.Column<string>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    SourceReference = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmissionFactors", x => x.EmissionFactorId);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    FamilyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FamilyName = table.Column<string>(type: "TEXT", nullable: false),
                    SharedConsumption = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.FamilyId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyId = table.Column<int>(type: "INTEGER", nullable: true),
                    FamilyId1 = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Families_FamilyId1",
                        column: x => x.FamilyId1,
                        principalTable: "Families",
                        principalColumn: "FamilyId");
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActivityType = table.Column<int>(type: "INTEGER", nullable: false),
                    CarbonEmission = table.Column<decimal>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplianceType = table.Column<string>(type: "TEXT", nullable: true),
                    UsageTime = table.Column<decimal>(type: "TEXT", nullable: true),
                    PowerRating = table.Column<decimal>(type: "TEXT", nullable: true),
                    EmissionFactorId = table.Column<int>(type: "INTEGER", nullable: true),
                    Consumption = table.Column<decimal>(type: "TEXT", nullable: true),
                    SourceType = table.Column<string>(type: "TEXT", nullable: true),
                    ElectricityActivity_EmissionFactorId = table.Column<int>(type: "INTEGER", nullable: true),
                    FoodType = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<decimal>(type: "TEXT", nullable: true),
                    Source = table.Column<string>(type: "TEXT", nullable: true),
                    FoodActivity_EmissionFactorId = table.Column<int>(type: "INTEGER", nullable: true),
                    Mode = table.Column<string>(type: "TEXT", nullable: true),
                    Distance = table.Column<decimal>(type: "TEXT", nullable: true),
                    FuelType = table.Column<string>(type: "TEXT", nullable: true),
                    LocationStart = table.Column<string>(type: "TEXT", nullable: true),
                    LocationEnd = table.Column<string>(type: "TEXT", nullable: true),
                    TravelActivity_EmissionFactorId = table.Column<int>(type: "INTEGER", nullable: true),
                    WasteType = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: true),
                    WasteActivity_EmissionFactorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_EmissionFactors_ElectricityActivity_EmissionFactorId",
                        column: x => x.ElectricityActivity_EmissionFactorId,
                        principalTable: "EmissionFactors",
                        principalColumn: "EmissionFactorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_EmissionFactors_EmissionFactorId",
                        column: x => x.EmissionFactorId,
                        principalTable: "EmissionFactors",
                        principalColumn: "EmissionFactorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_EmissionFactors_FoodActivity_EmissionFactorId",
                        column: x => x.FoodActivity_EmissionFactorId,
                        principalTable: "EmissionFactors",
                        principalColumn: "EmissionFactorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_EmissionFactors_TravelActivity_EmissionFactorId",
                        column: x => x.TravelActivity_EmissionFactorId,
                        principalTable: "EmissionFactors",
                        principalColumn: "EmissionFactorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_EmissionFactors_WasteActivity_EmissionFactorId",
                        column: x => x.WasteActivity_EmissionFactorId,
                        principalTable: "EmissionFactors",
                        principalColumn: "EmissionFactorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    BadgeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CriteriaMet = table.Column<string>(type: "TEXT", nullable: false),
                    IconUrl = table.Column<string>(type: "TEXT", nullable: false),
                    DateEarned = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.BadgeId);
                    table.ForeignKey(
                        name: "FK_Badges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaderboardEntries",
                columns: table => new
                {
                    LeaderboardEntryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rank = table.Column<int>(type: "INTEGER", nullable: false),
                    Period = table.Column<string>(type: "TEXT", nullable: false),
                    CarbonEmission = table.Column<decimal>(type: "TEXT", nullable: false),
                    CommunityId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderboardEntries", x => x.LeaderboardEntryId);
                    table.ForeignKey(
                        name: "FK_LeaderboardEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    SuggestionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    SavingAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    DateTimeIssued = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.SuggestionId);
                    table.ForeignKey(
                        name: "FK_Suggestions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ElectricityActivity_EmissionFactorId",
                table: "Activities",
                column: "ElectricityActivity_EmissionFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_EmissionFactorId",
                table: "Activities",
                column: "EmissionFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_FoodActivity_EmissionFactorId",
                table: "Activities",
                column: "FoodActivity_EmissionFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TravelActivity_EmissionFactorId",
                table: "Activities",
                column: "TravelActivity_EmissionFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_WasteActivity_EmissionFactorId",
                table: "Activities",
                column: "WasteActivity_EmissionFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_UserId",
                table: "Badges",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderboardEntries_UserId",
                table: "LeaderboardEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_UserId",
                table: "Suggestions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FamilyId1",
                table: "Users",
                column: "FamilyId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "LeaderboardEntries");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "EmissionFactors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
