using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaFamilia.Migrations
{
    /// <inheritdoc />
    public partial class BeneficioNulos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MotivoRejeicao",
                table: "Beneficio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataBloqueio",
                table: "Beneficio",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotivoBloqueio",
                table: "Beneficio",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataBloqueio",
                table: "Beneficio");

            migrationBuilder.DropColumn(
                name: "MotivoBloqueio",
                table: "Beneficio");

            migrationBuilder.AlterColumn<int>(
                name: "MotivoRejeicao",
                table: "Beneficio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
