using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPerfilAcesso.Data.Migrations
{
    public partial class Usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeTipoUsuario = table.Column<string>(maxLength:256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcessoTipoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeFuncionalidade = table.Column<string>(maxLength:128, nullable: true),
                    IdTipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessoTipoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcessoTipoUsuario_TipoUsuario_IdTipoUsuario",
                        column: x => x.IdTipoUsuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfisUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTipoUsuario = table.Column<int>(nullable: false),
                    UserId = table.Column<string>( maxLength:450,nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfisUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfisUsuarios_TipoUsuario_IdTipoUsuario",
                        column: x => x.IdTipoUsuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfisUsuarios_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcessoTipoUsuario_IdTipoUsuario",
                table: "AcessoTipoUsuario",
                column: "IdTipoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PerfisUsuarios_IdTipoUsuario",
                table: "PerfisUsuarios",
                column: "IdTipoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PerfisUsuarios_UserId",
                table: "PerfisUsuarios",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessoTipoUsuario");

            migrationBuilder.DropTable(
                name: "PerfisUsuarios");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
