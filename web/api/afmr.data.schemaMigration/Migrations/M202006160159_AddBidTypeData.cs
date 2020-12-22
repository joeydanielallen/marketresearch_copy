using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202006160159, TransactionBehavior.None)]
	public class M202006160159_AddBidTypeData : Migration
	{
		public override void Up()
		{
			Insert.IntoTable("BidType")
				.Row(new { Id = 1, Name = "Unknown" })
				.Row(new { Id = 2, Name = "Open Bid" })
				.Row(new { Id = 3, Name = "Closed Bid" });
		}

		public override void Down()
		{
		}
	}
}
