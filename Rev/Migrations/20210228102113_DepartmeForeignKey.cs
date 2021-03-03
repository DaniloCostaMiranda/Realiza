using Microsoft.EntityFrameworkCore.Migrations;

namespace Rev.Migrations
{
    public partial class DepartmeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Department_DepartmentId",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Tipo_TipoId",
                table: "Registro");

            migrationBuilder.AlterColumn<int>(
                name: "TipoId",
                table: "Registro",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Registro",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Department_DepartmentId",
                table: "Registro",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Tipo_TipoId",
                table: "Registro",
                column: "TipoId",
                principalTable: "Tipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Department_DepartmentId",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Tipo_TipoId",
                table: "Registro");

            migrationBuilder.AlterColumn<int>(
                name: "TipoId",
                table: "Registro",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Registro",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Department_DepartmentId",
                table: "Registro",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Tipo_TipoId",
                table: "Registro",
                column: "TipoId",
                principalTable: "Tipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
