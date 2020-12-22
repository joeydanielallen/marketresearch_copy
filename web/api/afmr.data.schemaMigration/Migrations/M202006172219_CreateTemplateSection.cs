using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006172219, TransactionBehavior.None)]
	public class M202006172219_CreateTemplateSection : Migration
	{
		private string _tableName = "TemplateSection";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("TemplateId").AsInt32().NotNullable().ForeignKey("Template", "Id")
				.WithColumn("SectionId").AsInt32().NotNullable().ForeignKey("Section", "Id")
				.WithColumn("TemplateSectionGroupId").AsInt32().Nullable().ForeignKey("TemplateSectionGroup", "Id")
				.WithColumn("OrderIndex").AsInt32();
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
