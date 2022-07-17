using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobRecruitment.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    AdministrativeLevel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyNature = table.Column<string>(maxLength: 50, nullable: true),
                    CompanySize = table.Column<string>(maxLength: 50, nullable: true),
                    IndustryType = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyAddress = table.Column<string>(maxLength: 100, nullable: true),
                    CompanyIntroduce = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Educations = table.Column<string>(nullable: true),
                    Welfares = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(maxLength: 50, nullable: true),
                    JobPay = table.Column<string>(maxLength: 50, nullable: true),
                    Welfare = table.Column<string>(maxLength: 500, nullable: true),
                    Education = table.Column<string>(maxLength: 50, nullable: true),
                    WorkExperience = table.Column<string>(maxLength: 50, nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    WorkArea = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    PublishTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    PositionInfo = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Companys",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Jobs1",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CityId",
                table: "Jobs",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
