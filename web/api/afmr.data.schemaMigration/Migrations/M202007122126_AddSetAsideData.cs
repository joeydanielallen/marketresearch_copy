using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007122126, TransactionBehavior.None)]
	public class M202007122126_AddSetAsideData : Migration
	{
		public override void Up()
		{
			Insert.IntoTable("SetAside")
				.Row(new { Id = 1, Name = "SDB", Description = "Small Disadvantaged Business" })
				.Row(new { Id = 2, Name = "EDWOSB", Description="Economically Disadvantaged Woman Owned Small Business" })
				.Row(new { Id = 3, Name = "WOSB", Description = "Woman Owned Small Business" })
				.Row(new { Id = 4, Name = "8(a)", Description = "Socially and Economically Disadvantaged" })
				.Row(new { Id = 5, Name = "HUBZone", Description = "Historically Under-utilized Business Zone" })
				.Row(new { Id = 6, Name = "Veteran", Description = "" })
				.Row(new { Id = 7, Name = "SDVOSB", Description = "Service Disabled Veteran Owned Business" })
				.Row(new { Id = 8, Name = "Native", Description = "" });
		}

		public override void Down()
		{
		}
	}
}
