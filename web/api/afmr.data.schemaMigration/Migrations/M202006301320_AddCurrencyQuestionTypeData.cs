using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006301320, TransactionBehavior.None)]
	public class M202006301320_AddCurrencyQuestionTypeData : Migration
	{
		public override void Up()
		{
			Insert.IntoTable("QuestionType").Row(new { Id = 8, Name = "Currency", Description = "Monetary amount", HasMultipleSelection = false });
		}

		public override void Down()
		{
		}
	}
}
