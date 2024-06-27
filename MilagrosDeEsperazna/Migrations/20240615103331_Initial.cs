using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilagrosDeEsperanza.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    id_comentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    mensaje = table.Column<string>(type: "text", nullable: false),
                    fecha_envio = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comentar__1BA6C6F45BF574F2", x => x.id_comentario);
                });

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    id_noticia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    contenido = table.Column<string>(type: "text", nullable: true),
                    imagen = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    fecha_publicacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Noticias__1D4A6BA1A6C3FAC4", x => x.id_noticia);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    id_proyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    imagen = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proyecto__F38AD81D25AA5C4D", x => x.id_proyecto);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    primer_apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    segundo_apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__AB6E6165C2EEAE02", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "Voluntarios",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    id_voluntario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    primer_apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    segundo_apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Voluntar__AB6E6165572DA4BB", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "VoluntariosProyectos",
                columns: table => new
                {
                    id_asociacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    id_proyecto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Voluntar__086AFDE70D2F15A3", x => x.id_asociacion);
                    table.ForeignKey(
                        name: "FK__Voluntari__email__44FF419A",
                        column: x => x.email,
                        principalTable: "Voluntarios",
                        principalColumn: "email");
                    table.ForeignKey(
                        name: "FK__Voluntari__id_pr__45F365D3",
                        column: x => x.id_proyecto,
                        principalTable: "Proyectos",
                        principalColumn: "id_proyecto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoluntariosProyectos_email",
                table: "VoluntariosProyectos",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_VoluntariosProyectos_id_proyecto",
                table: "VoluntariosProyectos",
                column: "id_proyecto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "VoluntariosProyectos");

            migrationBuilder.DropTable(
                name: "Voluntarios");

            migrationBuilder.DropTable(
                name: "Proyectos");
        }
    }
}
