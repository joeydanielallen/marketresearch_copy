using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006172200, TransactionBehavior.None)]
	public class M202006172200_CreateSection : Migration
	{
		private string _tableName = "Section";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Name").AsString(64).NotNullable()
				.WithColumn("Description").AsString(256);
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
