using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hotelcourseworkV2.Migrations
{
    /// <inheritdoc />
    public partial class update_dish_composition_ingridient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Quantity",
                table: "composition");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "composition");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0620162b-4259-49f5-b8a8-d309f5418362", "d086c706-f409-4bab-b650-3a3afa66aefa", "Горничные", "ГОРНИЧНЫЕ" },
                    { "2ff25d85-3d79-4b23-bbd1-fc15c307114d", "8ebdf565-3af0-4db6-9891-857ced67151e", "Зарегистрированный клиент", "ЗАРЕГИСТРИРОВАННЫЙ КЛИЕНТ" },
                    { "7d108a05-9a7a-4064-b932-69f998001820", "141f2e17-ba37-417c-8ff6-f6f6a5d2d561", "Сотрудник рецепции", "СОТРУДНИК РЕЦЕПЦИИ" },
                    { "8fcaae98-b088-40fc-b265-aa867146c601", "67c1c375-586b-49e4-a486-5af0055aa4ea", "Повар в отеле", "ПОВАР В ОТЕЛЕ" },
                    { "a8847759-04db-4bb1-b08b-9fbc91b23440", "f1cc2b5c-6d3e-4500-8371-3295ce8b0c0c", "Владелец сети", "ВЛАДЕЛЕЦ СЕТИ" },
                    { "d7c943ac-d7bd-43e6-9379-c78e02e9a86a", "5ecfd994-11c0-4d42-8571-1279b88f4234", "Директор", "ДИРЕКТОР" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "0620162b-4259-49f5-b8a8-d309f5418362");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "2ff25d85-3d79-4b23-bbd1-fc15c307114d");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "7d108a05-9a7a-4064-b932-69f998001820");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "8fcaae98-b088-40fc-b265-aa867146c601");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "a8847759-04db-4bb1-b08b-9fbc91b23440");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "d7c943ac-d7bd-43e6-9379-c78e02e9a86a");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "composition",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "composition",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

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
    }
}
