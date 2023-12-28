using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesOrderDataManager.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SalesOrders",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("5b32effd-2636-4cab-8ac9-3258c746aa53"), "California Hotel AJK", "CA" },
                    { new Guid("5eca5808-4f44-4c4c-b481-72d2bdf24203"), "New York Building 1", "NY" }
                });

            migrationBuilder.InsertData(
                table: "Windows",
                columns: new[] { "Id", "Name", "OrderId", "QuantityOfWindows", "TotalSubElements" },
                values: new object[,]
                {
                    { new Guid("4ffa6173-bc0b-4d3b-9a68-65227dd1bc8b"), "C Zone 5", new Guid("5eca5808-4f44-4c4c-b481-72d2bdf24203"), 2, 1 },
                    { new Guid("5eca5808-4f44-4c4c-b481-72d2bdf24203"), "A51", new Guid("5eca5808-4f44-4c4c-b481-72d2bdf24203"), 4, 3 },
                    { new Guid("5eca5808-545a-4c4c-b481-72d2bdf24203"), "GLB", new Guid("5b32effd-2636-4cab-8ac9-3258c746aa53"), 3, 2 },
                    { new Guid("6eca5808-4f44-4c4c-b481-72d2bdf24203"), "OHF", new Guid("5b32effd-2636-4cab-8ac9-3258c746aa53"), 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "SubElements",
                columns: new[] { "Id", "Element", "Height", "Type", "Width", "WindowId" },
                values: new object[,]
                {
                    { new Guid("03027fbc-d76e-41cb-873b-c79bdde5f7d2"), "2", 1850, "Window", 800, new Guid("5eca5808-4f44-4c4c-b481-72d2bdf24203") },
                    { new Guid("32bccc93-e4ac-450f-82de-b521941c0640"), "1", 1850, "Doors", 1200, new Guid("5eca5808-4f44-4c4c-b481-72d2bdf24203") },
                    { new Guid("49b11a88-762d-429e-ac8f-9ef1ff4c012b"), "1", 2000, "Window", 1500, new Guid("4ffa6173-bc0b-4d3b-9a68-65227dd1bc8b") },
                    { new Guid("607a7e2b-25c2-478d-9d74-2cd17db2cebe"), "1", 2200, "Doors", 1400, new Guid("5eca5808-545a-4c4c-b481-72d2bdf24203") },
                    { new Guid("69d727b9-852f-4018-b1eb-acc16a37034d"), "3", 1850, "Window", 700, new Guid("5eca5808-4f44-4c4c-b481-72d2bdf24203") },
                    { new Guid("79265336-bfd2-41eb-873c-eb34616cbd71"), "1", 2000, "Window", 1500, new Guid("6eca5808-4f44-4c4c-b481-72d2bdf24203") },
                    { new Guid("a3cc6050-04f4-4e1a-9292-31fc05b26293"), "2", 2200, "Window", 600, new Guid("5eca5808-545a-4c4c-b481-72d2bdf24203") },
                    { new Guid("e467b989-ea10-4541-8d39-43e1e87f03a9"), "1", 2000, "Window", 1500, new Guid("6eca5808-4f44-4c4c-b481-72d2bdf24203") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubElements",
                keyColumn: "Id",
                keyValue: new Guid("03027fbc-d76e-41cb-873b-c79bdde5f7d2"));

            migrationBuilder.DeleteData(
                table: "SubElements",
                keyColumn: "Id",
                keyValue: new Guid("32bccc93-e4ac-450f-82de-b521941c0640"));

            migrationBuilder.DeleteData(
                table: "SubElements",
                keyColumn: "Id",
                keyValue: new Guid("49b11a88-762d-429e-ac8f-9ef1ff4c012b"));

            migrationBuilder.DeleteData(
                table: "SubElements",
                keyColumn: "Id",
                keyValue: new Guid("607a7e2b-25c2-478d-9d74-2cd17db2cebe"));

            migrationBuilder.DeleteData(
                table: "SubElements",
                keyColumn: "Id",
                keyValue: new Guid("69d727b9-852f-4018-b1eb-acc16a37034d"));

            migrationBuilder.DeleteData(
                table: "SubElements",
                keyColumn: "Id",
                keyValue: new Guid("79265336-bfd2-41eb-873c-eb34616cbd71"));

            migrationBuilder.DeleteData(
                table: "SubElements",
                keyColumn: "Id",
                keyValue: new Guid("a3cc6050-04f4-4e1a-9292-31fc05b26293"));

            migrationBuilder.DeleteData(
                table: "SubElements",
                keyColumn: "Id",
                keyValue: new Guid("e467b989-ea10-4541-8d39-43e1e87f03a9"));

            migrationBuilder.DeleteData(
                table: "Windows",
                keyColumn: "Id",
                keyValue: new Guid("4ffa6173-bc0b-4d3b-9a68-65227dd1bc8b"));

            migrationBuilder.DeleteData(
                table: "Windows",
                keyColumn: "Id",
                keyValue: new Guid("5eca5808-4f44-4c4c-b481-72d2bdf24203"));

            migrationBuilder.DeleteData(
                table: "Windows",
                keyColumn: "Id",
                keyValue: new Guid("5eca5808-545a-4c4c-b481-72d2bdf24203"));

            migrationBuilder.DeleteData(
                table: "Windows",
                keyColumn: "Id",
                keyValue: new Guid("6eca5808-4f44-4c4c-b481-72d2bdf24203"));

            migrationBuilder.DeleteData(
                table: "SalesOrders",
                keyColumn: "Id",
                keyValue: new Guid("5b32effd-2636-4cab-8ac9-3258c746aa53"));

            migrationBuilder.DeleteData(
                table: "SalesOrders",
                keyColumn: "Id",
                keyValue: new Guid("5eca5808-4f44-4c4c-b481-72d2bdf24203"));
        }
    }
}
