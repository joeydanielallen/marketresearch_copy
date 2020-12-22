using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006181552, TransactionBehavior.None)]
	public class M202006181552_CreateCustomSelectAnswer : Migration
	{
		private string _tableName = "CustomSelectAnswer";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("QuestionId").AsInt32().ForeignKey("Question", "Id")
				.WithColumn("Name").AsString(64).NotNullable()
				.WithColumn("Description").AsString(256)
				.WithColumn("OrderIndex").AsInt32();
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
