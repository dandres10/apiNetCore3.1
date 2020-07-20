﻿using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace PeliculasApi.Migrations
{
    public partial class saladecinedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SalaDeCines",
                columns: new[] { "Id", "Nombre", "Ubicacion" },
                values: new object[] { 3, "Sambil", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9118804 18.4826214)") });

            migrationBuilder.InsertData(
                table: "SalaDeCines",
                columns: new[] { "Id", "Nombre", "Ubicacion" },
                values: new object[] { 4, "Megacentro", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.856427 18.506934)") });

            migrationBuilder.InsertData(
                table: "SalaDeCines",
                columns: new[] { "Id", "Nombre", "Ubicacion" },
                values: new object[] { 5, "Village East Cinema", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-73.986227 40.730898)") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SalaDeCines",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
