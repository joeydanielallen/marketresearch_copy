using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007101529, TransactionBehavior.None)]
	public class M202007101529_CreateTemplateInstanceAnswer : Migration
	{
		private string _tableName = "TemplateInstanceAnswer";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("TemplateInstanceId").AsInt32().NotNullable().ForeignKey("TemplateInstance", "Id")
				.WithColumn("TemplateSectionId").AsInt32().NotNullable().ForeignKey("TemplateSection", "Id")
				.WithColumn("SectionQuestionId").AsInt32().NotNullable().ForeignKey("SectionQuestion", "Id")
				.WithColumn("AnswerGroupIndex").AsInt32().Nullable()
				.WithColumn("AnswerValue").AsString(int.MaxValue).Nullable();
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
