using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Tags(Tags.DevTag)]
	[Migration(202006301312, TransactionBehavior.None)]
	public class M202006301312_DeleteSectionData : Migration
	{
		public override void Up()
		{
			Delete.FromTable("TemplateSection").AllRows();
			Delete.FromTable("SectionQuestion").AllRows();
			Delete.FromTable("Question").AllRows();
			Delete.FromTable("Section").AllRows();
			Delete.FromTable("TemplateSectionGroup").AllRows();
			Update.Table("Template").Set(new {Name = "AFMC MP5327.9001", Description= "Product/Service Market Research Report" }).Where(new { Name = "Template 1 Name" });
			}

		public override void Down()
		{
		}
	}
}
