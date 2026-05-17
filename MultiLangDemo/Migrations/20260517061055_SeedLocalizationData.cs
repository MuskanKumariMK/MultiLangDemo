using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MultiLangDemo.Migrations
{
    /// <inheritdoc />
    public partial class SeedLocalizationData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LocalizationResources",
                columns: new[] { "Id", "Culture", "Key", "Value" },
                values: new object[,]
                {
                    { 1, "en", "Welcome", "Welcome to Database Localization" },
                    { 2, "en", "Description", "Dynamic translations loaded from database." },
                    { 3, "hi", "Welcome", "डेटाबेस लोकलाइजेशन में आपका स्वागत है" },
                    { 4, "hi", "Description", "डेटाबेस से डायनामिक ट्रांसलेशन लोड किए गए हैं।" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocalizationResources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LocalizationResources",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LocalizationResources",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LocalizationResources",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
