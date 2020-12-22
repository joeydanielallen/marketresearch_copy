using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007101445, TransactionBehavior.None)]
	public class M202007101445_UpdateSectionCanRepeatData : Migration
	{
		public override void Up()
		{
			Update.Table("Section").Set(new { CanRepeat = true }).Where(new { Name = "III. Vendor Information" });

		}

		public override void Down()
		{
			Update.Table("Section").Set(new { CanRepeat = false }).Where(new { Name = "III. Vendor Information" });
		}
	}
}
