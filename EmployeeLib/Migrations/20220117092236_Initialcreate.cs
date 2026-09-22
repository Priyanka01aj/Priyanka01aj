using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeLib.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Country_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Country_Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    State_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country_Id = table.Column<int>(type: "int", nullable: false),
                    Country_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.State_Id);
                    table.ForeignKey(
                        name: "FK_State_Country_Country_Id1",
                        column: x => x.Country_Id1,
                        principalTable: "Country",
                        principalColumn: "Country_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    City_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.City_Id);
                    table.ForeignKey(
                        name: "FK_City_State_State_Id1",
                        column: x => x.State_Id1,
                        principalTable: "State",
                        principalColumn: "State_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_State_Id1",
                table: "City",
                column: "State_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_State_Country_Id1",
                table: "State",
                column: "Country_Id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
