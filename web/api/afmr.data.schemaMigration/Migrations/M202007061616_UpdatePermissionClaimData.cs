using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007061616, TransactionBehavior.None)]
	public class M202007061616_UpdatePermissionClaimData : Migration
	{
		public override void Up()
		{
			Delete.ForeignKey().FromTable("RoleClaim").ForeignColumn("PermissionClaimId").ToTable("PermissionClaim").PrimaryColumn("PermissionClaimId");

			Update.Table("PermissionClaim")
				.Set(new { PermissionClaimId = 7 }).Where(new { PermissionClaimId = 6 });

			Update.Table("RoleClaim")
				.Set(new { PermissionClaimId = 7 }).Where(new { PermissionClaimId = 6 });

			Update.Table("PermissionClaim")
				.Set(new { PermissionClaimId = 6 }).Where(new { PermissionClaimId = 5 });

			Update.Table("RoleClaim")
				.Set(new { PermissionClaimId = 6 }).Where(new { PermissionClaimId = 5 });

			Update.Table("PermissionClaim")
				.Set(new { PermissionClaimId = 5 }).Where(new { PermissionClaimId = 4 });

			Update.Table("RoleClaim")
				.Set(new { PermissionClaimId = 5 }).Where(new { PermissionClaimId = 4 });

			Create.ForeignKey().FromTable("RoleClaim").ForeignColumn("PermissionClaimId").ToTable("PermissionClaim").PrimaryColumn("PermissionClaimId");

		}

		public override void Down()
		{
		}
	}
}
