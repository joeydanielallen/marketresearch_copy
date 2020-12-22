using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006151646, TransactionBehavior.None)]
	public class M202006151646_AddSourceTypeData : Migration
	{
		public override void Up()
		{
			Insert.IntoTable("SourceType").Row(new { Id = 1, Name = "Domestic" });
			Insert.IntoTable("SourceType").Row(new { Id = 2, Name = "Foreign" });
		}

		public override void Down()
		{
		}
	}
}
