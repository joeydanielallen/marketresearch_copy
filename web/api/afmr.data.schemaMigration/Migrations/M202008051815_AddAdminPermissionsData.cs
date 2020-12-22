using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202008051815, TransactionBehavior.None)]
	public class M202008051815_AddAdminPermissionsData : Migration
	{
		public override void Up()
		{
			Insert.IntoTable("PermissionClaim")
				.Row(new { PermissionClaimId = 8,  ClaimName = "Manage Users"})
				.Row(new { PermissionClaimId = 9,  ClaimName = "Manage Roles"})
				.Row(new { PermissionClaimId = 10, ClaimName = "Manage Form Templates"})
				.Row(new { PermissionClaimId = 11, ClaimName = "Manage Configurations"})
				.Row(new { PermissionClaimId = 12, ClaimName = "Manage Organizations" });

			Execute.Sql(upSql);

		}

		public override void Down()
		{
			Execute.Sql(downSql);

			Delete.FromTable("PermissionClaim")
				.Row(new { PermissionClaimId = 8 })
				.Row(new { PermissionClaimId = 9 })
				.Row(new { PermissionClaimId = 10 })
				.Row(new { PermissionClaimId = 11 })
				.Row(new { PermissionClaimId = 12 });
		}

		private string upSql = @"
  declare @adminRoleId int
  select top 1 @adminRoleId = AppRoleId from AppRole where AppRoleName = 'Admin'

  insert into RoleClaim
  select @adminRoleId, 8
  union all select @adminRoleId, 9
  union all select @adminRoleId, 10
  union all select @adminRoleId, 11
  union all select @adminRoleId, 12";

		private string downSql = @"
delete from RoleClaim where PermissionClaimId in (8,9,10,11,12)
";
	}
}
