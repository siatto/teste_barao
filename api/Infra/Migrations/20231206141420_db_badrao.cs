using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Infra.Migrations
{
    /// <inheritdoc />
    public partial class db_badrao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstudanteLocalidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstudanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudanteLocalidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstudanteLocalidade_Estudante_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "Estudante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudanteLocalidade_Localidade_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstudanteLocalidade_EstudanteId",
                table: "EstudanteLocalidade",
                column: "EstudanteId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudanteLocalidade_LocalidadeId",
                table: "EstudanteLocalidade",
                column: "LocalidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudanteLocalidade");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Estudante");

            migrationBuilder.DropTable(
                name: "Localidade");
        }
    }
}
