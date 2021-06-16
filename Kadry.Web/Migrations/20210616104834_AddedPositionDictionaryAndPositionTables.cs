using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kadry.Web.Migrations
{
    public partial class AddedPositionDictionaryAndPositionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dictionary");

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "Dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChangedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObjectGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_AspNetUsers_ChangedById",
                        column: x => x.ChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Positions_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                schema: "Hr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(type: "int", nullable: true),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChangedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObjectGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_AspNetUsers_ChangedById",
                        column: x => x.ChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Position_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Position_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Hr",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Position_Positions_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "Dictionary",
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Position_ChangedById",
                schema: "Hr",
                table: "Position",
                column: "ChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Position_CreatedById",
                schema: "Hr",
                table: "Position",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Position_PersonId",
                schema: "Hr",
                table: "Position",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_PositionId",
                schema: "Hr",
                table: "Position",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_ChangedById",
                schema: "Dictionary",
                table: "Positions",
                column: "ChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CreatedById",
                schema: "Dictionary",
                table: "Positions",
                column: "CreatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Position",
                schema: "Hr");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "Dictionary");
        }
    }
}
