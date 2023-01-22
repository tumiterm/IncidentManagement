using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Incident_and_Infrastructure_Management.Migrations
{
    public partial class UpdateIncidentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Incident");

            migrationBuilder.AddColumn<DateTime>(
                name: "AttendedOn",
                table: "Incident",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAttendedTo",
                table: "Incident",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendedOn",
                table: "Incident");

            migrationBuilder.DropColumn(
                name: "IsAttendedTo",
                table: "Incident");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Incident",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
