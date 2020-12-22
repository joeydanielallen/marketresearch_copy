using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202007232125, TransactionBehavior.None)]
	public class M202007232125_AddSystemControlTypeData : Migration
	{
		public override void Up()
		{
			Insert.IntoTable("SystemControlType")
				.Row(new { Id = 1, Name = "VendorSelect" });

			Update.Table("Section")
				.Set(new { SystemControlTypeId = 1, CanDelete = false })
				.Where(new { Name = "III. Vendor Information" });
		}

		public override void Down()
		{
		}
	}
}
