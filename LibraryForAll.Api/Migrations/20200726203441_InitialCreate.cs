using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryForAll.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "PersonName", "Surname" },
                values: new object[] { 1, "Bakhtiyor", "Esanov" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "PersonName", "Surname" },
                values: new object[] { 2, "Name2", "Surname2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
