using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoApp.PhotoAPI.Migrations
{
    public partial class IlkDbOlusturma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firmalar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    FirmaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmalar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciTipler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciTipler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    FirmaID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciTipID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Firmalar_FirmaID",
                        column: x => x.FirmaID,
                        principalTable: "Firmalar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_KullaniciTipler_KullaniciTipID",
                        column: x => x.KullaniciTipID,
                        principalTable: "KullaniciTipler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FirmaID",
                table: "Users",
                column: "FirmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_KullaniciTipID",
                table: "Users",
                column: "KullaniciTipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Firmalar");

            migrationBuilder.DropTable(
                name: "KullaniciTipler");
        }
    }
}
