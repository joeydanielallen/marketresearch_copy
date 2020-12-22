using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202008140951, TransactionBehavior.None)]
	public class M202008140951_CreateLog : Migration
	{
		private string _tableName = "Log";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Message").AsString(int.MaxValue).Nullable()
				.WithColumn("MessageTemplate").AsString(int.MaxValue).Nullable()
				.WithColumn("Level").AsString(128).Nullable()
				.WithColumn("TimeStamp").AsDateTimeOffset(7).NotNullable()
				.WithColumn("Exception").AsString(int.MaxValue).Nullable()
				.WithColumn("Properties").AsXml().Nullable()
				.WithColumn("LogEvent").AsString(int.MaxValue).Nullable();
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
