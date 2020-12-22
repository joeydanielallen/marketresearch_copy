using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006181544, TransactionBehavior.None)]
	public class M202006181544_CreateQuestion : Migration
	{
		private string _tableName = "Question";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("Name").AsString(64).NotNullable()
				.WithColumn("Description").AsString(256)
				.WithColumn("QuestionTypeId").AsInt32().NotNullable().ForeignKey("QuestionType", "Id")
				.WithColumn("MaxLength").AsInt32();
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
