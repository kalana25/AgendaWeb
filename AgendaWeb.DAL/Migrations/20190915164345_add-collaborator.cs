using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaWeb.DAL.Migrations
{
    public partial class addcollaborator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collaborators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FristName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    OtherNames = table.Column<string>(maxLength: 250, nullable: true),
                    NIC = table.Column<string>(maxLength: 12, nullable: true),
                    RegistrationNo = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    CommunicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collaborators_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collaborators_Communications_CommunicationId",
                        column: x => x.CommunicationId,
                        principalTable: "Communications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborators_AddressId",
                table: "Collaborators",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborators_CommunicationId",
                table: "Collaborators",
                column: "CommunicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaborators");
        }
    }
}
