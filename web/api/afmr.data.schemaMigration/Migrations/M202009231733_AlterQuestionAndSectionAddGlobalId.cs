using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202009231733, TransactionBehavior.None)]
	public class M202009231733_AlterQuestionAndSectionAddGlobalId : Migration
	{
		private string Section = "TemplateSection";
		private string Question = "SectionQuestion";
		private string GlobalId = "GlobalId";

		public override void Up()
		{
			Alter.Table(Section).AddColumn(GlobalId).AsString(36).Nullable();
			Alter.Table(Question).AddColumn(GlobalId).AsString(36).Nullable();
		}

		public override void Down()
		{
			Delete.Column(GlobalId).FromTable(Section);
			Delete.Column(GlobalId).FromTable(Question);
		}
	}
}
