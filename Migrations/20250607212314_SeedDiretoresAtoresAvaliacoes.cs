using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmesTerror.Migrations
{
    /// <inheritdoc />
    public partial class SeedDiretoresAtoresAvaliacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Atores",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Vera Farmiga" },
                    { 2, "Patrick Wilson" },
                    { 3, "Florence Pugh" }
                });

            migrationBuilder.InsertData(
                table: "Avaliacoes",
                columns: new[] { "Id", "Comentario", "Data", "FilmeId", "FilmeId1", "Nota" },
                values: new object[,]
                {
                    { 1, "Assustador e bem dirigido!", new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 9 },
                    { 2, "Atmosfera única.", new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 8 }
                });

            migrationBuilder.InsertData(
                table: "Diretores",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "James Wan" },
                    { 2, "Ari Aster" }
                });

            migrationBuilder.InsertData(
                table: "FilmesAtores",
                columns: new[] { "AtorId", "FilmeId", "FilmeId1" },
                values: new object[,]
                {
                    { 1, 2, null },
                    { 2, 2, null },
                    { 3, 9, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Avaliacoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Avaliacoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FilmesAtores",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "FilmesAtores",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "FilmesAtores",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
