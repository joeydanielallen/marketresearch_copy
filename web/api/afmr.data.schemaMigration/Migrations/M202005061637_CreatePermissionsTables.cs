using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202005061637, TransactionBehavior.None)]
	public class M202005061637_CreatePermissionsTables : Migration
	{
		private const string AppRoleName = "AppRole";
		private const string PermissionClaimName = "PermissionClaim";
		private const string RoleClaimName = "RoleClaim";
		private const string UserRoleName = "UserRole";

		public override void Up()
		{
			Create.Table(AppRoleName)
				.WithColumn("AppRoleId").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("AppRoleName").AsString(64).NotNullable().Unique();

			Create.Table(PermissionClaimName)
				.WithColumn("PermissionClaimId").AsInt32().NotNullable().PrimaryKey()
				.WithColumn("ClaimName").AsString(64).NotNullable().Unique();

			Create.Table(RoleClaimName)
				.WithColumn("RoleClaimId").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("AppRoleId").AsInt32().NotNullable().ForeignKey(AppRoleName, "AppRoleId")
				.WithColumn("PermissionClaimId").AsInt32().NotNullable().ForeignKey(PermissionClaimName, "PermissionClaimId");

			Create.Table(UserRoleName)
				.WithColumn("UserRoleId").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("AppRoleId").AsInt32().NotNullable().ForeignKey(AppRoleName, "AppRoleId")
				.WithColumn("UserAccountId").AsInt32().NotNullable().ForeignKey("UserAccount", "UserAccountId");
		}

		public override void Down()
		{
			Delete.Table(UserRoleName);
			Delete.Table(RoleClaimName);
			Delete.Table(PermissionClaimName);
			Delete.Table(AppRoleName);
		}
	}
}
