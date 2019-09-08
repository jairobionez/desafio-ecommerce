using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioEcommerce.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PAGAMENTO",
                columns: table => new
                {
                    NROPAGAMENTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    SOBRENOME = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true),
                    RUA = table.Column<string>(type: "varhcar(60)", maxLength: 60, nullable: true),
                    CIDADE = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    ESTADO = table.Column<string>(type: "varhcar(20)", maxLength: 20, nullable: true),
                    CEP = table.Column<string>(type: "varhcar(8)", maxLength: 8, nullable: true),
                    BAIRRO = table.Column<string>(type: "varhcar(20)", maxLength: 20, nullable: true),
                    NUMERO = table.Column<string>(type: "varhcar(6)", maxLength: 6, nullable: true),
                    TOTAL = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    TOTALPAGO = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DTAPAGAMENTO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DOCUMENTO = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    TIPODOCUMENTO = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGAMENTO", x => x.NROPAGAMENTO);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    SKU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DESCRICAO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IMAGEM = table.Column<byte[]>(type: "image", nullable: true),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    VALOR = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    PESO = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    CODEAN = table.Column<string>(type: "varchar(13)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.SKU);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOITEM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    VLRUNITARIO = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    NROPAGAMENTO = table.Column<int>(type: "int", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOITEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PEDIDOITEM_PAGAMENTO_NROPAGAMENTO",
                        column: x => x.NROPAGAMENTO,
                        principalTable: "PAGAMENTO",
                        principalColumn: "NROPAGAMENTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOITEM_NROPAGAMENTO",
                table: "PEDIDOITEM",
                column: "NROPAGAMENTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PEDIDOITEM");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "PAGAMENTO");
        }
    }
}
