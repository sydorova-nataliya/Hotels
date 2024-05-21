using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hotelcourseworkV2.Migrations
{
    /// <inheritdoc />
    public partial class add_tables_menu_dish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_dish_id_dish",
                table: "menu");

            migrationBuilder.DropIndex(
                name: "IX_menu_id_dish",
                table: "menu");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "0bc0078f-52f6-418a-b26e-2013446d911b");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "37bde467-0fcf-48da-a019-c1376a68260a");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "92fdc870-4085-4d0e-aadd-1382544346ab");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "b10a721c-e7a3-44e4-83fc-13189a9fe680");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "c26e91a0-0d7c-42b0-8c4b-e3c175a642a5");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "dbc5b035-7273-4e88-b1ca-8b12ae1adb86");

            migrationBuilder.DropColumn(
                name: "id_dish",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "price",
                table: "menu");

            migrationBuilder.CreateTable(
                name: "menu_dish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    menu_id = table.Column<int>(type: "integer", nullable: false),
                    dish_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_dish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menu_dish_dish_dish_id",
                        column: x => x.dish_id,
                        principalTable: "dish",
                        principalColumn: "id_dish",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menu_dish_menu_menu_id",
                        column: x => x.menu_id,
                        principalTable: "menu",
                        principalColumn: "id_menu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d541e71-4a82-4706-974a-611fbc5f4db8", "6d488586-69f1-461e-850d-68bb2a619f44", "Владелец сети", "ВЛАДЕЛЕЦ СЕТИ" },
                    { "5131f5f5-db41-41ed-b9eb-e37280581f77", "c0edd945-80fe-4b9d-9752-999ea9e7f034", "Зарегистрированный клиент", "ЗАРЕГИСТРИРОВАННЫЙ КЛИЕНТ" },
                    { "6730839f-f7b0-49be-9806-727fa21b1778", "f31131e9-9e8e-48f0-a8b7-decb09e5a216", "Директор", "ДИРЕКТОР" },
                    { "a058182c-ac4d-4322-8e63-8148efe4e68c", "a2b471a1-17a5-4472-9f57-35b616f21364", "Горничные", "ГОРНИЧНЫЕ" },
                    { "a05c318f-5058-4ce8-8136-fed24b84d78c", "b8e6185d-702d-4657-bbd9-72a87fce369b", "Повар в отеле", "ПОВАР В ОТЕЛЕ" },
                    { "f6141a02-2efd-4e0b-a375-b2f09b41b305", "e0191a73-b09a-4a61-abd8-869ca6f43929", "Сотрудник рецепции", "СОТРУДНИК РЕЦЕПЦИИ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_menu_dish_dish_id",
                table: "menu_dish",
                column: "dish_id");

            migrationBuilder.CreateIndex(
                name: "IX_menu_dish_menu_id",
                table: "menu_dish",
                column: "menu_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu_dish");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "3d541e71-4a82-4706-974a-611fbc5f4db8");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "5131f5f5-db41-41ed-b9eb-e37280581f77");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "6730839f-f7b0-49be-9806-727fa21b1778");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "a058182c-ac4d-4322-8e63-8148efe4e68c");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "a05c318f-5058-4ce8-8136-fed24b84d78c");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "f6141a02-2efd-4e0b-a375-b2f09b41b305");

            migrationBuilder.AddColumn<int>(
                name: "id_dish",
                table: "menu",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "menu",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bc0078f-52f6-418a-b26e-2013446d911b", "ce2cf883-6caa-4204-a0d5-8c4c2efe916a", "Сотрудник рецепции", "СОТРУДНИК РЕЦЕПЦИИ" },
                    { "37bde467-0fcf-48da-a019-c1376a68260a", "fe566a35-a285-4d6c-9633-36379b3aacc3", "Владелец сети", "ВЛАДЕЛЕЦ СЕТИ" },
                    { "92fdc870-4085-4d0e-aadd-1382544346ab", "6332b101-3539-4349-99ed-6ef6462595ff", "Зарегистрированный клиент", "ЗАРЕГИСТРИРОВАННЫЙ КЛИЕНТ" },
                    { "b10a721c-e7a3-44e4-83fc-13189a9fe680", "dbe87e47-8118-4bed-bb9b-ca0cdc8a3c6b", "Горничные", "ГОРНИЧНЫЕ" },
                    { "c26e91a0-0d7c-42b0-8c4b-e3c175a642a5", "f09ccdd6-08bb-44f1-9baa-b1a34bfb190f", "Повар в отеле", "ПОВАР В ОТЕЛЕ" },
                    { "dbc5b035-7273-4e88-b1ca-8b12ae1adb86", "f0ca12d9-d52e-4023-a7aa-2bbbeee4ccde", "Директор", "ДИРЕКТОР" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_menu_id_dish",
                table: "menu",
                column: "id_dish");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_dish_id_dish",
                table: "menu",
                column: "id_dish",
                principalTable: "dish",
                principalColumn: "id_dish",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
