using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007032125, TransactionBehavior.None)]
	public class M202007032125_RemoveUserAccountAppKeyConstraint : Migration
	{
		public override void Up()
		{
			//Alter.Table("UserAccount").AlterColumn("AppKey").AsString(128).Nullable();
			Delete.Index().OnTable("UserAccount").OnColumn("AppKey");
		}

		public override void Down()
		{
		}
	}
}
