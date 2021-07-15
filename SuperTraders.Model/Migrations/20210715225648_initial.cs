using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SuperTraders.Model.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Symbol = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(2)", precision: 2, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Created_by = table.Column<int>(type: "integer", nullable: false),
                    Created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modified_by = table.Column<int>(type: "integer", nullable: false),
                    Modified_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted_by = table.Column<int>(type: "integer", nullable: false),
                    Deleted_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Created_by = table.Column<int>(type: "integer", nullable: false),
                    Created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modified_by = table.Column<int>(type: "integer", nullable: false),
                    Modified_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted_by = table.Column<int>(type: "integer", nullable: false),
                    Deleted_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradingTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(2)", precision: 2, nullable: false),
                    Result = table.Column<int>(type: "integer", nullable: false),
                    ResultMessage = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    User_id = table.Column<int>(type: "integer", nullable: false),
                    ShareId = table.Column<int>(type: "integer", nullable: true),
                    Share_id = table.Column<int>(type: "integer", nullable: false),
                    Created_by = table.Column<int>(type: "integer", nullable: false),
                    Created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modified_by = table.Column<int>(type: "integer", nullable: false),
                    Modified_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted_by = table.Column<int>(type: "integer", nullable: false),
                    Deleted_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradingTransactions_Shares_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Shares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TradingTransactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserShares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(2)", precision: 2, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    User_id = table.Column<int>(type: "integer", nullable: false),
                    ShareId = table.Column<int>(type: "integer", nullable: true),
                    Share_id = table.Column<int>(type: "integer", nullable: false),
                    Created_by = table.Column<int>(type: "integer", nullable: false),
                    Created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modified_by = table.Column<int>(type: "integer", nullable: false),
                    Modified_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted_by = table.Column<int>(type: "integer", nullable: false),
                    Deleted_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserShares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserShares_Shares_ShareId",
                        column: x => x.ShareId,
                        principalTable: "Shares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserShares_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TradingTransactions_ShareId",
                table: "TradingTransactions",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_TradingTransactions_UserId",
                table: "TradingTransactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserShares_ShareId",
                table: "UserShares",
                column: "ShareId");

            migrationBuilder.CreateIndex(
                name: "IX_UserShares_UserId",
                table: "UserShares",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradingTransactions");

            migrationBuilder.DropTable(
                name: "UserShares");

            migrationBuilder.DropTable(
                name: "Shares");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
