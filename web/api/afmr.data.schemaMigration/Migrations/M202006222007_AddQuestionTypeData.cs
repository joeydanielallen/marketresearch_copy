using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006222007, TransactionBehavior.None)]
	public class M202006222007_AddQuestionTypeData : Migration
	{
		public override void Up()
		{
			Insert.IntoTable("QuestionType")
				.Row(new { Id = 3, Name = "Date", Description = "", HasMultipleSelection = false })
				.Row(new { Id = 4, Name = "Number", Description = "Positive whole number", HasMultipleSelection = false })
				.Row(new { Id = 5, Name = "Select", Description = "Single selection from a list of items", HasMultipleSelection = false})
				.Row(new { Id = 6, Name = "Vendor Select", Description = "List of selected vendors", HasMultipleSelection = true })
				.Row(new { Id = 7, Name = "Multiple Select", Description = "Multiple selection from a list of items", HasMultipleSelection = true });
		}

		public override void Down()
		{
		}
	}
}
