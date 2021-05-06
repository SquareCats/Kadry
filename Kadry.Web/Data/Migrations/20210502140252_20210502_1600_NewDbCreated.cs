using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kadry.Web.Data.Migrations
{
    public partial class _20210502_1600_NewDbCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.EnsureSchema(
            //    name: "dbo");

            //migrationBuilder.CreateTable(
            //    name: "CountryDictionary",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ChengedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        ChangedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        ObjectGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Sort = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CountryDictionary", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CountryDictionary_AspNetUsers_ChengedById",
            //            column: x => x.ChengedById,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_CountryDictionary_AspNetUsers_CreatedById",
            //            column: x => x.CreatedById,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CurrencyDictionary",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ChengedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        ChangedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        ObjectGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Sort = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CurrencyDictionary", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CurrencyDictionary_AspNetUsers_ChengedById",
            //            column: x => x.ChengedById,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_CurrencyDictionary_AspNetUsers_CreatedById",
            //            column: x => x.CreatedById,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LevelDictionary",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ChengedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        ChangedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        ObjectGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LevelDictionary", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_LevelDictionary_AspNetUsers_ChengedById",
            //            column: x => x.ChengedById,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LevelDictionary_AspNetUsers_CreatedById",
            //            column: x => x.CreatedById,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LogActivitiesDictionary",
            //    schema: "dbo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Level = table.Column<int>(type: "int", maxLength: 100, nullable: false),
            //        CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ChengedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        ChangedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        ObjectGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Sort = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LogActivitiesDictionary", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_LogActivitiesDictionary_AspNetUsers_ChengedById",
            //            column: x => x.ChengedById,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LogActivitiesDictionary_AspNetUsers_CreatedById",
            //            column: x => x.CreatedById,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LogDb",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ActivityId = table.Column<int>(type: "int", nullable: true),
            //        ActivityTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Host = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ChengedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //        ChangedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        ObjectGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LogDb", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_LogDb_AspNetUsers_ChengedById",
            //            column: x => x.ChengedById,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LogDb_AspNetUsers_CreatedById",
            //            column: x => x.CreatedById,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_LogDb_LogActivitiesDictionary_ActivityId",
            //            column: x => x.ActivityId,
            //            principalSchema: "dbo",
            //            principalTable: "LogActivitiesDictionary",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_CountryDictionary_ChengedById",
            //    schema: "dbo",
            //    table: "CountryDictionary",
            //    column: "ChengedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CountryDictionary_CreatedById",
            //    schema: "dbo",
            //    table: "CountryDictionary",
            //    column: "CreatedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CurrencyDictionary_ChengedById",
            //    schema: "dbo",
            //    table: "CurrencyDictionary",
            //    column: "ChengedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CurrencyDictionary_CreatedById",
            //    schema: "dbo",
            //    table: "CurrencyDictionary",
            //    column: "CreatedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LevelDictionary_ChengedById",
            //    schema: "dbo",
            //    table: "LevelDictionary",
            //    column: "ChengedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LevelDictionary_CreatedById",
            //    schema: "dbo",
            //    table: "LevelDictionary",
            //    column: "CreatedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LogActivitiesDictionary_ChengedById",
            //    schema: "dbo",
            //    table: "LogActivitiesDictionary",
            //    column: "ChengedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LogActivitiesDictionary_CreatedById",
            //    schema: "dbo",
            //    table: "LogActivitiesDictionary",
            //    column: "CreatedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LogDb_ActivityId",
            //    table: "LogDb",
            //    column: "ActivityId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LogDb_ChengedById",
            //    table: "LogDb",
            //    column: "ChengedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LogDb_CreatedById",
            //    table: "LogDb",
            //    column: "CreatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryDictionary",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CurrencyDictionary",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LevelDictionary",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LogDb");

            migrationBuilder.DropTable(
                name: "LogActivitiesDictionary",
                schema: "dbo");
        }
    }
}
