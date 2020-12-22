using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006021611, TransactionBehavior.None)]
	public class M202006021611_AddOrgData : Migration
	{
		public override void Up()
		{
			Insert.IntoTable("Org").Row(new { Name = "421st", Description = "421 SCMG" });
			Insert.IntoTable("Org").Row(new { Name = "422nd", Description = "422 SCMG" });
		}

		public override void Down()
		{
			Delete.FromTable("Org").AllRows();
		}
	}
}
