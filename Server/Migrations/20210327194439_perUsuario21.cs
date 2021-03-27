using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroAcademicoApp.Server.Migrations
{
    public partial class perUsuario21 : Migration
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
                    UsuarioIdMenuNavigationIdMenu = table.Column<int>(nullable: true)
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
                        name: "FK_Perfiles_Menu_UsuarioIdMenuNavigationIdMenu",
                        column: x => x.UsuarioIdMenuNavigationIdMenu,
                        principalTable: "Menu",
                        principalColumn: "IdMenu",
                        onDelete: ReferentialAction.Restrict);
                });

           



            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_UsuarioId",
                table: "Perfiles",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfiles_UsuarioIdMenuNavigationIdMenu",
                table: "Perfiles",
                column: "UsuarioIdMenuNavigationIdMenu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "Perfiles");

          

            migrationBuilder.DropTable(
                name: "Menu");

         
        }
    }
}
