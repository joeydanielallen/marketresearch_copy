using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006181543, TransactionBehavior.None)]
	public class M202006181543_CreateQuestionType : Migration
	{
		private string _tableName = "QuestionType";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
				.WithColumn("Name").AsString(64).NotNullable()
				.WithColumn("Description").AsString(256)
				.WithColumn("HasMultipleSelection").AsBoolean().NotNullable().WithDefaultValue(0);
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
