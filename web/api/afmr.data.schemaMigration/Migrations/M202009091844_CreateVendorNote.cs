using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202009091844, TransactionBehavior.None)]
	public class M202009091844_CreateVendorNote : Migration
	{
		private string _tableName = "VendorNote";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("VendorId").AsInt32().NotNullable().ForeignKey("Vendor", "Id")
				.WithColumn("SavedByUserAccountId").AsInt32().NotNullable().ForeignKey("UserAccount", "UserAccountId")
				.WithColumn("SavedOnUtc").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
				.WithColumn("Title").AsString(128).NotNullable()
				.WithColumn("Note").AsString(int.MaxValue).NotNullable();
		}

		public override void Down()
		{
			Delete.Table(_tableName);
		}
	}
}
