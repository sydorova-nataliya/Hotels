using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hotelcourseworkV2.Migrations
{
    /// <inheritdoc />
    public partial class add_failde_hotel_room_status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "16b4b03a-b62a-46bb-9383-268cd00e4a5b");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "24188499-3190-4f85-8c21-4f22cb4a92e0");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "79a023bf-a795-4ec5-a015-d5cbeab6665c");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "984b49c8-939a-4116-870d-2e04bac669bf");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "b91c6f61-78d2-46dc-9548-6694c13be1ca");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "f2abaa1c-bb95-42fd-93ba-cab81a58d901");

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "hotel_type_room",
                type: "boolean",
                nullable: true);

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0400162f-0a32-4f4a-aedf-facb6832669d", "b9e639f8-37c5-435b-971d-1820d633f2cd", "Владелец сети", "ВЛАДЕЛЕЦ СЕТИ" },
                    { "334d710d-d882-497e-ab44-76d010990372", "f7dd09ea-872d-4e49-8441-c7231c15c879", "Горничные", "ГОРНИЧНЫЕ" },
                    { "364f2788-9521-45e1-a794-1b60ad67006d", "626ce8c6-3c91-46c5-86f5-eb9468436cea", "Повар в отеле", "ПОВАР В ОТЕЛЕ" },
                    { "6499e821-52a1-4ea4-a1c9-782325e9d460", "7326589b-b1cc-4015-8abc-986c9a1f4ccb", "Директор", "ДИРЕКТОР" },
                    { "796393d6-2b79-4931-a5e8-6cac408cd1c9", "dd36d454-6477-4a05-a8f3-3626fcad25e9", "Сотрудник рецепции", "СОТРУДНИК РЕЦЕПЦИИ" },
                    { "bca04317-ec92-4d5a-96b2-9816c6720570", "2111abe1-c2ca-4b67-9876-0947489e6989", "Зарегистрированный клиент", "ЗАРЕГИСТРИРОВАННЫЙ КЛИЕНТ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "0400162f-0a32-4f4a-aedf-facb6832669d");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "334d710d-d882-497e-ab44-76d010990372");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "364f2788-9521-45e1-a794-1b60ad67006d");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "6499e821-52a1-4ea4-a1c9-782325e9d460");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "796393d6-2b79-4931-a5e8-6cac408cd1c9");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: "bca04317-ec92-4d5a-96b2-9816c6720570");

            migrationBuilder.DropColumn(
                name: "status",
                table: "hotel_type_room");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16b4b03a-b62a-46bb-9383-268cd00e4a5b", "d2a957af-6a2f-4d87-9101-b38022d12831", "Директор", "ДИРЕКТОР" },
                    { "24188499-3190-4f85-8c21-4f22cb4a92e0", "9b57dea2-5fb8-48b9-afbe-cedd26592468", "Владелец сети", "ВЛАДЕЛЕЦ СЕТИ" },
                    { "79a023bf-a795-4ec5-a015-d5cbeab6665c", "90c2077a-f093-4f8c-a933-0fe35a6aeba9", "Горничные", "ГОРНИЧНЫЕ" },
                    { "984b49c8-939a-4116-870d-2e04bac669bf", "82f351a6-ae84-47f9-abe3-50b80d7fa604", "Зарегистрированный клиент", "ЗАРЕГИСТРИРОВАННЫЙ КЛИЕНТ" },
                    { "b91c6f61-78d2-46dc-9548-6694c13be1ca", "91b5082a-dd77-4770-9241-87984f4adef0", "Сотрудник рецепции", "СОТРУДНИК РЕЦЕПЦИИ" },
                    { "f2abaa1c-bb95-42fd-93ba-cab81a58d901", "a87d5868-f7db-4741-8b2e-7c7b306686bf", "Повар в отеле", "ПОВАР В ОТЕЛЕ" }
                });
        }
    }
}
