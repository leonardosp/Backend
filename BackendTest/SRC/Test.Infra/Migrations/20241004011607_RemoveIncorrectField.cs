using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIncorrectField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEntregador",
                table: "Alugueis");

            migrationBuilder.DropColumn(
                name: "IdMoto",
                table: "Alugueis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdEntregador",
                table: "Alugueis",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdMoto",
                table: "Alugueis",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
