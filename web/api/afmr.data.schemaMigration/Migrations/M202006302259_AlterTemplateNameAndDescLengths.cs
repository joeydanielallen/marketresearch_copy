using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006302259, TransactionBehavior.None)]
	public class M202006302259_AlterTemplateNameAndDescLengths : Migration
	{
		public override void Up()
		{
			Alter.Column("Name").OnTable("Question").AsString(2048).NotNullable();
			Alter.Column("Description").OnTable("Question").AsString(4096).NotNullable();
			Alter.Column("Name").OnTable("Section").AsString(2048).NotNullable();
			Alter.Column("Description").OnTable("Section").AsString(4096).NotNullable();
			Alter.Column("Name").OnTable("TemplateSectionGroup").AsString(2048).NotNullable();
			Alter.Column("Description").OnTable("TemplateSectionGroup").AsString(4096).NotNullable();
			Alter.Column("Name").OnTable("CustomSelectAnswer").AsString(1024).NotNullable();
			Alter.Column("Description").OnTable("CustomSelectAnswer").AsString(4096).NotNullable();
		}

		public override void Down()
		{
		}
	}
}
