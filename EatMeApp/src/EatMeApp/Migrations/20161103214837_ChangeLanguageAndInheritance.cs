using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EatMeApp.Migrations
{
    public partial class ChangeLanguageAndInheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cocineros",
                table: "Cocineros");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "CocineroId",
                table: "Cocineros");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Cocineros");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Cocineros");

            migrationBuilder.DropColumn(
                name: "Codigo_Postal",
                table: "Cocineros");

            migrationBuilder.DropColumn(
                name: "Contraseña",
                table: "Cocineros");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Cocineros");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Cocineros");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Cocineros");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Cocineros");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Cocineros");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Cocineros");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Eventos",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGeneratedOnAdd", true);

            migrationBuilder.AddColumn<int>(
                name: "CookerId",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cocineros",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGeneratedOnAdd", true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Cocineros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Cocineros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Cocineros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Cocineros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityCard",
                table: "Cocineros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Cocineros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Cocineros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Cocineros",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "Cocineros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Cocineros",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Eventos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CookerId",
                table: "Eventos",
                column: "CookerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cookers",
                table: "Cocineros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Cookers_CookerId",
                table: "Eventos",
                column: "CookerId",
                principalTable: "Cocineros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "Eventos",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "Cocineros",
                newName: "Cookers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Cookers_CookerId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CookerId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cookers",
                table: "Cookers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CookerId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cookers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Cookers");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Cookers");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Cookers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Cookers");

            migrationBuilder.DropColumn(
                name: "IdentityCard",
                table: "Cookers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Cookers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Cookers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Cookers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Cookers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Cookers");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Events",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGeneratedOnAdd", true);

            migrationBuilder.AddColumn<int>(
                name: "CocineroId",
                table: "Cookers",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGeneratedOnAdd", true);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Codigo_Postal",
                table: "Cookers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eventos",
                table: "Events",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cocineros",
                table: "Cookers",
                column: "CocineroId");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Eventos");

            migrationBuilder.RenameTable(
                name: "Cookers",
                newName: "Cocineros");
        }
    }
}
