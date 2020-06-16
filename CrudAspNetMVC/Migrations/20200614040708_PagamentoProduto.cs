using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudAspNetMVC.Migrations
{
    public partial class PagamentoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desejos_Formas_FormaId",
                table: "Desejos");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDir_Categorias_CategoriaId",
                table: "DespesaDir");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDir_Formas_FormaId",
                table: "DespesaDir");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDir_Produtos_ProdutoId",
                table: "DespesaDir");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaFixa_Categorias_CategoriaId",
                table: "DespesaFixa");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaFixa_Formas_FormaId",
                table: "DespesaFixa");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaFixa_Produtos_ProdutoId",
                table: "DespesaFixa");

            migrationBuilder.DropForeignKey(
                name: "FK_Mercado_Categorias_CategoriaId",
                table: "Mercado");

            migrationBuilder.DropForeignKey(
                name: "FK_Mercado_Formas_FormaId",
                table: "Mercado");

            migrationBuilder.DropForeignKey(
                name: "FK_Mercado_Produtos_ProdutoId",
                table: "Mercado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mercado",
                table: "Mercado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formas",
                table: "Formas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DespesaFixa",
                table: "DespesaFixa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DespesaDir",
                table: "DespesaDir");

            migrationBuilder.RenameTable(
                name: "Mercado",
                newName: "Mercados");

            migrationBuilder.RenameTable(
                name: "Formas",
                newName: "FormaPagamento");

            migrationBuilder.RenameTable(
                name: "DespesaFixa",
                newName: "DespesasFixas");

            migrationBuilder.RenameTable(
                name: "DespesaDir",
                newName: "DespesaDiretas");

            migrationBuilder.RenameIndex(
                name: "IX_Mercado_ProdutoId",
                table: "Mercados",
                newName: "IX_Mercados_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Mercado_FormaId",
                table: "Mercados",
                newName: "IX_Mercados_FormaId");

            migrationBuilder.RenameIndex(
                name: "IX_Mercado_CategoriaId",
                table: "Mercados",
                newName: "IX_Mercados_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaFixa_ProdutoId",
                table: "DespesasFixas",
                newName: "IX_DespesasFixas_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaFixa_FormaId",
                table: "DespesasFixas",
                newName: "IX_DespesasFixas_FormaId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaFixa_CategoriaId",
                table: "DespesasFixas",
                newName: "IX_DespesasFixas_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaDir_ProdutoId",
                table: "DespesaDiretas",
                newName: "IX_DespesaDiretas_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaDir_FormaId",
                table: "DespesaDiretas",
                newName: "IX_DespesaDiretas_FormaId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaDir_CategoriaId",
                table: "DespesaDiretas",
                newName: "IX_DespesaDiretas_CategoriaId");

            migrationBuilder.AddColumn<long>(
                name: "FormaId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mercados",
                table: "Mercados",
                column: "MercadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormaPagamento",
                table: "FormaPagamento",
                column: "FormaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DespesasFixas",
                table: "DespesasFixas",
                column: "DespesaFixId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DespesaDiretas",
                table: "DespesaDiretas",
                column: "DespesaDirId");

            migrationBuilder.CreateTable(
                name: "PagamentoProduto",
                columns: table => new
                {
                    ProdutoId = table.Column<long>(nullable: false),
                    FormaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoProduto", x => new { x.ProdutoId, x.FormaId });
                    table.ForeignKey(
                        name: "FK_PagamentoProduto_FormaPagamento_FormaId",
                        column: x => x.FormaId,
                        principalTable: "FormaPagamento",
                        principalColumn: "FormaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagamentoProduto_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FormaId",
                table: "Produtos",
                column: "FormaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoProduto_FormaId",
                table: "PagamentoProduto",
                column: "FormaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desejos_FormaPagamento_FormaId",
                table: "Desejos",
                column: "FormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDiretas_Categorias_CategoriaId",
                table: "DespesaDiretas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDiretas_FormaPagamento_FormaId",
                table: "DespesaDiretas",
                column: "FormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDiretas_Produtos_ProdutoId",
                table: "DespesaDiretas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesasFixas_Categorias_CategoriaId",
                table: "DespesasFixas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesasFixas_FormaPagamento_FormaId",
                table: "DespesasFixas",
                column: "FormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesasFixas_Produtos_ProdutoId",
                table: "DespesasFixas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mercados_Categorias_CategoriaId",
                table: "Mercados",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mercados_FormaPagamento_FormaId",
                table: "Mercados",
                column: "FormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mercados_Produtos_ProdutoId",
                table: "Mercados",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_FormaPagamento_FormaId",
                table: "Produtos",
                column: "FormaId",
                principalTable: "FormaPagamento",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desejos_FormaPagamento_FormaId",
                table: "Desejos");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDiretas_Categorias_CategoriaId",
                table: "DespesaDiretas");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDiretas_FormaPagamento_FormaId",
                table: "DespesaDiretas");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesaDiretas_Produtos_ProdutoId",
                table: "DespesaDiretas");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesasFixas_Categorias_CategoriaId",
                table: "DespesasFixas");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesasFixas_FormaPagamento_FormaId",
                table: "DespesasFixas");

            migrationBuilder.DropForeignKey(
                name: "FK_DespesasFixas_Produtos_ProdutoId",
                table: "DespesasFixas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mercados_Categorias_CategoriaId",
                table: "Mercados");

            migrationBuilder.DropForeignKey(
                name: "FK_Mercados_FormaPagamento_FormaId",
                table: "Mercados");

            migrationBuilder.DropForeignKey(
                name: "FK_Mercados_Produtos_ProdutoId",
                table: "Mercados");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_FormaPagamento_FormaId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "PagamentoProduto");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_FormaId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mercados",
                table: "Mercados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormaPagamento",
                table: "FormaPagamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DespesasFixas",
                table: "DespesasFixas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DespesaDiretas",
                table: "DespesaDiretas");

            migrationBuilder.DropColumn(
                name: "FormaId",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Mercados",
                newName: "Mercado");

            migrationBuilder.RenameTable(
                name: "FormaPagamento",
                newName: "Formas");

            migrationBuilder.RenameTable(
                name: "DespesasFixas",
                newName: "DespesaFixa");

            migrationBuilder.RenameTable(
                name: "DespesaDiretas",
                newName: "DespesaDir");

            migrationBuilder.RenameIndex(
                name: "IX_Mercados_ProdutoId",
                table: "Mercado",
                newName: "IX_Mercado_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Mercados_FormaId",
                table: "Mercado",
                newName: "IX_Mercado_FormaId");

            migrationBuilder.RenameIndex(
                name: "IX_Mercados_CategoriaId",
                table: "Mercado",
                newName: "IX_Mercado_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesasFixas_ProdutoId",
                table: "DespesaFixa",
                newName: "IX_DespesaFixa_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesasFixas_FormaId",
                table: "DespesaFixa",
                newName: "IX_DespesaFixa_FormaId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesasFixas_CategoriaId",
                table: "DespesaFixa",
                newName: "IX_DespesaFixa_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaDiretas_ProdutoId",
                table: "DespesaDir",
                newName: "IX_DespesaDir_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaDiretas_FormaId",
                table: "DespesaDir",
                newName: "IX_DespesaDir_FormaId");

            migrationBuilder.RenameIndex(
                name: "IX_DespesaDiretas_CategoriaId",
                table: "DespesaDir",
                newName: "IX_DespesaDir_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mercado",
                table: "Mercado",
                column: "MercadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formas",
                table: "Formas",
                column: "FormaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DespesaFixa",
                table: "DespesaFixa",
                column: "DespesaFixId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DespesaDir",
                table: "DespesaDir",
                column: "DespesaDirId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desejos_Formas_FormaId",
                table: "Desejos",
                column: "FormaId",
                principalTable: "Formas",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDir_Categorias_CategoriaId",
                table: "DespesaDir",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDir_Formas_FormaId",
                table: "DespesaDir",
                column: "FormaId",
                principalTable: "Formas",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaDir_Produtos_ProdutoId",
                table: "DespesaDir",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaFixa_Categorias_CategoriaId",
                table: "DespesaFixa",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaFixa_Formas_FormaId",
                table: "DespesaFixa",
                column: "FormaId",
                principalTable: "Formas",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespesaFixa_Produtos_ProdutoId",
                table: "DespesaFixa",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mercado_Categorias_CategoriaId",
                table: "Mercado",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mercado_Formas_FormaId",
                table: "Mercado",
                column: "FormaId",
                principalTable: "Formas",
                principalColumn: "FormaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mercado_Produtos_ProdutoId",
                table: "Mercado",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
