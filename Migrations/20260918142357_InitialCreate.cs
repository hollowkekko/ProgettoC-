using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProgettoC_.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cognome = table.Column<string>(type: "text", nullable: false),
                    Età = table.Column<int>(type: "integer", nullable: false),
                    Genere = table.Column<string>(type: "text", nullable: false),
                    Peso = table.Column<int>(type: "integer", nullable: false),
                    Altezza = table.Column<int>(type: "integer", nullable: false),
                    ObiettivoCalorieWorkout = table.Column<int>(type: "integer", nullable: false),
                    ObiettivoCarboidratiWorkout = table.Column<int>(type: "integer", nullable: false),
                    ObiettivoProteineWorkout = table.Column<int>(type: "integer", nullable: false),
                    ObiettivoGrassiWorkout = table.Column<int>(type: "integer", nullable: false),
                    ObiettivoCalorieRest = table.Column<int>(type: "integer", nullable: false),
                    ObiettivoCarboidratiRest = table.Column<int>(type: "integer", nullable: false),
                    ObiettivoProteineRest = table.Column<int>(type: "integer", nullable: false),
                    ObiettivoGrassiRest = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Giorni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsWorkout = table.Column<bool>(type: "boolean", nullable: false),
                    UtenteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giorni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Giorni_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allenamenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descrizione = table.Column<string>(type: "text", nullable: false),
                    Durata = table.Column<int>(type: "integer", nullable: false),
                    CalorieBruciate = table.Column<int>(type: "integer", nullable: false),
                    GiornoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allenamenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allenamenti_Giorni_GiornoId",
                        column: x => x.GiornoId,
                        principalTable: "Giorni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pasti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Calorie = table.Column<int>(type: "integer", nullable: false),
                    Carboidrati = table.Column<int>(type: "integer", nullable: false),
                    Proteine = table.Column<int>(type: "integer", nullable: false),
                    Grassi = table.Column<int>(type: "integer", nullable: false),
                    GiornoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pasti_Giorni_GiornoId",
                        column: x => x.GiornoId,
                        principalTable: "Giorni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allenamenti_GiornoId",
                table: "Allenamenti",
                column: "GiornoId");

            migrationBuilder.CreateIndex(
                name: "IX_Giorni_UtenteId",
                table: "Giorni",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pasti_GiornoId",
                table: "Pasti",
                column: "GiornoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allenamenti");

            migrationBuilder.DropTable(
                name: "Pasti");

            migrationBuilder.DropTable(
                name: "Giorni");

            migrationBuilder.DropTable(
                name: "Utenti");
        }
    }
}
