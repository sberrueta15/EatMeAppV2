using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EatMeApp.Migrations
{
    public partial class RequiredProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Commnesals",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Cookers",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Cookers",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Cookers",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Cookers",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Cookers",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Commnesals",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Commnesals",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Commnesals",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Commnesals",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Commnesals",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Commnesals_EventId",
                table: "Commnesals",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commnesals_Events_EventId",
                table: "Commnesals",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commnesals_Events_EventId",
                table: "Commnesals");

            migrationBuilder.DropIndex(
                name: "IX_Commnesals_EventId",
                table: "Commnesals");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Commnesals");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Cookers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Commnesals",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Commnesals",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Commnesals",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Commnesals",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Commnesals",
                nullable: true);
        }
    }
}
