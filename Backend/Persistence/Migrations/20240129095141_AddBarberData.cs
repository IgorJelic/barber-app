using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBarberData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "Username", "Password", "IsDeleted" },
                values: new object[,]{
                    {Guid.NewGuid(), "barber1", "pasword1", false},
                    {Guid.NewGuid(), "barber2", "password2", false}
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
