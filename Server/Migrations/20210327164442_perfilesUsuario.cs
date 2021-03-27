using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroAcademicoApp.Server.Migrations
{
    public partial class perfilesUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    IdMenu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpcionMenu = table.Column<string>(nullable: true),
                    NombreMenu = table.Column<string>(nullable: true),
                    Icono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.IdMenu);
                });



            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioIdMenu = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true),
                   
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.IdPerfil);
                    table.ForeignKey(
                        name: "FK_Perfiles_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Perfiles_Menu_UsuarioIdMenu",
                        column: x => x.UsuarioIdMenu,
                        principalTable: "Menu",
                        principalColumn: "IdMenu",
                        onDelete: ReferentialAction.Restrict);
                });

            


            migrationBuilder.CreateIndex(
                name: "FK_Perfiles_Menu_UsuarioIdMenu",
                table: "Perfiles",
                column: "UsuarioIdMenu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Perfiles");

        }
    }
}
