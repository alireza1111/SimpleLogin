using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginEntityFramework.Migrations
{
    public partial class AddSpLoginFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "users",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.Sql(@"CREATE OR REPLACE FUNCTION sp_login(varchar(100), varchar(100)) RETURNS integer
as $$
begin
   return (select count(1) FROM users WHERE name = $1 and password = $2);
commit;
end; 
$$ LANGUAGE plpgsql;");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "users");
        }
    }
}
