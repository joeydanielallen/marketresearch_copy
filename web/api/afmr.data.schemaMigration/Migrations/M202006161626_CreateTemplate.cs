using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006161626, TransactionBehavior.None)]
	public class M202006161626_CreateTemplate : Migration
	{
		private string _tableName = "Template";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
				.WithColumn("Name").AsString(128).NotNullable()
				.WithColumn("Description").AsString(1024)
				.WithColumn("MinEstimatedValue").AsDecimal(11, 2).NotNullable()
				.WithColumn("MaxEstimatedValue").AsDecimal(11, 2).NotNullable()
				.WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(1);
	}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
