using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hotelcourseworkV2.Migrations
{
    /// <inheritdoc />
    public partial class add_failde_composition_composition_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_composition",
                table: "composition");

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
                name: "copmosition_id",
                table: "composition",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_composition",
                table: "composition",
                column: "copmosition_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_composition_id_dish",
                table: "composition",
                column: "id_dish");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_composition",
                table: "composition");

            migrationBuilder.DropIndex(
                name: "IX_composition_id_dish",
                table: "composition");

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

            migrationBuilder.DropColumn(
                name: "copmosition_id",
                table: "composition");

            migrationBuilder.AddPrimaryKey(
                name: "PK_composition",
                table: "composition",
                column: "id_dish");

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
    }
}
