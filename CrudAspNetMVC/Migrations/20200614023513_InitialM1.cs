using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudAspNetMVC.Migrations
{
    public partial class InitialM1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Formas",
                columns: table => new
                {
                    FormaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormaNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formas", x => x.FormaId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProdutoNome = table.Column<string>(nullable: true),
                    ProdutoDescricao = table.Column<string>(nullable: true),
                    CategoriaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Desejos",
                columns: table => new
                {
                    DesejoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesejoValor = table.Column<double>(nullable: false),
                    DesejoData = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<long>(nullable: true),
                    FormaId = table.Column<long>(nullable: true),
                    CategoriaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desejos", x => x.DesejoId);
                    table.ForeignKey(
                        name: "FK_Desejos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Desejos_Formas_FormaId",
                        column: x => x.FormaId,
                        principalTable: "Formas",
                        principalColumn: "FormaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Desejos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DespesaDir",
                columns: table => new
                {
                    DespesaDirId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DespDirValor = table.Column<double>(nullable: false),
                    DespDirData = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FormaId = table.Column<long>(nullable: true),
                    CategoriaId = table.Column<long>(nullable: true),
                    ProdutoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesaDir", x => x.DespesaDirId);
                    table.ForeignKey(
                        name: "FK_DespesaDir_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DespesaDir_Formas_FormaId",
                        column: x => x.FormaId,
                        principalTable: "Formas",
                        principalColumn: "FormaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DespesaDir_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DespesaFixa",
                columns: table => new
                {
                    DespesaFixId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DespFixValor = table.Column<double>(nullable: false),
                    DespFixData = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FormaId = table.Column<long>(nullable: true),
                    CategoriaId = table.Column<long>(nullable: true),
                    ProdutoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesaFixa", x => x.DespesaFixId);
                    table.ForeignKey(
                        name: "FK_DespesaFixa_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DespesaFixa_Formas_FormaId",
                        column: x => x.FormaId,
                        principalTable: "Formas",
                        principalColumn: "FormaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DespesaFixa_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mercado",
                columns: table => new
                {
                    MercadoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MercadoValor = table.Column<double>(nullable: false),
                    MercadoData = table.Column<DateTime>(nullable: false),
                    StatusCompra = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<long>(nullable: true),
                    FormaId = table.Column<long>(nullable: true),
                    CategoriaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercado", x => x.MercadoId);
                    table.ForeignKey(
                        name: "FK_Mercado_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercado_Formas_FormaId",
                        column: x => x.FormaId,
                        principalTable: "Formas",
                        principalColumn: "FormaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mercado_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desejos_CategoriaId",
                table: "Desejos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Desejos_FormaId",
                table: "Desejos",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_Desejos_ProdutoId",
                table: "Desejos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDir_CategoriaId",
                table: "DespesaDir",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDir_FormaId",
                table: "DespesaDir",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaDir_ProdutoId",
                table: "DespesaDir",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaFixa_CategoriaId",
                table: "DespesaFixa",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaFixa_FormaId",
                table: "DespesaFixa",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_DespesaFixa_ProdutoId",
                table: "DespesaFixa",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercado_CategoriaId",
                table: "Mercado",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercado_FormaId",
                table: "Mercado",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercado_ProdutoId",
                table: "Mercado",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desejos");

            migrationBuilder.DropTable(
                name: "DespesaDir");

            migrationBuilder.DropTable(
                name: "DespesaFixa");

            migrationBuilder.DropTable(
                name: "Mercado");

            migrationBuilder.DropTable(
                name: "Formas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
