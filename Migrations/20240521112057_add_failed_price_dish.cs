using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hotelcourseworkV2.Migrations
{
    /// <inheritdoc />
    public partial class add_failed_price_dish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "dish",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e657972-3eb9-481b-a3e4-37f590829ffb", "3d64c474-7ee1-478d-b36a-1ac9dbe84284", "Зарегистрированный клиент", "ЗАРЕГИСТРИРОВАННЫЙ КЛИЕНТ" },
                    { "8053677a-6150-40c6-986f-70ec9f9d1bf4", "48816bf3-2ed4-4a6d-aed9-7703a86cb453", "Владелец сети", "ВЛАДЕЛЕЦ СЕТИ" },
                    { "80f84687-4f41-44ae-9649-1704e38414d8", "ff381d31-11a0-4de7-b28f-ddd8167c09d8", "Сотрудник рецепции", "СОТРУДНИК РЕЦЕПЦИИ" },
                    { "916d57ba-e7da-41a0-ad92-6da9d16970e5", "08b27bd5-4375-41f6-9b73-ff751454cd2e", "Горничные", "ГОРНИЧНЫЕ" },
                    { "b6131b4f-49ee-4bfb-a8fa-74ff1ff39300", "1e697b90-75c3-4c49-b6c1-c388d972facb", "Повар в отеле", "ПОВАР В ОТЕЛЕ" },
                    { "ca7f9b07-fb52-4415-9c72-3fe57330491a", "d8036965-224d-4e50-82bc-7b9c2041079b", "Директор", "ДИРЕКТОР" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "6e657972-3eb9-481b-a3e4-37f590829ffb");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "8053677a-6150-40c6-986f-70ec9f9d1bf4");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "80f84687-4f41-44ae-9649-1704e38414d8");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "916d57ba-e7da-41a0-ad92-6da9d16970e5");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "b6131b4f-49ee-4bfb-a8fa-74ff1ff39300");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "ca7f9b07-fb52-4415-9c72-3fe57330491a");

            migrationBuilder.DropColumn(
                name: "price",
                table: "dish");

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
        }
    }
}
