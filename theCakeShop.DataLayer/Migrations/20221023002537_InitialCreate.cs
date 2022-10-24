using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace theCakeShop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cakes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cakes_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "character varying(20)", maxLength: 20, nullable: true),
                    lastname = table.Column<string>(name: "last_name", type: "character varying(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    userid = table.Column<string>(name: "user_id", type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    userprofileid = table.Column<int>(name: "user_profile_id", type: "integer", nullable: false),
                    cakeid = table.Column<int>(name: "cake_id", type: "integer", nullable: false),
                    paid = table.Column<bool>(type: "boolean", nullable: true),
                    delivered = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cart_pkey", x => x.id);
                    table.ForeignKey(
                        name: "cakes_orders_fk",
                        column: x => x.id,
                        principalTable: "cakes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "users_orders_fk",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "cakes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
