using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradianBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedMissingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FooterLink_FooterSection_SectionId",
                table: "FooterLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FooterSection",
                table: "FooterSection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FooterLink",
                table: "FooterLink");

            migrationBuilder.RenameTable(
                name: "FooterSection",
                newName: "FooterSections");

            migrationBuilder.RenameTable(
                name: "FooterLink",
                newName: "FooterLinks");

            migrationBuilder.RenameIndex(
                name: "IX_FooterLink_SectionId",
                table: "FooterLinks",
                newName: "IX_FooterLinks_SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FooterSections",
                table: "FooterSections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FooterLinks",
                table: "FooterLinks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Declarations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CNumber = table.Column<string>(type: "text", nullable: false),
                    RNumber = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declarations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FooterLinks_FooterSections_SectionId",
                table: "FooterLinks",
                column: "SectionId",
                principalTable: "FooterSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FooterLinks_FooterSections_SectionId",
                table: "FooterLinks");

            migrationBuilder.DropTable(
                name: "Declarations");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FooterSections",
                table: "FooterSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FooterLinks",
                table: "FooterLinks");

            migrationBuilder.RenameTable(
                name: "FooterSections",
                newName: "FooterSection");

            migrationBuilder.RenameTable(
                name: "FooterLinks",
                newName: "FooterLink");

            migrationBuilder.RenameIndex(
                name: "IX_FooterLinks_SectionId",
                table: "FooterLink",
                newName: "IX_FooterLink_SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FooterSection",
                table: "FooterSection",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FooterLink",
                table: "FooterLink",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FooterLink_FooterSection_SectionId",
                table: "FooterLink",
                column: "SectionId",
                principalTable: "FooterSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
