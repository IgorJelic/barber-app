using Microsoft.EntityFrameworkCore.Migrations;
using Shared.Enums;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Username", "Password", "Role" },
                values: new object[,]{
                    {Guid.NewGuid(), "admin", "admin", 0},
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
