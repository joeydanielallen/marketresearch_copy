using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006151658, TransactionBehavior.None)]
	public class M202006151658_CreateServiceType : Migration
	{
		private string _tableName = "ServiceType";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
				.WithColumn("Name").AsString(128).NotNullable().Unique("UIX_" + _tableName + "_Name");
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
