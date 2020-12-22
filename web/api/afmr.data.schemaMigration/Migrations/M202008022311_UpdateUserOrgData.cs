using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202008022311, TransactionBehavior.None)]
	public class M202008022311_UpdateUserOrgData : Migration
	{
		public override void Up()
		{
			Execute.Sql(sql);
		}

		public override void Down()
		{
		}

		private string sql = @"
  update UserOrg
  set OrgId = (select top 1 Id from Org where Name = '421st')
  where UserAccountId = (select top 1 UserAccountId from UserAccount where Email = 'engineer421@email.com')

  
  update UserOrg
  set OrgId = (select top 1 Id from Org where Name = '422nd')
  where UserAccountId = (select top 1 UserAccountId from UserAccount where Email = 'loggie422@email.com')";
	}
}
