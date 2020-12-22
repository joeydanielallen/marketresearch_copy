using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006021610, TransactionBehavior.None)]
	public class M202006021610_CreateOrg : Migration
	{

		public override void Up()
		{
			Create.Table("Org")
				.WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
				.WithColumn("Name").AsString(128).NotNullable()
				.WithColumn("Description").AsString(1024);
		}

		public override void Down()
		{
			Delete.Table("Org");
		}
	}
}
