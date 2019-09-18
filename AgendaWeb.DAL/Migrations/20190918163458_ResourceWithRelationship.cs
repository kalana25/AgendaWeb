using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaWeb.DAL.Migrations
{
    public partial class ResourceWithRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Abbreviation = table.Column<string>(maxLength: 5, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Plannable = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    StyleId = table.Column<int>(nullable: false),
                    CollaboratorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Collaborators_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceResourceProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResourceId = table.Column<int>(nullable: false),
                    ResourceProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceResourceProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceResourceProfiles_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceResourceProfiles_ResourceProfiles_ResourceProfileId",
                        column: x => x.ResourceProfileId,
                        principalTable: "ResourceProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceResourceProfiles_ResourceId",
                table: "ResourceResourceProfiles",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceResourceProfiles_ResourceProfileId",
                table: "ResourceResourceProfiles",
                column: "ResourceProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_CollaboratorId",
                table: "Resources",
                column: "CollaboratorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_StyleId",
                table: "Resources",
                column: "StyleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceResourceProfiles");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
