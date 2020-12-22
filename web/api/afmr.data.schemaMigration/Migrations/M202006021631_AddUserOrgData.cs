using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Tags(Tags.DevTag)]
	[Migration(202006021631, TransactionBehavior.None)]
	public class M202006021631_AddUserOrgData : Migration
	{
		public override void Up()
		{
			Execute.Sql(insertSql);
		}

		public override void Down()
		{
			Delete.FromTable("UserOrg").AllRows();
		}

		private string insertSql = @"
insert into UserOrg
select (select UserAccountId from UserAccount where Email = 'support@email.com'), (select Id from Org where Name = '421st')
union all select (select UserAccountId from UserAccount where Email = 'support@email.com'), (select Id from Org where Name = '422nd')
";
	}
}
