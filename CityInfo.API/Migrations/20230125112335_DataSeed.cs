using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.API.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Stolica", "Warszawa" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Piękne miasto położone nad morzem", "Gdanśk" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Miasto Królów Polskich", "Kraków" });

            migrationBuilder.InsertData(
                table: "PointsOfIntrest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 1, 2, "Najokazalsza i najcenniejsza budowla świecka dawnego Gdańska, siedziba władz miasta. Budowany był od 1379 do 1492 roku.", "Ratusz Głównego Miasta" });

            migrationBuilder.InsertData(
                table: "PointsOfIntrest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 2, 2, "Przez wiele lat był jednym z najwspanialszych tego typu obiektów w Europie północnej.", "Dwór Artusa" });

            migrationBuilder.InsertData(
                table: "PointsOfIntrest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 3, 3, "Słynna bazylika z dwiema wieżami", "Bazylika Mariacka" });

            migrationBuilder.InsertData(
                table: "PointsOfIntrest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 4, 3, "średniowieczny zamek królewski", "Zamek królewski na wawelu" });

            migrationBuilder.InsertData(
                table: "PointsOfIntrest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 5, 2, "to jeden z najpiękniejszych kompleksów ogrodowych nie tylko w Polsce, ale i w Europie ", "Łazienki Królewskie" });

            migrationBuilder.InsertData(
                table: "PointsOfIntrest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 6, 2, "To tak naprawdę wizytówka stolicy i najwyższy budynek w Polsce (ma 237 m wysokości) ", "Pałac Kultury i Nauki" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointsOfIntrest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointsOfIntrest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointsOfIntrest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointsOfIntrest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointsOfIntrest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointsOfIntrest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
