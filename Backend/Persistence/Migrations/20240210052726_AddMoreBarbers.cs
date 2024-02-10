using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreBarbers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "Username", "Password", "IsDeleted", "Gender" },
                values: new object[,]{
                    {Guid.NewGuid(), "Milica", "pasword3", false, 1},
                    {Guid.NewGuid(), "Natalija", "password4", false, 1},
                    {Guid.NewGuid(), "Jovan", "pasword5", false, 0},
                    {Guid.NewGuid(), "Dragan", "password6", false, 0},
                    {Guid.NewGuid(), "Katarina", "pasword7", false, 1},
                    {Guid.NewGuid(), "Uros", "password8", false, 0},
                    {Guid.NewGuid(), "Bosiljka", "password9", false, 1},
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
