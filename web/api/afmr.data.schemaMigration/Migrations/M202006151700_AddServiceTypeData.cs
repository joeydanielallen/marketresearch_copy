using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006151700, TransactionBehavior.None)]
	public class M202006151700_AddServiceTypeData : Migration
	{
		public override void Up()
		{
			Insert.IntoTable("ServiceType").Row(new { Id = 1, Name = "Buy" });
			Insert.IntoTable("ServiceType").Row(new { Id = 2, Name = "Repair" });
		}

		public override void Down()
		{
		}
	}
}
