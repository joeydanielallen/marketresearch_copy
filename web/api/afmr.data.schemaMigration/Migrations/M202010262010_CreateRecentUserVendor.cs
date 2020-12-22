using FluentMigrator;

namespace afmr.data.schemaMigration.Migrations
{
	[Migration(202010262010, TransactionBehavior.None)]
	public class M202010262010_CreateRecentUserVendor : Migration
	{
		private string _tableName = "RecentUserVendor";

		public override void Up()
		{
			Create.Table(_tableName)
				.WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
				.WithColumn("UserAccountId").AsInt32().NotNullable().ForeignKey("UserAccount", "UserAccountId").Indexed("IX_RecentUserVendor_UserAccountId")
				.WithColumn("VendorId").AsInt32().NotNullable().ForeignKey("Vendor", "Id")
				.WithColumn("CreatedOnUtc").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime);
		}

		public override void Down()
		{
			Delete.Index("IX_RecentUserVendor_UserAccountId").OnTable(_tableName);
			Delete.ForeignKey().FromTable(_tableName).ForeignColumn("UserAccountId");
			Delete.Table(_tableName);
		}
	}
}
