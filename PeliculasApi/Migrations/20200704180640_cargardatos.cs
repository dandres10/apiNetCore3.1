﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeliculasApi.Migrations
{
    public partial class cargardatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actores",
                columns: new[] { "Id", "FechaNacimiento", "Foto", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(1962, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jim Carrey" },
                    { 2, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Robert Downey Jr." },
                    { 3, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chris Evans" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Aventura" },
                    { 2, "Animación" },
                    { 3, "Suspenso" },
                    { 4, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Id", "EnCines", "FechaEstreno", "Poster", "Titulo" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Avengers: Endgame" },
                    { 2, false, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Avengers: Infinity Wars" },
                    { 3, false, new DateTime(2020, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sonic the Hedgehog" },
                    { 4, false, new DateTime(2020, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emma" },
                    { 5, false, new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Wonder Woman 1984" }
                });

            migrationBuilder.InsertData(
                table: "PeliculasActores",
                columns: new[] { "ActorId", "PeliculaId", "Orden", "Personaje" },
                values: new object[,]
                {
                    { 2, 1, 1, "Tony Stark" },
                    { 3, 1, 2, "Steve Rogers" },
                    { 2, 2, 1, "Tony Stark" },
                    { 3, 2, 2, "Steve Rogers" },
                    { 1, 3, 1, "Dr. Ivo Robotnik" }
                });

            migrationBuilder.InsertData(
                table: "PeliculasGeneros",
                columns: new[] { "PeliculaId", "GeneroId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 1 },
                    { 2, 3 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 3 },
                    { 4, 4 },
                    { 5, 3 },
                    { 5, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "PeliculaId", "GeneroId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "PeliculaId", "GeneroId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "PeliculaId", "GeneroId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "PeliculaId", "GeneroId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "PeliculaId", "GeneroId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "PeliculaId", "GeneroId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "PeliculaId", "GeneroId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "PeliculaId", "GeneroId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "PeliculasGeneros",
                keyColumns: new[] { "PeliculaId", "GeneroId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
