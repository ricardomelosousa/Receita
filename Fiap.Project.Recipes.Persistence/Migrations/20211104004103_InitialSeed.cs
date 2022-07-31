using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Project.Recipes.Persistence.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredientes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preparo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Descricao", "Titulo" },
                values: new object[,]
                {
                    { 1, "Doces e sobremesas", "Doces e sobremesas" },
                    { 2, "Bolos e tortas", "Bolos e tortas" },
                    { 3, "Massas", "Massas" },
                    { 4, "Carnes", "Carnes" },
                    { 5, "Aves", "Aves" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Login", "Nome", "Role", "Senha" },
                values: new object[] { 1, "admin@admin", "admin", "Administrador", "Administrador", "123456" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "DataInclusao", "Descricao", "Imagem", "Ingredientes", "Preparo", "Tags", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 11, 3, 21, 41, 3, 198, DateTimeKind.Local).AddTicks(8411), "Deliciosos cookies", null, "ingredientes do cookie", "preparo do cookie", "cookie;aveia;", "Cookies de aveia" },
                    { 2, 1, new DateTime(2021, 11, 3, 21, 41, 3, 199, DateTimeKind.Local).AddTicks(5574), "famoso pudim", null, "ingrdientes do pudim", "preparo do pudim", "pudim;leite;", "Pudim de leite" },
                    { 3, 2, new DateTime(2021, 11, 3, 21, 41, 3, 199, DateTimeKind.Local).AddTicks(5587), "irresistível bolo de chocolate", null, "ingredientes do bolo", "preparo do bolo", "bolo;chocolate;", "Bolo de chocolate" },
                    { 4, 2, new DateTime(2021, 11, 3, 21, 41, 3, 199, DateTimeKind.Local).AddTicks(5589), "deliciosa torta", null, "ingredientes da torta", "preparo da torta", "torta;limao;", "Torta de limão" },
                    { 5, 3, new DateTime(2021, 11, 3, 21, 41, 3, 199, DateTimeKind.Local).AddTicks(5590), "Massa clássica", null, "ingredientes do carbonara", "preparo do carbonara", "carbonara;bacon;", "Carbonara" },
                    { 6, 3, new DateTime(2021, 11, 3, 21, 41, 3, 199, DateTimeKind.Local).AddTicks(5592), "almoço de domingo", null, "ingredientes da lasanha", "preparo da lasanha", "lasanha;queijo;", "Lasanha" },
                    { 7, 4, new DateTime(2021, 11, 3, 21, 41, 3, 199, DateTimeKind.Local).AddTicks(5593), "delicioso", null, "ingredientes do bolode carne", "preparo do bolo de carne", "carne;queijo;presunto;", "Bolo de carne" },
                    { 8, 4, new DateTime(2021, 11, 3, 21, 41, 3, 199, DateTimeKind.Local).AddTicks(5595), "tradicional carne de panela", null, "ingredientes de carne de panela", "preparo de carne de panela", "", "Carne de panela" },
                    { 9, 5, new DateTime(2021, 11, 3, 21, 41, 3, 199, DateTimeKind.Local).AddTicks(5597), "Strogonoff de frango fácil", null, "ingredientes de strogonoff de frango", "preparo de strogonoff de frango", "", "Strogonoff de frango" },
                    { 10, 5, new DateTime(2021, 11, 3, 21, 41, 3, 199, DateTimeKind.Local).AddTicks(5598), "Medalhão de frango com bacon irresistível", null, "ingredientes de Medalhão de frango com bacon", "preparo de Medalhão de frango com bacon", "frango;bacon;", "Medalhão de frango com bacon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
