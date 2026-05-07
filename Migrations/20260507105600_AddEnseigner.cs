using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestionEDT_Core.Migrations
{
    /// <inheritdoc />
    public partial class AddEnseigner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    IdEnseignant = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomEnseignant = table.Column<string>(type: "text", nullable: false),
                    Adresse = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Specialite = table.Column<string>(type: "text", nullable: false),
                    Grade = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.IdEnseignant);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                columns: table => new
                {
                    CodeSalle = table.Column<string>(type: "text", nullable: false),
                    Capacite = table.Column<int>(type: "integer", nullable: false),
                    NomBatiment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.CodeSalle);
                });

            migrationBuilder.CreateTable(
                name: "Matieres",
                columns: table => new
                {
                    IdMatiere = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomMatiere = table.Column<string>(type: "text", nullable: false),
                    IdEnseignant = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matieres", x => x.IdMatiere);
                    table.ForeignKey(
                        name: "FK_Matieres_Enseignants_IdEnseignant",
                        column: x => x.IdEnseignant,
                        principalTable: "Enseignants",
                        principalColumn: "IdEnseignant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    IdProm = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomProm = table.Column<string>(type: "text", nullable: false),
                    Mention = table.Column<string>(type: "text", nullable: false),
                    Niveau = table.Column<string>(type: "text", nullable: false),
                    CodeSalle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.IdProm);
                    table.ForeignKey(
                        name: "FK_Promotions_Salles_CodeSalle",
                        column: x => x.CodeSalle,
                        principalTable: "Salles",
                        principalColumn: "CodeSalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EDTs",
                columns: table => new
                {
                    IdEDT = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HeureDebut = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HeureFin = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CodeSalle = table.Column<string>(type: "text", nullable: false),
                    IdMatiere = table.Column<int>(type: "integer", nullable: false),
                    IdEnseignant = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDTs", x => x.IdEDT);
                    table.ForeignKey(
                        name: "FK_EDTs_Enseignants_IdEnseignant",
                        column: x => x.IdEnseignant,
                        principalTable: "Enseignants",
                        principalColumn: "IdEnseignant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EDTs_Matieres_IdMatiere",
                        column: x => x.IdMatiere,
                        principalTable: "Matieres",
                        principalColumn: "IdMatiere",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EDTs_Salles_CodeSalle",
                        column: x => x.CodeSalle,
                        principalTable: "Salles",
                        principalColumn: "CodeSalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enseigners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdProm = table.Column<int>(type: "integer", nullable: false),
                    IdEnseignant = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseigners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enseigners_Enseignants_IdEnseignant",
                        column: x => x.IdEnseignant,
                        principalTable: "Enseignants",
                        principalColumn: "IdEnseignant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enseigners_Promotions_IdProm",
                        column: x => x.IdProm,
                        principalTable: "Promotions",
                        principalColumn: "IdProm",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EDTs_CodeSalle",
                table: "EDTs",
                column: "CodeSalle");

            migrationBuilder.CreateIndex(
                name: "IX_EDTs_IdEnseignant",
                table: "EDTs",
                column: "IdEnseignant");

            migrationBuilder.CreateIndex(
                name: "IX_EDTs_IdMatiere",
                table: "EDTs",
                column: "IdMatiere");

            migrationBuilder.CreateIndex(
                name: "IX_Enseigners_IdEnseignant",
                table: "Enseigners",
                column: "IdEnseignant");

            migrationBuilder.CreateIndex(
                name: "IX_Enseigners_IdProm",
                table: "Enseigners",
                column: "IdProm");

            migrationBuilder.CreateIndex(
                name: "IX_Matieres_IdEnseignant",
                table: "Matieres",
                column: "IdEnseignant");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_CodeSalle",
                table: "Promotions",
                column: "CodeSalle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EDTs");

            migrationBuilder.DropTable(
                name: "Enseigners");

            migrationBuilder.DropTable(
                name: "Matieres");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "Salles");
        }
    }
}
