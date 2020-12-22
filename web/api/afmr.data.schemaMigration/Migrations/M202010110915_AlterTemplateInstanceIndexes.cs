using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202010110915, TransactionBehavior.None)]
	public class M202010110915_AlterTemplateInstanceIndexes : Migration
	{
		public override void Up()
		{
			Create.Index("IX_TemplateInstanceUser_TemplateInstanceId").OnTable("TemplateInstanceUser").OnColumn("TemplateInstanceId");
			Create.Index("IX_TemplateInstanceAnswer_TemplateInstanceId").OnTable("TemplateInstanceAnswer").OnColumn("TemplateInstanceId");
			Create.Index("IX_TemplateInstanceAnswer_TemplateSectionId").OnTable("TemplateInstanceAnswer").OnColumn("TemplateSectionId");
			Create.Index("IX_TemplateInstanceAnswer_SectionQuestionId").OnTable("TemplateInstanceAnswer").OnColumn("SectionQuestionId");
			Create.Index("IX_TemplateSection_TemplateId").OnTable("TemplateSection").OnColumn("TemplateId");
			Create.Index("IX_TemplateSection_SectionId").OnTable("TemplateSection").OnColumn("SectionId");
			Create.Index("IX_SectionQuestion_SectionId").OnTable("SectionQuestion").OnColumn("SectionId");
			Create.Index("IX_SectionQuestion_QuestionId").OnTable("SectionQuestion").OnColumn("QuestionId");
		}

		public override void Down()
		{
			Delete.Index("IX_SectionQuestion_QuestionId").OnTable("SectionQuestion").OnColumn("QuestionId");
			Delete.Index("IX_SectionQuestion_SectionId").OnTable("SectionQuestion").OnColumn("SectionId");
			Delete.Index("IX_TemplateSection_SectionId").OnTable("TemplateSection").OnColumn("SectionId");
			Delete.Index("IX_TemplateSection_TemplateId").OnTable("TemplateSection").OnColumn("TemplateId");
			Delete.Index("IX_TemplateInstanceAnswer_SectionQuestionId").OnTable("TemplateInstanceAnswer").OnColumn("SectionQuestionId");
			Delete.Index("IX_TemplateInstanceAnswer_TemplateSectionId").OnTable("TemplateInstanceAnswer").OnColumn("TemplateSectionId");
			Delete.Index("IX_TemplateInstanceAnswer_TemplateInstanceId").OnTable("TemplateInstanceAnswer").OnColumn("TemplateInstanceId");
			Delete.Index("IX_TemplateInstanceUser_TemplateInstanceId").OnTable("TemplateInstanceUser").OnColumn("TemplateInstanceId");
		}
	}
}
