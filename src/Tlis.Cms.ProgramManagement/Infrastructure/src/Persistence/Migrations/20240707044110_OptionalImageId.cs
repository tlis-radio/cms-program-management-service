using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OptionalImageId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "image_id",
                schema: "cms_program_management",
                table: "broadcast",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "image_id",
                schema: "cms_program_management",
                table: "broadcast",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
