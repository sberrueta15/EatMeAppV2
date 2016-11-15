using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EatMeApp.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Commnesals_Events_EventId",
            //    table: "Commnesals");

            //migrationBuilder.DropIndex(
            //    name: "IX_Commnesals_EventId",
            //    table: "Commnesals");

            //migrationBuilder.DropColumn(
            //    name: "EventId",
            //    table: "Commnesals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Commnesals",
                nullable: true);

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
    }
}
