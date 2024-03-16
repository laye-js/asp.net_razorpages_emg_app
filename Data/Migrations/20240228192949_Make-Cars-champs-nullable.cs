using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMG.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeCarschampsnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Finitions_FinitionId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Marques_MarqueId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Modeles_ModeleId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ModeleId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MarqueId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FinitionId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Année",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Finitions_FinitionId",
                table: "Cars",
                column: "FinitionId",
                principalTable: "Finitions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Marques_MarqueId",
                table: "Cars",
                column: "MarqueId",
                principalTable: "Marques",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Modeles_ModeleId",
                table: "Cars",
                column: "ModeleId",
                principalTable: "Modeles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Finitions_FinitionId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Marques_MarqueId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Modeles_ModeleId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModeleId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MarqueId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FinitionId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Année",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Finitions_FinitionId",
                table: "Cars",
                column: "FinitionId",
                principalTable: "Finitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Marques_MarqueId",
                table: "Cars",
                column: "MarqueId",
                principalTable: "Marques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Modeles_ModeleId",
                table: "Cars",
                column: "ModeleId",
                principalTable: "Modeles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
