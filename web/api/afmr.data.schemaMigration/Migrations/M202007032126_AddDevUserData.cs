using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Tags(Tags.DevTag)]
	[Migration(202007032126, TransactionBehavior.None)]
	public class M202007032126_AddDevUserData : Migration
	{
		public override void Up()
		{
			Insert.IntoTable("AppRole")
				.Row(new
				{
					AppRoleName = "Logistician"
				})
				.Row(new
				{
					AppRoleName = "Engineer"
				});

			Insert.IntoTable("UserAccount")
				.Row(new
				{
					Email = "loggie421@email.com",
					ExpiresOnUtc = System.DateTime.UtcNow.AddDays(180),
					UserName = "loggie421@email.com",
					PasswordHash = "Gx+JN1Vif7dGfvk7QtMgJQWARtThNGda9VWK/x++1nHtoWqVSiNgntq+W0biWFKwQNE9FakQgtV08iBiFR/IbWwAbwBnAGcAaQBlADQAMgAxAEAAZQBtAGEAaQBsAC4AYwBvAG0A",
					FirstName = "Loggie",
					LastName = "421"
				})
				.Row(new
				{
					Email = "engineer421@email.com",
					ExpiresOnUtc = System.DateTime.UtcNow.AddDays(180),
					UserName = "engineer421@email.com",
					PasswordHash = "IK7QGmGoX/QiLe12/L3GQzf+GG/FbSvF1lva2ZnlkC4j3C1wmCnzVoTc/bK1JL2tpL0scbM9/wM4fbnanCz80mUAbgBnAGkAbgBlAGUAcgA0ADIAMQBAAGUAbQBhAGkAbAAuAGMAbwBtAA==",
					FirstName = "Egineer",
					LastName = "421"
				})
				.Row(new
				{
					Email = "loggie422@email.com",
					ExpiresOnUtc = System.DateTime.UtcNow.AddDays(180),
					UserName = "loggie422@email.com",
					PasswordHash = "t+fVXVa1mAoUCjIVd8J8GIzGKDEEvyURFe74Ee4wHmD+1v++h+r0o85XCRIE7uFkBq27UMY1LPvYqcniwkYzqmwAbwBnAGcAaQBlADQAMgAyAEAAZQBtAGEAaQBsAC4AYwBvAG0A",
					FirstName = "Loggie",
					LastName = "422"
				})
				.Row(new
				{
					Email = "engineer422@email.com",
					ExpiresOnUtc = System.DateTime.UtcNow.AddDays(180),
					UserName = "engineer422@email.com",
					PasswordHash = "SX2QE000joE27G0NxNkr0+pwnlhuP7QIlvTtQC2l9/iFxsJr/SBti8yn4NK7a/yxZ+1CwuHwEcHmzXqvEDWDlGUAbgBnAGkAbgBlAGUAcgA0ADIAMgBAAGUAbQBhAGkAbAAuAGMAbwBtAA==",
					FirstName = "Engineer",
					LastName = "422"
				});


			Execute.Sql(sql);
		}

		public override void Down()
		{
		}

		private readonly string sql = @"
insert into UserOrg
		select (select UserAccountId from UserAccount where Email = 'loggie421@email.com'), (select Id from Org where Name = '421st')
union all select (select UserAccountId from UserAccount where Email = 'engineer421@email.com'), (select Id from Org where Name = '422nd')
union all select (select UserAccountId from UserAccount where Email = 'loggie422@email.com'), (select Id from Org where Name = '421st')
union all select (select UserAccountId from UserAccount where Email = 'engineer422@email.com'), (select Id from Org where Name = '422nd')

insert into UserRole
		select (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician'), (select top 1 UserAccountId from UserAccount where Email like 'loggie421%')
union all select (select top 1 AppRoleId from AppRole where AppRoleName = 'Logistician'), (select top 1 UserAccountId from UserAccount where Email like 'loggie422%')
union all select (select top 1 AppRoleId from AppRole where AppRoleName = 'Engineer'), (select top 1 UserAccountId from UserAccount where Email like 'engineer421%')
union all select (select top 1 AppRoleId from AppRole where AppRoleName = 'Engineer'), (select top 1 UserAccountId from UserAccount where Email like 'engineer422%')

insert into RoleClaim
		select (select top 1 AppRoleId from AppRole where AppRoleName='Logistician'), (select top 1 PermissionClaimId from PErmissionClaim where ClaimName = 'InitiateMarketResearch')
union all select (select top 1 AppRoleId from AppRole where AppRoleName='Engineer'), (select top 1 PermissionClaimId from PErmissionClaim where ClaimName = 'ViewMarketResearch')
";
	}
}
