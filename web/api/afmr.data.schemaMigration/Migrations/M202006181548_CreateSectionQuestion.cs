using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006181548, TransactionBehavior.None)]
	public class M202006181548_CreateSectionQuestion : Migration
	{
		private string _tableName = "SectionQuestion";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("SectionId").AsInt32().NotNullable().ForeignKey("Section", "Id")
				.WithColumn("QuestionId").AsInt32().ForeignKey("Question", "Id")
				.WithColumn("OrderIndex").AsInt32();
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
