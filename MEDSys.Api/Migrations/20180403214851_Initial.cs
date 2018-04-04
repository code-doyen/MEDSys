using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MEDSys.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientBirthday = table.Column<string>(nullable: true),
                    ClientLastName = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    ServiceLine = table.Column<string>(nullable: true),
                    ServiceLineEndDate = table.Column<DateTime>(nullable: false),
                    ServiceLineStartDate = table.Column<DateTime>(nullable: false),
                    StaffLastName = table.Column<string>(nullable: true),
                    StaffName = table.Column<string>(nullable: true),
                    StaffSpecialty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");
        }
    }
}
