using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoCrud.DAL.Migrations
{
    public partial class EstaBorrado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Appellido",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "Nombre",
            //    table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "EstaBorrado",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaBorrado",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            //migrationBuilder.AddColumn<string>(
            //    name: "Appellido",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Nombre",
            //    table: "AspNetUsers",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");
        }
    }
}
