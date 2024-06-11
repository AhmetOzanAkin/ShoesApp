using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoesApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    InfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ShoesId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedPhone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedPhone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameVisibility = table.Column<bool>(type: "bit", nullable: true),
                    RelatedName1Visibility = table.Column<bool>(type: "bit", nullable: true),
                    RelatedName2Visibility = table.Column<bool>(type: "bit", nullable: true),
                    RelatedPhone1Visibility = table.Column<bool>(type: "bit", nullable: true),
                    RelatedPhone2Visibility = table.Column<bool>(type: "bit", nullable: true),
                    AddressVisibility = table.Column<bool>(type: "bit", nullable: true),
                    MessageVisibility = table.Column<bool>(type: "bit", nullable: true),
                    EmailVisibility = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.InfoId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
