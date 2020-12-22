using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202005061736, TransactionBehavior.None)]
	public class M202005061736_CreatePermissionDevData : Migration
	{
		public override void Up()
		{
			Execute.Sql(@"
insert into AppRole select 'Admin'
declare @AdminId int = @@Identity

insert into PermissionClaim 
	select 4, 'ViewMarketResearch'
union all select 5, 'InitiateMarketResearch'

insert into RoleClaim
	select @AdminId, 4
union all select @AdminId, 5

insert into UserRole select @AdminId, (select top 1 UserAccountId from UserAccount where Email='support@email.com')");
		}

		public override void Down()
		{
			Execute.Sql(@"
delete from UserRole where UserAccountId = (select top 1 UserAccountId from UserAccount where Email='support@email.com')
delete from RoleClaim where PermissionClaimId in (4, 5)
delete from PermissionClaim where PermissionClaimId in (4, 5)
delete from AppRole where AppRoleName = 'Admin'");
		}
	}
}
