using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Tags(Tags.DevTag)]
	[Migration(202007060239, TransactionBehavior.None)]
	public class M202007060239_AddRoleClaimsAndNewClaimData : Migration
	{
		public override void Up()
		{
			Execute.Sql(@"
insert into PermissionClaim select 6, 'StartResearch'

insert into RoleClaim
		select (select top 1 AppRoleId from AppRole where AppRoleName='Logistician'), (select top 1 PermissionClaimId from PermissionClaim where ClaimName = 'ViewMarketResearch')
union all select (select top 1 AppRoleId from AppRole where AppRoleName='Logistician'), (select top 1 PermissionClaimId from PermissionClaim where ClaimName = 'StartResearch')
union all select (select top 1 AppRoleId from AppRole where AppRoleName='Engineer'), (select top 1 PermissionClaimId from PermissionClaim where ClaimName = 'InitiateMarketResearch')
");
		}

		public override void Down()
		{
		}
	}
}
