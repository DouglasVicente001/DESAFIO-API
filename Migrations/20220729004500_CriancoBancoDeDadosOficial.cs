using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAPI.Migrations
{
    public partial class CriancoBancoDeDadosOficial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeCliente = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Veterinarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeVeterinario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cachorros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeCachorro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Raca = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cachorros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cachorros_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VeterinarioId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Temperamento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Diagnostico = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Veterinarios_VeterinarioId",
                        column: x => x.VeterinarioId,
                        principalTable: "Veterinarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AtendimentoCachorro",
                columns: table => new
                {
                    AtendimentosId = table.Column<int>(type: "int", nullable: false),
                    CachorrosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoCachorro", x => new { x.AtendimentosId, x.CachorrosId });
                    table.ForeignKey(
                        name: "FK_AtendimentoCachorro_Atendimentos_AtendimentosId",
                        column: x => x.AtendimentosId,
                        principalTable: "Atendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentoCachorro_Cachorros_CachorrosId",
                        column: x => x.CachorrosId,
                        principalTable: "Cachorros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "NomeCliente" },
                values: new object[,]
                {
                    { 1, "Clecio" },
                    { 2, "Frederico" },
                    { 3, "Pedro" },
                    { 4, "Kestrel" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Senha" },
                values: new object[] { 1, "Veterinario@gft.com", "Gft@1234" });

            migrationBuilder.InsertData(
                table: "Veterinarios",
                columns: new[] { "Id", "NomeVeterinario" },
                values: new object[,]
                {
                    { 1, "Dr.Faust" },
                    { 2, "Dr.David Banner" },
                    { 3, "Dra.Potter" }
                });

            migrationBuilder.InsertData(
                table: "Atendimentos",
                columns: new[] { "Id", "ClienteId", "DataEntrada", "Diagnostico", "Temperamento", "VeterinarioId" },
                values: new object[,]
                {
                    { 3, 2, new DateTime(2022, 7, 28, 21, 45, 0, 291, DateTimeKind.Local).AddTicks(4784), "Animal registrado para vacinação.", "Sociável", 1 },
                    { 4, 2, new DateTime(2022, 7, 28, 21, 45, 0, 291, DateTimeKind.Local).AddTicks(4785), "Animal apresentou-se com desânimo e vômito.", "Passivo", 1 },
                    { 1, 1, new DateTime(2022, 7, 28, 21, 45, 0, 291, DateTimeKind.Local).AddTicks(4403), "Animal com fortes dores na região do torax.", "Agressivo", 2 },
                    { 2, 1, new DateTime(2022, 7, 28, 21, 45, 0, 291, DateTimeKind.Local).AddTicks(4778), "Animal com dores na região da barriga.", "Passivo", 2 },
                    { 8, 4, new DateTime(2022, 7, 28, 21, 45, 0, 291, DateTimeKind.Local).AddTicks(4791), "Animal com perna direita traseira supostamente fraturada", "Agressivo", 2 },
                    { 5, 3, new DateTime(2022, 7, 28, 21, 45, 0, 291, DateTimeKind.Local).AddTicks(4787), "Animal registrado para vacinação", "Sociável", 3 },
                    { 6, 3, new DateTime(2022, 7, 28, 21, 45, 0, 291, DateTimeKind.Local).AddTicks(4788), "Animal registrado para castração", "Passivo", 3 },
                    { 7, 3, new DateTime(2022, 7, 28, 21, 45, 0, 291, DateTimeKind.Local).AddTicks(4790), "Animal registrado para vacinação", "Agressivo", 3 }
                });

            migrationBuilder.InsertData(
                table: "Cachorros",
                columns: new[] { "Id", "ClienteId", "NomeCachorro", "Raca" },
                values: new object[,]
                {
                    { 2, 1, "Rex", "PitBull" },
                    { 8, 1, "Merlim", "PastorAlemão" },
                    { 1, 2, "Floquinho", "Dálmata" },
                    { 3, 2, "Fred", "HuskySiberiano" },
                    { 4, 3, "Lilica", "Yorkshire" },
                    { 5, 3, "Penélope", "Poodle" },
                    { 6, 3, "Hulk", "Rottweiler" },
                    { 7, 4, "Yoda", "Pinscher" }
                });

            migrationBuilder.InsertData(
                table: "AtendimentoCachorro",
                columns: new[] { "AtendimentosId", "CachorrosId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 3 },
                    { 1, 8 },
                    { 2, 2 },
                    { 8, 7 },
                    { 5, 4 },
                    { 6, 5 },
                    { 7, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoCachorro_CachorrosId",
                table: "AtendimentoCachorro",
                column: "CachorrosId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_ClienteId",
                table: "Atendimentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_VeterinarioId",
                table: "Atendimentos",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cachorros_ClienteId",
                table: "Cachorros",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentoCachorro");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Cachorros");

            migrationBuilder.DropTable(
                name: "Veterinarios");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
