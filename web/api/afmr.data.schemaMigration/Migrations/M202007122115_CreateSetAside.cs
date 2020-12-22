using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007122115, TransactionBehavior.None)]
	public class M202007122115_CreateSetAside : Migration
	{
		private string _tableName = "SetAside";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
				.WithColumn("Name").AsString(64).NotNullable()
				.WithColumn("Description").AsString(2048).NotNullable();
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
