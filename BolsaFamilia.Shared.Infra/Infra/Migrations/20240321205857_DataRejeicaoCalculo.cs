using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaFamilia.Migrations
{
    /// <inheritdoc />
    public partial class DataRejeicaoCalculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCalculoRejeicao",
                table: "Beneficio",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCalculoRejeicao",
                table: "Beneficio");
        }
    }
}
