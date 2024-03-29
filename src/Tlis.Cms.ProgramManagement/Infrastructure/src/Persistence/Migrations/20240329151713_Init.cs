﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cms_program_management");

            migrationBuilder.CreateTable(
                name: "show",
                schema: "cms_program_management",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    hero_image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_show", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "broadcast",
                schema: "cms_program_management",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    show_id = table.Column<Guid>(type: "uuid", nullable: false),
                    program_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_broadcast", x => x.id);
                    table.ForeignKey(
                        name: "fk_broadcast_show_program_id",
                        column: x => x.program_id,
                        principalSchema: "cms_program_management",
                        principalTable: "show",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_broadcast_name",
                schema: "cms_program_management",
                table: "broadcast",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_broadcast_program_id",
                schema: "cms_program_management",
                table: "broadcast",
                column: "program_id");

            migrationBuilder.CreateIndex(
                name: "ix_show_name",
                schema: "cms_program_management",
                table: "show",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "broadcast",
                schema: "cms_program_management");

            migrationBuilder.DropTable(
                name: "show",
                schema: "cms_program_management");
        }
    }
}
